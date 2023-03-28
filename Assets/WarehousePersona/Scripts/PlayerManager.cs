using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rbd2;
    private float moveSpeed;
    private bool isMove;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        moveSpeed = 700f;
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true && this.transform.position.x <= 47)
        {
            rbd2.velocity = Vector2.right * moveSpeed*Time.deltaTime;
        }
        else
        {
            rbd2.velocity = Vector2.left * 0;
        }
    }

    public void MoveStart()
    {
        isMove = true;
    }
    public void MoveStop()
    {
        isMove = false;
    }
}
