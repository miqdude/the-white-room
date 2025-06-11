using UnityEngine;

public class CharacterControl : MonoBehaviour
{
	public float gravitySettings = -9.81f;
	public float jumpHeight = 2f;
	public float rotating_speed = 100f;
	public Transform groundCheck;
	public float groundDistance = 1f;
	public float airSpeed = 5f;
	public float jumpingTime = .3f;

	[SerializeField]
	LayerMask groundMask = 0;

	private CharacterController controller;
	private Animator animator;
	bool IsGrounded = true;
	private Vector3 velocity;
	private Vector3 rootMotionDelta;
	private float jumpingTimeCounter;
	private bool isJumping = false;

	private float gravity;

	void Start()
	{
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		animator.applyRootMotion = false; // We'll apply it manually
		gravity = gravitySettings;
	}

	void Update()
	{
		IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		animator.SetBool("IsGrounded", IsGrounded);

		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		float move_amount = Mathf.Clamp01(Mathf.Abs(movement.x) + Mathf.Abs(movement.z));

		animator.SetFloat("MoveAmount", move_amount);

		if (move_amount > 0f)
		{
			Vector3 cam = Camera.main.transform.forward;
			movement = Quaternion.LookRotation(new Vector3(cam.x, 0f, cam.z)) * movement;

			Quaternion targe_rotation = Quaternion.LookRotation(movement);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targe_rotation, rotating_speed * Time.deltaTime);
		}

		// Handle Jumping
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
			animator.SetTrigger("Jump");

			// variable jumping
			jumpingTimeCounter = jumpingTime;
			isJumping = true;
		}

		if (Input.GetKey(KeyCode.Space) && isJumping)
		{
			if (jumpingTimeCounter > 0f)
			{
				velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
				jumpingTimeCounter -= Time.deltaTime;
			}
			else
			{
				isJumping = false;
			}
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			isJumping = false;
		}

		// Apply gravity
		velocity.y += gravity * Time.deltaTime;

		// Final movement: root motion delta + gravity
		Vector3 finalMove = rootMotionDelta + velocity * Time.deltaTime;
		controller.Move(finalMove);

		// Reset root motion delta for next frame
		rootMotionDelta = Vector3.zero;

		if (!IsGrounded)
		{
			Vector3 velocity = movement * airSpeed;
			velocity.y = gravity;

			controller.Move(velocity * Time.deltaTime);
		}
	}

	void OnAnimatorMove()
	{
		if (IsGrounded)
		{
			// Only apply horizontal root motion
			Vector3 delta = animator.deltaPosition;
			delta.y = 0;
			rootMotionDelta += delta;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
	}
}
