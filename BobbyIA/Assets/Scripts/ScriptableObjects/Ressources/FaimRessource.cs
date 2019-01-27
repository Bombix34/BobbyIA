using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Ressources/Faim")]
public class FaimRessource : FuzzyVariable
{

	public float GetRepus()
	{
		return leftFunction.Evaluate(actualVal/100);
	}

	public float GetFaim()
	{
		return centerFunction.Evaluate(actualVal/100);
	}

	public float GetAffame()
	{
		return rightFunction.Evaluate(actualVal/100);
	}

}

