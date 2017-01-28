using System.Collections.Generic;
using UnityEngine;

public class LocationInfo : ScriptableObject
{
	public static Dictionary<int, Location> locs = new Dictionary<int, Location>()
	{
		{0,  new Location {locName = "Forlorn Waste",
			locOwned = false,
			locOwner = FactionManager.FactionList.none,
			locVector = new Vector3(-365f, 92f, 731.1f),
			distance = 100f } },
	};

	public class Location
	{
		public float distance { get; set; }
		public string locName { get; set; }
		public bool locOwned { get; set; }
		public FactionManager.FactionList locOwner { get; set; }
		public Vector3 locVector { get; set; }
		public LocRegions locRegion { get; set; }
	}

	public enum LocRegions
	{
		nw,
		n,
		ne,
		w,
		c,
		e,
		sw,
		s,
		se
	}
}