using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int scoreNum, currentHP, ballVelocity;

    public Image hpCircle;
    public ParticleSystem collisionParticleSystem;
    public Rigidbody2D ballBody;
    public GameObject memoryBall;
    public int  totalHP = 100;

    void Start()
    {
        currentHP = totalHP;
        SetHP();

    }

    private void OnCollisionEnter2D(Collision2D ball_Col) {
        var particleEM = collisionParticleSystem.emission;
        var particleDur = collisionParticleSystem.main.duration;
        ballVelocity = (int)Mathf.Round(ballBody.velocity.magnitude/50);

        if (ball_Col.gameObject.tag == "Player") {     
            particleEM.enabled = true;
            collisionParticleSystem.Play();

            if (currentHP < 50) {
                currentHP -= ballVelocity + 3;
            } else {
                currentHP -= ballVelocity + 1;

            }

            if (currentHP != 0) {
                SetHP();
            }

            if (currentHP <= 0) {
                Destroy(memoryBall);
            }

        }
    }

    void SetHP() {
        hpCircle.fillAmount = (float)currentHP / totalHP;
        
    }

}
