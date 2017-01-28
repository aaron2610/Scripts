using System.Collections;
using UnityEngine;

public class InteractSmallTree : MonoBehaviour
{
	public InteractTree Interact;
	public enum TreeSize
	{
		smallTree,
		bigTree
	}
	public TreeSize treeSize;
	
	public void Start()
	{
		Interact = new InteractTree();
		Interact.thisObj = gameObject;
		
		switch ( treeSize )
		{
			case TreeSize.smallTree:
				{
					Interact.numOfDrops = Random.Range(1, 4);
					break;
				}
			case
				 TreeSize.bigTree:
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