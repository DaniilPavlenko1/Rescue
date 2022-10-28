using UnityEngine;
using Photon.Pun;
using TMPro;

public class CrateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createText;
    public TMP_InputField joinText;
    int levelUnLock;
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
        levelUnLock = PlayerPrefs.GetInt("levels", 1);
        if(PlayerPrefs.GetInt("levels") > 1)
        {
            PlayerPrefs.SetInt("levels", 1);
        }
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createText.text, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinText.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
    }
}
