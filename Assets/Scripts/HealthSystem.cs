using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	[SerializeField]
	int MaxHP = 100;

	[SerializeField]
	int CurrHP = 100;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		CurrHP = MaxHP;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void GiveDamage(int amount)
	{
		CurrHP -= amount;
	}

	public int GetCurrentHP()
	{
		return CurrHP;
	}
}
