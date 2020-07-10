using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class EndGame : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI endGameText;

    #region Singleton
    
    public static EndGame instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }


    #endregion

    public void OnRetry()
    {        
        SceneManager.LoadScene(0);

    }

    
    //called when a game is over, if pacman wins entry true if ghost wins, entry false.
    public void GameEnd(bool pacmanWin)
    {        
        endGamePanel.gameObject.SetActive(true);
        endGameText.SetText(pacmanWin ? "Pacmans won!" : "Ghosts won!");

    }
}
