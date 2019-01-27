using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnStationState : State {

	PlayerManager playerManager;
	StationReglages currentStation;

	float chrono;

	public PlayerOnStationState(ObjectManager objectManager, StationReglages next):base(objectManager)
	{
		curObject=objectManager;
		playerManager=(PlayerManager)curObject;
		currentStation =next;
		stateName="BOBBY "+currentStation.speechToDisplay;
		chrono=Random.Range(2f,3f);
	}

	public override void Enter()
	{
		//modifie les fuzzy variable lors de l'utilisation de la station
		currentStation.ApplyModifVariables();
		currentStation.ApplyNewEmote(playerManager.GetEmoteDisplay());
		DebugUI.instance.currentChoiceText.text=stateName;
		playerManager.GetAnimator().SetBool("Move",false);
	}

	public override void Execute()
	{
		chrono-=Time.deltaTime;
		if(chrono<=0)
			Exit();
	}

	public override void Exit()
	{
		playerManager.TakeDecision();
	}
}
