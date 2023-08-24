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

    private void Start ()
    {
        StartCoroutine(REG());
        StartCoroutine(RandomNoises());
    }  

    private IEnumerator REG()
    {
        float random = Random.Range(timeInterval.x,timeInterval.y);
        yield return new WaitForSeconds(random);
        int rng = Random.Range(0,7); // MAX EXCLUSIVE
        switch (rng)    
        {
            case 0: 
                lightFlicker.FlickerLight(true,15f);
                break;
            case 1:
                lightFlicker.ChangeColour();
                break;
            case 2:
                oxygen.canDecreaseCount = true;
                break;
            case 3:
                antiGravity.TurnOffGravity();
                break;
            case 4:
                pressure.canDecreaseCount = true;
                break;
            case 5:
                fireGenerator.GenerateFire();
                break;
            case 6:
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
        AudioManager.instance.PlayAudio(clips[randomClip],1.0f);
        StartCoroutine(RandomNoises());
    }

}
