using System.Collections;
using UnityEngine;

public class InteractOpenBox : MonoBehaviour
{
	public InteractOpen Interact;
	public enum Boxsize
	{
		smallBox,
		bigBox
	}
	public Boxsize treeSize;

	public void Start()
	{
		Interact = new InteractOpen();
		Interact.thisObj = gameObject;
		switch ( treeSize )
		{
			case Boxsize.smallBox:
				{
					Interact.numOfDrops = Random.Range(0, 3);
					break;
				}
			case
				 Boxsize.bigBox:
				{
					Interact.numOfDrops = Random.Range(0, 6);
					break;
				}
			default:
				Interact.numOfDrops = Random.Range(0, 3);
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