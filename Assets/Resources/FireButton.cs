using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    public bool checkPressed(){
        return isPressed;
    }
    
}
