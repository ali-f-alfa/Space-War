using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text Life;
    public EventSystemCustom eventSystem;
    
    void Start()
    {
        eventSystem.OnCharacterKillEnemy.AddListener(UpdateScore);
        eventSystem.OnCharacterHit.AddListener(DecreaseLife);
        //eventSystem.OnGameEndedWon.AddListener(EndGameWon);
        //eventSystem.OnGameEndedLost.AddListener(EndGameLost);
    }

    public void UpdateScore()
    {
        int newTextValue = int.Parse(ScoreText.text) + 10;
        ScoreText.text = newTextValue.ToString();
    }

    public void DecreaseLife()
    {
        int newTextValue = int.Parse(ScoreText.text) - 1;
        Life.text = newTextValue.ToString();
    }

    //public void EndGameWon()
    //{
    //    if (int.Parse(KeyCounter.text) >= Constants.RequiredKeyCountToWin)
    //    {
    //        //Debug.Log("YOU WON!");
    //        WinLabel.text = "You Won!";
    //    }
    //}

    //public void EndGameLost()
    //{
    //    LostLabel.text = "You Lost!";
    //}

}
