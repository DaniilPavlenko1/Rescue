using UnityEngine;
using Photon.Pun;
using TMPro;

public class TextWaitingReady : MonoBehaviour
{
    public TMP_Text Waiting;
    public TMP_Text Ready;
    public GameObject Settings;
    void Update()
    {
        int count = PhotonNetwork.CurrentRoom.PlayerCount;
        if (Settings.activeSelf)
        {
            Waiting.enabled = false;
            Ready.enabled = false;
        }
        else if (count == 1)
        {
            Waiting.enabled = true;
            Ready.enabled = false;
        }
        else if (count == 2)
        {
            Waiting.enabled = false;
            Ready.enabled = true;
        }
        else { Debug.Log("Player count = 0"); }
    }
}
