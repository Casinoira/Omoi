using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // public TMP_Text scoreText;
    // public GameObject memoryBall;
    private int scoreNum, currentHP, ballVelocity, ballCount = 0;

    public Image hpCircle;
    public ParticleSystem collisionParticleSystem;
    public Rigidbody2D body;
    public GameObject ballClone, memoryBall;
    public float spawnDuration;
    public int  totalHP = 100, ballMaxCount = 3;

    void Start()
    {
        currentHP = totalHP;
        SetHP();

    }

    private void OnCollisionEnter2D(Collision2D ball_Col) {
        var particleEM = collisionParticleSystem.emission;
        var particleDur = collisionParticleSystem.main.duration;
        ballVelocity = (int)Mathf.Round(body.velocity.magnitude/50);

        // print("Velocity : " + ballVelocity);

        if (ball_Col.gameObject.tag == "Multiplier"){
            if(ballCount < ballMaxCount);
            GameObject tmpBall = Instantiate(ballClone, body.position, Quaternion.identity);
            ballCount++;

            StartCoroutine(SelfDestructBall(tmpBall));
        }

        if (ball_Col.gameObject.tag == "MemoryBall") {     
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

            if (currentHP == 0) {
                Destroy(memoryBall);
            }

        }
    }

    void SetHP() {
        hpCircle.fillAmount = (float)currentHP / totalHP;
        
    }

    IEnumerator SelfDestructBall(GameObject prefabBall) {
        yield return new WaitForSeconds(spawnDuration);

        Destroy(prefabBall);
        ballCount--;
    }
}
