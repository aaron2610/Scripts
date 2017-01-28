using UnityEngine;
using System.Collections.Generic;

public class InteractDrink : MonoBehaviour
{
	public string WellName;
	public InteractWater Interact;
	public InteractWater.LiquidContainerType liquidContainerType = InteractWater.LiquidContainerType.pond;

	public void Start()
	{
		Interact = new InteractWater();
		Interact.maxAmount = InteractWater.WaterAmount(liquidContainerType);
		Interact.Setup();
	}

	public void OnTriggerEnter(Collider other)
	{
		Interact.energyReduce = 0f;
		Interact.drinkAmount = 0.3f;
		Interact.thirstReduce = 0f;
		Interact.hungerReduce = 0f;
		Interact.interacter = other.gameObject;
		Interact.OnTriggerEnter(other);

	}

	public void OnTriggerExit(Collider other)
	{
		Interact.OnTriggerExit(other);
	}

	public void OnMouseOver()
	{
		UIManager.infoBox.text = "Capacity: " + Interact.currentAmount;
	}

	public void OnMouseExit()
	{
		UIManager.ClearInfoBox();
	}

}