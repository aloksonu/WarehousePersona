using GamePlay.Quiz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class InboundManager : MonoSingleton<InboundManager>
{
    private const string QUIZ01 = "Whats the process of storing goods in warehouse called which also involves picking items from inventory and placing them on a pallet or shelf?";
    private const string QUIZ01_A = "Put Away.";
    private const string QUIZ01_B = "Importing.";
    private const string QUIZ01_C = "Exporting.";
    private const string QUIZ01_D = "Storage.";

    private const string QUIZ02 = "......... is a subject-oriented, integrated, time-variant, nonvolatile collection of data in support of management decisions.";
    private const string QUIZ02_A = "Data Warehousing.";
    private const string QUIZ02_B = "Data Mining.";
    private const string QUIZ02_C = "Web Mining.";
    private const string QUIZ02_D = "Text Mining.";

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
        // Fader.Instance.BringIn();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NTransport, CallFaderAssignGate);
        transportEnvoirnment.SetActive(false);
        assignGateEnvoirnment.SetActive(true);
        _vCam[1].SetActive(true);
       // this.Invoke(nameof(CallFaderAssignGate),2f);
        isCallAssignGate = true;
    }

    private void CallFaderAssignGate()
    {
        mainCam.transform.position = new Vector3(0, 0, -10);
        btnTransport.transform.gameObject.SetActive(false);
        btnAssignGate.transform.gameObject.SetActive(true);
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NAssignLane);
        //Fader.Instance.BringOut();
    }

    internal void callVarification()
    {
        //Fader.Instance.BringIn();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NAssignLane, CallfaderVarification);
        assignGateEnvoirnment.SetActive(false);
        btnAssignGate.transform.gameObject.SetActive(false);
        verification.transform.gameObject.SetActive(true);
        btnVarification.transform.gameObject.SetActive(true);
        isCallVarification = true;
       // this.Invoke(nameof(CallfaderVarification), 1f);
    }

    private void CallfaderVarification()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NVerification);
        //Fader.Instance.BringOut();
    }
    internal void callUnload()
    {
        // Fader.Instance.BringIn();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NVerification, CallfaderUnload);
        verification.transform.gameObject.SetActive(false);
        btnVarification.transform.gameObject.SetActive(false);
        unloadEnvoirnment.SetActive(true);
        btnUnload.transform.gameObject.SetActive(true);
        //this.Invoke(nameof(CallfaderUnload), 1f);
    }

    private void CallfaderUnload()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NUnload);
        //Fader.Instance.BringOut();
    }

    internal void callChecking()
    {
        //Fader.Instance.BringIn();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NUnload, CallfaderChecking);
        unloadEnvoirnment.SetActive(false);
        btnUnload.transform.gameObject.SetActive(false);
        checkingEnvoirnment.SetActive(true);
        btnChecking.transform.gameObject.SetActive(true);
        //this.Invoke(nameof(CallfaderChecking), 1f);
    }

    private void CallfaderChecking()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NChecking);
        //Fader.Instance.BringOut();
    }

    internal void callReceiving()
    {
        //Fader.Instance.BringIn();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NChecking, CallfaderReceiving);
        checkingEnvoirnment.SetActive(false);
        btnChecking.transform.gameObject.SetActive(false);
        receivingEnvoirnment.SetActive(true);
        btnReceiving.transform.gameObject.SetActive(true);
        //this.Invoke(nameof(CallfaderReceiving), 1f);
    }

    private void CallfaderReceiving()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NReceiving);
        //Fader.Instance.BringOut();
    }

    internal void callPutaway()
    {
        //Fader.Instance.BringIn();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NReceiving, CallfaderPutaway);
        receivingEnvoirnment.SetActive(false);
        btnReceiving.transform.gameObject.SetActive(false);
        putawayEnvoirnment.SetActive(true);
        btnPutaway.transform.gameObject.SetActive(true);
        //this.Invoke(nameof(CallfaderPutaway), 1f);
    }

    private void CallfaderPutaway()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NPutAway);
        //Fader.Instance.BringOut();
    }

    internal void callPutawayNarrator()
    {
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NPutAway, Quiz_01);
    }


    internal void Quiz_01()
    {
        Quizcontroller.Instance.BringQuizPanel(Quiz_02, Quiz_02, QUIZ01,
            QUIZ01_A, new string[]
            {
                    QUIZ01_B, QUIZ01_C, QUIZ01_D
            });
    }

    internal void Quiz_02()
    {
        Quizcontroller.Instance.BringQuizPanel(BringQuizCompletePanel, BringQuizCompletePanel, QUIZ02,
           QUIZ02_A, new string[]
           {
                    QUIZ02_B, QUIZ02_C, QUIZ02_D
           });
    }
    internal void Quiz_03()
    {
        //Quizcontroller.Instance.BringQuizPanel(Quiz_04, Quiz_04, QUIZ03,
        //    QUIZ03_A, new string[]
        //    {
        //           QUIZ03_B, QUIZ03_C, QUIZ03_D
        //    });
    }

    internal void BringQuizCompletePanel()
    {
        QuizCompletePanel.Instance.BringPanel();
    }
}
