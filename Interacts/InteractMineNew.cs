using System.Collections;
using UnityEngine;

public class InteractMineNew : MonoBehaviour
{
	private int numofDrops;
	public enum RockSize
	{
		smallRock,
		bigRock
	}
	public RockSize rockSize;
	public InteractMine Interact;
	public void Start()
	{
		GameObject obj = gameObject;
		Interact = new InteractMine();
		Interact.thisObj = obj;
		switch (rockSize)
		{
			case RockSize.smallRock:
				{
					Interact.numOfDrops = Random.Range(1, 4);
					break;
				}
			case
				 RockSize.bigRock:
				{
					Interact.numOfDrops = Random.Range(3, 6);
					break;
				}
			default:
				Interact.numOfDrops = Random.Range(1, 4);
				break;
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		Interact.OnTriggerEnter(other);
		Interact.thisObj = gameObject;
		Interact.spawnLoc = gameObject.transform.position;

	}

	private void OnTriggerExit(Collider other)
	{
		Interact.OnTriggerExit(other);
			
	}
}