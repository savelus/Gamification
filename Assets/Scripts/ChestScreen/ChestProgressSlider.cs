using ChestScreen;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestProgressSlider : MonoBehaviour
{
    public static ChestProgressSlider Singleton;
    public Slider slider;

    private int LastChest = 0;

    public int SegmentsCount = 0;

    public int chestID => Mathf.RoundToInt(slider.value / (slider.maxValue / SegmentsCount));

    private void Awake()
    {
        Singleton = this;
    }

    public void UpdateSliderValue(float value)
    {
        
        if (chestID > 0 && chestID != LastChest)
        {
            LastChest = chestID;
        }
    }
}
