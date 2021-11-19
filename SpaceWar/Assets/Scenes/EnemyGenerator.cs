using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class EnemyGenerator : MonoBehaviour
{
    public float missileMovingSpeed;
    public Sprite MissileSprite;
    public Sprite EnemyType1Sprite;
    public Sprite EnemyType2Sprite;
    public Sprite EnemyType3Sprite;
    public Sprite Gift1Sprit;
    public Sprite HeartSprit;

    public EventSystemCustom eventSystem;
    public List<GameObject> allAliveEnemies;
    public int rateOfEnemystrike;
    private int Level;
    private bool isLoading;

    void Start()
    {
        Level = 1;
        rateOfEnemystrike = 50;
        isLoading = false;
        allAliveEnemies = new List<GameObject>();
        initializeEnemiesForLevel(1);
    }

    
    void Update()
    {
        if ((allAliveEnemies.Count == 0) && !isLoading)
        {
            isLoading = true;
            StartCoroutine(StartNewLevel(++Level));
        }

        if (isTimetoLunchMissile() && !isLoading)
        {
            allAliveEnemies[UnityEngine.Random.Range(0, allAliveEnemies.Count)].GetComponent<EnemyScript>().LunchMissile();
        }
        

    }
    public bool isTimetoLunchMissile()
    {
        if ((Time.frameCount % 10 == 0)) {
            if ((UnityEngine.Random.Range(0, rateOfEnemystrike) % ((int)(rateOfEnemystrike / (Math.Sqrt(allAliveEnemies.Count)))+1) == 0))
            {
                return true;
            }
        }
        return false;

    }
    public void initializeEnemiesForLevel(int L)
    {
        if (L == 1)
        {
            for (int i = 0; i < 9; i++)
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type3, new Vector2(2f * (i - 4), 4f)));
            for (int i = 0; i < 13; i++)
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type2, new Vector2(1.3f * (i - 6), 2.5f)));
            for (int i = 0; i < 15; i++)
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type1, new Vector2(1.1f * (i - 7), 1.2f)));
        }
        else if (L == 2)
        {
            for (int i = 0; i < 4; i++) {
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type3, new Vector2(2f * (2*i - 4), 4f))); 
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type2, new Vector2(2f * (2*i - 3), 4f))); 
            }
            for (int i = 0; i < 13; i++)
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type2, new Vector2(1.3f * (i - 6), 2.5f)));
            for (int i = 0; i < 15; i++)
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type1, new Vector2(1.1f * (i - 7), 1.2f)));
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type3, new Vector2(2f * (2 * i - 4), 4f)));
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type2, new Vector2(2f * (2 * i - 3), 4f)));
            }
            for (int i = 0; i < 13; i++)
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type2, new Vector2(1.3f * (i - 6), 2.5f)));
            for (int i = 0; i < 15; i++)
                allAliveEnemies.Add(CreateEnemy(EnemiesType.Type1, new Vector2(1.1f * (i - 7), 1.2f)));
        }
    }

    public GameObject CreateEnemy(EnemiesType enemyType, Vector2 position)
    {
        GameObject enemy = new GameObject();
        enemy.name = "generated enemy " + enemyType.ToString();

        enemy.transform.position = position;

        SpriteRenderer spriteRenderer = enemy.AddComponent<SpriteRenderer>();

        EnemyScript enemyScript = enemy.AddComponent<EnemyScript>();
        enemyScript.missileMovingSpeed = this.missileMovingSpeed;
        enemyScript.MissileSprite = this.MissileSprite;
        enemyScript.eventSystem = this.eventSystem;
        enemyScript.TypeOfEnemy = enemyType;
        enemyScript.GiftSprit = Gift1Sprit;
        enemyScript.HeartSprit = HeartSprit;

        if (enemyType == EnemiesType.Type1)
        {
            spriteRenderer.sprite = EnemyType1Sprite;
            enemy.tag = TagNames.EnemyType1.ToString();
            spriteRenderer.color = new Color(1, 1, 0, 1);
        }
        else if (enemyType == EnemiesType.Type2)
        {
            spriteRenderer.sprite = EnemyType2Sprite;
            enemy.tag = TagNames.EnemyType2.ToString();
            spriteRenderer.color = new Color(0.2f, 0.3f, 0.9f, 1);

        }
        else if (enemyType == EnemiesType.Type3)
        {
            spriteRenderer.sprite = EnemyType3Sprite;
            enemy.tag = TagNames.EnemyType3.ToString();
            spriteRenderer.color = new Color(0, 1, 1, 1);

        }


        PolygonCollider2D bc = enemy.AddComponent<PolygonCollider2D>() as PolygonCollider2D;
        bc.isTrigger = true;

        //enemyRb.velocity = transform.up * -1 * missileMovingSpeed;
        return enemy;
    }
    
    public IEnumerator StartNewLevel(int level)
    {
        yield return new WaitForSeconds(2.5f);
        initializeEnemiesForLevel(level);
        if (rateOfEnemystrike >= 3)
            rateOfEnemystrike = (int)(rateOfEnemystrike/1.5f);
        this.isLoading = false;
    }
}
