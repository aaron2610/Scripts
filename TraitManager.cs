using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitManager : MonoBehaviour
{
	public float factor;

	public enum Traits_e
	{
		bigBoned,
		fastHealing,
		fat,
		friendly,
		holy,
		likeable,
		notHungry,
		quick,
		slowWalker,
		smart,
		strong,
		thickSkin,
		trustOthers
	}

	public Traits_e traitPicked;

	public void Trait(Traits_e traitGot, float BaseFactor)
	{
		traitPicked = traitGot;
		factor = BaseFactor * Random.Range(-0.4f, 1.8f);
		var Npc = gameObject.GetComponent<CharBio>();
		switch ( traitPicked )
		{
			case Traits_e.bigBoned:
				{
					Npc.maxHunger += 10f * factor;
					Npc.hungerTick *= 1.2f;
					break;
				}
			case Traits_e.fastHealing:
				{
					Npc.healthTick *= 1.3f * factor;
					break;
				}

			case Traits_e.fat:
				{
					Npc.charSpd *= 0.8f * factor;
					Npc.charDex -= 10f * factor;
					Npc.maxHunger += 10f * factor;
					break;
				}
			case Traits_e.friendly:
				{
					Npc.likeable += 5f * factor;
					Npc.charCharisma += 6f * factor;
					Npc.aggressionLevel *= 0.9f;
					break;
				}
			case Traits_e.holy:
				{
					Npc.piety += 30 * factor;
					break;
				}

			case Traits_e.likeable:
				{
					Npc.charCharisma += 16f * factor;
					Npc.likeable += 5f * factor;
					break;
				}
			case Traits_e.notHungry:
				Npc.hungerTick *= 0.7f * factor;
				break;

			case Traits_e.quick:
				{
					Npc.charSpd += 1.2f;
					Npc.charDex += 10f * factor;
					break;
				}

			case Traits_e.slowWalker:
				Npc.charSpd *= 0.8f * factor;
				break;

			case Traits_e.smart:
				{
					Npc.charCharisma += 3f;
					Npc.lifeDesire = "becomeFactionLeader";
					break;
				}
			case Traits_e.strong:
				{
					Npc.charStr += 10f * factor;
					break;
				}
			case Traits_e.thickSkin:
				{
					Npc.maxHealth += 10f * factor;
					Npc.healthTick *= 1.1f;
					break;
				}

			case Traits_e.trustOthers:
				break;

			default:
				{
					break;
				}
		}
	}
}