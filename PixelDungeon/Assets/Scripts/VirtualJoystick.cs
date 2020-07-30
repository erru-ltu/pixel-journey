using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image bgImage;
    private Image joystick;

    private Vector3 inputVector;

    private void Start()
    {
        bgImage = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, 
            eventData.position, eventData.pressEventCamera, out position));

        position.x = (position.x / bgImage.rectTransform.sizeDelta.x);
        position.y = (position.y / bgImage.rectTransform.sizeDelta.y);

        inputVector = new Vector2(position.x * 2 - 1, position.y * 2 - 1);

        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (bgImage.rectTransform.sizeDelta.x / 2), 
            inputVector.y * (bgImage.rectTransform.sizeDelta.y / 2));

    }

    //when we touch joystick
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //position of joystick when finger released
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    //function to move character by X axis
    public float Horizontal()
    {
        if(inputVector.x != 0)
        {
            return inputVector.x;
        }
        
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    //function to move character by Y axis
    public float Vertical()
    {
        if (inputVector.y != 0)
        {
            return inputVector.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }



}
