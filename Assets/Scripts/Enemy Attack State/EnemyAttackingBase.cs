using UnityEngine;

public abstract class EnemyAttackingBase
{
	public abstract void StartState(EnemyAttack enemy);
	public abstract void FrameUpdate(EnemyAttack enemy);
	public abstract void ExitState(EnemyAttack enemy);
}
