using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text Life;
    public Text Energy;
    public Text Level;
    public Text GameOver;
    public EventSystemCustom eventSystem;
    private ShipMove Player;
    private EnemyGenerator enemyGenerator;

    void Start()
    {
        eventSystem.OnCharacterKillEnemy.AddListener(UpdateScore);
        eventSystem.OnCharacterEatGift.AddListener(UpdateScore);
        eventSystem.OnUpdateEnergy.AddListener(UpdateEnergy);
        eventSystem.OnUpdateLevel.AddListener(UpdateLevel);
        eventSystem.OnCharacterHit.AddListener(UpdateLife);
        //eventSystem.OnGameEndedWon.AddListener(EndGameWon);
        //eventSystem.OnGameEndedLost.AddListener(EndGameLost);
        Player = GameObject.Find("Ship").GetComponent<ShipMove>();
        enemyGenerator = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();

    }

    public void UpdateScore()
    {
        ScoreText.text = Player.Score.ToString();
    }

    public void UpdateLevel()
    {
        Level.text = enemyGenerator.Level.ToString();
    }

    public void UpdateEnergy()
    {
        Energy.text = Player.Energy.ToString();
    }

    public void UpdateLife()
    {
        if (Player.Life <= 0)
            StartCoroutine(EndGameLost());

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

    public IEnumerator EndGameLost()
    {
        //todo: show game over
        GameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }
    //public IEnumerator Wait()
    //{
    //    isRecharging = true;
    //    Debug.Log("isRecharging");
    //    yield return new WaitForSeconds(2.5f);
    //    isRecharging = false;
    //    Debug.Log("isRecharging finished");

    //}

}
