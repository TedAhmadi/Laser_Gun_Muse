using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScore20 : MonoBehaviour {
    public ParticleSystem Particle;
    void start()
    {
        Particle = GetComponent<ParticleSystem>();
        Particle.Stop();
    }
    public void Die(int actTarget)
    {
        Particle.Play();
        //CubeExplode.PlayOneShot(cubeexplosion, 5f);
        if (actTarget == 1)
        {
            GlobalScore.CurrentScore += 20;
            Destroy(this.gameObject, 0.6f);
        }
    }
}
