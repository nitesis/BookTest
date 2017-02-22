using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchScript.InputSources.InputHandlers;
using TouchScript.Gestures;

public class CardTransition : MonoBehaviour {

	public Texture texture1;
	public Texture texture2;

	private Gesture gesture;
	private TapGesture tapGesture;
	private RawImage image;
	private GameObject circleMask;
	private Animator circleMaskAnimator;

	void Start ()
	{
		tapGesture = GetComponent<TapGesture> ();
		tapGesture.Tapped += tappedEventHandler;

		circleMask = gameObject.transform.parent.GetChild(0).gameObject;
		circleMaskAnimator = circleMask.GetComponent<Animator> ();
	}

	void ChangeTheImage ()
	{
		
		if (image.texture == (Texture)texture1) 
		{
			image.texture = (Texture)texture2;
		}
		else
		{
			image.texture = (Texture)texture1;
		}
	}

	void tappedEventHandler (object sender, System.EventArgs e)
	{
		circleMaskAnimator.SetTrigger ("AnimateIn");

		if (circleMaskAnimator.GetBool("AnimatedIn")) {
			circleMaskAnimator.Play ("AnimateOut", 0, 0f);
			circleMaskAnimator.SetBool ("AnimatedIn", false);
		} 
		else 
		{
			circleMaskAnimator.SetBool ("AnimatedIn", true);
			circleMaskAnimator.Play ("AnimateIn", 0, 0f);
		}

	}
}
