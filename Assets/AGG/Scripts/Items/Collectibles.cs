using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
         if(collision.CompareTag("Player"))
         {
            Destroy(gameObject);
         } 
    }
}
