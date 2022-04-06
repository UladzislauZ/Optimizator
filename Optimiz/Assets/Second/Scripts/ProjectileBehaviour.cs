using System;
using UnityEngine;
using Object = System.Object;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileBehaviour : MonoBehaviour
{
	[Header("Movement")]
	public float speed = 50f;

	public event Action<GameObject> Off;

	private Rigidbody _rigidbody;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		var objTransform = transform;
		var movement = objTransform.forward * speed * Time.deltaTime;
		_rigidbody.MovePosition(objTransform.position + movement);
	}

	void OnTriggerEnter(Collider theCollider)
	{
		if (theCollider.CompareTag("Enemy") || theCollider.CompareTag("Environment"))
		{
			Off?.Invoke(gameObject);
			gameObject.SetActive(false);
		}
	}
}
