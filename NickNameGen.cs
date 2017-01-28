using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using GameDataEditor;

public class NickNameGen : MonoBehaviour
{
	private int chance;

	public List<string> leaderGenericNames = new List<string>
	{
		"the Boss",
		"the King",
		"the Followed"
	};

	public List<string> religionGenericNickName = new List<string>
	{
		"the Holy",
		"the Lords Ear"
	};

	public List<string> dexNickNames = new List<string>
	{
		"the Agile",
		"Sharp-Eyed"
	};

	public List<string> maxHealthGenericNickName = new List<string>
	{
		"Ironside",
		"the Hearty",
		"the Bold"
	};

	public List<string> strongNickNames = new List<string>
	{
		"the Ironfist",
		"Stone",
		"the Bold"
	};

	public List<string> MoralStrongNickNames = new List<string>
	{
		"the IronShield",
		"the Protector",
		"the Bold"
	};

	public List<string> NotMoralStrongNickNames = new List<string>
	{
		"the Dreaded",
		"Dark Blade",
		"Bloodgrimace",
		"the Bold"
	};

	public CharBio NpcBio;

	private void Start()
	{
		NpcBio = gameObject.GetComponent<CharBio>();
	}

	public string NameGen()
	{
		NpcBio = gameObject.GetComponent<CharBio>();
		if ( NpcBio.professionType == CharBuilder.ProfessionType.FactionLeader ) NpcBio.displayName = FactionManager.facts[NpcBio.factionList].leaderTitle;
		if ( Chance(NpcBio.charStr) && IsGoodMoral() ) return RandomFromList(MoralStrongNickNames);
		if ( Chance(NpcBio.charStr) ) return RandomFromList(strongNickNames);
		if ( Chance(NpcBio.charDex) ) return RandomFromList(dexNickNames);
		if ( Chance(NpcBio.piety) ) return RandomFromList(religionGenericNickName);
		if ( Chance(NpcBio.maxHealth) ) return RandomFromList(maxHealthGenericNickName);
		return NpcBio.displayName;
	}

	public string RandomFromList(List<string> nameList)
	{
		int randomNamePicker = Random.Range(0, nameList.Count - 1);
		return NpcBio.firstName + " " + nameList[randomNamePicker];
	}

	private bool Chance(float stat)
	{
		chance = Random.Range(1, 10);
		return chance <= 4 && stat >= 110f;
	}

	private bool IsGoodMoral()
	{
		chance = Random.Range(1, 10);
		return NpcBio.moralPublic >= 80f && chance <= 6;
	}

	private bool IsBadMoral()
	{
		chance = Random.Range(1, 10);
		return NpcBio.moralPublic <= 50f && chance <= 6;
	}
}