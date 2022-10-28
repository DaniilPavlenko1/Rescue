using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Level1");
    }
}
