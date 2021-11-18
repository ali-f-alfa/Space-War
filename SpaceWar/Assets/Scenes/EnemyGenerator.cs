﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float missileMovingSpeed;
    public Sprite MissileSprite;
    public Sprite EnemyType1Sprite;
    public Sprite EnemyType2Sprite;
    public Sprite EnemyType3Sprite;

    void Start()
    {
        initializeEnemies();
    }

    
    void Update()
    {
        
    }

    public void initializeEnemies()
    {
        for (int i = 0; i < 9; i++)
            CreateEnemy(EnemiesType.Type3, new Vector2(2f*(i - 4), 4f));
        for (int i = 0; i < 13; i++)
            CreateEnemy(EnemiesType.Type2, new Vector2(1.3f*(i - 6), 2.5f));
        for (int i = 0; i < 15; i++)
            CreateEnemy(EnemiesType.Type1, new Vector2(1.1f* (i - 7), 1.2f));

    }

    public GameObject CreateEnemy(EnemiesType enemyType, Vector2 position)
    {
        GameObject enemy = new GameObject();
        enemy.name = "generated enemy " + enemyType.ToString();

        enemy.transform.position = position;

        SpriteRenderer spriteRenderer = enemy.AddComponent<SpriteRenderer>();

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

        EnemyScript enemyScript = enemy.AddComponent<EnemyScript>();
        enemyScript.missileMovingSpeed = this.missileMovingSpeed;
        enemyScript.MissileSprite = this.MissileSprite;

        PolygonCollider2D bc = enemy.AddComponent<PolygonCollider2D>() as PolygonCollider2D;
        bc.isTrigger = true;

        //enemyRb.velocity = transform.up * -1 * missileMovingSpeed;
        return enemy;
    }
}