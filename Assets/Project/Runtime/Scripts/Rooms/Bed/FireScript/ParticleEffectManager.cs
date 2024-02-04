using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
    public GameObject ParticleEmitterPrefab;
    private GameObject instance;

    public void Activate(){
        instance = Instantiate(ParticleEmitterPrefab, transform.position, transform.rotation);
    }

    public void Desactivate(){
        Destroy(instance);
    }
}
