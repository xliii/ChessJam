using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events {

	public enum EventType
	{
		WIN
	}

	private static Dictionary<EventType, UnityEvent> events = new Dictionary<EventType, UnityEvent>();

	public static void RegisterEvent(EventType type, UnityAction handler)
	{
		if (!events.ContainsKey(type))
		{
			events[type] = new UnityEvent();
		}
		events[type].AddListener(handler);
	}

	public static void TriggerEvent(EventType type)
	{
		if (!events.ContainsKey(type))
		{
			Debug.LogWarning("No handlers registered for " + type);
			return;
		}
		
		events[type].Invoke();
	}
}
