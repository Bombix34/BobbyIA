using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Stations/Predicat")]
public class Predicat : ScriptableObject 
{

	public Ressource valeur1;
	public Ressource valeur2;
	public Ressource valeur3;
	public Ressource valeur4;

	public Desirabilite desirabiliteConcerne;

	public float TestPredicat(RessourcesManager ressources)
	{
		if(valeur2==Ressource.none)
			return TestValeur(valeur1,ressources);
		else if(valeur3==Ressource.none)
			return Mathf.Min(TestValeur(valeur1,ressources),TestValeur(valeur2,ressources));
		else if(valeur4==Ressource.none)
			return Mathf.Min(TestValeur(valeur1,ressources),TestValeur(valeur2,ressources),TestValeur(valeur3,ressources));
		else
			return Mathf.Min(TestValeur(valeur1,ressources),TestValeur(valeur2,ressources),TestValeur(valeur3,ressources),TestValeur(valeur4,ressources));
	}

	float TestValeur(Ressource ressourceType, RessourcesManager ressourcesRef)
	{
		float result=0f;
		switch(ressourceType)
		{
			//SOMMEIL
			case Ressource.enforme:
				result=ressourcesRef.GetSommeil().GetEnForme();
				break;
			case Ressource.fatigue:
				result=ressourcesRef.GetSommeil().GetFatigue();
				break;
			case Ressource.epuise :
				result=ressourcesRef.GetSommeil().GetEpuise();
				break;

			//FAIM
			case Ressource.repus :
				result=ressourcesRef.GetFaim().GetRepus();
				break;
			case Ressource.faim :
				result=ressourcesRef.GetFaim().GetFaim();
				break;
			case Ressource.affame :
				result=ressourcesRef.GetFaim().GetAffame();
				break;

			//TRAVAIL
			case Ressource.libre :
				result=ressourcesRef.GetTravail().GetLibre();
				break;
			case Ressource.preoccupe :
				result=ressourcesRef.GetTravail().GetPreoccupe();
				break;
			case Ressource.stresse :
				result=ressourcesRef.GetTravail().GetStresse();
				break;
			
			//ENNUI
			case Ressource.enjoue :
				result=ressourcesRef.GetEnnui().GetEnjoue();
				break;
			case Ressource.pensif :
				result=ressourcesRef.GetEnnui().GetPensif();
				break;
			case Ressource.ennui :
				result=ressourcesRef.GetEnnui().GetEnnui();
				break;
		}
		return result;
	}

	public enum Ressource
	{
		none,
		enforme,fatigue,epuise,
		repus,faim,affame,
		libre,preoccupe,stresse,
		enjoue,pensif,ennui
	}

	public enum Desirabilite
	{
		ND,D,TD
	}
}
