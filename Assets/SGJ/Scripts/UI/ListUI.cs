using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SGJ.Scripts.UI
{
	[RequireComponent(typeof(RectTransform))]
	public class ListUI : MonoBehaviour
	{
		[SerializeField] private GameObject container;
		[SerializeField] private GameObject itemPrefab;
		[SerializeField] private float hideXPosition = -200;
		[SerializeField] private float showXPosition = 150;
		[SerializeField] private float transitionTime = 0.5f;

		private RectTransform rectTransform;
		private Dictionary<string, GameObject> items;

		private bool _isShowing = false;

		private void Start()
		{
			rectTransform = GetComponent<RectTransform>();
			showXPosition = transform.position.x;
			items = new Dictionary<string, GameObject>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				ToggleUI();
			}
		}

		private void ToggleUI()
		{
			if (LeanTween.isTweening(rectTransform))
			{
				return;
			}

			if (_isShowing)
			{
				HideList();
				_isShowing = false;
			}
			else
			{
				ShowList();
				_isShowing = true;
			}
		}

		public void AddItem(Quest quest)
		{
			if (items.ContainsKey(quest.title))
				return;

			GameObject itemUi = Instantiate(itemPrefab, container.transform) as GameObject;
			Text text = itemUi.GetComponentInChildren<Text>();
			if (text != null) text.text = quest.description;
			items.Add(quest.title, itemUi);
		}

		public void RemoveItem(Quest quest)
		{
			if (items.ContainsKey(quest.title))
			{
				GameObject item = items[quest.title];
				items.Remove(quest.title);
				Destroy(item);
			}
		}

		private void HideList()
		{
			LeanTween.moveX(rectTransform, hideXPosition, transitionTime)
				.setEase(LeanTweenType.easeInExpo);
			_isShowing = false;
		}

		public void ShowList()
		{
			LeanTween.moveX(rectTransform, showXPosition, transitionTime)
				.setEase(LeanTweenType.easeInExpo);
			_isShowing = true;
		}
	}
}