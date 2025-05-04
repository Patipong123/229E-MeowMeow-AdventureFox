using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinText.text = "x " + coinCount.ToString();
    }
}
