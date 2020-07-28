using System;
using System.Linq;
using UnityEngine;

namespace SGJ.Scripts
{
	public class AudioManager : MonoBehaviour
	{
		public enum SoundType
		{
			Speech,
			Scene1,
			Scene2
		}

		public static AudioManager Instance { get; private set; }

		private AudioSource _audioSource;

		public void Initialize()
		{
			var soundGameObject = new GameObject("Audio Source");
			_audioSource = soundGameObject.AddComponent<AudioSource>();
		}

		public void PlaySoundAtPosition(SoundType soundType, Vector3 position)
		{
			AudioClip audioClip = GetAudioClip(soundType);
			_audioSource.PlayOneShot(audioClip);
			_audioSource.transform.position = position;
		}

		public void PlayRandomSoundAtPosition(SoundType soundType, Vector3 position)
		{
			AudioClip audioClip = GetRandomAudioClip(soundType);
			_audioSource.PlayOneShot(audioClip);
			_audioSource.transform.position = position;
		}

		private void OnEnable()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		private void Start()
		{
			Initialize();
		}

		private AudioClip GetRandomAudioClip(SoundType soundType)
		{
			return GameAssets.Instance.soundAudioClips
				.Where(o => o.soundType.Equals(soundType))
				.OrderBy(o => Guid.NewGuid())
				.Select(o => o.audioClip)
				.First();
		}

		private AudioClip GetAudioClip(SoundType soundType)
		{
			return GameAssets.Instance.soundAudioClips
				.Where(o => o.soundType.Equals(soundType))
				.Select(o => o.audioClip)
				.First();
		}
	}
}