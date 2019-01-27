using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationsManager : MonoBehaviour {

	public List<StationReglages> stations;

	void Start () 
	{
		GetComponent<RessourcesManager>().RandomizeVal();
	}
	
	void Update () 
	{
		/* if(Input.GetKeyDown("e"))
		{
			GetMostDesirableStation();
		}else if(Input.GetKeyDown("r"))
		{
			GetComponent<RessourcesManager>().RandomizeVal();
		}*/
	}

	public StationReglages GetMostDesirableStation()
	{
		List<float> desirabilityStations=new List<float>();
		float maxVal=0f;
		StationReglages finalChoice=null;
		foreach(StationReglages stat in stations)
		{
			desirabilityStations.Add(stat.TestDesirabilityStation(GetComponent<RessourcesManager>()));

			if(desirabilityStations[desirabilityStations.Count-1]>maxVal)
			{
				maxVal=desirabilityStations[desirabilityStations.Count-1];
				finalChoice=stat;
			}else if(desirabilityStations[desirabilityStations.Count-1]==maxVal)
			{
				var rand = Random.Range(0f,100f);
				if(rand>50)
				//changer le choix random par un choix lié a la valeur de la variable
				{
					maxVal=desirabilityStations[desirabilityStations.Count-1];
					finalChoice=stat;
				}
			}
		}
		DebugUI.instance.currentChoiceText.text=finalChoice.stationName.ToString()+" - % "+maxVal;
		return finalChoice;
	}
}
