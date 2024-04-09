using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryBall : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float speed;

    int NextPosIndex;
    Transform NextPos;

    // Start is called before the first frame update
    void Start()
    {
        NextPos = Positions[0];    
    }

    // Update is called once per frame
    void Update()
    {
        MoveMemoryBall();
    }

    void MoveMemoryBall() {
        if (transform.position == NextPos.position) {
            NextPosIndex++;

            if (NextPosIndex >= Positions.Length) {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];

        } else {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
        }
    }
}
