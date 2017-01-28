using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Towns : ScriptableObject
{
	public static Dictionary<TownList, TownInfo> town = new Dictionary<TownList, TownInfo>
	{
		{ TownList.grimsby, new TownInfo
			{
				townName ="Grimsby",
				factionList = FactionManager.FactionList.theMountainGuardians,
				townPOI = new List<TownPOI> { TownPOI.miningPost},
				mayorTitle = "Captain",
				cityDescription = "Grimbsy is small mining outpost",
				taxRate = 0.05f,
				waterStorageAmount = 0f,
				foodStorageAmount = 0f,
				ironStorageAmount = 0f,
				allowOutsiders = true,
				population = 0,
				religion = religionEnum.atheist
			 }
		}
	};

	public enum TownList
	{
		tecson,
		nisgend,
		neburgh,
		ochoimery,
		olusrith,
		sia,
		qona,
		jagos,
		lokheah,
		leigh,
		leighton,
		grimsby,
		marclesfield,
		travercraig,
		llanybydder,
		hurtlepool,
		naporia,
		hornsey,
		hollyhead,
		pantmawr,
		southwold
	}

	public enum TownPOI
	{
		genericTown,
		capitol,
		militaryOutpost,
		tradingHub,
		miningPost,
		ruin
	}

	public class FactionTown
	{
		public TownInfo townInfos { get; set; }
	}

	public class TownInfo
	{
		public string townName { get; set; }
		public FactionManager.FactionList factionList { get; set; }
		public List<TownPOI> townPOI { get; set; }
		public string mayorTitle { get; set; }
		public string cityDescription { get; set; }
		public float taxRate { get; set; }
		public float waterStorageAmount { get; set; }
		public float foodStorageAmount { get; set; }
		public float ironStorageAmount { get; set; }
		public bool allowOutsiders { get; set; }
		public int population { get; set; }
		public religionEnum religion { get; set; }
		public float defectionChance { get; set; }
		public FactionManager.FactionList defectFactionOfChoice { get; set; }
	}
}