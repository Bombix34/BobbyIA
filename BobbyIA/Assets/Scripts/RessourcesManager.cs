using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesManager : MonoBehaviour 
{

	[SerializeField]
	SommeilRessource sommeil;

	[SerializeField]
	TravailRessource travail;

	[SerializeField]
	EnnuiRessource ennui;

	[SerializeField]
	FaimRessource faim;

	void Start()
	{
		InitRessource();
	}

	void Update()
	{
		UpdateRessources();
	}

	void UpdateRessources()
	{
		sommeil.Update();
		travail.Update();
		ennui.Update();
		faim.Update();
	}

	void InitRessource()
	{
		sommeil.SetModifPerTime(0.3f);
		travail.SetModifPerTime(0.2f);
		ennui.SetModifPerTime(0.25f);
		faim.SetModifPerTime(0.3f);

		sommeil.SetActualVal(Random.Range(30f,60f));
		travail.SetActualVal(Random.Range(0f,50f));
		ennui.SetActualVal(Random.Range(0f,20f));
		faim.SetActualVal(Random.Range(30f,60f));
	}

	public void RandomizeVal()
	{
		sommeil.SetActualVal(Random.Range(0f,100f));
		travail.SetActualVal(Random.Range(0f,100f));
		ennui.SetActualVal(Random.Range(0f,100f));
		faim.SetActualVal(Random.Range(0f,100f));
	}


	public SommeilRessource GetSommeil(){return sommeil;}
	public TravailRessource GetTravail(){return travail;}
	public EnnuiRessource GetEnnui(){return ennui;}
	public FaimRessource GetFaim(){return faim;}
}
