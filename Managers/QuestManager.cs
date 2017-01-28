//using System;
//using UnityEngine;

//public class QuestManager : MonoBehaviour
//{
//	public static bool savedWife;
//	public static bool accusedWifeOfMurder;
//	public static bool helpedWifeWithMurder;
//	public static bool saveSlaves;
//	public static int numOfSlavesSaved = 0;
//	public static bool learnHistoryOfRomis;
//	public static bool saveALife;
//}

//public class SaveWifeQuest : MonoBehaviour
//{
//	public int numOfFoes;

//	public void StartQuest(int NumOfFoes)
//	{
//		numOfFoes = NumOfFoes;
//		if ( RelationManager.bandits <= 30f )
//			numOfFoes += 2;

//	}

//	public void FinishQuest()
//	{
//		if ( QuestManager.helpedWifeWithMurder == true )
//		{
//			RelationManager.theWife += 20f;
//			RelationManager.theSon += 10f;
//			QuestManager.savedWife = true;
//		} else if ( QuestManager.accusedWifeOfMurder == true )
//		{
//			RelationManager.theSon += 10f;
//			RelationManager.theWife -= 5f;
//			QuestManager.savedWife = false;
//		}
//	}
//}

//public class AccuseWifeOfMurderQuest : MonoBehaviour
//{
//	public enum Options
//	{
//		accuse,
//		help,
//		doNothing
//	}

//	public Options options;

//	public void StartQuest()
//	{
//	}

//	public void OptionPick(Options selection)
//	{
//		Options optionPick = selection;
//		switch ( optionPick )
//		{
//			case Options.accuse:
//				{
//					RelationManager.theWife -= 30f;
//					RelationManager.theSon -= 10f;
//					StartAccuse();
//					break;
//				}
//			case Options.help:
//				{
//					RelationManager.theWife += 10f;
//					break;
//				}
//			case Options.doNothing:
//				{
//					RelationManager.theWife -= 5f;
//					RelationManager.theSon += 5f;
//					break;
//				}
//		}
//	}

//	public void StartAccuse()
//	{
//	}
//}