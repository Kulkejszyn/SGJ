using System;
using DialogueEditor;
using UnityEngine;

namespace SGJ.Scripts
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController : MonoBehaviour
	{
		public static PlayerController Instance { get; private set; }

		public bool canWalkDuringConversation;

		[SerializeField] private PlayerStats playerStats;
		private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
			Instance = this;
        }

        private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
            if (ConversationManager.Instance)
            {
				if (!canWalkDuringConversation && ConversationManager.Instance.IsConversationActive)
				{
					_rigidbody2D.velocity = Vector2.zero;
					return;
				}
			}
			
			Move();
		}

		void Move()
		{
			_rigidbody2D.velocity = new Vector2(
				Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical")) * playerStats.moveSpeed;
		}

		public static Transform GetPlayerTransform()
        {
			return Instance.transform;
        }
	}
}