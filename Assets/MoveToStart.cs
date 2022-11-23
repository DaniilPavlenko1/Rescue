using Photon.Pun;
using UnityEngine;

public class MoveToStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player1(Clone)").gameObject.transform.position = new Vector2((float)-7.49, (float)-4.4);
        }
        if (GameObject.Find("Player2"))
        {
            if (collision.gameObject.CompareTag("Player2"))
            {
                GameObject.Find("Player2").gameObject.transform.position = new Vector2((float)7.35, (float)-4.3);
            }
        }
    }
}
