using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

namespace SGJ.Scripts
{
	[RequireComponent(typeof(SpriteRenderer))]
	public abstract class Interactable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
	{
		private SpriteRenderer SpriteRenderer { get; set; }

		protected virtual void Start()
		{
			SpriteRenderer = GetComponent<SpriteRenderer>();
		}

		
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			throw new NotImplementedException();
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			SpriteRenderer.material = GameAssets.Instance.UnlitMaterial;
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			SpriteRenderer.material = GameAssets.Instance.LitMaterial;
		}
	}
}