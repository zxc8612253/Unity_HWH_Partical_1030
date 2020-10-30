using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playpartical : MonoBehaviour
{
    [SerializeField]ParticleSystem myparticleSystem;
    
    public void playPartical()
    {
        myparticleSystem.Play();
    }
    
}
