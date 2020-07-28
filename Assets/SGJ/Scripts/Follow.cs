using System.Collections;
using System.Collections.Generic;
using SGJ.Scripts;
using UnityEngine;

// It just Lerps the object to the target with a set speed
public class Follow : MonoBehaviour
{
	public static Follow Instance { get; private set; }

	public Transform target;
	[Range(0, 1)] public float speed; // 0-1, 1 is instant
	public bool startAtPosition;
	public float yPos;


	private float origZ;

    private void Awake()
    {
		Instance = this;
    }

    void Start()
	{
		target = FindObjectOfType<PlayerController>()?.transform;
		origZ = transform.position.z;

		if (startAtPosition)
			transform.position = target.position;
	}

	void Update()
	{
	}

	private void FixedUpdate()
	{
		Vector2 pos = Vector2.Lerp(transform.position, target.position + new Vector3(0, yPos, 0), speed);

		transform.position = new Vector3(pos.x, pos.y, origZ);
	}

	public void MoveImmediately()
    {
		transform.position = target.position;
	}
}