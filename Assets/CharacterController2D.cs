using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
{
    float maxSpeed = 2f;
    float jumpHeight = 5f;
    float gravityScale = 1.5f;
    bool facingRight;
    float moveDirection = 0;
    bool isGrounded = false;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    Animator anim;
    PhotonView photonView;

    public static GameObject LocalPlayerInstance;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = false;  
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
        }
        DontDestroyOnLoad(this.gameObject);
        if (photonView.IsMine)
        {
            //Movement controls
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
                anim.SetBool("walk", true);
            }
            else
            {
                if (isGrounded || r2d.velocity.magnitude < 0.01f)
                {
                    moveDirection = 0;
                    anim.SetBool("walk", false);
                }
            }
            //Change facing direction
            if (moveDirection != 0)
            {
                if (moveDirection > 0 && !facingRight)
                {
                    facingRight = true;
                    t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                }
                if (moveDirection < 0 && facingRight)
                {
                    facingRight = false;
                    t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                }
            }
            //Jumping
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
            {
                r2d.velocity = Vector2.up * jumpHeight;
            }
        }
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }
}