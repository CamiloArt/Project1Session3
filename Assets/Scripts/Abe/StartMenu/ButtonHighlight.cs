using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, ISelectHandler{

    void Start()
    {
        Debug.Log("Start");
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
        Debug.Log("Works");
    }
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
    }
}