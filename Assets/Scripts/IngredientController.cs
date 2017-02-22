using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.UI;

public class IngredientController : MonoBehaviour {

	public Button button;
	TapGesture tapGesture;
	Ingredient ingredient;

	// Use this for initialization
	void Start () {
		ingredient = button.GetComponent<Ingredient>();

		//button.onClick.AddListener(ingredient.Select);
		tapGesture = button.GetComponent<TapGesture> ();
		tapGesture.Tapped += tappedEventHandler;
	}

	void tappedEventHandler (object sender, System.EventArgs e)
	{
		ingredient.Select ();
	}
}
