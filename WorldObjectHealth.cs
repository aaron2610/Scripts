using System.Collections;
using UnityEngine;

public class WorldObjectHealth : MonoBehaviour
{
	public float maxHealth;
	public float currentHealth;
	public bool hasDropOnDestroy;
	public bool hasDropOnHit;
	public float chanceToDropOnHit = 100f;
	public GameObject droppedItemOnDestroy;
	public GameObject droppedItemOnHit;

	private float randomNum;

	public void Start()
	{
		currentHealth = maxHealth;
	}

	public void Hit(float hitFor)
	{
		currentHealth -= hitFor;
		if ( currentHealth <= 0f )
		{
			if ( hasDropOnDestroy == true )
				Instantiate(droppedItemOnDestroy, gameObject.transform.position, gameObject.transform.rotation);
			Destroy(gameObject);
		}
		else
			if ( hasDropOnHit == true && RandomDropChance() == true )
		{
			Instantiate(droppedItemOnHit, gameObject.transform.position, gameObject.transform.rotation);
		}
	}

	public bool RandomDropChance()
	{
		randomNum = Random.Range(0f, 100f);
		return randomNum <= chanceToDropOnHit ? true : false;
	}
}