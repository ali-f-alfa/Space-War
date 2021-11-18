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
            GameObject go1 = new GameObject();
            go1.name = "moving missile";
            Rigidbody2D missileRb = go1.AddComponent<Rigidbody2D>();
            missileRb.bodyType = RigidbodyType2D.Kinematic;
            go1.transform.position = this.transform.position + new Vector3(0, 0.4f, 0);
            SpriteRenderer spriteRenderer = go1.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = MissileSprite;
            missileRb.velocity = transform.up * -1* missileMovingSpeed;
            //Debug.Log(MissileRb.velocity);

        }
    }
}
