using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Ressources/Travail")]
public class TravailRessource : FuzzyVariable
{

	public float GetLibre()
	{
		return leftFunction.Evaluate(actualVal/100);
	}

	public float GetPreoccupe()
	{
		return centerFunction.Evaluate(actualVal/100);
	}

	public float GetStresse()
	{
		return rightFunction.Evaluate(actualVal/100);
	}

}
