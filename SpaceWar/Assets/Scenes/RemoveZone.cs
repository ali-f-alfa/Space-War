using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        GameObject.Destroy(Collider.gameObject);
    }

}
