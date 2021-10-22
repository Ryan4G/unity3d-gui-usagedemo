using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStars : MonoBehaviour
{
    Dictionary<int, Toggle> toggles;

    List<int> triggerList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        toggles = new Dictionary<int, Toggle>();
        GameObject canvas = GameObject.Find("Canvas");

        foreach(Transform t in canvas.transform.GetComponentsInChildren<Transform>())
        {
            if (t.name.Contains("ToggleStar"))
            {
                Toggle toggle = t.GetComponent<Toggle>();

                int index = System.Convert.ToInt32(toggle.name.Replace("ToggleStar", ""));

                toggle.onValueChanged.AddListener((bool isOn) =>
                {
                    // avoid trigger twice
                    if (!triggerList.Contains(index))
                    {
                        this.operateToggles(index);
                    }
                });

                toggles.Add(index, toggle);
            }
        }
    }

    private void operateToggles(int index)
    {
        for(int i = 1; i <= toggles.Count; i++)
        {
            if (toggles.ContainsKey(i))
            {
                var changeBool = i <= index;

                if (toggles[i].isOn != changeBool)
                {
                    triggerList.Add(i);
                    // it will trigger valueChanged event
                    toggles[i].isOn = changeBool;
                }
            }
        }

        triggerList.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
