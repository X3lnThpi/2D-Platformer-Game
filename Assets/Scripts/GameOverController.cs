using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;


    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadGame);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
     

    private void ReloadGame()
    {
        Debug.Log("Reload game method called");
        SceneManager.LoadScene("S2");
    }
}
