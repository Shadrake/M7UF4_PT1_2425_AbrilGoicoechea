using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Search;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText, orbText;
    //public Image[] items;
    public List<Image> items;
    
    public static GameManager gameManager;
    public int orbs = 0, coins = 0;

    void Awake()
    {
        if (GameManager.gameManager != null && GameManager.gameManager !=this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OrbCollected(int i)
    {
        orbs+= 1;
        orbText.text = "Orbs: " + orbs;
    }

    public void CoinCollected(int i)
    {
        coins+= i;
        coinText.text = "Coins: " + coins;
    }

    public interface ICollectable
    {
        public void OnCollected();
    }

    /*public void ItemCollected(Sprite sprite, int id)
    {
        items[id].sprite = sprite;
    }
    */

    public void ItemCollected(Sprite sprite, int i)
    {
        items[i].sprite = sprite;
    }
}