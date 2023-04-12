using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignGate : MonoBehaviour
{
    internal Rigidbody2D rbd2;
    internal float moveSpeed;
    internal bool isMove;
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        moveSpeed = 700f;
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isMove == true && this.transform.position.x <= 3.7)
        //{
        //    rbd2.velocity = Vector2.right * moveSpeed * Time.deltaTime;
        //}
        //else
        //{
        //    rbd2.velocity = Vector2.left * 0;
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ProcessName>().strProcessName == "AssignGate")
        {
            Debug.Log("AssignGate Done");
            StartCoroutine(StartVarificationE());
        }
    }
    private IEnumerator StartVarificationE()
    {
        yield return new WaitForSeconds(2f);
        InboundManager.Instance.callVarification();
    }

    public void MoveStart()
    {
        isMove = true;
        rbd2.velocity = Vector2.right * moveSpeed * Time.deltaTime;
    }
    public void MoveStop()
    {
        isMove = false;
        rbd2.velocity = Vector2.left * 0;
    }
}
