using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Trigger2 : MonoBehaviourPunCallbacks
{
    public GameObject Canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
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
