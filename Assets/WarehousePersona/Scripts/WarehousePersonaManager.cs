using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarehousePersonaManager : MonoBehaviour
{
    [SerializeField] Transport transport;
    [SerializeField] GameObject transportEnvoirnment;
    [SerializeField] AssignGate assignGate;
    [SerializeField] GameObject assignGateEnvoirnment;
    [SerializeField] Verification verification;
    [SerializeField] private GameObject[] _vCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] private Button btnTransport;
    [SerializeField] private Button btnAssignGate;
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
            //Fader.Instance.BringIn();
            isTransportCompleted = true;
            transport.rbd2.velocity = Vector2.left * 0;
            Debug.Log("Greater Value");

            if (isCallAssignGate == false)
            this.Invoke("callAssignGate", 2f);
        }

        if(assignGateEnvoirnment.activeInHierarchy == true && assignGate.transform.position.x < 3.7)
        { 
        if (assignGate.isMove == true)
        {
            assignGate.rbd2.velocity = Vector2.right * assignGate.moveSpeed * Time.deltaTime;
        }
        else
        {
            assignGate.rbd2.velocity = Vector2.left * 0;
        }
       }

        else if(assignGate.transform.position.x >= 3.7)
        {
            assignGate.rbd2.velocity = Vector2.left * 0;
            this.Invoke(nameof(CallNarratorText), 2f);
        }
    }

    private void callAssignGate()
    {
         Fader.Instance.BringIn();
        // transport.gameObject.SetActive(false);
        transportEnvoirnment.SetActive(false);
       // assignGate.gameObject.SetActive(true);
        assignGateEnvoirnment.SetActive(true);
        _vCam[1].SetActive(true);
        mainCam.transform.position = new Vector3(0,0,-10);
        this.Invoke(nameof(CallFader),3f);
        isCallAssignGate = true;
    }

    private void CallFader()
    {
        btnTransport.transform.gameObject.SetActive(false);
        btnAssignGate.transform.gameObject.SetActive(true);
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NAssignGate);
        Fader.Instance.BringOut();
    }
    private void CallNarratorText()
    {
        NarratorText.Instance.BringIn();
    }
}
