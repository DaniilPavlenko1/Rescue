using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel2 : MonoBehaviour
{
    public string nextLevelName;
    public static int ontigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player2")
        {
            ontigger++;
            Debug.Log(ontigger);
        }
        //if (col.gameObject.tag == "Player2")
        //{
        //    SceneManager.LoadScene(nextLevelName);
        //    Debug.Log("Lecimy do kolejnej planszy!");
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            ontigger--;
            Debug.Log(ontigger);
        }
    }
}
