using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public ItemScriptableObjects item1, item2;
    public Image image1, image2;
    public TextMeshProUGUI textItem1, textItem2;
    public Button buy1, buy2;

    private void OnEnable()
    {
        image1.sprite = item1.image;
        image2.sprite = item2.image;
        CheckIfCanBuy(item1, textItem1, buy1);
        CheckIfCanBuy(item2, textItem2, buy2);
    }

    public void BuyItem1()
    {
        GameManager.gameManager.ItemCollected(item1.image, 0);
        GameManager.gameManager.CoinCollected(-item1.price);
        CheckIfCanBuy(item1,textItem1 , buy1);
        CheckIfCanBuy(item1, textItem1, buy1);
    }

    public void BuyItem2()
    {
        GameManager.gameManager.ItemCollected(item2.image, 0);
        GameManager.gameManager.CoinCollected(-item2.price);
        CheckIfCanBuy(item2, textItem2, buy2);
        CheckIfCanBuy(item2, textItem2, buy2);
    }

    private void CheckIfCanBuy(ItemScriptableObjects item, TextMeshProUGUI insuCoins, Button buyButton)
    {
        if(GameManager.gameManager.coins >= item.price)
        {
            insuCoins.text = "" + item.price;
            insuCoins.color = Color.yellow;
            buyButton.interactable = true;
        }

        else
        {
            insuCoins.text = "insuficient coins: " + item.price;
            insuCoins.color = Color.red;
            buyButton.interactable = false;
        }
    }
}
