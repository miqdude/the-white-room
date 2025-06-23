using Microlight.MicroBar;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
	public UnityEvent OnDead;

	[SerializeField]
	int MaxHP = 100;

	[SerializeField]
	int CurrHP = 100;

	[SerializeField]
	MicroBar healthBar;

	public CameraShakeCinemachine cameraShakeCinemachine;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		CurrHP = MaxHP;

		if (healthBar != null)
		{
			healthBar.Initialize(MaxHP);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void GiveDamage(int amount)
	{
		CurrHP -= amount;

		if (healthBar != null)
		{
			healthBar.UpdateBar(CurrHP - amount);
		}

		// Camera shake effect
		if (cameraShakeCinemachine != null)
		{
			cameraShakeCinemachine.ShakeCamera(10f, 1f);
		}

		if (CurrHP <= 0)
		{
			if (OnDead != null)
			{
				OnDead.Invoke();
			}
		}
	}

	public int GetCurrentHP()
	{
		return CurrHP;
	}
}
