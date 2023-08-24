using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public MeshRenderer[] meshRenderers;
    public Transform cameraT;
    public GameObject handProp;
    public AudioClip pickUp;
    public AudioSource audioSource;
    public ParticleSystem smoke;
    private bool isInHand = false;

    private void Update()
    {
        if(!isInHand) return;

        if(Input.GetMouseButton(0))
        {
            if(!audioSource.isPlaying)
            {
                smoke.Play();                
                audioSource.Play();
            }
            RaycastHit hit;
            if(Physics.Raycast(cameraT.position,cameraT.forward,out hit, 2.5f,LayerMask.GetMask("Fire")))
            {
                hit.collider.GetComponent<Fire>().health -= 2f;
            }
        }
        else
        {
            audioSource.Stop();
            smoke.Stop();
        }
    }

    public void InteractWithExt()
    {
        isInHand = !isInHand;
        AudioManager.instance.PlayAudio(pickUp,1.0f);
        if(isInHand) {
            PickUpExtinguisher();
        }
        else {
            PutDownExtinguisher();
        }
    }

    private void PickUpExtinguisher()
    {
        handProp.SetActive(true);
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.enabled = false;
        }
    }

    private void PutDownExtinguisher()
    {
        handProp.SetActive(false);
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.enabled = true;
        }
    }
}
