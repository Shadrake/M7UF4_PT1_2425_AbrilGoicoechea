using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Item : MonoBehaviour, ICollectable
{
    public int id;
    public Sprite sprite;
    
    public void OnCollected()
    {
        GameManager.gameManager.ItemCollected(sprite, id);
        Destroy(gameObject);
    }
}
