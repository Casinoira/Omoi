using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    // public GameObject memoryBall;
    private int scoreNum;
    private float multiplierTimer;
    private bool isMultiplied = false;

    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        scoreNum = 100;
        scoreText.text = scoreNum.ToString();
    }

    private void OnCollisionEnter2D(Collision2D ball_Col) {
        var particleEM = collisionParticleSystem.emission;
        var particleDur = collisionParticleSystem.main.duration;

        if (ball_Col.gameObject.tag == "Multiplier") {
            isMultiplied = true;
            multiplierTimer = Time.deltaTime;

            print("multiplierTime: " + multiplierTimer);
            print("isMultiplied: " + isMultiplied);
        }

        if (ball_Col.gameObject.tag == "MemoryBall") {     
            particleEM.enabled = true;
            collisionParticleSystem.Play();

            if(multiplierTimer >= 0.02) {
                multiplierTimer = 0;
                isMultiplied = false;
            }
            
            if (isMultiplied == true) {
                scoreNum -= 2;
            }else{
                scoreNum -= 1;
            }

            if (scoreNum != 0) {
                print("multiplierTime: " + multiplierTimer);
                print("hit isMultiplied: " + isMultiplied);

                scoreText.text = scoreNum.ToString();

            }

            
        }
    }

}
