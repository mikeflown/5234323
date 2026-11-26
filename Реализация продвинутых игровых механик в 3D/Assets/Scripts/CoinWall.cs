using UnityEngine;

public class CoinWall : MonoBehaviour
{
    [Header("Requirements")]
    public int requiredCoins = 5;
    [Header("Wall")]
    public GameObject wallToDisable;
    [Header("Optional")]
    public bool checkEveryFrame = true;
    private bool alreadyDisabled = false;
    void Update()
    {
        if (alreadyDisabled) return;
        if (!checkEveryFrame && alreadyDisabled) return;
        if (Wallet.Instance != null && Wallet.Instance.balance >= requiredCoins)
        {
            DisableWall();
        }
    }
    void DisableWall()
    {
        if (wallToDisable != null)
            wallToDisable.SetActive(false);
        alreadyDisabled = true;
        Debug.Log($"Wall disabled! Coins: {Wallet.Instance.balance}/{requiredCoins}");
    }
    public void CheckCoins()
    {
        if (Wallet.Instance != null && Wallet.Instance.balance >= requiredCoins)
            DisableWall();
    }
}