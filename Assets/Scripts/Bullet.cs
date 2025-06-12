using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject explosionEffectPrefab;
	public GameObject explosionOnHitPlayer;

	public int damage = 3;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		// Debug.Log("bullet hit " + collision.collider.name);
		if (collision.collider.gameObject.CompareTag("Ground"))
		{
			Vector3 contactPoint = collision.contacts[0].point;
			Vector3 contactNormal = collision.contacts[0].normal;
			Quaternion rotation = Quaternion.Euler(90f,0,0); // Align forward to normal
			contactPoint += new Vector3(0,0.5f,0);

			Instantiate(explosionEffectPrefab, contactPoint, rotation);
		}

		if (collision.collider.gameObject.CompareTag("Player"))
		{
			HealthSystem playerHealth = collision.collider.GetComponent<HealthSystem>();
			playerHealth.GiveDamage(damage);

			Vector3 contactPoint = collision.contacts[0].point;
			Vector3 contactNormal = collision.contacts[0].normal;
			Quaternion rotation = Quaternion.Euler(90f,0,0); // Align forward to normal
			contactPoint += new Vector3(0,0.5f,0);

			Instantiate(explosionOnHitPlayer, contactPoint, rotation);
		}

		Destroy(gameObject);
	}
}
