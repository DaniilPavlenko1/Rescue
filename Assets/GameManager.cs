using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviourPunCallbacks
{
    GameObject player1;
    GameObject player2;
    public GameObject LoadingScreen;
    float timeRemaining = 3;
    public TMP_Text timer;
    public GameObject timerObject;
    float timeStart = 5;
    public GameObject menu;
    public GameObject win1;
    public GameObject win2;
    private int x = 0;

    public void Start()
    {
        player1 = GameObject.Find("Player1(Clone)");
        player2 = GameObject.Find("Player2");
        player1.gameObject.transform.localScale = new Vector3((float)0, (float)0, (float)0);
        if(player2) player2.gameObject.transform.localScale = new Vector3((float)0, (float)0, (float)0);
    }
    public void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0 && timeRemaining > -2)
        {
            LoadingScreen.SetActive(false);
            menu.SetActive(true);
            win1.SetActive(false);
            win2.SetActive(false);
            player1.GetComponent<Animator>().enabled = false;
            player1.GetComponent<CharacterController2D>().enabled = false;
            player1.gameObject.transform.localScale = new Vector3((float)-0.2, (float)0.2, (float)0.2);
            player1.gameObject.transform.position = new Vector2((float)-7.49, (float)-4.4);
            if (player2)
            {
                player2.GetComponent<Animator>().enabled = false;
                player2.GetComponent<CharacterController2D>().enabled = false;
                player2.gameObject.transform.localScale = new Vector3((float)0.2, (float)0.2, (float)0.2);
                player2.gameObject.transform.position = new Vector2((float)7.35, (float)-4.3);
            }
        }
        else if (timeRemaining < -1)
        {
            if (timeStart == 5)
            {
                timerObject.SetActive(true);
                timer.text = timeStart.ToString();
            }
            if (timeStart > 0)
            {
                timeStart -= Time.deltaTime;
                timer.text = Mathf.Round(timeStart).ToString();
            }
            if (timeStart < 1)
            {
                timer.text = "GO";
            }
            if (timeStart < 0 && win1.activeSelf == false && win2.activeSelf == false)
            {
                timerObject.SetActive(false);
                player1.GetComponent<CharacterController2D>().enabled = true;
                player1.GetComponent<Animator>().enabled = true;
                if (player2)
                {
                    player2.GetComponent<CharacterController2D>().enabled = true;
                    player2.GetComponent<Animator>().enabled = true;
                }
            }
            if (win1.activeSelf || win2.activeSelf)
            {
                player1.GetComponent<Animator>().enabled = false;
                player1.GetComponent<CharacterController2D>().enabled = false;
                if (player2)
                {
                    player2.GetComponent<Animator>().enabled = false;
                    player2.GetComponent<CharacterController2D>().enabled = false;
                }
            }
            if (x == 1)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    SceneManager.LoadScene("Lobby");
                }
            }
            if (x == 2)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    SceneManager.LoadScene("EmptyScene");
                }
            }
            if (x == 3)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    SceneManager.LoadScene("EmptyScene2");
                }
            }
        }
    }
    public void BacktoLobby()
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene("Lobby");
        }
        if (PhotonNetwork.IsMasterClient == false)
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            x = 1;
        }
    }
    public void Restart()
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene("EmptyScene");
        }
        if (PhotonNetwork.IsMasterClient == false)
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            x = 2;
        }
    }
    public void Restart2()
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene("EmptyScene2");
        }
        if (PhotonNetwork.IsMasterClient == false)
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            x = 3;
        }
    }
}