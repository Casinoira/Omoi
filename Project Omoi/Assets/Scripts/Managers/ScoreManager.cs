using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int scoreNum, currentHP, ballVelocity;

    public Image hpCircle;
    public ParticleSystem collisionParticleSystem;
    public Rigidbody2D ballBody;
    public GameObject memoryBall;
    public int  totalHP = 100, sceneBuildIndex;

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

            
            if (currentHP < totalHP / 2) {
                currentHP -= (ballVelocity + 3);
            } else {
                currentHP -= (ballVelocity + 1);

            }

            print("ballVelocity: " + ballVelocity);
            print("ballVelocity: " + currentHP);

            if (currentHP != 0) {
                SetHP();
            }

            if (currentHP <= 0) {
                Destroy(memoryBall);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }

        }
    }

    void SetHP() {
        hpCircle.fillAmount = (float)currentHP / totalHP;
    }

}
