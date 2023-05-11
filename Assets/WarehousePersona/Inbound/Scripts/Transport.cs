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
        moveSpeed = 700f;
        isMove = false;
        isMoveStarted = false;
        isMoveStoped = false;
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<ProcessName>().strProcessName == "Transport")
        {
            Debug.Log("Transport Done");
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
        isMoveStarted = true;
        rbd2.velocity = Vector2.right *moveSpeed * Time.deltaTime;
        //NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NTransport);
    }
    public void MoveStop()
    {
        isMove = false;
        isMoveStoped = true;
        rbd2.velocity = Vector2.left * 0;
    }
}
