using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleRun;
    ParticleSystem.MainModule _particleRunMain;

    [SerializeField] ParticleSystem _particlePack;
    ParticleSystem.MainModule _particlePackMain;

    [SerializeField] PlayerResource pr;
    [SerializeField] Player.PlayerController pc;


    float runLifetime;
    float sprayLifetime;
    
    void Start()
    {
        _particleRunMain = _particleRun.main;
        runLifetime = _particleRunMain.startLifetime.constant;

        _particlePackMain = _particlePack.main;
        sprayLifetime = _particlePackMain.startLifetime.constant;

    }
    void FixedUpdate()
    {
        if (pc.GetMoving())
        {
            _particleRunMain.startLifetime = runLifetime;
        }
        else
        {
            _particleRunMain.startLifetime = 0;
        }

        if (pr.spraying)
        {
            _particlePackMain.startLifetime = sprayLifetime;
        }
        else
        {
            _particlePackMain.startLifetime = 0;
        }
    }
}
