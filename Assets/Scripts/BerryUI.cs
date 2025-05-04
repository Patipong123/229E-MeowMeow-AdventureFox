using TMPro;
using UnityEngine;

public class BerryUI : MonoBehaviour
{
    public TextMeshProUGUI berryText;
    private int berryCount = 0;

    public void AddBerry(int amount)
    {
        berryCount += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        berryText.text = "x " + berryCount.ToString();
    }
}
