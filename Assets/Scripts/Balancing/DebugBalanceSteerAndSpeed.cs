using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugBalanceSteerAndSpeed : MonoBehaviour
{
    [SerializeField] private JoystickPlayerExample _targetScript;
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private Slider _steerSlider;
    
    [SerializeField] private Text _speedVal;
    [SerializeField] private Text _steerVal;
    
    [SerializeField] private float _speedOriginalVal;
    [SerializeField] private float _steerOriginalVal;

    [SerializeField] private Button _resetButton;


    void Start()
    {
        _speedOriginalVal = _targetScript.speed;
        _steerOriginalVal = _targetScript.steer;

        _speedVal.text = _speedOriginalVal.ToString();
        _steerVal.text = _steerOriginalVal.ToString();


        _speedSlider.SetValueWithoutNotify(_targetScript.speed);
        _steerSlider.SetValueWithoutNotify(_targetScript.steer);

        _speedSlider.onValueChanged.AddListener(OnValChangeSpeed);
        _steerSlider.onValueChanged.AddListener(OnValChangeSteer);

        _resetButton.onClick.AddListener(ResetValues);
    }

    private void ResetValues()
    {
        _speedSlider.value = _speedOriginalVal;
        _steerSlider.value = _steerOriginalVal;
    }

    private void OnValChangeSpeed(float val)
    {
        _targetScript.speed = val;
        _speedVal.text = val.ToString();
    }
    private void OnValChangeSteer(float val)
    {
        _targetScript.steer = val;
        _steerVal.text = val.ToString();
    }
}
