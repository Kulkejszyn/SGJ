using System;
using System.Collections;
using System.Collections.Generic;
using SGJ.Scripts;
using SGJ.Scripts.UI;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	[SerializeField] private ListUI listUi;
	private List<Quest> activeQuests;

	private void Start()
	{
		activeQuests = new List<Quest>();
	}

	public void StartQuest(Quest quest)
	{
		if (!quest.IsActive)
		{
			quest.StartQuest();
			activeQuests.Add(quest);
			listUi?.AddItem(quest);
		}
	}

	public void FinishQuest(Quest quest)
	{
		if (quest.IsActive && quest.IsDone)
		{
			Debug.Log(quest.title + " finished");
			activeQuests.Remove(quest);
			listUi?.RemoveItem(quest);
		}
	}
}