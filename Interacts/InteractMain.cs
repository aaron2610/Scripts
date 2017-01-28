using System;
using UnityEngine;

public class InteractMain
{
	public bool active;
	public float currentAmount;
	public float drinkAmount;
	public float maxAmount;
	public float strAdd = 0;
	public float numOfDrops = 0;
	public float thirstReduce = 0.01f;
	public float hungerReduce = 0.02f;
	public Vector3 spawnLoc;
	public GameObject thisObj;
	public GameObject obj1;
	public GameObject obj2;
	public GameObject objectDrop;
	public float energyReduce = 0;
	public int numOfOptions;
	public string interactName;

	public GameObject interacter = null;

	public enum LiquidContainerType
	{
		pond,
		lake,
		well,
		tank,
		jug
	}

	public LiquidContainerType liquidcontainertype;

	public void statUpdate(float str, float energy, float hunger, float thirst)
	{
		if ( interacter.GetComponent<CharBio>() )
		{
			interacter.GetComponent<CharBio>().charStr += str;
			interacter.GetComponent<CharBio>().currentEnergy += energy;
			interacter.GetComponent<CharBio>().currentHunger += hunger;
			interacter.GetComponent<CharBio>().currentThirst += thirst;
		}
	}

	public virtual void Setup()
	{
		throw new NotImplementedException();
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		IconSetup();
		interacter = other.gameObject.transform.root.gameObject;
		if ( PlayerCheck.Check(interacter) )
		{
			if ( numOfOptions == 1 )
				SetUpOneOption();
			if ( numOfOptions == 2 )
				SetupTwoOption();
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		interacter = other.gameObject.transform.root.gameObject;
		if ( PlayerCheck.Check(interacter) )
			UIManager.HideElements();
	}

	public virtual void SetUpOneOption()
	{
		UIManager.IntPanelA.gameObject.SetActive(true);
		UIManager.optionA.gameObject.SetActive(true);
		UIManager.optionB.gameObject.SetActive(false);
		//UIManager.optionA.onClick.AddListener(OptionA);

		Debug.Log("Interacting with Item");
	}

	public virtual void SetupTwoOption()
	{
		UIManager.IntPanelA.gameObject.SetActive(true);
		UIManager.optionA.gameObject.SetActive(true);
		UIManager.optionB.gameObject.SetActive(true);
		//UIManager.optionA.onClick.AddListener(OptionA);
		//UIManager.optionB.onClick.AddListener(OptionB);

		Debug.Log("Interacting with Item");
	}

	public virtual void IconSetup()
	{
		throw new NotImplementedException();
	}

	public virtual void OptionDrop()
	{
		Debug.Log(numOfDrops);
		numOfDrops--;
		GameObject drop = MonoBehaviour.Instantiate(objectDrop, new Vector3(spawnLoc.x, spawnLoc.y + 1, spawnLoc.z), Quaternion.identity);
		if ( drop.GetComponent<Rigidbody>() == null )
		{
			drop.AddComponent<Rigidbody>();
		}
		Debug.Log("Spawning " + objectDrop + " at " + spawnLoc);
		if ( interacter.GetComponentInChildren<WeaponInfo>() && interacter.GetComponentInChildren<WeaponInfo>().weaponType == WeaponInfo.WeaponType.blunt )
		{ statUpdate(strAdd * 2, energyReduce * 0.2f, hungerReduce, thirstReduce); }
		else
		{ statUpdate(strAdd, energyReduce, hungerReduce, thirstReduce); }

		if ( numOfDrops <= 0 )
		{
			UIManager.HideElements();
			MonoBehaviour.Destroy(thisObj);
		}
		Debug.Log(numOfDrops);
		//Mine rock
	}

	public virtual void OptionLightFire()
	{
		active = !active;
		if ( active == true && currentAmount >= 1 )
		{
			obj1.SetActive(active);
			obj2.SetActive(active);
		}
		else
		{
			obj1.SetActive(false);
			obj2.SetActive(false);
		}
	}

	public virtual void OptionDrink()
	{
		Debug.Log(currentAmount);
		if ( currentAmount >= drinkAmount )
		{
			drinkAmount = 0.3f;
			interacter.GetComponent<CharBio>().currentThirst += drinkAmount;
			currentAmount -= drinkAmount;
			statUIUpdater.thirstUI_s.text = "You drink some water";
			Debug.Log(currentAmount);
		}
		else
		{
			statUIUpdater.thirstUI_s.text = "No water";
		}
		Debug.Log("You drink water");
	}

	public virtual void OptionA()
	{
		throw new NotImplementedException();
	}

	public virtual void OptionB()
	{
		throw new NotImplementedException();
	}
}

public class InteractMine : InteractMain
{
	public override void IconSetup()
	{
		numOfOptions = 1;
		strAdd = 0.015f;
		energyReduce = 0.05f;
		objectDrop = ObjectDropManager.stoneObj;
		UIManager.optionA.image.sprite = UISpriteManager.mineStone;
		UIManager.optionA.onClick.AddListener(OptionDrop);
	}
}

public class InteractWater : InteractMain
{
	public void UIUpdate()
	{
		UIManager.infoBox.text = (" Capacity: " + currentAmount + " of " + maxAmount);
	}

	public override void Setup()
	{
		currentAmount = maxAmount / 2f;
	}

	public static float WaterAmount(LiquidContainerType liquidcontainertype)
	{
		float waterMax;
		switch ( liquidcontainertype )
		{
			case (LiquidContainerType.jug):
				waterMax = 2f;
				return waterMax;

			case (LiquidContainerType.lake):
				waterMax = 200000f;
				return waterMax;

			case (LiquidContainerType.pond):
				waterMax = 100000f;
				return waterMax;

			case (LiquidContainerType.tank):
				waterMax = 10000f;
				return waterMax;

			case (LiquidContainerType.well):
				waterMax = 80000f;
				return waterMax;

			default:
				waterMax = 4f;
				return waterMax;
		}
	}

	public override void IconSetup()
	{
		numOfOptions = 2;
		UIManager.optionA.image.sprite = UISpriteManager.waterDrink;
		UIManager.optionB.image.sprite = UISpriteManager.waterCan;
		UIManager.optionA.onClick.AddListener(OptionDrink);
		UIManager.optionB.onClick.AddListener(OptionB);
	}

	public override void OptionB()
	{
		//TODO Make a water cannister!!
		Debug.Log("You store water");
		//Mine rock
	}
}

public class InteractTree : InteractMain
{
	public override void IconSetup()
	{
		numOfOptions = 1;
		objectDrop = ObjectDropManager.stickObj;
		strAdd = 0.01f;
		UIManager.optionA.image.sprite = UISpriteManager.treeBranch;
		UIManager.optionA.onClick.AddListener(OptionDrop);
	}
}

public class InteractOpen : InteractMain
{
	public override void IconSetup()
	{
		numOfOptions = 1;
		objectDrop = ObjectDropManager.stickObj;  //TODO make random
		strAdd = 0.01f;
		UIManager.optionA.image.sprite = UISpriteManager.crate;
		UIManager.optionA.onClick.AddListener(OptionDrop);
	}
}

public class InteractFire : InteractMain
{
	public override void IconSetup()
	{
		numOfOptions = 2;
		UIManager.optionA.image.sprite = UISpriteManager.fireLight;
		UIManager.optionA.onClick.AddListener(OptionLightFire);
		UIManager.optionB.image.sprite = UISpriteManager.treeBranch;
		UIManager.optionB.onClick.AddListener(OptionDrop);
	}
}