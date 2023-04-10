using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InboundManager : MonoBehaviour
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
    [SerializeField] private Button btnVarification;
    private bool isTransportCompleted;
    private bool isCallAssignGate;
    private bool isCallVarification;

    void Start()
    {
        isTransportCompleted = false;
        isCallAssignGate = false;
        isCallVarification = false;
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

        else if(assignGate.transform.position.x >= 3.7 && isCallVarification == false)
        {
            assignGate.rbd2.velocity = Vector2.left * 0;
            this.Invoke(nameof(callVarification), 2f);
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
        this.Invoke(nameof(CallFaderAssignGate),3f);
        isCallAssignGate = true;
    }

    private void CallFaderAssignGate()
    {
        btnTransport.transform.gameObject.SetActive(false);
        btnAssignGate.transform.gameObject.SetActive(true);
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NAssignGate);
        Fader.Instance.BringOut();
    }

    private void callVarification()
    {
        Fader.Instance.BringIn();
        assignGateEnvoirnment.SetActive(false);
        btnAssignGate.transform.gameObject.SetActive(false);
        verification.transform.gameObject.SetActive(true);
        btnVarification.transform.gameObject.SetActive(true);
        isCallVarification = true;
        this.Invoke(nameof(CallfaderVarification), 1f);
    }

    private void CallfaderVarification()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NVerification);
        Fader.Instance.BringOut();
    }
}
