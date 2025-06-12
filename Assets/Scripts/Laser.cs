using UnityEngine;

public class Laser : MonoBehaviour
{
	float laserHitRemaining;

	[SerializeField]
	int damage = 5;

	[SerializeField]
	LayerMask PlayerLayer = 0;

	public Transform LaserEndPoint;
	public float laserRadius = .3f;
	public float laserHitFrequency = .3f; 

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		laserHitRemaining = laserHitFrequency;
	}

	// Update is called once per frame
	void Update()
	{

		if (laserHitRemaining <= 0f)
		{
			Collider[] hitPlayers = Physics.OverlapCapsule(transform.position, LaserEndPoint.position, laserRadius, PlayerLayer);

			foreach (Collider hitPlayer in hitPlayers)
			{
				if (hitPlayer.gameObject.CompareTag("Player"))
				{
					HealthSystem playerHealth = hitPlayer.GetComponent<HealthSystem>();

					playerHealth.GiveDamage(2);

					// Debug.Log("Laser Damage player");
				}
			}
		}


		if (laserHitRemaining > 0f)
		{
			laserHitRemaining -= Time.deltaTime;
		}
		else
		{
			laserHitRemaining = laserHitFrequency;
		}
	}

	void OnDrawGizmos()
	{
		// Debug.DrawRay(transform.position, LaserEndPoint.transform.position, Color.red);
	}
}
