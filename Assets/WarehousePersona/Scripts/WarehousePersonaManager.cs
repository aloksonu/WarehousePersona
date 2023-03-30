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

    void FixedUpdate()
    {
        if (transport.transform.position.x < 38 && isTransportCompleted == false)
        {
            if (transport.isMove == true)
            {
                transport.rbd2.velocity = Vector2.right * transport.moveSpeed * Time.deltaTime;
                Debug.Log("Moving");
            }
            else
            {
                transport.rbd2.velocity = Vector2.left * 0;
                Debug.Log("Stoped");
            }
        }

        else if (transport.transform.position.x >= 38)
        {
            Fader.Instance.BringIn();
            isTransportCompleted = true;
            transport.rbd2.velocity = Vector2.left * 0;
            Debug.Log("Greater Value");
        }
    }
}
