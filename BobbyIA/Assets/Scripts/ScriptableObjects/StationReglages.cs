using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Stations/Station")]
public class StationReglages : ScriptableObject {

	[SerializeField]
	public StationType stationName;
	public string speechToDisplay;
	
	public Sprite emote;

	[SerializeField]
	[Range(0,100)]
	int ND; // valeur représentative peu désirable

	[SerializeField]
	[Range(0,100)]
	int D; // valeur représentative désirable

	[SerializeField]
	[Range(0,100)]
	int TD; // valeur représentative très désirable

	float actualDesirability=0f;

	public List<Predicat> predicats;

	public List<ModifVariable> modifRessources;
	

	public float TestDesirabilityStation(RessourcesManager ressources)
	{
		//test de la désirabilité de la station
		//avec les prédicats

		float valTD=0f; //confiance TD
		float valD=0f;	//confiance D
		float valND=0f;	// confiance ND

		for(int i =0; i < predicats.Count;i++)
		{
			switch(predicats[i].desirabiliteConcerne)
			{
				case Predicat.Desirabilite.ND:
					valND= Mathf.Max(valND,predicats[i].TestPredicat(ressources));
					break;
				case Predicat.Desirabilite.D:
					valD= Mathf.Max(valND,predicats[i].TestPredicat(ressources));
					break;
				case Predicat.Desirabilite.TD:
					valTD= Mathf.Max(valND,predicats[i].TestPredicat(ressources));
					break;
			}
		}
		//calcul du maxima 
		if(valD==0&&valTD==0&&valND==0)
			actualDesirability=0f;
		else
			actualDesirability = ((valTD*TD)+(valD*D)+(valND*D)) / (valTD+valD+valND) ;
		return actualDesirability;
	}

	public void ApplyModifVariables()
	//quand on entre dans une station, on applique des modifs aux fuzzy variables
	{
		foreach(ModifVariable modif in modifRessources)
		{
			modif.variableConcerned.AddVal(modif.modifValue);
		}
	}

	public void ApplyNewEmote(SpriteRenderer container)
	//pour appliquer la nouvelle emote lors du changement de station pour celle-ci
	{
		container.sprite=emote;
		//active la bulle pour laffichage de l'emote
		container.transform.parent.gameObject.SetActive(true);
	}

	public enum StationType{
		dormir,
		reviser,
		reviser_panique,
		manger_cassecroute,
		manger_repas,
		jouer_JV,
		lire_livre,
		flaner,
		seffondrer
	}

	[System.Serializable]
	public struct ModifVariable
	{
		public FuzzyVariable variableConcerned;
		[Range(-100,100)]
		public int modifValue;
	}
}
