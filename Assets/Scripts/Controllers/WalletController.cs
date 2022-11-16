using System;
using TMPro;
using UnityEngine;

public class WalletController : MonoBehaviour
{
    int playerMoney;
    int button2Price = 3;
    int button3Price = 5;
    int collectedCoin = 0;
    TextMeshProUGUI walletText;

    public static Action boughtButton2;
    public static Action boughtButton3;

    void Start()
    {
        walletText = GetComponentInChildren<TextMeshProUGUI>();
        MoneyAmountController();
        ButtonSessions.clickedButton2 += CanBuyButton2;
        ButtonSessions.clickedButton3 += CanBuyButton3;
        Coin.getCoin += CollectCoin;
    }

    void CollectCoin()
    {
        collectedCoin += 1;
    }

    void SaveCollectedCoin()
    {
        //TODO: kaydet, topa carpıpo oyunu kazandığında playerprefse
    }

    void CanBuyButton2()
    {
        if (playerMoney >= button2Price)
        {
            playerMoney -= button2Price;
            SaveMoneyToPlayerPrefs();
            boughtButton2?.Invoke();
        }
    }
    
    void CanBuyButton3()
    {
        if (playerMoney >= button3Price)
        {
            playerMoney -= button3Price;
            SaveMoneyToPlayerPrefs();
            boughtButton3?.Invoke();
        }
    }

    void MoneyAmountController()
    {
        WalletGetter();
        WalletSetter();
    }
    
    
    void WalletGetter()
    {
        playerMoney = PlayerPrefs.GetInt("playerMoney");
    }
    
    void WalletSetter()
    {
        walletText.text = playerMoney.ToString();
    }

    void SaveMoneyToPlayerPrefs()
    {
        PlayerPrefs.SetInt("playerMoney",playerMoney);
    }

    void OnDisable()
    {
        ButtonSessions.clickedButton2 -= CanBuyButton2;
        ButtonSessions.clickedButton3 -= CanBuyButton3;
        Coin.getCoin -= CollectCoin;
    }
}
