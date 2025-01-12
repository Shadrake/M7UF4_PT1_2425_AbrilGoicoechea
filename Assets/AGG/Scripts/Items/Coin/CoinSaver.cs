using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaver : MonoBehaviour
{
    public int id;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("Coin" + id) && PlayerPrefs.GetInt("Coin" + id) == 1)
        {
            LoadCoin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Coin" +  id, 1);
    }

    public void LoadCoin()
    {
        GameManager.gameManager.CoinCollected(1);
        gameObject.SetActive(false);
    }
}
