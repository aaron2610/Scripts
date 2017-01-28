using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WolfBio : MonoBehaviour
{

	public float maxHealth;
	public float currentHealth;
	public float charStr;
	public float charSpd;
	public float maxHunger = 120f;
	public float maxThirst = 4f;
	public float currentHunger;
	public float currentThirst;
	public int wolfDenID;
	public NavMeshAgent agentMesh;

	public enum WolfState
	{
		HuntingRabbit,
		goHome,
		HuntingHuman,
		FindWater,
		Relax
	}

	public WolfState wolfstate;


	// public Transform home;

	void Start()
	{
		//	home = this.transform.parent;
		//QQQ TODO Set home as wolf den, might do in FSM
		wolfDenID = GetComponentInParent<WolfDenBio>().wolfDenID;
		agentMesh = GetComponent<NavMeshAgent>();
		maxHealth = Random.Range(50f, 65f);
		charSpd = 5f;
		charStr = Random.Range(90f, 125f);
		currentHealth = maxHealth;
		currentHunger = maxHunger;
		currentThirst = maxThirst;

		gameObject.AddComponent<MultiTags>();
		gameObject.AddTag(wolfDenID.ToString());
		InvokeRepeating("StatCheck", 1, 3);
		InvokeRepeating("StatUpdate", 1, 10);
	}

	void Update()
	{
		switch ( wolfstate )
		{
			case WolfState.goHome:
				GoHome();
				break;
			case WolfState.HuntingHuman:
				HuntHuman();
				break;
			case WolfState.HuntingRabbit:
				break;

			default:
				break;
		}
	}

	void StatUpdate()
	{
		currentHealth += 1f;
		currentHunger -= 0.2f;
		currentThirst -= 0.08f;
	}

	void StatCheck()
	{
		if ( currentHealth < 1f )
			Destroy(gameObject);
		if ( currentHunger < 3f )
			currentHealth -= 0.2f;
		if ( currentThirst < 1f )
			currentHealth -= 0.3f;

		//Clamps the variables to min and max
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);
		currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
	}

	void GoHome()
	{

	}

	void HuntHuman()
	{

	}

	void LoneWolf()
	{
		maxHealth += 10f;
		maxHunger += 10f;
		charStr += 10f;
		charSpd *= 1.05f;
	

	}


}