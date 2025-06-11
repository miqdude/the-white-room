using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
	public float lifetime = 1f;

	float timeRemaining;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		timeRemaining = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
		timeRemaining -= Time.deltaTime;

		if (timeRemaining <= 0f)
		{
        	Destroy(this.gameObject); 	
		}
        
    }
}
