using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScore80 : MonoBehaviour {


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
        if (actTarget == 7)
        {
            GlobalScore.CurrentScore += 80;
            Destroy(this.gameObject, 0.6f);
        }
    }
}
