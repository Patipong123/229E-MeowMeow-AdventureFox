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

    public bool TryUseBerry(int amount)
    {
        if (berryCount >= amount)
        {
            berryCount -= amount;
            UpdateUI();
            return true;
        }

        return false;
    }


    private void UpdateUI()
    {
        berryText.text = "x " + berryCount.ToString();
    }
}
