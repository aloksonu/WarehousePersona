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
        moveSpeed = 500f;
        isMove = false;
        isMoveStarted = false;
        isMoveStoped = false;
    }

    // Update is called once per frame
    void Update()
    {

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
