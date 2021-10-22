using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodSlider : MonoBehaviour
{
    Slider slider;
    bool keepIncrease = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += 0.5f * Time.deltaTime * (keepIncrease ? 1.0f : -1.0f);

        if (slider.value <= 0)
        {
            keepIncrease = true;
        }

        if (slider.value >= 1)
        {
            keepIncrease = false;
        }
    }
}
