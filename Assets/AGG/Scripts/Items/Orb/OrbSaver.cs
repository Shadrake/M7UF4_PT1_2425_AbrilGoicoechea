using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSaver : MonoBehaviour
{
    public int id;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("Orb" + id) && PlayerPrefs.GetInt("Orb" + id) == 1)
        {
            LoadOrb();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Orb" + id, 1);
    }

    public void LoadOrb()
    {
        GameManager.gameManager.OrbCollected(1);
        gameObject.SetActive(false);
    }
}
