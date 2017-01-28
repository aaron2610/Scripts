using UnityEngine;
using System.Collections;

public class hitground : MonoBehaviour {
	private int counti = 0;
	void Start () {


	}
	
	// Update is called once per frame
	void Update()
	{
		if ( counti < 5 )
		{

		Vector3 curPos = transform.position;
		//	GameObject place_obj;
			Vector3 newPos;
			RaycastHit hit;

			//place_obj = this.GetComponentInParent< GameObject>(); // = GetComponentInParent<ScriptableObject>;

			Ray landingRay = new Ray(transform.position, Vector3.down);
			if(Physics.Raycast(landingRay, out hit))
			{
				newPos = curPos;
				newPos.y -= hit.distance;
				//float yDistance = hit.distance;
				transform.position = newPos;
				Destroy(this);
			}
			if ( gameObject.transform.position.y <= 3f )
			{
				Destroy(gameObject);
			}
			counti++;
		} else
		{
			if ( gameObject.transform.position.y <= 3f )
			{
				Destroy(gameObject);
			}
		}

	}
}