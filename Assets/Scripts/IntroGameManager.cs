using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroGameManager : MonoBehaviour
{
    public AudioClip ambientClip;
    public PlayerAttack Player;
    public ThirdPersonController playerThirdPersonController;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ambientClip;
        audioSource.loop = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.IsAttackDisabled = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered portal");

        playerThirdPersonController.canMove = false;

        SceneManager.LoadScene(1); // load game scene
    }
}
