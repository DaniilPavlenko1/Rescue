using UnityEngine;
using Photon.Pun;

public class Trigger1 : MonoBehaviourPunCallbacks
{
    public GameObject Canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("Buttons").SetActive(false);
        Canvas.SetActive(true);
        UnLockLevel();
    }
    public void UnLockLevel()
    {
        if (PlayerPrefs.GetInt("levels") == 1)
        {
            PlayerPrefs.SetInt("levels", 2);
        }
    }
}