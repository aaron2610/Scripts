using UnityEngine;

//using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LookAtNPC : MonoBehaviour
{
	public TextMesh NpcText;

	public void Start()
	{
		NpcText.gameObject.SetActive(false);
	}

	private void OnMouseEnter()
	{
		Debug.Log("Mouse over");
		NpcText.gameObject.SetActive(true);
	}

	private void OnMouseOver()
	{
		Debug.Log("Mouse over");
		NpcText.gameObject.SetActive(true);
	}

	private void OnMouseExit()
	{
		NpcText.gameObject.SetActive(false);
	}
}