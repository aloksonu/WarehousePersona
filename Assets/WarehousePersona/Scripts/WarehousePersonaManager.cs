using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehousePersonaManager : MonoBehaviour
{
    [SerializeField] Transport transport;
    [SerializeField] GameObject transportEnvoirnment;
    [SerializeField] AssignGate assignGate;
    [SerializeField] GameObject assignGateEnvoirnment;
    private bool isTransportCompleted;
    private bool isCallAssignGate;

    void Start()
    {
        isTransportCompleted = false;
        isCallAssignGate = false;
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NInbound);
    }

    void FixedUpdate()
    {
        if (transport.transform.position.x < 38 && isTransportCompleted == false && isCallAssignGate == false)
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

        else if (transport.transform.position.x >= 38 && isCallAssignGate == false)
        {
            Fader.Instance.BringIn();
            isTransportCompleted = true;
            transport.rbd2.velocity = Vector2.left * 0;
            Debug.Log("Greater Value");

            if (isCallAssignGate == false)
            this.Invoke("callAssignGate", 2f);
        }
    }

    private void callAssignGate()
    {
       // transport.gameObject.SetActive(false);
        transportEnvoirnment.SetActive(false);
       // assignGate.gameObject.SetActive(true);
        assignGateEnvoirnment.SetActive(true);
        Fader.Instance.BringOut();
        isCallAssignGate = true;
    }
}
