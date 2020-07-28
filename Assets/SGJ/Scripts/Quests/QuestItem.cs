using UnityEngine;
using UnityEngine.EventSystems;

namespace SGJ.Scripts
{
	public class QuestItem : Interactable
	{
		public Quest quest;

		public override void OnPointerClick(PointerEventData eventData)
		{
			if (!quest.IsActive)
			{
				return;
			}

			if (quest.questType == QuestType.PICK_UP)
			{
				//TODO:: Pickup effect
				quest.FinishQuest();
				gameObject.SetActive(false);
			}

			if (quest.questType == QuestType.SPEECH)
			{
				quest.FinishQuest();
			}
		}
		
	}
}