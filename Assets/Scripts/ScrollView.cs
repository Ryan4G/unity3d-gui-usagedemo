using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour
{
    ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = this.GetComponent<ScrollRect>();

        scrollRect.onValueChanged.AddListener((Vector2 vec) =>
        {
            Debug.Log(vec);
        });

        scrollRect.verticalNormalizedPosition = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
