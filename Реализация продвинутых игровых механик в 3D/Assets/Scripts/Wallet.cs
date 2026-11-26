using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance;
    public int balance = 0;
    public TMP_Text balanceText;
    public GameObject walletCanvas;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddMoney(int amount)
    {
        balance += amount;
        if (balanceText != null)
            balanceText.text = balance.ToString();
    }

    public void Show()
    {
        if (walletCanvas != null)
            walletCanvas.SetActive(true);
    }
}
