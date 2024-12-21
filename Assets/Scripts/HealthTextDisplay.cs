using TMPro;
using UnityEngine;

public class HealthTextDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;

    private int _maximumLifeForce;

    private void Start()
    {
        Initialization();
    }

    private void OnEnable()
    {
        _health.HealthHasChanged += Print;
    }

    private void OnDisable()
    {
        _health.HealthHasChanged -= Print;
    }

    private void Initialization()
    {
        _maximumLifeForce = _health.GetMaximumLifeForce();
        Print();
    }

    private void Print()
    {
        _text.text = $"Çהמנמגüו: {_health.LifeForce}/{_maximumLifeForce}";
    }
}
