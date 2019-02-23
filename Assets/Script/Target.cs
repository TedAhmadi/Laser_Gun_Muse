using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    //public ParticleSystem Particle;
    public void Die()
    {
        //Particle.Play();
        //CubeExplode.PlayOneShot(cubeexplosion, 5f);
        GlobalScore.CurrentScore += 50;

        Destroy(this.gameObject, 5f);
    }
}

