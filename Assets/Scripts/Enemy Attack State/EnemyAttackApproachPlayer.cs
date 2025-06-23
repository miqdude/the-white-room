using UnityEngine;

public class EnemyAttackApproachPlayer : EnemyAttackingBase
{
	Vector3 playerPos;

	public override void StartState(EnemyAttack enemy)
	{
		playerPos = enemy.playerPos.transform.position;
	}

	public override void FrameUpdate(EnemyAttack enemy)
	{
		Vector3 dir = playerPos - enemy.transform.position;
		dir.y = 0;

		// enemy.transform.position += dir * enemy.movingSpeed * Time.deltaTime;
		if (dir.magnitude > 0.1f)
		{
			enemy.Move(dir.normalized * enemy.movingSpeed * Time.deltaTime);
		}
	}
	
	public override void ExitState(EnemyAttack enemy)
	{
		
	}
}
