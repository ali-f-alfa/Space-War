using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float missileMovingSpeed;
    public Sprite MissileSprite;
    private int n;
    public EventSystemCustom eventSystem;
    public EnemiesType TypeOfEnemy;
    private ShipMove Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Ship").GetComponent<ShipMove>();
        n = 1200;
    }

    // Update is called once per frame
    void Update()
    {

        if (UnityEngine.Random.Range(0, 1500) % n == 0)
        {
            if (n > 200)
            {
                n /= 2;
                //Debug.Log(n);

            }
            LunchMissileFrom(this.transform.position - new Vector3(0, 0.2f, 0));
            //Debug.Log(n);

        }
    }


    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.CompareTag(TagNames.Missile1.ToString()))
        {
            Explode(Collider.gameObject);
            Player.Score += ScoreOfKillingEnemy();
            eventSystem.OnCharacterKillEnemy.Invoke();
            //Debug.Log("collision");
        }
    }
    private int ScoreOfKillingEnemy()
    {
        if (TypeOfEnemy == EnemiesType.Type1)
            return 5;
        else if (TypeOfEnemy == EnemiesType.Type2)
            return 8;
        else if (TypeOfEnemy == EnemiesType.Type3)
            return 10;

        else return -999999;
    }

    private void Explode(GameObject missile)
    {
        GameObject.Destroy(missile);
        GameObject.Destroy(this.gameObject);

    }

    private GameObject LunchMissileFrom(Vector3 position)
    {
        GameObject go1 = new GameObject();
        go1.name = "moving missile enemy";

        Rigidbody2D missileRb = go1.AddComponent<Rigidbody2D>();
        missileRb.bodyType = RigidbodyType2D.Kinematic;

        go1.transform.position = position;
        go1.transform.Rotate(new Vector3(180, 0, 0));

        SpriteRenderer spriteRenderer = go1.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = MissileSprite;

        go1.tag = TagNames.EnemyMissile.ToString();

        BoxCollider2D bc = go1.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.isTrigger = true;

        missileRb.velocity = transform.up * -1 * missileMovingSpeed;

        return go1;
    }

}
