using UnityEngine;
using TMPro;

public class UICoinPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _coinText;

    private void OnEnable()
    {
        CoinManager.OnCurrentCoinsChanged += CoinManager_OnCurrentCoinsChanged;
    }

    private void OnDisable()
    {
        CoinManager.OnCurrentCoinsChanged -= CoinManager_OnCurrentCoinsChanged;
    }

    private void CoinManager_OnCurrentCoinsChanged(int current, int total)
    {
        _coinText.text = current.ToString();
    }

}
