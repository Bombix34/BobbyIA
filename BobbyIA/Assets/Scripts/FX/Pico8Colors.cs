using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Waves/Pico8Colors")]
public class Pico8Colors : ScriptableObject {

	public Color blackColor= new Color(0f,0f,0f);
	public Color whiteColor= new Color(255f,241f,232f);
	public Color greyDarkColor= new Color(95f,87f,79f);
	public Color greyLightColor= new Color(194f,195f,199f);
	public Color brownColor= new Color(171f,82f,54f);
	public Color beigeColor= new Color(255f,204f,170f);
	public Color orangeColor= new Color(255f,163f,1f);
	public Color yellowColor= new Color(254f,240f,36f);
	public Color greenLightColor= new Color(2f,231f,86f);
	public Color greenDarkColor= new Color(0f,135f,81f);
	public Color blueLightColor= new Color(41f,173f,255f);
	public Color blueDarkColor= new Color(29f,43f,83f);
	public Color purpleLightColor= new Color(131f,118f,156f);
	public Color purpleDarkColor= new Color(126f,37f,82f);
	public Color redColor= new Color(255f,0f,77f);
	public Color pinkColor= new Color(255f,119f,168f);


	public Color ChooseColor(PicoColors color){
		Color choosenColor = blackColor;
		switch(color){
			case PicoColors.black:
				choosenColor = blackColor;
				break;
			case PicoColors.white:
				choosenColor = whiteColor;
				break;
			case PicoColors.greyDark:
				choosenColor = greyDarkColor;
				break;
			case PicoColors.greyLight:
				choosenColor = greyLightColor;
				break;
			case PicoColors.brown:
				choosenColor = brownColor;
				break;
			case PicoColors.beige:
				choosenColor = beigeColor;
				break;
			case PicoColors.orange:
				choosenColor = orangeColor;
				break;
			case PicoColors.yellow:
				choosenColor = yellowColor;
				break;
			case PicoColors.greenLight:
				choosenColor = greenLightColor;
				break;
			case PicoColors.greenDark:
				choosenColor = greenDarkColor;
				break;
			case PicoColors.blueLight:
				choosenColor = blueLightColor;
				break;
			case PicoColors.blueDark:
				choosenColor = blueDarkColor;
				break;
			case PicoColors.purpleLight:
				choosenColor = purpleLightColor;
				break;
			case PicoColors.purpleDark:
				choosenColor = purpleDarkColor;
				break;
			case PicoColors.red:
				choosenColor = redColor;
				break;
			case PicoColors.pink:
				choosenColor = pinkColor;
				break;
		}
		return choosenColor;
	}

	public enum PicoColors
	{
    	black = 0,
   		white = 232,
    	greyDark = 79,
    	greyLight = 199,
    	brown = 54,
		beige=170,
		orange = 1,
		yellow = 36,
		greenLight =86,
		greenDark = 81,
		blueLight = 255,
		blueDark = 83,
		purpleLight = 156,
		purpleDark=82,
		red=77,
		pink = 168
	}

}
