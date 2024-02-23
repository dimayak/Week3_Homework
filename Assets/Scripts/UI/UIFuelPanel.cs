using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFuelPanel : MonoBehaviour
{
    [SerializeField] private Image _progressBarFill;

    private void OnEnable()
    {
        FuelManager.OnFuelAmountChanged += FuelManager_OnFuelAmountChanged;
    }

    private void OnDisable()
    {
        FuelManager.OnFuelAmountChanged -= FuelManager_OnFuelAmountChanged;
    }

    private void FuelManager_OnFuelAmountChanged(FuelManager fuelManager)
    {
        float progress = Mathf.Clamp01(fuelManager.CurrentFuelAmount / fuelManager.MaxFuelAmount);
        Vector3 scale = _progressBarFill.rectTransform.localScale;
        scale.x = progress;
        _progressBarFill.rectTransform.localScale = scale;
    }
}
