using UnityEngine;
using System.Collections.Generic;

public class InteractCampfire : MonoBehaviour
{
	public InteractFire Interact;

	public void Start()
	{
		GameObject obj1 = transform.GetChild(0).gameObject;
		GameObject obj2 = transform.GetChild(1).gameObject;
		Interact = new InteractFire();
	}

	private void OnTriggerEnter(Collider other)
	{
		GameObject obj1 = transform.GetChild(0).gameObject;
		GameObject obj2 = transform.GetChild(1).gameObject;
		Interact.OnTriggerEnter(other);
	}

	private void OnTriggerExit(Collider other)
	{
		Interact.OnTriggerExit(other);
	}
}