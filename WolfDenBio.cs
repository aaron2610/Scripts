using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WolfDenBio : MonoBehaviour
{
	public GameObject wolfObj;
	public int wolfDenID;
	public int wolfPop;
	public int popDelay = 1;
	Vector3 pos = new Vector3();
	
	private void Start()
	{
		wolfDenID = Random.Range(1, 9000);
		InvokeRepeating("WolfPopCounter", 1, 15);
		pos.y += 1f;
	}

	private void WolfPopCounter()
	{
		wolfPop = gameObject.transform.childCount;
		switch ( wolfPop )
		{
			case 0:

				Destroy(gameObject);
				break;
			case 1:
				var loneWolf = gameObject.GetComponentInChildren<WolfBio>();
				Debug.Log("Lone Wolf");
				loneWolf.SendMessage("LoneWolf");
				break;
			default:
				popDelay++;
				if ( popDelay <= 20 )
				{
					GameObject drop = Instantiate(wolfObj, this.transform, true);
					//pos.x += Random.Range(-6f, 6f);
					//pos.z += Random.Range(-6f, 6f);
					//drop.transform.position = pos;
					popDelay = 1;
				}
				break;
		}	
	}
}

