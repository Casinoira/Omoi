using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // public TMP_Text scoreText;
    // public GameObject memoryBall;
    public Image hpCircle;
    public int totalHP = 100;
    private int scoreNum, currentHP;
    private float multiplierTimer;
    private bool isMultiplied = false;

    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHP = 100;
        // scoreText.text = currentHP.ToString() + "/" + totalHP.ToString();
        
        SetHP();

    }

    void SetHP() {
        hpCircle.fillAmount = (float)currentHP / totalHP;
        
    }

    private void OnCollisionEnter2D(Collision2D ball_Col) {
        var particleEM = collisionParticleSystem.emission;
        var particleDur = collisionParticleSystem.main.duration;

        if (ball_Col.gameObject.tag == "Multiplier") {
            isMultiplied = true;
            multiplierTimer = Time.deltaTime;

            // print("multiplierTime: " + multiplierTimer);
            // print("isMultiplied: " + isMultiplied);
        }

        if (ball_Col.gameObject.tag == "MemoryBall") {     
            particleEM.enabled = true;
            collisionParticleSystem.Play();

            if(multiplierTimer >= 0.02) {
                multiplierTimer = 0;
                isMultiplied = false;
            }
            
            if (isMultiplied == true) {
                currentHP -= 4;
            }else{
                currentHP -= 2;
            }

            if (currentHP != 0) {
                // print("multiplierTime: " + multiplierTimer);
                // print("hit isMultiplied: " + isMultiplied);

                // scoreText.text = currentHP.ToString() + "/" + totalHP.ToString();
                SetHP();
            }

            // if (currentHP == 0) {

            // }

        }
    }

}
