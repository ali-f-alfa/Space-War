﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCharacterHit;
    public UnityEvent OnCharacterKillEnemy;
    public UnityEvent OnCharacterEatGift;
    //public UnityEvent OnGameEndedWon;
    //public UnityEvent OnGameEndedLost;

    void Awake()
    {
        OnCharacterHit = new UnityEvent();
        OnCharacterKillEnemy = new UnityEvent();
        OnCharacterEatGift = new UnityEvent();
        //OnGameEndedWon = new UnityEvent();
        //OnGameEndedLost = new UnityEvent();
    }
}
