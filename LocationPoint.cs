using UnityEngine;

public class LocationPoint : MonoBehaviour
{
	public string thisLocName;
	private string caption;
	public bool owned;
	public float distanceOfLocation;
	public LocationInfo.LocRegions locRegion = LocationInfo.LocRegions.c;
	public FactionManager.FactionList locOwner;

	public enum LocationType
	{
		locationCaption,
		factionHomeCity,
		factionPOI,
		factionTerritory
	}

	public LocationType locationType;

	// Use this for initialization
	private void Start()
	{
		switch ( locationType )
		{
			case LocationType.factionHomeCity:
				caption = FactionManager.facts[locOwner].homeCity + " of " + FactionManager.facts[locOwner].factionName;
				break;

			case LocationType.factionPOI:
				{
					caption = thisLocName + " of " + FactionManager.facts[locOwner].factionName;
					break;
				}

			case LocationType.locationCaption:
				{
					caption = thisLocName;
					break;
				}
			case LocationType.factionTerritory:
				{
					caption = FactionManager.facts[locOwner].factionName + " territory";
					break;
				}
			default:
				break;
		}
		int i = LocationInfo.locs.Count + 1;
		LocationInfo.locs.Add(i, new LocationInfo.Location { locName = caption, distance = distanceOfLocation, locOwned = owned, locRegion = locRegion, locOwner = locOwner, locVector = gameObject.transform.position });
	}
}