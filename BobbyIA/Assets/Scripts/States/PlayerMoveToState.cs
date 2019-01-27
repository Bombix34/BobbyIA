using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveToState : State {

	PlayerManager playerManager;
	StationReglages nextStation;

	float chrono;

	public PlayerMoveToState(ObjectManager objectManager, StationReglages next):base(objectManager)
	{
		curObject=objectManager;
		playerManager=(PlayerManager)curObject;
		nextStation =next;
		stateName="BOBBY IS MOVING";
		chrono=Random.Range(2f,3f);
	}

	public override void Enter()
	{
		DebugUI.instance.currentChoiceText.text=stateName;
		playerManager.GetAnimator().SetBool("Move",true);
		playerManager.GetEmoteContainer().SetActive(false);
	}

	public override void Execute()
	{
		chrono-=Time.deltaTime;
		if(chrono<=0)
			Exit();
	}

	public override void Exit()
	{
		curObject.ChangeState(new PlayerOnStationState(curObject,nextStation));
	}
}
