using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform shootPosition;
	public float launchSpeedMin = 5f, launchSpeedMax = 20f;
	public Transform bulletPivot;
	public float bulletCooldownTime = .8f;

	public Transform playerPos;
	public float movingSpeed = 5f;
	public GameObject LaserParent;
	public float LaserSpiningSpeed = 3f;


	public float stateTime = 10f;
	float stateTimeRemaining;
	EnemyAttackingBase currentAttackState;
	EnemyAttackBallShower enemyAttackBallShower = new EnemyAttackBallShower();
	EnemyAttackApproachPlayer enemyAttackApproachPlayer = new EnemyAttackApproachPlayer();
	EnemyAttackLaser enemyAttackLaser = new EnemyAttackLaser();
	EnemyAttackIdle enemyAttackIdle = new EnemyAttackIdle();

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		if (bulletPrefab == null)
		{
			Debug.Log("No bullet prefab!");
		}

		currentAttackState = enemyAttackIdle;
		currentAttackState.StartState(this);

		stateTimeRemaining = stateTime;
	}

	// Update is called once per frame
	void Update()
	{
		currentAttackState.FrameUpdate(this);

		if (stateTimeRemaining > 0f)
		{
			stateTimeRemaining -= Time.deltaTime;
		}
		else
		{
			int rnd = Random.Range(1, 5);
			// int rnd = 0;

			currentAttackState.ExitState(this);

			switch (rnd)
			{
				case 1:
					currentAttackState = enemyAttackBallShower;
					break;
				case 2:
					currentAttackState = enemyAttackApproachPlayer;
					break;
				case 3:
					currentAttackState = enemyAttackLaser;
					break;
				default:
					currentAttackState = enemyAttackIdle;
					break;
			}

			currentAttackState.StartState(this);
			// Debug.Log("Current state : " + currentAttackState.ToString());
			stateTimeRemaining = stateTime;
		}
	}

	public GameObject SpawnBullet()
	{
		return Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
	}
}
