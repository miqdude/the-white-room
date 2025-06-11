using UnityEngine;

public class Laser : MonoBehaviour
{
	[SerializeField]
	int damage = 5;

	[SerializeField]
	float MaxLaserDistance = 5f;

	[SerializeField]
	LayerMask PlayerLayer = 0;

	Vector3 laserEndPoint;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		laserEndPoint = transform.position + transform.forward * MaxLaserDistance;
	}

	// Update is called once per frame
	void Update()
	{
		RaycastHit raycastHit;
		bool isHit = Physics.Raycast(transform.position, transform.forward, out raycastHit, MaxLaserDistance, PlayerLayer);

		if (isHit)
		{
			laserEndPoint = raycastHit.point;

			Debug.Log("Laser hit " + raycastHit.collider.name);
		}
	}

	void OnDrawGizmos()
	{
		Debug.DrawRay(transform.position, transform.forward * MaxLaserDistance, Color.red);
	}
}
