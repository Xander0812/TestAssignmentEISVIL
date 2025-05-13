using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Color color = default;
    public Shape shape = default;

    public GameObject _particles;

    public void DestroySelf()
    {
        TaskSystem.objectDestroyed.Invoke(new ObjectData(shape, color));
        ParticleSystem _deathParticles = Instantiate(_particles, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = _deathParticles.main;
        main.startColor = color;

        Destroy(gameObject);
    }
}
