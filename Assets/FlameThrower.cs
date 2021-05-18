using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public ParticleSystem fire;

    public void Nost(int a)
    {
        fire.maxParticles = a;
    }
}
