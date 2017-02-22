using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour {

	Sprite image;
	bool ingredientChoosed;


	void Start()
	{
		image = GetComponent<Image>().sprite;
		SetImage(image);

	}

	public void Select()
	{
		//Debug.Log (ingredientChoosed);
		if (ingredientChoosed == false) 
		{
			//ColorButton();
			StartCoroutine("ColorButton");
		} 
		else 
		{
			//DecolorButton();
			StartCoroutine("DecolorButton");
		}
		Debug.Log (ingredientChoosed);
	}

	void ColorButton()
	{
		GetComponent<Image>().material.SetFloat("_GreyscaleAmount", 0f);
		ingredientChoosed = true;
	}

	void DecolorButton()
	{
		GetComponent<Image>().material.SetFloat("_GreyscaleAmount", 1f);
		ingredientChoosed = false;
	}

	public void SetImage(Sprite ingredientImage)
	{
		this.image = ingredientImage;

		var image = GetComponent<Image>();
		var greyscaleMaterial = new Material(Shader.Find("Greyscale"));
		greyscaleMaterial.SetFloat("_GreyscaleAmount", 1f);

		image.sprite = ingredientImage;
		image.material = greyscaleMaterial;
	}
}
