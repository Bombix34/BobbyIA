using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Ressources/Ennui")]
public class EnnuiRessource : FuzzyVariable
{

	public float GetEnjoue()
	{
		return leftFunction.Evaluate(actualVal/100);
	}

	public float GetPensif()
	{
		return centerFunction.Evaluate(actualVal/100);
	}

	public float GetEnnui()
	{
		return rightFunction.Evaluate(actualVal/100);
	}

}