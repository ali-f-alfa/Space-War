using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMove : MonoBehaviour
{
    public float shipMovingSpeed;
    public float missileMovingSpeed;
    private Vector3 moveVector;
    public Sprite MissileSprite;

    public EventSystemCustom eventSystem;
    public int Life;
    public int Score;
    private bool Isblinking;

    void Start()
    {
        Life = 3;
        Score = 0;
        Isblinking = false;
        moveVector = new Vector3(1 * shipMovingSpeed, 0, 0);
        //jumpAmount = 1f;
        //MissileRb = Missile.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && (transform.position.x <= 9))
        {
            transform.position += moveVector;
        }

        if (Input.GetKey(KeyCode.A) && (transform.position.x >= -9.1))
        {
            transform.position -= moveVector;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LunchMissileFrom(this.transform.position + new Vector3(0, 0.4f, 0));
            //Debug.Log(this.transform.position);

        }
    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {

        if (Collider.gameObject.CompareTag(TagNames.EnemyMissile.ToString()) && !Isblinking)
        {
            Life -= 1;
            Explode(Collider.gameObject);
            eventSystem.OnCharacterHit.Invoke();
            BlinkPlayer(5);
            //Debug.Log("collision");
        }

        if (Collider.gameObject.CompareTag(TagNames.Gift1.ToString()))
        {
            //todo: update gun
            this.Score += 50;
            GameObject.Destroy(Collider.gameObject);
            eventSystem.OnCharacterEatGift.Invoke();
            //Debug.Log("collision");
        }

        if (Collider.gameObject.CompareTag(TagNames.Heart.ToString()))
        {
            //todo: update gun
            if (Life < 3)
            {
                Life++;
                eventSystem.OnCharacterHit.Invoke();
            }
            GameObject.Destroy(Collider.gameObject);
            //Debug.Log("collision");
        }
    }

    private void Explode(GameObject EnemyMissile)
    {
        //this.gameObject.SetActive(false);
        GameObject.Destroy(EnemyMissile);
    }

    private GameObject LunchMissileFrom(Vector3 position) 
    {
        GameObject go1 = new GameObject();
        go1.name = "moving missile";
        Rigidbody2D missileRb = go1.AddComponent<Rigidbody2D>();
        missileRb.bodyType = RigidbodyType2D.Kinematic;
        go1.transform.position = position;
        SpriteRenderer spriteRenderer = go1.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = MissileSprite;
        go1.tag = TagNames.Missile1.ToString();

        PolygonCollider2D bc = go1.AddComponent<PolygonCollider2D>() as PolygonCollider2D;
        bc.isTrigger = true;

        missileRb.velocity = transform.up * -1 * missileMovingSpeed;

        return go1;
    }

    public void BlinkPlayer(int numBlinks)
    {
        StartCoroutine(DoBlinks(numBlinks, 0.3f));
    }

    public IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        this.Isblinking = true;
        Renderer r = this.gameObject.GetComponent<Renderer>();
        for (int i = 0; i < numBlinks * 2; i++)
        {
            r.enabled = !r.enabled;
            yield return new WaitForSeconds(seconds);
        }
        r.enabled = true;
        this.Isblinking = false;
    }
}
