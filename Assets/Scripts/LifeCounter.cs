using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining = 3;
    PlayerController pl;

    public void LoseLife()
    {
        //Decrease the value of livesRemaing
        livesRemaining--;
        //Hide one of the heart image
        if(livesRemaining >= 0)
        {
            lives[livesRemaining].enabled = false;
        }
        
        //If we run out of life. we Lose the game
        if(livesRemaining == 0)
        {
            Debug.Log("Die Die You Player");
             pl.Animator.SetBool("Dead", true);
            // pl.Invoke("ReloadGame", 3f);
            // Destroy(gameObject);
            // throw new NotImplementedException();
        }

        if (livesRemaining < 0)
        {
            Debug.Log("Less than 0");
        }
    }

    private void Start()
    {
        pl = gameObject.GetComponent<PlayerController>();
    }
}
