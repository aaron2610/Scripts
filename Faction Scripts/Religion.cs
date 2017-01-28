using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum religionEnum
{
	atheist,
	romisEmpire,
	theFive,
	nessen,
	romisCult
}

public enum pietyLevel
{
	none,
	little,
	some,
	devout,
	cult
}

public static class Religion
{
	public static string Name(this religionEnum religionPicked)
	{
		switch ( religionPicked )
		{
			case religionEnum.atheist:
				return "Atheism";

			case religionEnum.romisEmpire:
				return "Faith of Romis";

			case religionEnum.romisCult:
				return "True Faith of Romis";

			case religionEnum.nessen:
				return "Nessen";

			case religionEnum.theFive:
				return "The Holy Five";

			default:
				return "Error on Religion Name";
		}
	}

	public static string MemberName(this religionEnum religionPicked)
	{
		switch ( religionPicked )
		{
			case religionEnum.atheist:
				return "Atheist";

			case religionEnum.romisEmpire:
				return "Romeist";

			case religionEnum.romisCult:
				return "Romeist";

			case religionEnum.nessen:
				return "Nessenic";

			case religionEnum.theFive:
				return "Quantist";

			default:
				return "Error on Religion Name";
		}
	}

	public static string GodName(this religionEnum religionPicked)
	{
		switch ( religionPicked )
		{
			case religionEnum.atheist:
				return "no god";

			case religionEnum.romisEmpire:
				return "Romis";

			case religionEnum.romisCult:
				return "Romis";

			case religionEnum.nessen:
				return "Nessen";

			case religionEnum.theFive:
				return "The Holy Five";

			default:
				return "Error on Religion Name";
		}
	}

	public static string LeaderTitle(this religionEnum religionPicked)
	{
		switch ( religionPicked )
		{
			case religionEnum.atheist:
				return "";

			case religionEnum.romisEmpire:
				return "The Unburnt";

			case religionEnum.romisCult:
				return "The Burning Prophet";

			case religionEnum.nessen:
				return "Shield of Men";

			case religionEnum.theFive:
				return "The Sixth";

			default:
				return "Error on Religion Name";
		}
	}

	public static string HomeCity(this religionEnum religionPicked)
	{
		switch ( religionPicked )
		{
			case religionEnum.atheist:
				return "";

			case religionEnum.romisEmpire:
				return FactionManager.facts[FactionManager.FactionList.romisEmpire].homeCity;

			case religionEnum.romisCult:
				return FactionManager.facts[FactionManager.FactionList.cultOfRomis].homeCity;

			case religionEnum.nessen:
				return FactionManager.facts[FactionManager.FactionList.nessenkin].homeCity;

			case religionEnum.theFive:
				return FactionManager.facts[FactionManager.FactionList.holySix].homeCity;

			default:
				return "Error on Religion Name";
		}
	}

	public static bool AllowsWomen(this religionEnum religionPicked)
	{
		switch ( religionPicked )
		{
			case religionEnum.atheist:
				return true;

			case religionEnum.romisEmpire:
				return true;

			case religionEnum.romisCult:
				return true;

			case religionEnum.nessen:
				return true;

			case religionEnum.theFive:
				return true;

			default:
				return true;
		}
	}
}