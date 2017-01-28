using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharBio : MonoBehaviour
{
	[Tooltip("Check to mark that this is the player")]
	public bool isPlayer;

	private GameObject thisObj;
	public Animator animator;

	[Header("Name Settings")]
	public string firstName;

	public string familyName, fullName, displayName;

	[Tooltip("Character Nickname")]
	public string nickName = "";

	[Header("Faction Settings")]
	public FactionManager.FactionList factionList;

	//Traits
	[Header("Personality Settings")]
	public TraitManager.Traits_e traitOne;

	public TraitManager.Traits_e traitTwo;
	public TraitManager.Traits_e familyTrait;
	public float likeable = 75f;
	public float moralPrivate = 70f;
	public float moralPublic = 80f;
	public float trusting = 50f;

	//Biography
	[Header("Biography Settings")]
	[Tooltip("Select if male")]
	public bool isMale = true;

	public CharBuilder.ProfessionType professionType;
	public CharBuilder.SexualityType sexualityType;
	public string backStory, lifeDesire, currentGoal, likes, dislikes;

	[Tooltip("Percent chance of fleeing")]
	public float aggressionLevel = 1f;

	[Tooltip("Percent chance of obeying")]
	public float obeyLevel = 1f;

	[HideInInspector]
	public float visionDistance = 20f;

	[HideInInspector]
	public float hearingDistance = 30f;

	public religionEnum religion;
	public string religionName;
	public string religionGod;
	public float piety;

	//Stat
	[Header("Stat Settings")]
	public float charStr;

	public float charSpd, charCharisma, charLuck, currentThirst, currentHunger, currentHealth, currentEnergy;

	[Tooltip("Dex used to check hit & dodge chance")]
	public float charDex = 100f;

	//Max Stats
	public float maxHealth = 100f;

	public float maxHunger = 100f;
	public float maxThirst = 3f;  //Gallons of water
	public float maxEnergy = 100f;

	//Weapon
	[Header("Weapon Settings")]
	public float weaponQuality;

	public float weaponMass, weaponLength, bleedDamage, attackDamage, charDamage, chanceCrit, weaponDamage, randomDamage;

	//Armor
	[Header("Armor Settings")]
	public float helmet = 0f;

	public float shoulders = 0f;
	public float torso = 0f;
	public float pants = 0f;
	public float boots = 0f;
	public float gloves = 0f;
	private int bleedLength = 0;

	//Stat Ticker
	[Header("Stat Tick Settings")]
	[Tooltip("How quickly you gain energy back")]
	public float energyTick = 0.01f;

	[Tooltip("How quickly you gain health back")]
	public float healthTick = 0.4f;

	[Tooltip("How quickly you get thirsty")]
	public float thirstTick = 0.1f;

	[Tooltip("How quickly you get hungry")]
	public float hungerTick = 0.05f;

	private void Awake()
	{
		gameObject.AddComponent<MultiTags>();
	}

	private void Start()

	{
		thisObj = gameObject;
		religionName = religion.Name();
		religionGod = religion.GodName();
		CharBuilder charbuilder = gameObject.AddComponent<CharBuilder>();
		charbuilder.BuildNow();

		TraitManager traitManager = gameObject.AddComponent<TraitManager>();
		traitManager.Trait(traitOne, 1.3f);
		traitManager.Trait(traitTwo, 1.1f);
		traitManager.Trait(familyTrait, 1f);
		animator = gameObject.GetComponent<Animator>();
		if ( religion.Name() == "Atheist" )
		{
			piety = 0f;
		}
		else
		{
			piety = Random.Range(1f, 80f);
		}

		if ( isPlayer == true )
			gameObject.AddTag("Player");

		gameObject.AddTag(professionType.ToString());
		gameObject.AddTag(religion.Name());
		gameObject.AddTag(FactionManager.facts[factionList].factionName);

		currentHealth = maxHealth;
		currentThirst = maxThirst;
		currentHunger = maxHunger;
		currentEnergy = maxEnergy;

		fullName = firstName + " " + familyName;
		displayName = fullName;

		if ( isPlayer )
			Debug.Log("Starting Invokes");

		StartCoroutine(StatCheck());
		StartCoroutine(StatUpdate());
	}

	private void Update()
	{
	}

	private IEnumerator StatCheck()
	{
		while ( true )
		{
			if ( currentHealth <= 1f )
			{
				animator.Play("death");
				Destroy(gameObject, 10f); //TODO a real death sequence
			}
			if ( currentThirst <= 5f )
				currentHealth -= 2 * healthTick;
			if ( currentHunger <= 5f )
				currentEnergy -= 2 * energyTick;

			//Clamps the variables to min and max
			currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
			currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);
			currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

			if ( bleedLength >= 1 )
				startBleed(bleedDamage);

			yield return new WaitForSeconds(3f);
		}
	}

	public IEnumerator StatUpdate()
	{
		while ( true )
		{
			currentHealth += healthTick;
			currentEnergy += energyTick;
			currentHunger -= hungerTick;
			currentThirst -= thirstTick;
			yield return new WaitForSeconds(1f);
		}
	}

	//Method is ran after Generator is finished
	public void DoneGen()
	{
		currentHealth = maxHealth;
		currentThirst = maxThirst;
		currentHunger = maxHunger;
		currentEnergy = maxEnergy;
		if ( firstName == "" || firstName == null )
		{
			if ( gameObject.GetComponent<NameGen>() )
			{
				NameGen nameGen = gameObject.GetComponent<NameGen>();
				firstName = nameGen.FirstName();
			}
			else
			{
				NameGen nameGen = gameObject.AddComponent<NameGen>();
				firstName = nameGen.FirstName();
			}
		}

		if ( familyName == "" || familyName == null )
		{
			if ( gameObject.GetComponent<NameGen>() )
			{
				NameGen nameGen = gameObject.GetComponent<NameGen>();
				familyName = nameGen.LastName();
			}
			else
			{
				NameGen nameGen = gameObject.AddComponent<NameGen>();
				familyName = nameGen.LastName();
			}
		}
		if ( nickName.Length > 0 ) displayName = firstName + " " + nickName;
		else
			displayName = firstName + " " + familyName;

		if ( Random.Range(1, 10) >= 3 && nickName.Length < 1 )
		{
			NickNameGen nickNameGen = gameObject.AddComponent<NickNameGen>();
			displayName = nickNameGen.NameGen();
		}

		Debug.Log("Done generating " + displayName);
	}

	public void OnDefend(float damage)
	{
		Debug.Log("Starting OnDefend");
		float gotDamage = damage;
		currentEnergy -= 3f;
		if ( isPlayer )
			statUIUpdater.energyUI_s.text = " You try to defend";
		float newDamage;
		float parryChance = Random.Range(1f, 300f);
		if ( parryChance >= charDex )
		{
			int hitWhere = Random.Range(1, 11);
			switch ( hitWhere )
			{
				case 1:
					newDamage = damage * 1.1f - helmet;
					currentHealth = currentHealth - newDamage;
					if ( helmet < 1f )
						bleedLength = 10;
					break;

				case 2:
					newDamage = damage - shoulders;
					currentHealth = currentHealth - newDamage;
					if ( shoulders < 1 )
						bleedLength = 10;
					break;

				case 3:
					newDamage = damage - torso;
					currentHealth = currentHealth - newDamage;
					if ( torso < 1 )
						bleedLength = 10;
					break;

				case 4:
					newDamage = damage - torso;
					currentHealth = currentHealth - newDamage;
					if ( torso < 1 )
						bleedLength = 10;
					break;

				case 5:
					newDamage = damage - torso;
					currentHealth = currentHealth - newDamage;
					break;

				case 6:
					newDamage = damage - pants;
					currentHealth -= newDamage;
					if ( torso < 1 )
						bleedLength = 10;
					break;

				case 7:
					newDamage = damage - pants;
					currentHealth -= newDamage;
					break;

				case 8:
					newDamage = damage - gloves;
					currentHealth -= newDamage;
					break;

				case 9:
					newDamage = damage - boots;
					currentHealth -= newDamage;
					break;

				case 10:
					newDamage = damage;
					currentHealth -= newDamage;
					if ( torso < 1 )
						bleedLength = 10;
					break;

				default:
					newDamage = damage;
					currentHealth -= newDamage;
					if ( torso < 1 )
						bleedLength = 10;
					break;
			}
		}
		else
		{
			animator.SetTrigger("Parry");
			Debug.Log("Parried");
			currentEnergy -= (weaponMass * 0.5f);
			if ( isPlayer == true )
				statUIUpdater.energyUI_s.text = "You dodge";
		}
	}

	private void startBleed(float bleedDamage)
	{
		currentHealth -= bleedDamage;
		bleedLength--;
	}

	public bool SuccessHit()
	{
		if ( charDex > Random.Range(1f, 300f) )
		{
			Debug.Log("SuccesHit is true");
			return true;
		}
		else
		{
			if ( GotLuck(200f) )
			{
				if ( charDex > Random.Range(1f, 300f) )
				{
					return true;
				}
				else
				{
					Debug.Log("SuccesHit is false");
					return false;
				}
			}
			else
			{
				Debug.Log("SuccesHit is true");
				return false;
			}
		}
	}

	public bool GotLuck(float maxRange)
	{
		if ( charLuck * 30f >= Random.Range(0, maxRange) )
		{
			return true;
		}
		else { return false; }
	}

	public bool Hampered()
	{
		if ( currentEnergy < 30f || currentThirst < 1.8f || currentHunger < 60f )  //Checks for energy level
		{ return true; }
		else { return false; }
	}

	private float NPCDmg()
	{
		float finalDmg;
		finalDmg = charStr * (currentHunger * 0.01f) * (currentEnergy * 0.01f);
		return finalDmg;
	}

	public void MeleeAttack()
	{
		Debug.Log("Starting MeleeAttack");
		if ( SuccessHit() == true )
		{
			if ( isPlayer ) statUIUpdater.energyUI_s.text = "You swing your weapon";
			//currentEnergy -= weaponMass;
			chanceCrit = Random.Range(0f, 3f);
			if ( charLuck > chanceCrit )
			{
				animator.SetTrigger("AttackCrit");
			}
			else
			{
				animator.SetTrigger("Attack");
			}
		}
		else //if ( hasWeaponInHand == true )
		{
			animator.SetTrigger("Attack");
			if ( isPlayer )
				statUIUpdater.energyUI_s.text = "You miss";
		}
		//else
		//{
		//	Fists();
		//	animator.SetTrigger("AttackFists");
		//	if ( isPlayer ) statUIUpdater.energyUI_s.text = "You throw a punch";
		//	//TODO add punching colliders
		//}
	}

	public void FromWeaponHit(GameObject obj, float weaponDmg)
	{
		Debug.Log("Starting fromWeaponHit");
		weaponDamage = weaponDmg;
		float finalDmg;
		randomDamage = Random.Range(1f, 5f);
		if ( Hampered() == true )
		{
			Debug.Log("Hampered attack");
			charDamage = NPCDmg() * .6f;
		}
		else
			charDamage = NPCDmg();

		finalDmg = weaponDamage + randomDamage + (charDamage * 0.5f);
		obj.GetComponent<CharBio>().OnDefend(finalDmg);
		Debug.Log("You hit for " + finalDmg);
	}

	public void Fists()
	{
		weaponDamage = 3.5f * charStr * 0.1f;
		weaponMass = 1f * currentHunger * 0.1f;
	}

	public void SendEvent(string toWhat)
	{
		string action = toWhat;
		switch ( action )
		{
			case "toStrike":

				break;

			default:
				break;
		}
	}
}