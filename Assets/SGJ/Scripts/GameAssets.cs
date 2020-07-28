using System;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

namespace SGJ.Scripts
{
	public class GameAssets : MonoBehaviour
	{
		[Serializable]
		public class SoundAudioClip
		{
			public AudioClip audioClip;
			public AudioManager.SoundType soundType;
		}

		private static GameAssets _instance;
		public static GameAssets Instance
		{
			get
			{
				if (_instance == null)
					_instance = Instantiate((GameObject) Resources.Load("GameAssets")).GetComponent<GameAssets>();
				return _instance;
			}
		}

		public Material LitMaterial;

		public Material UnlitMaterial;

		public NPCConversation alreadyTalkedConversation;
		public List<SoundAudioClip> soundAudioClips;
	}
}