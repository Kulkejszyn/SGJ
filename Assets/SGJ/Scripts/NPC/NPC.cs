﻿using System;
using System.Collections.Generic;
using System.Linq;
using DialogueEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SGJ.Scripts
{
	public class NPC : Interactable
	{
		public NPCConversation conversation;
		public NPCConversation alreadyTalkedConversation;
		private NPCConversation _currentConversation;

		private bool hasTalked;

		protected override void Start()
		{
			base.Start();
			_currentConversation = conversation;
			alreadyTalkedConversation.DefaultName = conversation.DefaultName;
		}

		private void PlayConversationSpeech()
		{
			throw new NotImplementedException();
		}

		public void StartConversation()
		{
			if (hasTalked)
			{
				//_currentConversation = GameAssets.Instance.alreadyTalkedConversation;

				// bo w aktualnej wersji chcemy żeby można było rozmawiać kilka razy
				_currentConversation = alreadyTalkedConversation;
			}

			if (!ConversationManager.Instance.IsConversationActive)
			{
				ConversationManager.Instance.StartConversation(_currentConversation);
				hasTalked = true;
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{

			Debug.Log($"NPC {gameObject.name} clicked");

			if (!ConversationManager.Instance.IsConversationActive)
			{
				StartConversation();
			}
		}
	}
}