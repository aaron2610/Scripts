using UnityEngine;
using System.Collections;

public class RelationManager : MonoBehaviour
{
	public CharBio charBio;

	public void Start()
	{
		charBio = gameObject.GetComponent<CharBio>();
	}

	public float DefaultToOther()
	{
		float baseLevel;
		baseLevel = (charBio.charCharisma * 0.25f) + charBio.likeable + charBio.moralPublic;
		return baseLevel;
	}
}

//}

//	//Starting Family & Friends
//	public static float theWife = 80f;
//	public static float theSon = 90f;

//	//Religion
//	public static float romisReligion = 70f;
//	public static float atheistReligion = 90f;

//	//Factions
//	public static float ravenClawFaction = 30f;
//	public static float pigCity = 40f;

//	//Pig City
//	public static float bawsHaws;

//	//OTHERS
//	public static float bandits = 20f;
//	public static float slaves = 70f;

//	public float RanNum(float min, float max)
//	{
//		float result = Random.Range(min, max);
//		return result;
//	}

//	public void Start()
//	{
//		theWife = RanNum(70f, 80f);
//		theSon = RanNum(80, 110f);
//		bawsHaws = RanNum(10f, 80f);

//	}
//}