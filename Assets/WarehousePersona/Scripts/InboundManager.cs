using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class InboundManager : MonoSingleton<InboundManager>
{
    public Transport transport;
    public GameObject transportEnvoirnment;
    public AssignGate assignGate;
    public GameObject assignGateEnvoirnment;
    [SerializeField] Verification verification;
    public GameObject unloadEnvoirnment;
    public GameObject checkingEnvoirnment;
    public GameObject receivingEnvoirnment;
    public GameObject putawayEnvoirnment;
    [SerializeField] private GameObject[] _vCam;
    [SerializeField] GameObject mainCam;
    public  Button btnTransport;
    public  Button btnAssignGate;
    public Button btnVarification;
    public Button btnUnload;
    public Button btnChecking;
    public Button btnReceiving;
    public Button btnPutaway;
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

    //void FixedUpdate()
    //{
    //    if (transport.transform.position.x < 38 && isTransportCompleted == false && isCallAssignGate == false)
    //    {
    //        if (transport.isMove == true)
    //        {
    //            transport.rbd2.velocity = Vector2.right * transport.moveSpeed * Time.deltaTime;
    //            Debug.Log("Moving");
    //        }
    //        else
    //        {
    //            transport.rbd2.velocity = Vector2.left * 0;
    //            Debug.Log("Stoped");
    //        }
    //    }

    //    else if (transport.transform.position.x >= 38 && isCallAssignGate == false)
    //    {
    //        isTransportCompleted = true;
    //        transport.rbd2.velocity = Vector2.left * 0;
    //        Debug.Log("Greater Value");

    //        if (isCallAssignGate == false)
    //        this.Invoke("callAssignGate", 2f);
    //    }

    //    if(assignGateEnvoirnment.activeInHierarchy == true && assignGate.transform.position.x < 3.7)
    //    { 
    //    if (assignGate.isMove == true)
    //    {
    //        assignGate.rbd2.velocity = Vector2.right * assignGate.moveSpeed * Time.deltaTime;
    //    }
    //    else
    //    {
    //        assignGate.rbd2.velocity = Vector2.left * 0;
    //    }
    //   }

    //    else if(assignGate.transform.position.x >= 3.7 && isCallVarification == false)
    //    {
    //        assignGate.rbd2.velocity = Vector2.left * 0;
    //        this.Invoke(nameof(callVarification), 2f);
    //    }
    //}

    internal void callAssignGate()
    {
         Fader.Instance.BringIn();
        // transport.gameObject.SetActive(false);
        transportEnvoirnment.SetActive(false);
       // assignGate.gameObject.SetActive(true);
        assignGateEnvoirnment.SetActive(true);
        //_vCam[0].SetActive(false);
        _vCam[1].SetActive(true);
        //mainCam.transform.position = new Vector3(0,0,-10);
        this.Invoke(nameof(CallFaderAssignGate),2f);
        isCallAssignGate = true;
    }

    private void CallFaderAssignGate()
    {
        mainCam.transform.position = new Vector3(0, 0, -10);
        btnTransport.transform.gameObject.SetActive(false);
        btnAssignGate.transform.gameObject.SetActive(true);
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NAssignLane);
        Fader.Instance.BringOut();
    }

    internal void callVarification()
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
    internal void callUnload()
    {
        Fader.Instance.BringIn();
        verification.transform.gameObject.SetActive(false);
        btnVarification.transform.gameObject.SetActive(false);
        unloadEnvoirnment.SetActive(true);
        btnUnload.transform.gameObject.SetActive(true);
        this.Invoke(nameof(CallfaderUnload), 1f);
    }

    private void CallfaderUnload()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NUnload);
        Fader.Instance.BringOut();
    }

    internal void callChecking()
    {
        Fader.Instance.BringIn();
        unloadEnvoirnment.SetActive(false);
        btnUnload.transform.gameObject.SetActive(false);
        checkingEnvoirnment.SetActive(true);
        btnChecking.transform.gameObject.SetActive(true);
        this.Invoke(nameof(CallfaderChecking), 1f);
    }

    private void CallfaderChecking()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NChecking);
        Fader.Instance.BringOut();
    }

    internal void callReceiving()
    {
        Fader.Instance.BringIn();
        checkingEnvoirnment.SetActive(false);
        btnChecking.transform.gameObject.SetActive(false);
        receivingEnvoirnment.SetActive(true);
        btnReceiving.transform.gameObject.SetActive(true);
        this.Invoke(nameof(CallfaderReceiving), 1f);
    }

    private void CallfaderReceiving()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NReceiving);
        Fader.Instance.BringOut();
    }

    internal void callPutaway()
    {
        Fader.Instance.BringIn();
        receivingEnvoirnment.SetActive(false);
        btnReceiving.transform.gameObject.SetActive(false);
        putawayEnvoirnment.SetActive(true);
        btnPutaway.transform.gameObject.SetActive(true);
        this.Invoke(nameof(CallfaderPutaway), 1f);
    }

    private void CallfaderPutaway()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NPutAway);
        Fader.Instance.BringOut();
    }
}
