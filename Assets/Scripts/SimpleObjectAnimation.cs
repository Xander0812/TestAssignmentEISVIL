using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SimpleObjectAnimation : MonoBehaviour
{
    public float amp;
    public float frequency;
    Vector3 initPosition;
    public float startHight;

    float randomAmp;
    float randomFrequency;

    private void Start()
    {
        initPosition = transform.position;
        randomAmp = Random.Range(-amp,amp);
        randomFrequency = Random.Range(1,frequency);
    }

    private void Update()
    {
        transform.position = new Vector3(initPosition.x, startHight + (Mathf.Sin(Time.time * randomFrequency) * randomAmp), initPosition.z);
    }
}
