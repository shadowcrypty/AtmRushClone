using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField]
    private Event _event;
    [SerializeField]
    private UnityEvent _response;

    private void OnEnable()
    {
        _event.Register(this);
    }
    private void OnDisable()
    {
        _event.UnRegister(this);
    }
    public void OnEventOccurs() 
    {
        _response.Invoke();
    }
}
