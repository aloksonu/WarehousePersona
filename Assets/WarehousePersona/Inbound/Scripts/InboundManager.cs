using Audio.Warehouse;
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

    //public Transport transport;
    public GameObject transportEnvoirnment;
    //public AssignGate assignGate;
    public GameObject assignGateEnvoirnment;
    //[SerializeField] Verification verification;
    public GameObject verificationEnvoirnment;
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
        DesableAll();
        StartTransport();
    }


    private void DesableAll()
    {
        transportEnvoirnment.SetActive(false);
        btnTransport.transform.gameObject.SetActive(false);
        assignGateEnvoirnment.SetActive(false);
        btnAssignGate.transform.gameObject.SetActive(false);
        verificationEnvoirnment.SetActive(false);
        btnVarification.transform.gameObject.SetActive(false);
        unloadEnvoirnment.SetActive(false);
        btnUnload.transform.gameObject.SetActive(false);
        checkingEnvoirnment.SetActive(false);
        btnChecking.transform.gameObject.SetActive(false);
        receivingEnvoirnment.SetActive(false);
        btnReceiving.transform.gameObject.SetActive(false);
        putawayEnvoirnment.SetActive(false);
        btnPutaway.transform.gameObject.SetActive(false);
    }


    internal void StartTransport()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NTransport);
        transportEnvoirnment.SetActive(true);
        btnTransport.transform.gameObject.SetActive(true);
    }

    internal void StartDefOfTransport()
    {
        NarratorPanel.Instance.BringOutNarrator();
        _vCam[1].SetActive(true);
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NTransport, StartAssignGate, AudioName.Transport);
    }

    internal void StartAssignGate()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NAssignLane);
        transportEnvoirnment.SetActive(false);
        btnTransport.transform.gameObject.SetActive(false);
        assignGateEnvoirnment.SetActive(true);
        btnAssignGate.transform.gameObject.SetActive(true);
        mainCam.transform.position = new Vector3(0, 0, -10);
        isCallAssignGate = true;
    }

    internal void StartDefOfAssignGate()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NAssignLane, StartVarification, AudioName.AssignLane);
    }

    internal void StartVarification()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NVerification);
        assignGateEnvoirnment.SetActive(false);
        btnAssignGate.transform.gameObject.SetActive(false);
        verificationEnvoirnment.SetActive(true);
        btnVarification.transform.gameObject.SetActive(true);
        isCallVarification = true;
    }

    internal void StartDefOfVarification()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NVerification, StartUnload, AudioName.Verification1);
    }
    internal void StartUnload()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NUnload);
        verificationEnvoirnment.SetActive(false);
        btnVarification.transform.gameObject.SetActive(false);
        unloadEnvoirnment.SetActive(true);
        btnUnload.transform.gameObject.SetActive(true);
    }

    internal void StartDefOfUnload()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NUnload, StartChecking, AudioName.Unload);
    }

    internal void StartChecking()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NChecking);
        unloadEnvoirnment.SetActive(false);
        btnUnload.transform.gameObject.SetActive(false);
        checkingEnvoirnment.SetActive(true);
        btnChecking.transform.gameObject.SetActive(true);
    }

    internal void StartDefOfChecking()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NChecking, StartReceiving, AudioName.Checking);
    }

    internal void StartReceiving()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NReceiving);
        checkingEnvoirnment.SetActive(false);
        btnChecking.transform.gameObject.SetActive(false);
        receivingEnvoirnment.SetActive(true);
        btnReceiving.transform.gameObject.SetActive(true);
    }

    internal void StartDefOfReceiving()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NReceiving, StartPutaway, AudioName.Receiving);
    }

    internal void StartPutaway()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NPutAway);
        receivingEnvoirnment.SetActive(false);
        btnReceiving.transform.gameObject.SetActive(false);
        putawayEnvoirnment.SetActive(true);
        btnPutaway.transform.gameObject.SetActive(true);
    }

    internal void StartDefOfPutaway()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NPutAway, Quiz_01, AudioName.PutAway);
    }

    //internal void callPutawayNarrator()
    //{
    //    NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NPutAway, Quiz_01);
    //}


    internal void Quiz_01()
    {
        UiBg.Instance.BringIn();
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
