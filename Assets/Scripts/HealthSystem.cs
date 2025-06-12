using Microlight.MicroBar;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	[SerializeField]
	int MaxHP = 100;

	[SerializeField]
	int CurrHP = 100;

	[SerializeField]
	MicroBar healthBar;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		CurrHP = MaxHP;
		healthBar.Initialize(MaxHP);
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
	}

	public int GetCurrentHP()
	{
		return CurrHP;
	}
}
