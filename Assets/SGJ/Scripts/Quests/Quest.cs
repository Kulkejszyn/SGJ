using System;
using UnityEngine;

namespace SGJ.Scripts
{
	[CreateAssetMenu(menuName = "Assets/Quest")]
	public class Quest : ScriptableObject
	{
		public bool IsActive { get; private set; } = false;
		public bool IsDone { get; private set; } = false;

		public QuestType questType;
		public string title;
		public string questGiverName;
		[TextArea] public string description;


		private void OnEnable()
		{
			IsActive = false;
			IsDone = false;
		}

		public void FinishQuest()
		{
			IsDone = true;
		}

		public void StartQuest()
		{
			IsActive = true;
		}
	}

	public enum QuestType
	{
		PICK_UP,
		SPEECH
	}
}