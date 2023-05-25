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
    bool isCompleted;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        moveSpeed = 500f;
        isMove = false;
        isMoveStarted = false;
        isMoveStoped = false;
        isCompleted = false;
    }

    void FixedUpdate()
    {
        if (isMove == true && isCompleted == false)
        {
            this.rbd2.velocity = Vector2.right * moveSpeed * Time.deltaTime;
            //Debug.Log("Moving");
        }
        else
        {
            this.rbd2.velocity = Vector2.left * 0;
            //Debug.Log("Stoped");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<ProcessName>().strProcessName == "Transport")
        {
            Debug.Log("Transport Done");
            isCompleted = true;
            StartCoroutine(StartAssignGateE());
        }
    }

    private IEnumerator StartAssignGateE()
    {        
        yield return new WaitForSeconds(2f);
        InboundManager.Instance.StartDefOfTransport();
    }

    public void MoveStart()
    {
        isMove = true;
        //isMoveStarted = true;
        //rbd2.velocity = Vector2.right *moveSpeed * Time.deltaTime;
        
    }
    public void MoveStop()
    {
        isMove = false;
        //isMoveStoped = true;
        //rbd2.velocity = Vector2.left * 0;
    }
}
