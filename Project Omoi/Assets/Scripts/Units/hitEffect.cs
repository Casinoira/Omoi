using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEffect : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D ball_Col) {
        var particleEM = collisionParticleSystem.emission;
        var particleDur = collisionParticleSystem.main.duration;

        if (ball_Col.gameObject.name == "Ball") {   
            particleEM.enabled = true;
            collisionParticleSystem.Play();
        }
    }
}
