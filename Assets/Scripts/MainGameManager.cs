using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public AudioClip AudioClip;
    public Player player;

    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = AudioClip;

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinGame()
    {
        player.DisableMovement();
    }
}
