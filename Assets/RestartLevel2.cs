using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel2 : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Level2");
    }
}
