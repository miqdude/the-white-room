using UnityEngine;

public class EnemyAttackLaser : EnemyAttackingBase
{

	public override void StartState(EnemyAttack enemy)
	{
		enemy.LaserParent.SetActive(true);
	}

	public override void FrameUpdate(EnemyAttack enemy)
	{
		enemy.transform.Rotate(new Vector3(0, enemy.LaserSpiningSpeed, 0) * Time.deltaTime);
	}
	
	public override void ExitState(EnemyAttack enemy)
	{
		enemy.LaserParent.SetActive(false);
	}
}
