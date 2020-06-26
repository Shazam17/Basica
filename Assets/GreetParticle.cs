using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class GreetParticle : MonoBehaviour
{
    public UIParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem.PauseParticleEmission();
        transform.SetAsLastSibling();
    }

    public void TurnParticleOn()
    {
        particleSystem.StartParticleEmission();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
