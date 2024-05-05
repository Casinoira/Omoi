using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplierBlock : MonoBehaviour
{
    private int ballCount = 0;
    public int ballMaxCount = 3;
    public float spawnDuration = 5f, spawnPosX = 0, spawnPosY = 0;
    public GameObject ballClone, multiplierBody;
    // public Rigidbody2D body;

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player"){
            Vector3 multipliedBallPosition = multiplierBody.transform.position;
            multipliedBallPosition.x += spawnPosX;
            multipliedBallPosition.y += spawnPosY;

            if(ballCount < ballMaxCount) {
                GameObject tmpBall = Instantiate(ballClone, multipliedBallPosition , Quaternion.identity);
                ballCount++;

                print("ballCount : " + ballCount);
                
                StartCoroutine(SelfDestructBall(tmpBall));
            }

        }
    }
    IEnumerator SelfDestructBall(GameObject prefabBall) {
        yield return new WaitForSeconds(spawnDuration);

        Destroy(prefabBall);
        ballCount--;
    }
}
