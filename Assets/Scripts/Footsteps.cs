using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footsteps;
    private AudioSource audioSource;
    private int index; //how to randomize clip

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayFootstep()
    {
        audioSource.Stop();
        index = Random.Range(0, footsteps.Length); //pulling random object from array
        float pitch = Random.Range(0.8f, 1.2f);

        audioSource.clip = footsteps[index];
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}
