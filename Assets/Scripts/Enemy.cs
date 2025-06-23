using Microlight.MicroBar;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(EnemyAttack))]
public class Enemy : MonoBehaviour
{

	public UnityEvent EnemyDieEvent;

	[Tooltip("How many degrees to fall (e.g. 90)")]
	public float fallAngle = 90f;

	[Tooltip("Fall direction (e.g. Vector3.right for rightward)")]
	public Vector3 fallAxis = Vector3.forward;

	[Tooltip("Duration of the fall in seconds")]
	public float duration = 1.5f;

	[Tooltip("Optional: delay before falling")]
	public float delay = 0f;

	[SerializeField]
	private GameObject HitVFX;

	private bool hasFallen = false;
	private bool isDead = false;
	private EnemyAttack enemyAttack;

	void Awake()
	{
		enemyAttack = GetComponent<EnemyAttack>();
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (isDead)
		{
			Fall();
		}
	}

	public void ShowHitEffect(Vector3 pos)
	{
		Instantiate(HitVFX, pos, quaternion.identity);
	}

	public void HandleEnemyDie()
	{
		if (EnemyDieEvent != null)
		{
			isDead = true;
			EnemyDieEvent.Invoke();

			// disable enemy attack
			enemyAttack.DisableAttack();
			// enemyAttack.enabled = false;
		}
	}

	public void Fall()
	{
		if (hasFallen) return;

		hasFallen = true;

		// Rotate around pivot (simulate tipping from base)
		transform.DORotate(transform.eulerAngles + fallAxis * fallAngle, duration, RotateMode.Fast)
				 .SetEase(Ease.InQuad)
				 .SetDelay(delay);
	}
}
