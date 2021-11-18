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

    void Start()
    {
        moveVector = new Vector3(1 * shipMovingSpeed, 0, 0);
        //jumpAmount = 1f;
        //MissileRb = Missile.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveVector;

        }

        if (Input.GetKey(KeyCode.A))
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

        if (Collider.gameObject.CompareTag(TagNames.EnemyMissile.ToString()))
        {
            Explode(Collider.gameObject);
            //Debug.Log("collision");
        }
    }

    private void Explode(GameObject EnemyMissile)
    {
        //todo: heart decrease on UI and restart player
        this.gameObject.SetActive(false);
        EnemyMissile.SetActive(false);
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

}
