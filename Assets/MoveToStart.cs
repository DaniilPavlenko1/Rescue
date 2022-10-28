using UnityEngine;

public class MoveToStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("Player1(Clone)").gameObject.transform.position = new Vector2((float)-7.49, (float)-4.4);
        }
        if (collision.gameObject.tag == "Player2")
        {
            GameObject.Find("Player2").gameObject.transform.position = new Vector2((float)-7.49, (float)-4.4);
        }
    }
}
