using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceUI : MonoBehaviour 
{
	public FuzzyVariable ressource;

	[SerializeField]
	Pico8Colors colors;
	[SerializeField]
	Image sliderImg;

	public Text textUI;

	public Text leftVal;
	public Text centerVal;
	public Text rightVal;

	Slider slider;


	void Start () 
	{
		slider=GetComponent<Slider>();
		textUI.text=ressource.name;
	}
	
	void Update () 
	{
		slider.value=ressource.GetActualVal()/100;
		UpdateColor();
		leftVal.text=((Mathf.Round(ressource.Evaluate(0)*100f))/100).ToString();
		centerVal.text=((Mathf.Round(ressource.Evaluate(1)*100f))/100).ToString();
		rightVal.text=((Mathf.Round(ressource.Evaluate(2)*100f))/100).ToString();
	}

	void UpdateColor()
	{
		if(slider.value>0.66)
			sliderImg.color=colors.redColor;
		else if(slider.value>0.33)
			sliderImg.color=colors.yellowColor;
		else
			sliderImg.color=colors.greenLightColor;
	}
}
