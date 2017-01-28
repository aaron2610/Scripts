using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactionManager : ScriptableObject
{
	public static Dictionary<FactionList, Factions> facts = new Dictionary<FactionList, Factions>
	{
		{ FactionList.childrenOfRomis, new Factions {
										factionName = "Children of Romis",
										factionType = FactionType.religious,
										motto = "The Light in the Darkness",
										leaderTitle = "The Lord's Light",
										homeCity = "Romton",
										religion = religionEnum.romisEmpire,
										townInfo = new List<Towns.TownInfo> { Towns.town[Towns.TownList.grimsby]  },
										population = 0 } },
		{ FactionList.cultOfRomis, new Factions {
										factionName = "Fires of Romis",
										factionType = FactionType.cult,
										motto = "What Is Burnt Is Freed",
										leaderTitle = "The Lit",
										homeCity = "Flamefall",
										religion = religionEnum.romisCult,
										population = 0 } },
		{ FactionList.DawnOfTruth, new Factions { factionName = "Dawn of Truth",
										factionType = FactionType.cult,
										motto = "With Dawn Comes Light",
										leaderTitle = "The Truth",
										homeCity = "Glimmica",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.doomBringers, new Factions { factionName = "DOOM BRINGERS",
										factionType = FactionType.military,
										motto = "HERE IS DOOM",
										leaderTitle = "DR DOOM PHD",
										homeCity = "DOOMPLACE",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.eleflint, new Factions { factionName = "Eleflint Domain",
										factionType = FactionType.neutral,
										motto = "United in Strife, together in peace.",
										leaderTitle = "Lord",
										homeCity = "East Hill",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.guardiansOfTheSand, new Factions { factionName = "Guardians Of the Sand",
										factionType = FactionType.military,
										motto = "Here to Stay",
										leaderTitle = "Lord Commander",
										homeCity = "Barrenhold",
										religion = religionEnum.nessen,
										population = 0 } },
		{ FactionList.holySix, new Factions { factionName = "The Holy Six",
										factionType = FactionType.religious,
										motto = "The Six",
										leaderTitle = "The Sixth",
										homeCity = "Sector",
										religion = religionEnum.theFive,
										population = 0 } },
		{ FactionList.ironwell, new Factions {
										factionName = "House Ironwell",
										factionType = FactionType.traders,
										motto = "Deeds, not words.",
										leaderTitle = "Lord",
										homeCity = "Sharlavoy",
										religion = religionEnum.nessen,
										population = 0 } },
		{ FactionList.nessenkin, new Factions { factionName = "Nessenkin",
										factionType = FactionType.neutral,
										motto = "Nessen protect us",
										leaderTitle = "High Captain",
										homeCity = "Nesston",
										religion = religionEnum.nessen,
										population = 0 } },
		{ FactionList.none, new Factions {
										factionName = "No Faction",
										factionType = FactionType.neutral,
										motto =  string.Empty,
										leaderTitle = " ",
										homeCity = string.Empty,
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.othello, new Factions {
										factionName = "House Othello",
										factionType = FactionType.military,
										motto = "Rise Above",
										leaderTitle = "Great Father",
										homeCity = "Grande Thelopolis",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.ravenClaw, new Factions {
										factionName = "United Raven Claw",
										factionType = FactionType.military,
										motto = "Water, Pride, Honor.",
										leaderTitle = "The Raven",
										homeCity = "Ravenhold",
										religion = religionEnum.nessen,
										population = 0 } },
		{ FactionList.risingRepublic, new Factions {
										factionName = "Rising Republic of Democracy",
										factionType = FactionType.slavers,
										motto = "Freedom By Blood",
										leaderTitle = "Caesar",
										homeCity = "Suthasor",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.romisEmpire, new Factions {
										factionName = "The Holy Romis Empire",
										factionType = FactionType.religious,
										motto = "Led by Light",
										leaderTitle = "The Enlightened",
										homeCity = "New Romis",
										religion = religionEnum.romisEmpire,
										population = 0 } },
		{ FactionList.sectOfTheTrueProphet, new Factions {
										factionName = "Sect of the True Prophet",
										factionType = FactionType.cult,
										motto = "Follow us to Heaven",
										leaderTitle = "The Prophet",
										homeCity = "Shesuzma",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.theBrotherhood, new Factions {
										factionName = "United Brotherhood",
										factionType = FactionType.slavers,
										motto = "Family Blood",
										leaderTitle = "Father",
										homeCity = "Home",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.theMountainGuardians, new Factions {
										factionName = "Mountain Guardians",
										factionType = FactionType.military,
										motto = "The Eyes in the Hills",
										leaderTitle = "Captain",
										homeCity = "Paw Paw",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.thePit, new Factions {
										factionName = "Pit Inc.",
										factionType = FactionType.traders,
										motto = "Trade Center of the South",
										leaderTitle = "Boss",
										homeCity = "Pitforge",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.theTempleOrder, new Factions {
										factionName = "The Temple Order",
										factionType = FactionType.religious,
										motto = "Making Order from Chaos",
										leaderTitle = "Lord",
										homeCity = "The Temple",
										religion = religionEnum.atheist,
										population = 0 } },
		{ FactionList.unitedKin, new Factions {
										factionName = "United Kin of Nessen",
										factionType = FactionType.religious,
										motto = "All for the Mother",
										leaderTitle = "Great Sister",
										homeCity = "Nesserta",
										religion = religionEnum.nessen,
										population = 0 } },
		{ FactionList.valorShield, new Factions { factionName = "Valor Shields",
										factionType = FactionType.military,
										motto = "Ever Vigilant",
										leaderTitle = "High Captain",
										homeCity = "Valgor",
										religion = religionEnum.atheist,
										population = 0 } }
	};

	public static FactionManager.Factions RomisEmpire = FactionManager.facts[FactionList.romisEmpire];

	public enum FactionList
	{
		none,
		romisEmpire,
		ravenClaw,
		eleflint,
		thePit,
		childrenOfRomis,
		cultOfRomis,
		doomBringers,
		valorShield,
		sectOfTheTrueProphet,
		guardiansOfTheSand,
		risingRepublic,
		ironwell,
		unitedKin,
		theTempleOrder,
		othello,
		theMountainGuardians,
		DawnOfTruth,
		theBrotherhood,
		nessenkin,
		holySix
	}

	public enum FactionType
	{
		military,
		cult,
		religious,
		bandit,
		traders,
		neutral,
		wanderers,
		slavers
	}

	public class Factions
	{
		public string factionName { get; set; }
		public FactionType factionType { get; set; }
		public string homeCity { get; set; }
		public string leaderTitle { get; set; }
		public string motto { get; set; }
		public int population { get; set; }
		public religionEnum religion { get; set; }
		public List<Towns.TownInfo> townInfo { get; set; }
		//public Dictionary<Towns.TownList, Towns.TownInfo> town { get; set; } // = new Dictionary<TownList, TownInfo>();
	}
}