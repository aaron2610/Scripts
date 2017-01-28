using UnityEngine;
using System.Collections;

public class CharBuilder : MonoBehaviour
{
	public enum GodNames
	{
		None,
		TheSixGods,
		Romis,
		Zimonis,
	}

	public enum ReligionName
	{
		Atheist,
		Romis,
		FaithOfTheSix,
		Akius
	}

	public FactionManager.FactionList factionList;

	public enum ProfessionType
	{
		Jobless,
		Soldier,
		FactionLeader,
		SecondCommand,
		Farmer,
		Priest,
		Builder
	}

	public enum SexualityType
	{
		Straight,
		Gay,
		Bisexual,
		None
	}

	public enum Piety
	{
		none,
		little,
		some,
		much,
		cult
	}

	public Piety piety;
	public GodNames godNames;
	public ProfessionType professionType;
	public ReligionName religionName;
	public SexualityType sexualityType;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	//void Update () {
	//
	//}

	public void BuildNow()
	{
		//	Debug.Log("Starting debug");
		CharBio NpcBio = gameObject.GetComponent<CharBio>();

		Debug.Log(NpcBio.charStr);
		NpcBio.charStr = Random.Range(80f, 110f);
		NpcBio.charSpd = Random.Range(0.9f, 1.05f);
		NpcBio.charCharisma = Random.Range(90f, 105f);
		NpcBio.charLuck = Random.Range(.8f, 1.1f);
		NpcBio.maxHealth = Random.Range(90f, 105f);
		NpcBio.maxThirst = Random.Range(90f, 105f);
		NpcBio.maxHunger = Random.Range(90f, 105f);
		NpcBio.maxEnergy = Random.Range(90f, 105f);
		Debug.Log(NpcBio.charStr);

		switch ( NpcBio.professionType )
		{
			case ProfessionType.Soldier:
				NpcBio.charStr += Random.Range(1f, 10f);
				NpcBio.charCharisma -= 2f;
				NpcBio.aggressionLevel += 6f;
				Debug.Log(NpcBio.displayName + " is a soldier");
				break;

			case ProfessionType.FactionLeader:
				NpcBio.charCharisma += Random.Range(3f, 12f);
				NpcBio.charSpd *= 0.95f;
				NpcBio.charStr += Random.Range(1f, 6f);
				Debug.Log(NpcBio.displayName + " is a faction leader");

				break;

			case ProfessionType.Farmer:
				NpcBio.charSpd *= 0.95f;
				NpcBio.charStr += Random.Range(1f, 6f);
				break;

			default:
				Debug.Log("No profession");
				break;
		}

		if ( NpcBio.isMale == true )
		{
			NpcBio.charStr += Random.Range(4f, 7f);
			NpcBio.charDex -= Random.Range(1f, 4f);
		}
		else
		{
			NpcBio.charCharisma += Random.Range(1f, 6f);
			NpcBio.charSpd *= 1.05f;
			NpcBio.charStr -= Random.Range(1f, 7f);
			NpcBio.charDex += 2f;
		}

		gameObject.GetComponent<CharBio>().Invoke("DoneGen", 1);
	}
}