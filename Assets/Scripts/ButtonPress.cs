using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour
{
    EventTrigger eventTrigger;

    // Start is called before the first frame update
    void Start()
    {
        eventTrigger = this.GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener((BaseEventData data) =>
        {
            Debug.Log("Button Pressed");
        });

        eventTrigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
