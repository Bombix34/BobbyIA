using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Ressources/Sommeil")]
public class SommeilRessource : FuzzyVariable
{

	public float GetEnForme()
	{
		return leftFunction.Evaluate(actualVal/100);
	}

	public float GetFatigue()
	{
		return centerFunction.Evaluate(actualVal/100);
	}

	public float GetEpuise()
	{
		return rightFunction.Evaluate(actualVal/100);
	}

}
