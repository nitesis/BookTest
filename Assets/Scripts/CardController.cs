using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour 
{
	public CardStack active;
	public CardStack inactive;

	public void AllocateCard(GameObject card)
	{
		var diff1X = active.transform.position.x - card.transform.position.x;
		var diff1Z = active.transform.position.z - card.transform.position.z;

		var diff2X = inactive.transform.position.x - card.transform.position.x;
		var diff2Z = inactive.transform.position.z - card.transform.position.z;

		if (Mathf.Sqrt (Mathf.Pow(diff1X, 2) + Mathf.Pow(diff1Z,2)) 
			> Mathf.Sqrt (Mathf.Pow(diff2X,2) + Mathf.Pow(diff2Z,2))) 
		{
			if (active.transform.FindChild (card.name)) 
				active.RemoveTopCard ();
			inactive.AddCard (card);

		} 
		else 
		{
			if (inactive.transform.FindChild (card.name)) 
				inactive.RemoveTopCard ();
			active.AddCard (card);
		}
	}

}
