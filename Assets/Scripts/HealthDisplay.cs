using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _delayTime = 0.1f;

    private int _maximumLifeForce;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

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
        _slider.maxValue = _maximumLifeForce;
        _slider.value = _maximumLifeForce;
        _smoothSlider.maxValue = _maximumLifeForce;
        _smoothSlider.value = _maximumLifeForce;
        PrintText();
        _waitForSeconds = new WaitForSeconds(_delayTime);
    }

    private void Print()
    {
        PrintText();
        SlideSlider();
        StartSmoothSlide();
    }

    private void PrintText()
    {
        _text.text = $"Çהמנמגüו: {_health.LifeForce}/{_maximumLifeForce}";
    }
    private void SlideSlider()
    {
        _slider.value = _health.LifeForce;
    }

    private void StartSmoothSlide()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothSlide());
    }

    private IEnumerator SmoothSlide()
    {
        while (_smoothSlider.value != _health.LifeForce)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _health.LifeForce, _speed);
            yield return _waitForSeconds;
        }
    }
}
