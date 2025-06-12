using Microlight.MicroBar;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private GameObject HitVFX;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ShowHitEffect(Vector3 pos)
	{
		Instantiate(HitVFX, pos, quaternion.identity);
	}
}
