using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //Доделать куротину. создать внова заного весь UI....


    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _delayTime = 0.5f;

    private int _maximumLifeForce;
    private WaitForSeconds _waitForSeconds;
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
        SlideSmoothSlider();
    }

    private void PrintText()
    {
        _text.text = $"Здоровье: {_health.LifeForce}/{_maximumLifeForce}";
    }
    private void SlideSlider()
    {
        _slider.value = _health.LifeForce;
    }

    private void SlideSmoothSlider()
    {
        //_smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _health.LifeForce, _speed);
        StartCoroutine(AAA(_smoothSlider.value, _health.LifeForce));
    }

    private IEnumerator AAA(float current, int target)
    {
        while (current != target)
        {
            _smoothSlider.value = Mathf.MoveTowards(current, target, _speed);
           
        }

        yield return _waitForSeconds;
    }
}
