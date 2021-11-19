using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCreator : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Ship");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (transform.position.x <= 7))
        {
            GameObject go = GameObject.Instantiate(Player);
            go.transform.position = Player.transform.position + new Vector3(2, 0, 0);
        }
    }
}
