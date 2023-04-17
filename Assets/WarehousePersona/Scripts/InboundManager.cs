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

    internal void callAssignGate()
    {
         Fader.Instance.BringIn();
        transportEnvoirnment.SetActive(false);
        assignGateEnvoirnment.SetActive(true);
        _vCam[1].SetActive(true);
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
