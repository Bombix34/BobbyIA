﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectManager : MonoBehaviour {

	protected State currentState;
	

	public virtual void ChangeState(State newState){
	//newState==null permet de traiter les Idles des différentes config' : IA ou joueur
		if(newState==null)
			return;
		currentState=newState;
		newState.Enter();
	}

}
