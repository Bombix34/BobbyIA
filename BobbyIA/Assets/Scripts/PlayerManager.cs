using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ObjectManager
{

	ColorReplacement colorReplacement;

	StationsManager stationsManager;

	StationReglages currentStation=null;

	[SerializeField]
	GameObject emoteContainer;
	[SerializeField]
	SpriteRenderer emoteDisplay;

	Animator animator;

	void Start () 
	{
		animator=GetComponent<Animator>();
		emoteContainer.SetActive(false);
		colorReplacement=GetComponentInChildren<ColorReplacement>();
		colorReplacement.SwapColor(Pico8Colors.PicoColors.red, colorReplacement.colors.yellowColor);	
		stationsManager=GetComponent<StationsManager>();
		TakeDecision();
	}

	public override void ChangeState(State newState)
	{
		if(newState==null)
			return;
		
		currentState=newState;
		newState.Enter();
	}

	void Update()
	{
		if(currentState==null)
			return;
		currentState.Execute();
	}

	public void TakeDecision()
	//test de désirabilité avec les fuzzy variables et 
	//changement d'état pour bouger vers la nouvelle station
	{
		StationReglages nextStation = stationsManager.GetMostDesirableStation();
		if(currentStation==null)
		{
			currentStation=nextStation;
			ChangeState(new PlayerMoveToState(this,nextStation));
		}
		else
		{
			if(currentStation.name==nextStation.name)
				ChangeState(new PlayerOnStationState(this,nextStation));
			else
				ChangeState(new PlayerMoveToState(this,nextStation));
			currentStation=nextStation;
		}
	}

	public Animator GetAnimator()
	{
		return animator;
	}

	public SpriteRenderer GetEmoteDisplay()
	{
		return emoteDisplay;
	}
	public GameObject GetEmoteContainer()
	{
		return emoteContainer;
	}
	
}
