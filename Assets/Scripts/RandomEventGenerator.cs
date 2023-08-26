using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventGenerator : MonoBehaviour
{
    public Vector2 timeInterval;
    public LightFlicker lightFlicker; // 0 & 1
    public Oxygen oxygen; // 2
    public AntiGravity antiGravity; // 3
    public Pressure pressure; // 4
    public AudioClip[] clips; // 5
    public FireGenerator fireGenerator; // 6
    public RandomObstacles randomObstacles; // 7
    public AudioClip buttonClick;
    public AudioClip valve;
    public Transform audioLocation;

    private void Start ()
    {
        StartCoroutine(REG());
        StartCoroutine(RandomNoises());
    }  

    private IEnumerator REG()
    {
        float random = Random.Range(timeInterval.x,timeInterval.y);
        yield return new WaitForSeconds(random);
        int rng = Random.Range(0,6); // MAX EXCLUSIVE
        switch (rng)    
        {
            case 0: 
                if(Random.Range(0,2) == 0){
                    lightFlicker.FlickerLight(true,15f);
                } else {
                lightFlicker.ChangeColour();
                }
                break;
            case 1:
                oxygen.canDecreaseCount = true;
                AudioManager.instance.PlayAudio(buttonClick,1.0f,true,100f,oxygen.transform.position);
                break;
            case 2:
                AudioManager.instance.PlayAudio(buttonClick,1.0f,true,100f,antiGravity.transform.position);
                antiGravity.TurnOffGravity();
                break;
            case 3:
                AudioManager.instance.PlayAudio(valve,1.0f,true,100f,pressure.transform.position);
                pressure.canDecreaseCount = true;
                break;
            case 4:
                fireGenerator.GenerateFire();
                break;
            case 5:
                randomObstacles.SpawnRandomObstacle(15f);
                break;
            default:
                break;
        }
        StartCoroutine(REG());
    }

    private IEnumerator RandomNoises()
    {
        float random = Random.Range(timeInterval.x,timeInterval.y);
        yield return new WaitForSeconds(random);
        int randomClip = Random.Range(0,clips.Length);
        if(randomClip == 4 || randomClip == 5 || randomClip == 1)
        {
            AudioManager.instance.PlayAudio(clips[randomClip],1.0f,true,100f,audioLocation.position);
        }
        AudioManager.instance.PlayAudio(clips[randomClip],1.0f);

        StartCoroutine(RandomNoises());
    }

}
