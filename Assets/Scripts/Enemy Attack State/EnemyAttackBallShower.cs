using UnityEngine;

public class EnemyAttackBallShower : EnemyAttackingBase
{
	float timeleft;

	public override void StartState(EnemyAttack enemy)
	{
		timeleft = enemy.bulletCooldownTime;
	}

	public override void FrameUpdate(EnemyAttack enemy)
	{

		UpdateCooldownTime(enemy);

	}

	public override void ExitState(EnemyAttack enemy)
	{
		
	}

	void BallShowerAttack(EnemyAttack enemy)
	{
		float selectedLaunchSpeed = Random.Range(enemy.launchSpeedMin, enemy.launchSpeedMax);

		for (int i = 0; i < 18; i++)
		{
			var projectile = enemy.SpawnBullet();
			projectile.GetComponent<Rigidbody>().linearVelocity = selectedLaunchSpeed * enemy.shootPosition.up;
			projectile.GetComponent<Bullet>().damage = enemy.BulletDamage;

			enemy.bulletPivot.Rotate(new Vector3(0, 20f, 0));
		}
	}

	void UpdateCooldownTime(EnemyAttack enemy)
	{
		if (timeleft > 0f)
		{
			timeleft -= Time.deltaTime;
		}
		else
		{
			BallShowerAttack(enemy);
			timeleft = enemy.bulletCooldownTime;
		}
	}
}
