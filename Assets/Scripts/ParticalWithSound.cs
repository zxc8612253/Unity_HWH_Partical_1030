using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class ParticalWithSound : MonoBehaviour
{
    ParticleSystem _particleSystem;
    /// <summary> 當前的粒子數</summary>
    int _currentNumberOfPartical=0;

    [SerializeField] AudioClip bornSound;
    [SerializeField] AudioClip DieSound;
    [SerializeField] AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        var amount = _currentNumberOfPartical - _particleSystem.particleCount;
        //如果播放的粒子小於當前粒子數則撥死亡音效
        if (_particleSystem.particleCount<_currentNumberOfPartical)
        {
            StartCoroutine(PlaySound(DieSound,amount));
        }
        //如果播放的粒子大於當前粒子數則撥出生音效
       if (_particleSystem.particleCount >_currentNumberOfPartical)
        {
            StartCoroutine(PlaySound(bornSound, amount));
        }
        //當前粒子數=播放的粒子
        _currentNumberOfPartical = _particleSystem.particleCount;
    }

    IEnumerator PlaySound(AudioClip sound,int amount) 
    {
        aud.PlayOneShot(sound, amount);
        yield return null;
    }
}
