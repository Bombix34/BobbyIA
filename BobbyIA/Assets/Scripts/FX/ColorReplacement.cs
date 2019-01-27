using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorReplacement : MonoBehaviour {

	Texture2D mColorSwapTex;
	Color[] mSpriteColors;

	public Pico8Colors colors;
	Renderer mSpriteRenderer;

	float mHitEffectTimer = 0.0f;
	const float cHitEffectTime = 0.1f;

	void Awake(){
		mSpriteRenderer=GetComponent<Renderer>();

		InitColorSwapTex();
		
		mColorSwapTex.Apply();
	}


	public void Update()
	{
		if (mHitEffectTimer > 0.0f)
		{
			mHitEffectTimer -= Time.deltaTime;
			if (mHitEffectTimer <= 0.0f)
				ResetAllSpritesColors();
		}
	}

	public void InitColorSwapTex()
	{
		Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
		colorSwapTex.filterMode = FilterMode.Point;
	
		for (int i = 0; i < colorSwapTex.width; ++i)
			colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
	
		colorSwapTex.Apply();
	
		mSpriteRenderer.material.SetTexture("_SwapTex", colorSwapTex);
	
		mSpriteColors = new Color[colorSwapTex.width];
		mColorSwapTex = colorSwapTex;
	}

	public void SwapColor(Pico8Colors.PicoColors index, Color color)
	{
		InitColorSwapTex();
    	mSpriteColors[(int)index] = color;
    	mColorSwapTex.SetPixel((int)index, 0, color);
		mColorSwapTex.Apply();
	}

	public void SwapAllSpritesColorsTemporarily(Color color)
	{
		for (int i = 0; i < mColorSwapTex.width; ++i)
			mColorSwapTex.SetPixel(i, 0, color);
		mColorSwapTex.Apply();
	}

	public void StartHitEffect(Pico8Colors.PicoColors color)
	{
		mHitEffectTimer = cHitEffectTime;
		SwapAllSpritesColorsTemporarily(colors.ChooseColor(color));
	}

	public void ResetAllSpritesColors()
	{
		for (int i = 0; i < mColorSwapTex.width; ++i)
			mColorSwapTex.SetPixel(i, 0, mSpriteColors[i]);
		mColorSwapTex.Apply();
	}
}
