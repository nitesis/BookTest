using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Hit;

public class CardOrder : MonoBehaviour {

	public List<GameObject> cards;
	private Gesture gesture;
	private bool onStack;


	// Use this for initialization
	void Start () 
	{
		SetTop (cards [0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void gestureStateChangedHandler (object sender, GestureStateChangeEventArgs e)
	{
		Gesture gesture = sender as Gesture;
		Debug.Log ("Gesture:" + gesture);
		TouchHit hit;
		//gesture.GetTargetHitResult (out hit);
		if (e.State == Gesture.GestureState.Ended)
				ChangeOrder ();
	}

	void ChangeOrder ()
	{
		var temp = cards [0];
		cards.Remove(cards[0]);
		cards.Add (temp);
		SetTop (cards [0]);
		Debug.Log (cards [0].name);
		cards [0].transform.SetSiblingIndex (10);

		var count = cards.Count;
		Debug.Log ("Count: " + count);
	}

	void SetTop(GameObject card) 
	{
		foreach (var c in cards) 
			c.GetComponent<Gesture> ().StateChanged -= gestureStateChangedHandler;
		card.GetComponent<Gesture>().StateChanged += gestureStateChangedHandler;
	}
}
