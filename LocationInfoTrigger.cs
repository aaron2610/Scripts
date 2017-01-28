using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LocationInfoTrigger : MonoBehaviour
{
	public float dist;
	public string loc = "test";
	private Vector3 currentLoc;
	public int previousLocation = 0;  //Sets a default location TODO change this to the starting location of the game
	public LocationInfo.LocRegions locRegion;
	private LocationInfo.LocRegions currentRegion = LocationInfo.LocRegions.c;

	public void Start()
	{
		InvokeRepeating("LocRunner", 5f, 10f);
	}

	private void LocRunner()
	{
		currentLoc = gameObject.transform.position;
		dist = Vector3.Distance(currentLoc, LocationInfo.locs[previousLocation].locVector);
		if ( dist > LocationInfo.locs[previousLocation].distance )
		{
			foreach ( int i in LocationInfo.locs.Keys )
			{
				if ( LocationInfo.locs[i].locVector.x - currentLoc.x <= 300f )
				{
					dist = Vector3.Distance(currentLoc, LocationInfo.locs[i].locVector);
					Debug.Log("dist = " + dist);
					if ( dist <= LocationInfo.locs[i].distance )
					{
						UILocationUpdate(i);
						break;
					}
				}
				UIManager.locationUI.text = "No man's land";
				previousLocation = 0;
				currentRegion = LocationInfo.LocRegions.c;
			}
		}
	}

	public void UILocationUpdate(int i)
	{
		loc = LocationInfo.locs[i].locName;
		UIManager.locationUI.text = string.Format("Currently near: {0}", loc.ToString());
		previousLocation = i;
		currentRegion = LocationInfo.locs[i].locRegion;
	}
}