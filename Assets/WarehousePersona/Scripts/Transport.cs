using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    internal Rigidbody2D rbd2;
    internal float moveSpeed;
    internal bool isMove;
    internal bool isMoveStarted;
    internal bool isMoveStoped;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        moveSpeed = 1000f;
        isMove = false;
        isMoveStarted = false;
        isMoveStoped = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isMove == true && this.transform.position.x <= 38)
        //{
        //    rbd2.velocity = Vector2.right * moveSpeed*Time.deltaTime;
        //}
        //else
        //{
        //    rbd2.velocity = Vector2.left * 0;
        //}
    }

    public void MoveStart()
    {
        isMove = true;
        isMoveStarted = true;
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NTransport);
    }
    public void MoveStop()
    {
        isMove = false;
        isMoveStoped = true;
    }
}
