using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCharacterHit;
    public UnityEvent OnCharacterKillEnemy;
    public UnityEvent OnCharacterEatGift;
    public UnityEvent OnUpdateLevel;
    public UnityEvent OnUpdateEnergy;
    //public UnityEvent OnGameEndedWon;
    //public UnityEvent OnGameEndedLost;

    void Awake()
    {
        OnCharacterHit = new UnityEvent();
        OnCharacterKillEnemy = new UnityEvent();
        OnCharacterEatGift = new UnityEvent();
        OnUpdateLevel = new UnityEvent();
        OnUpdateEnergy = new UnityEvent();
        //OnGameEndedWon = new UnityEvent();
        //OnGameEndedLost = new UnityEvent();
    }
}
