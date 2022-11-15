using UnityEngine;

public class ShopPanelController : MonoBehaviour
{
    [Header("BuyButton2")]
    [SerializeField] GameObject buttonBeforeBuy1;
    [SerializeField] GameObject buttonAfterBuy1;
    [SerializeField] GameObject costPart1;
    [SerializeField] GameObject boughtPart1;
    int buyButton2;
    [Space(10)]
    
    [Header("BuyButton3")]
    [SerializeField] GameObject buttonBeforeBuy2;
    [SerializeField] GameObject buttonAfterBuy2;
    [SerializeField] GameObject costPart2;
    [SerializeField] GameObject boughtPart2;
    int buyButton3;

    void Start()
    {
        BuyButtonController();
        WalletController.boughtButton2 += BoughtButton2;
        WalletController.boughtButton3 += BoughtButton3;
    }

    void BuyButtonController()
    {
        BuyButton2Controller();
        BuyButton3Controller();
    }

    void BuyButton2Controller()
    {
        buyButton2 = PlayerPrefs.GetInt("buyButton2");

        if (buyButton2 == 0)
            return;
        else
        {
            buttonBeforeBuy1.SetActive(false);
            buttonAfterBuy1.SetActive(true);
            costPart1.SetActive(false);
            boughtPart1.SetActive(true);
        }
    }
    
    void BuyButton3Controller()
    {
        buyButton3 = PlayerPrefs.GetInt("buyButton3");
        
        if (buyButton3 == 0)
            return;
        else
        {
            buttonBeforeBuy2.SetActive(false);
            buttonAfterBuy2.SetActive(true);
            costPart2.SetActive(false);
            boughtPart2.SetActive(true);
        }
    }

    void BoughtButton2()
    {
        buyButton2 = 1;
        PlayerPrefs.SetInt("buyButton2", buyButton2);
        BuyButton2Controller();
    }

    void BoughtButton3()
    {
        buyButton3 = 1;
        PlayerPrefs.SetInt("buyButton3", buyButton3);
        BuyButton3Controller();
    }

    void OnDisable()
    {
        WalletController.boughtButton2 -= BoughtButton2;
        WalletController.boughtButton3 -= BoughtButton3;
    }
}
