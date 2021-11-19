using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float missileMovingSpeed;
    public Sprite MissileSprite;
    public Sprite GiftSprit;
    public Sprite HeartSprit;
    public EventSystemCustom eventSystem;
    public EnemiesType TypeOfEnemy;
    private ShipMove Player;
    private EnemyGenerator EnemyGenerator;

    // Start is called before the first frame update
    void Start()
    {
        EnemyGenerator = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
        Player = GameObject.Find("Ship").GetComponent<ShipMove>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.CompareTag(TagNames.Missile1.ToString()))
        {
            EnemyGenerator.ExplosionSound.Play();
            Explode(Collider.gameObject);
            Player.Score += ScoreOfKillingEnemy();
            eventSystem.OnCharacterKillEnemy.Invoke();


            if ((UnityEngine.Random.Range(0, 25) % 25 == 0))
                ReleaseGift();  

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
        EnemyGenerator.allAliveEnemies.Remove(this.gameObject);
        if (EnemyGenerator.allAliveEnemies.Count == 0)
            ReleaseHeart();
    }

    public void LunchMissile()
    {
        if (TypeOfEnemy == EnemiesType.Type1)
        {
            GameObject go1 = new GameObject();
            go1.name = "moving missile enemy";

            Rigidbody2D missileRb = go1.AddComponent<Rigidbody2D>();
            missileRb.bodyType = RigidbodyType2D.Kinematic;

            go1.transform.position = this.transform.position - new Vector3(0, 0.2f, 0);
            go1.transform.Rotate(new Vector3(180, 0, 0));

            SpriteRenderer spriteRenderer = go1.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = MissileSprite;

            go1.tag = TagNames.EnemyMissile.ToString();

            BoxCollider2D bc = go1.AddComponent<BoxCollider2D>() as BoxCollider2D;
            bc.isTrigger = true;

            missileRb.velocity = transform.up * -1 * missileMovingSpeed;
        }
        else if (TypeOfEnemy == EnemiesType.Type2)
        {
            GameObject go1 = new GameObject();
            go1.name = "moving missile enemy";

            Rigidbody2D missileRb = go1.AddComponent<Rigidbody2D>();
            missileRb.bodyType = RigidbodyType2D.Kinematic;

            go1.transform.position = this.transform.position - new Vector3(-0.07f, 0.2f, 0);
            go1.transform.Rotate(new Vector3(180, 0, 0));

            SpriteRenderer spriteRenderer = go1.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = MissileSprite;

            go1.tag = TagNames.EnemyMissile.ToString();

            BoxCollider2D bc = go1.AddComponent<BoxCollider2D>() as BoxCollider2D;
            bc.isTrigger = true;

            missileRb.velocity = transform.up * -1 * missileMovingSpeed * 1.15f;
            //second
            GameObject go2 = new GameObject();
            go2.name = "moving missile enemy";

            Rigidbody2D missileRb2 = go2.AddComponent<Rigidbody2D>();
            missileRb2.bodyType = RigidbodyType2D.Kinematic;

            go2.transform.position = this.transform.position - new Vector3(0.07f, 0.2f, 0);
            go2.transform.Rotate(new Vector3(180, 0, 0));

            SpriteRenderer spriteRenderer2 = go2.AddComponent<SpriteRenderer>();
            spriteRenderer2.sprite = MissileSprite;

            go2.tag = TagNames.EnemyMissile.ToString();

            BoxCollider2D bc2 = go2.AddComponent<BoxCollider2D>() as BoxCollider2D;
            bc2.isTrigger = true;

            missileRb2.velocity = transform.up * -1 * missileMovingSpeed * 1.15f;
        }
        else if (TypeOfEnemy == EnemiesType.Type3)
        {
            GameObject go1 = new GameObject();
            go1.name = "moving missile enemy";

            Rigidbody2D missileRb = go1.AddComponent<Rigidbody2D>();
            missileRb.bodyType = RigidbodyType2D.Kinematic;

            go1.transform.position = this.transform.position - new Vector3(-0.13f, 0.2f, 0);
            go1.transform.Rotate(new Vector3(180, 0, 0));

            SpriteRenderer spriteRenderer = go1.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = MissileSprite;

            go1.tag = TagNames.EnemyMissile.ToString();

            BoxCollider2D bc = go1.AddComponent<BoxCollider2D>() as BoxCollider2D;
            bc.isTrigger = true;

            missileRb.velocity = transform.up * -1 * missileMovingSpeed * 1.25f;
            //
            GameObject go2 = new GameObject();
            go2.name = "moving missile enemy";

            Rigidbody2D missileRb2 = go2.AddComponent<Rigidbody2D>();
            missileRb2.bodyType = RigidbodyType2D.Kinematic;

            go2.transform.position = this.transform.position - new Vector3(0, 0.2f, 0);
            go2.transform.Rotate(new Vector3(180, 0, 0));

            SpriteRenderer spriteRenderer2 = go2.AddComponent<SpriteRenderer>();
            spriteRenderer2.sprite = MissileSprite;

            go2.tag = TagNames.EnemyMissile.ToString();

            BoxCollider2D bc2 = go2.AddComponent<BoxCollider2D>() as BoxCollider2D;
            bc2.isTrigger = true;

            missileRb2.velocity = transform.up * -1 * missileMovingSpeed * 1.25f;
            //
            GameObject go3 = new GameObject();
            go3.name = "moving missile enemy";

            Rigidbody2D missileRb3 = go3.AddComponent<Rigidbody2D>();
            missileRb3.bodyType = RigidbodyType2D.Kinematic;

            go3.transform.position = this.transform.position - new Vector3(0.13f, 0.2f, 0);
            go3.transform.Rotate(new Vector3(180, 0, 0));

            SpriteRenderer spriteRenderer3 = go3.AddComponent<SpriteRenderer>();
            spriteRenderer3.sprite = MissileSprite;

            go3.tag = TagNames.EnemyMissile.ToString();

            BoxCollider2D bc3 = go3.AddComponent<BoxCollider2D>() as BoxCollider2D;
            bc3.isTrigger = true;

            missileRb3.velocity = transform.up * -1 * missileMovingSpeed *1.25f;
        }
    }

    public GameObject ReleaseGift()
    {
        GameObject gift = new GameObject();
        gift.name = "released gift";

        Rigidbody2D giftRb = gift.AddComponent<Rigidbody2D>();
        giftRb.bodyType = RigidbodyType2D.Kinematic;

        gift.transform.position = this.transform.position - new Vector3(0, 0.2f, 0);
        //gift.transform.Rotate(new Vector3(180, 0, 0));

        SpriteRenderer spriteRenderer = gift.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = GiftSprit;

        gift.tag = TagNames.Gift1.ToString();

        BoxCollider2D bc = gift.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.isTrigger = true;

        giftRb.velocity = transform.up * -1 * missileMovingSpeed * 0.5f;

        return gift;
    }

    public GameObject ReleaseHeart()
    {
        GameObject gift = new GameObject();
        gift.name = "released heart";

        Rigidbody2D giftRb = gift.AddComponent<Rigidbody2D>();
        giftRb.bodyType = RigidbodyType2D.Kinematic;

        gift.transform.position = this.transform.position - new Vector3(0, 0.2f, 0);
        //gift.transform.Rotate(new Vector3(180, 0, 0));

        SpriteRenderer spriteRenderer = gift.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = HeartSprit;

        gift.tag = TagNames.Heart.ToString();

        BoxCollider2D bc = gift.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.isTrigger = true;

        giftRb.velocity = transform.up * -1 * missileMovingSpeed * 0.4f;

        return gift;
    }

}
