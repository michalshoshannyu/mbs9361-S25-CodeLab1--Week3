using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public enum GameEvent
    {
        ENTER_PATH,
        EXIT_PATH,
        CHANGE_CAMERA
    }

    public class GeneralEvent : UnityEvent<object>
    {
    } //Empty class but need to exsist.

    private Dictionary<GameEvent, GeneralEvent> eventDictionary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<GameEvent, GeneralEvent>();
        }
    }
    
    public void StartListening(GameEvent eventName, UnityAction<object> listener)
    {
        GeneralEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new GeneralEvent();
            thisEvent.AddListener(listener);
            eventDictionary.Add(eventName, thisEvent);
        }
    }

    public void StopListening(GameEvent eventName, UnityAction<object> listener)
    {
        GeneralEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public void TriggerEvent(GameEvent gameEvent, object obj)
    {
        GeneralEvent thisEvent = null;
        if (eventDictionary.TryGetValue(gameEvent, out thisEvent))
        {
            thisEvent.Invoke(obj);
        }
    }

}