using System.Collections;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    private AudioSource audioSource;
    private bool isPlayingFootstep = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstepSound()
    {
        if(isPlayingFootstep) return;
        isPlayingFootstep = true;
        StartCoroutine(FootstepSound());
    }

    private IEnumerator FootstepSound()
    {
        int randomSoundIndex = Random.Range(0, footstepSounds.Length);
        audioSource.clip = footstepSounds[randomSoundIndex];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 0.05f);
        isPlayingFootstep = false;
    }
}