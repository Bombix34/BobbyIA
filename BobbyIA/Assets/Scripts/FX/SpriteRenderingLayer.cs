using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderingLayer : MonoBehaviour {

	SpriteRenderer spriteRender;
	public float modificator;

	protected virtual void Start () {
		spriteRender = GetComponent<SpriteRenderer> ();
	}

	protected virtual void Update () {
		spriteRender.sortingOrder = (int)(((1/transform.position.y) * 1000)+modificator);
	}
}
