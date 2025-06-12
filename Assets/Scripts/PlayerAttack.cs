using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
	public Transform HurtBoxPoint;
	public GameObject AxeHandHolder, AxeBackHolder;
	public int Damage=10;

	[SerializeField]
	LayerMask EnemyLayerMask = 0;

	[SerializeField]
	float HurtBoxRadius = 3f;

	private ThirdPersonController controller;

	Animator animator;
	private InputSystem_Actions _input;

	void Awake()
	{
		_input = new InputSystem_Actions();
		controller = GetComponent<ThirdPersonController>();
	}


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		animator = GetComponent<Animator>();
		AxeHandHolder.SetActive(false);
	}

	private void OnEnable()
	{
		_input.Player.Enable();

		_input.Player.LightAttack.performed += ctx => LightAttack();
	}

	private void OnDisable()
	{
		_input.Player.Disable();
	}


	// Update is called once per frame
	void Update()
	{
		
	}

	void LightAttack()
	{
		// Only perform attack while grounded
		if (!controller.Grounded)
		{
			return;
		}

		// Preventing character to move while performing attack
		// this is a custom code added to the ThirdPersonController
		controller.canMove = false;

		int attackIdx = Random.Range(1, 3);
		// Debug.Log("lightattack " + attackIdx);


		switch (attackIdx)
		{
			case 1:
				animator.SetBool("LightAttack1", true);
				break;
			case 2:
				animator.SetBool("LightAttack2", true);
				break;
			default:
				break;
		}

	}

	// this method is an animator event
	void ResetAttack()
	{
		controller.canMove = true;
		animator.SetBool("LightAttack1", false);
		animator.SetBool("LightAttack2", false);
	}

	// This method is an animator event
	public void Attack()
	{
		Collider[] hitEnemies = Physics.OverlapSphere(HurtBoxPoint.position, HurtBoxRadius, EnemyLayerMask);

		foreach (Collider hitEnemy in hitEnemies)
		{
			HealthSystem enemyHealth = hitEnemy.GetComponent<HealthSystem>();
			enemyHealth.GiveDamage(Damage);

			Enemy enemy = hitEnemy.GetComponent<Enemy>();

			enemy.ShowHitEffect(HurtBoxPoint.transform.position);

			Debug.Log("Current " + hitEnemy.name + " HP " + enemyHealth.GetCurrentHP());
		}

	}

	public void SetWeaponOnBack()
	{
		AxeHandHolder.SetActive(false);
		AxeBackHolder.SetActive(true);
	}

	public void SetWeaponOnHand()
	{
		AxeHandHolder.SetActive(true);
		AxeBackHolder.SetActive(false);
	}


	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(HurtBoxPoint.position, HurtBoxRadius);

		// Gizmos.color = Color.red;
		// Gizmos.DrawLine(AxeHandHolder.transform.position, SwordEnpoint.transform.position);
	}
}
