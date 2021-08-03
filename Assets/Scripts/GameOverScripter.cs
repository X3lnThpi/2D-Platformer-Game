using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScripter : MonoBehaviour
{
    public Button buttonRestart;

    private void Awake()
    {
         buttonRestart.onClick.AddListener(ReloadGame);
        // buttonRestart.onClick.AddListener(playerDied);
       // buttonRestart.onClick.AddListener(playerDied);
    }

    public void playerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadGame()
    {
        Debug.Log("Reload");
        SceneManager.LoadScene("S2");
    }

}