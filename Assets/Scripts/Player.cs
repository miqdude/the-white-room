using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    Animator animator;
    PlayerAttack playerAttack;
    ThirdPersonController thirdPersonController;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleOnDead()
    {
        DisableMovement();

        animator.SetBool("PlayerDead", true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void DisableMovement()
    {
        Debug.Log("player win");

        playerAttack.IsAttackDisabled = true;
        thirdPersonController.canMove = false;
    }
}
