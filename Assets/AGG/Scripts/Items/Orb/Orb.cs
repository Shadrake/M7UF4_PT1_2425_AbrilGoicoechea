using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Orb : MonoBehaviour, ICollectable
{
    public void OnCollected()
    {
        GameManager.gameManager.OrbCollected(1);
        Destroy(gameObject);
    }
}
