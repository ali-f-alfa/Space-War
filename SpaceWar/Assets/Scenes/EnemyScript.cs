using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float missileMovingSpeed;
    public Sprite MissileSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LunchMissileFrom(this.transform.position - new Vector3(0, 0.2f, 0));
            //Debug.Log(this.transform.position);

        }
    }


    private void OnTriggerEnter2D(Collider2D Collider)
    {

        if (Collider.gameObject.CompareTag(TagNames.Missile1.ToString()))
        {
            Explode(Collider.gameObject);
            Debug.Log("collision");
        }
    }

    private void Explode(GameObject missile)
    {
        this.gameObject.SetActive(false);
        missile.SetActive(false);
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
