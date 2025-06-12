using UnityEngine;

public class BillBoardEffect : MonoBehaviour
{
	[SerializeField]
	Transform camera;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		camera = Camera.main.transform;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void LateUpdate()
	{
		transform.LookAt(transform.position + camera.forward);
	}
}
