﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text Life;
    public EventSystemCustom eventSystem;
    private ShipMove Player;

    void Start()
    {
        eventSystem.OnCharacterKillEnemy.AddListener(UpdateScore);
        eventSystem.OnCharacterEatGift.AddListener(UpdateScore);
        eventSystem.OnCharacterHit.AddListener(UpdateLife);
        //eventSystem.OnGameEndedWon.AddListener(EndGameWon);
        //eventSystem.OnGameEndedLost.AddListener(EndGameLost);
        Player = GameObject.Find("Ship").GetComponent<ShipMove>();

    }

    public void UpdateScore()
    {
        ScoreText.text = Player.Score.ToString();
    }

    public void UpdateLife()
    {
        if (Player.Life <= 0)
            EndGameLost();

        Life.text = Player.Life.ToString();
    }

    //public void EndGameWon()
    //{
    //    if (int.Parse(KeyCounter.text) >= Constants.RequiredKeyCountToWin)
    //    {
    //        //Debug.Log("YOU WON!");
    //        WinLabel.text = "You Won!";
    //    }
    //}

    public void EndGameLost()
    {
        //todo: show game over
        SceneManager.LoadScene(0);
    }

}
