using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour {

	Sprite image;
	bool ingredientChoosen;


	void Start()
	{
		GetComponent<Image> ().material.EnableKeyword ("_NORMALMAP");
		image = GetComponent<Image>().sprite;
		SetImage(image);

	}

	public void Select()
	{
		//Debug.Log (ingredientChoosed);
		if (ingredientChoosen == false) 
		{
			//ColorButton();
			StartCoroutine("ColorButton");
		} 
		else 
		{
			//DecolorButton();
			StartCoroutine("DecolorButton");
		}
		Debug.Log (ingredientChoosen);
	}

	void ColorButton()
	{
		var image = GetComponent<Image>();
		if (image.material.HasProperty ("_GreyscaleAmount")) 
		{
			image.material.SetFloat ("_GreyscaleAmount", 0f);
			ingredientChoosen = true;
		}
	}

	void DecolorButton()
	{
		GetComponent<Image>().material.SetFloat("_GreyscaleAmount", 1f);
		ingredientChoosen = false;
	}

	public void SetImage(Sprite ingredientImage)
	{
		this.image = ingredientImage;

		var image = GetComponent<Image>();
		var greyscaleMaterial = new Material(Shader.Find("Greyscale"));
		//image.material.EnableKeyword("_DETAIL_MULX2");
		greyscaleMaterial.SetFloat("_GreyscaleAmount", 1f);

		image.sprite = ingredientImage;
		image.material = greyscaleMaterial;
	}
}
