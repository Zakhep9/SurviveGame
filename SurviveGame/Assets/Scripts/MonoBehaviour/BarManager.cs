using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image TemperatureBar;
    public Image WaterBar;

    private float _fillBarTemperature;
    private float _fillBarWater;
    void Start()
    {
        _fillBarTemperature = 1.0f;
        _fillBarWater = 1.0f;
    }

    void Update()
    {
        _fillBarWater -= Time.deltaTime * 0.01f;
        _fillBarTemperature -= Time.deltaTime * 0.001f;

        TemperatureBar.fillAmount = _fillBarTemperature;
        WaterBar.fillAmount = _fillBarWater;
    }
}
