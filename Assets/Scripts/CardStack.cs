using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class CardStack : MonoBehaviour 
{
	public Transform root;

	void Start()
	{
		Refresh ();
	}

	public void AddCard(GameObject card) 
	{
		card.transform.SetParent(transform);
		card.transform.SetSiblingIndex (10);
		card.transform.localPosition = Vector3.zero;

		Refresh ();
	}

	public void RemoveTopCard() 
	{
		if (transform.childCount > 0) 
			transform.GetChild (transform.childCount - 1).parent = root;
		Refresh ();
	}

	void gestureStateChangedHandler (object sender, GestureStateChangeEventArgs e)
	{
		if (e.State == Gesture.GestureState.Began) 
		{
			var gesture = sender as Gesture;
			var parent = gesture.gameObject.transform.parent.gameObject;
				SetCardStackOnTop (parent);
		}

		if (e.State == Gesture.GestureState.Ended) 
		{
			var gesture = sender as Gesture;
			FindObjectOfType<CardController> ().AllocateCard (gesture.gameObject);
		}
	}

	void SetCardStackOnTop(GameObject cardStack)
	{
		cardStack.transform.SetAsLastSibling ();
	}

	void Refresh()
	{
		if (transform.childCount > 0) 
		{
			foreach (Transform child in transform) 
			{
				//holt alle transform gestures und entfernt ihre event handler
				var gesture = child.gameObject.GetComponent<TransformGesture> ();
				gesture.StateChanged -= gestureStateChangedHandler;
				gesture.enabled = false;
			}
			// fügt dem obersten child event handler hinzu
			var gestureTop = transform.GetChild(transform.childCount - 1).gameObject.GetComponent<TransformGesture> ();
			gestureTop.enabled = true;
			gestureTop.StateChanged += gestureStateChangedHandler;
		}
	}
}
