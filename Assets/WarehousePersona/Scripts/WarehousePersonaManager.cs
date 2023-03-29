using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehousePersonaManager : MonoBehaviour
{
    [SerializeField] Transport transport;
    private bool isTransportCompleted;
    void Start()
    {
        isTransportCompleted = false;
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NInbound);
    }

    void Update()
    {
        if (transport.isMove == true && isTransportCompleted == false && transport.transform.position.x <= 38)
        {
            transport.rbd2.velocity = Vector2.right * transport.moveSpeed * Time.deltaTime;
        }
        //if (transport.transform.localPosition.x >= 38)
        //{
        //    Fader.Instance.BringIn();
        //    isTransportCompleted = true;
        //    transport.rbd2.velocity = Vector2.left * 0;
        //}
        //if(transport.isMove == false && isTransportCompleted == false && transport.transform.position.x <= 38)
        //{
        //    transport.rbd2.velocity = Vector2.left * 0;
        //}
        else
        {
            transport.rbd2.velocity = Vector2.left * 0;
        }
    }
}
