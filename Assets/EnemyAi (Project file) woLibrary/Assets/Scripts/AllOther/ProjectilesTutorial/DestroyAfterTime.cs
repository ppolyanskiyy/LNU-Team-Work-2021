using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public ParticleSystem momentBurst;
    public float timer;

    void Start()
    {
        Debug.Log("Start");
        momentBurst.playOnAwake = true;
        Invoke("Destroy", timer);
    }
    private void Destroy()
    {
        Debug.Log("ENDDD");
        Destroy(gameObject);
    }
}
