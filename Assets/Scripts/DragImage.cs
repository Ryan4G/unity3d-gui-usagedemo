using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragImage : MonoBehaviour
{
    public RectTransform dragArea;
    public Image imageDrag;
    public Image imageTarget;

    // Start is called before the first frame update
    void Start()
    {
        EventTrigger eventTrigger = imageDrag.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry dragEntry = new EventTrigger.Entry();
        dragEntry.eventID = EventTriggerType.Drag;
        dragEntry.callback = new EventTrigger.TriggerEvent();
        dragEntry.callback.AddListener((BaseEventData data) =>
        {
            Vector2 touchPos = ((PointerEventData)data).position;

            Vector2 uguiPos;

            bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(
                dragArea, touchPos, ((PointerEventData)data).enterEventCamera, out uguiPos);

            if (isRect && RectTransformUtility.RectangleContainsScreenPoint(
                dragArea, touchPos, ((PointerEventData)data).enterEventCamera))
            {
                imageDrag.rectTransform.localPosition = uguiPos;
            }

            imageDrag.raycastTarget = false;
        });

        EventTrigger.Entry endDragEntry = new EventTrigger.Entry();
        endDragEntry.eventID = EventTriggerType.EndDrag;
        endDragEntry.callback = new EventTrigger.TriggerEvent();
        endDragEntry.callback.AddListener((BaseEventData data) =>
        {
            var go = ((PointerEventData)data).pointerEnter;

            if (go != null && go.name.CompareTo(imageTarget.name) == 0)
            {
                imageDrag.rectTransform.position = imageTarget.rectTransform.position;
            }
            imageDrag.raycastTarget = true;
        });

        eventTrigger.triggers.Add(dragEntry);
        eventTrigger.triggers.Add(endDragEntry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
