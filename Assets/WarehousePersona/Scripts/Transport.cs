using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    internal Rigidbody2D rbd2;
    internal float moveSpeed;
    internal bool isMove;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        moveSpeed = 1000f;
        isMove = false;
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
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NTransport);
    }
    public void MoveStop()
    {
        isMove = false;
    }
}
