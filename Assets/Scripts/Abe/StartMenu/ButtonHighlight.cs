using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler{

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale += new Vector3(0.7f, 0.7f, 0.7f);
        Debug.Log("Run");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = initialScale;
        Debug.Log("Exit");
    }
    public void OnSelect(BaseEventData eventData)
    {
        transform.localScale += new Vector3(0.7f, 0.7f, 0.7f);
        Debug.Log("Run");
    }
    public void OnDeselect(BaseEventData eventData)
    {
        transform.localScale = initialScale;
        Debug.Log("Exit");
    }
}