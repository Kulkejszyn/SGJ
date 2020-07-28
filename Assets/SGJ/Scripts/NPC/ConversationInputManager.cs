using DialogueEditor;
using UnityEngine;

namespace SGJ.Scripts
{
	public class ConversationInputManager : MonoBehaviour
	{
		private void Update()
		{
			UpdateConversationInput();
		}

		private void UpdateConversationInput()
		{
			if (ConversationManager.Instance.IsConversationActive)
			{
				if (Input.GetKeyDown(KeyCode.W))
					ConversationManager.Instance.SelectPreviousOption();
				else if (Input.GetKeyDown(KeyCode.S))
					ConversationManager.Instance.SelectNextOption();
				else if (Input.GetKeyDown(KeyCode.E))
					ConversationManager.Instance.PressSelectedOption();
			}
		}
	}
}