using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float ValueChangeStep = 10;
    private const float ValueChangeSpeed = 20;

    private Slider _slider;
    private float _targetValue;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _targetValue = _slider.value;
    }

    private void Update()
    {
        if (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, ValueChangeSpeed * Time.deltaTime);
        }
    }

    public void OnDamage()
    {
        _targetValue = Mathf.Max(_targetValue - ValueChangeStep, _slider.minValue);
    }

    public void OnHeal()
    {
        _targetValue = Mathf.Min(_targetValue + ValueChangeStep, _slider.maxValue);
    }
}
