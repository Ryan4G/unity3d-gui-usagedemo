using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour
{
    Image image;

    float filledAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        filledAmount += 0.005f;

        if (filledAmount >= 1.0f)
        {
            filledAmount = 0;
        }

        image.fillAmount = filledAmount;
    }
}
