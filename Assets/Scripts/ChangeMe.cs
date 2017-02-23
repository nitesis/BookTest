using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeMe : MonoBehaviour {

	public Text theText;

	public void OnPointerEnter(PointerEventData eventData)
	//public void ColorMeRed()
	{
		theText.color = Color.red; //Or however you do your color
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		theText.color = Color.white; //Or however you do your color
	}
}
