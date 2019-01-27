using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyVariable  : ScriptableObject 
{
	[Header("Fonctions d'appartenance")]

	[SerializeField]
	protected AnimationCurve leftFunction;
	[SerializeField]
	protected AnimationCurve centerFunction;
	[SerializeField]
	protected AnimationCurve rightFunction;

	[Space]

	[Header("Valeur et modificateur")]
	
	[SerializeField]
	[Range(0f,99f)]
	protected float actualVal;

	[SerializeField]
	[Range(-50f,50f)]
	float modifPerTime;

	public void Update()
	{
		actualVal+=modifPerTime*Time.deltaTime;
		if(actualVal>100)
			actualVal=100;
		else if(actualVal<0)
			actualVal=0;
	}

//GETTER & SETTER______________________________________________________________________________________________

	public void SetModifPerTime(float newVal)
	{
		modifPerTime=newVal;
	}

	public void SetActualVal(float newVal)
	{
		actualVal=newVal;
	}

	public void AddVal(float newVal)
	{
		actualVal+=newVal;
		if(actualVal<0)
			actualVal=0;
		else if(actualVal>99)
			actualVal=99;
	}

	public float GetActualVal()
	{
		return actualVal;
	}

	public float Evaluate(int index)
	{
		//0 left
		//1 center
		//2 right
		if(index==0)
			return leftFunction.Evaluate(actualVal/100);
		else if(index==1)
			return centerFunction.Evaluate(actualVal/100);
		else
			return rightFunction.Evaluate(actualVal/100);
	}
	
}
