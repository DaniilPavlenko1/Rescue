using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Button[] buttons;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < PlayerPrefs.GetInt("levels"); i++)
        {
            buttons[i].interactable = true;
            Debug.Log(PlayerPrefs.GetInt("levels") + " = levels");
        }
    }

    public void loadLevel(int levelIndex)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(levelIndex);
        }
    }
}