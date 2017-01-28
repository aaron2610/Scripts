using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
	public int health = 2;
	public int maxHealth;
	public float waitTime = 6f;
	public GameObject bushSpawn;
	public GameObject leaf;

	public void Start()
	{
		maxHealth = Random.Range(1, 5);
		waitTime += Random.Range(20f, 60f);
		StartCoroutine(GrowthChance());
	}

	public IEnumerator GrowthChance()
	{
		if ( health <= 0 )
			Destroy(gameObject);
		if ( health == 1 )
		{
			int i = Random.Range(1, 100);
			if ( i <= 10 )
				Destroy(gameObject);
		}
		if ( health < maxHealth )
			health += 1;

		if ( Random.Range(1, 100) > 95 )
		{
			float i = Random.Range(1f, 4f);
			float j = Random.Range(-4f, -1f);
			bushSpawn = Instantiate(bushSpawn, new Vector3(transform.position.x + i, transform.position.y + 6, transform.position.z + j), Quaternion.identity);
			bushSpawn.AddComponent<hitground>();
			Debug.Log("new bush spawned");
			waitTime *= 1.7f;
			//if ( gameObject.transform.position.y < 51f )
			//{
			//	Destroy(gameObject);
			//}
		}

		Mathf.Clamp(health, 1, maxHealth);

		yield return new WaitForSeconds(waitTime);
	}
}