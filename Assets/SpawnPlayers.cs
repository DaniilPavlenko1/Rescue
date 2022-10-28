using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefabs1;
    public GameObject playerPrefabs2;
    public Transform spawnPoint;
    private Transform LastPosition;
    GameObject player1;
    GameObject player2;

    private void Start()
    {
        if (GameObject.Find("Player1(Clone)") && GameObject.Find("Player1(Clone)").GetComponent<PhotonView>().IsMine)
        {
            player1 = GameObject.Find("Player1(Clone)");
            player1.gameObject.transform.localScale = new Vector3((float)0.44, (float)0.44, (float)0.44);
            player1.gameObject.transform.position = new Vector2((float)-5.6, (float)-1.6);
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        }
        else { }
        if (GameObject.Find("Player2") && GameObject.Find("Player2").GetComponent<PhotonView>().IsMine)
        {
            player2 = GameObject.Find("Player2");
            player2.gameObject.transform.position = new Vector2((float)5.6, (float)-1.6);
            player2.gameObject.transform.localScale = new Vector3((float)0.44, (float)0.44, (float)0.44);
        }
        else { }
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            OnJoinedRoom();
        }
    }
    private void Update()
    {
        var player2 = GameObject.Find("Player2");
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1 && player2 == true)
        {
            LastPosition = GameObject.Find("Player2").transform;
            Destroy(GameObject.Find("Player2"));
            PhotonNetwork.Instantiate(playerPrefabs1.name, LastPosition.position, Quaternion.identity);

        }
        else { Debug.Log("No game object called 'Player2' found"); }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && player2 == true)
        {
            Destroy(GameObject.Find("Player2(Clone)"));
        }
        else { Debug.Log("No game object called 'Player2' found"); }

        if (GameObject.Find("Player1(Clone)") == true)
        {
            player1 = GameObject.Find("Player1(Clone)");
            player1.GetComponent<CharacterController2D>().enabled = true;
            player1.GetComponent<Animator>().enabled = true;
        }
        if (GameObject.Find("Player2") == true)
        {
            player2 = GameObject.Find("Player2");
            player2.GetComponent<CharacterController2D>().enabled = true;
            player2.GetComponent<Animator>().enabled = true;
        }
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Simple Main Menu Demo");
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            var prefab = PhotonNetwork.Instantiate(playerPrefabs2.name, spawnPoint.position, Quaternion.identity);
            prefab.name = "Player2";
        }
        else
        {
            if(GameObject.Find("Player1(Clone)") == false)
            {
                PhotonNetwork.Instantiate(playerPrefabs1.name, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}