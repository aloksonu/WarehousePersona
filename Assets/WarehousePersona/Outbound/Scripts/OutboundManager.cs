using Audio.Warehouse;
using GamePlay.Quiz;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class OutboundManager : MonoSingleton<OutboundManager>
{

    private const string QUIZ01 = "The process of organising the items based on their destination and shipment method called ......";
    private const string QUIZ01_A = "Sorting.";
    private const string QUIZ01_B = "Receiving.";
    private const string QUIZ01_C = "Lebelling.";
    private const string QUIZ01_D = "Shipping.";

    private const string QUIZ02 = "......... is a The process of selecting and retrieving the items from the inventory to fulfill the order";
    private const string QUIZ02_A = "Picking.";
    private const string QUIZ02_B = "Sorting.";
    private const string QUIZ02_C = "Lebelling.";
    private const string QUIZ02_D = "Shipping.";

    public GameObject orderReceivingEnvoirnment;
    public Button btnOrderReceiving;

    public GameObject pickingEnvoirnment;
    public Button btnPicking;

    public GameObject sortingEnvoirnment;
    public Button btnSorting;

    public GameObject lebellingEnvoirnment;
    public Button btnLebelling;

    public GameObject loadingEnvoirnment;
    public Button btnLoading;

    public GameObject verificationEnvoirnment;
    public Button btnVerification;

    public GameObject shippingEnvoirnment;
    public Button btnShipping;
    void Start()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NOutbound);
         DesableAll();
        StartOrderReceiving();
        //StartLebelling();
        //StartVerification();
    }

    private void DesableAll()
    {
        orderReceivingEnvoirnment.SetActive(false);
        btnOrderReceiving.transform.gameObject.SetActive(false);
        pickingEnvoirnment.SetActive(false);
        btnPicking.transform.gameObject.SetActive(false);
        sortingEnvoirnment.SetActive(false);
        btnSorting.transform.gameObject.SetActive(false);
        lebellingEnvoirnment.SetActive(false);
        btnLebelling.transform.gameObject.SetActive(false);
        loadingEnvoirnment.SetActive(false);
        btnLoading.transform.gameObject.SetActive(false);
        verificationEnvoirnment.SetActive(false);
        btnVerification.transform.gameObject.SetActive(false);
        shippingEnvoirnment.SetActive(false);
        btnShipping.transform.gameObject.SetActive(false);
    }

    internal void StartOrderReceiving()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NOrderReceiving);
        orderReceivingEnvoirnment.SetActive(true);
        btnOrderReceiving.transform.gameObject.SetActive(true);
    }

    internal void StartDefOfOrderReceiving()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NOrderReceiving, StartPicking, AudioName.OrderReceiving);
    }
    internal void StartPicking()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NPicking);
        orderReceivingEnvoirnment.SetActive(false);
        btnOrderReceiving.transform.gameObject.SetActive(false);
        pickingEnvoirnment.SetActive(true);
        btnPicking.transform.gameObject.SetActive(true);
    }

    internal void StartDefOfPicking()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NPicking, StartSorting, AudioName.Picking);
    }
    internal void StartSorting()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NSorting);
        pickingEnvoirnment.SetActive(false);
        btnPicking.transform.gameObject.SetActive(false);
        sortingEnvoirnment.SetActive(true);
        btnSorting.transform.gameObject.SetActive(true);
    }
    internal void StartDefOfSorting()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NSorting, StartLebelling, AudioName.Sorting);
    }

    internal void StartLebelling()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NLebelling);
        sortingEnvoirnment.SetActive(false);
        btnSorting.transform.gameObject.SetActive(false);
        lebellingEnvoirnment.SetActive(true);
        btnLebelling.transform.gameObject.SetActive(true);
    }
    internal void StartDefOfLebelling()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NLebelling, StartLoading, AudioName.Lebelling);
    }

    internal void StartLoading()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NLoading);
        lebellingEnvoirnment.SetActive(false);
        btnLebelling.transform.gameObject.SetActive(false);
        loadingEnvoirnment.SetActive(true);
        btnLoading.transform.gameObject.SetActive(true);
    }
    internal void StartDefOfLoading()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NLoading, StartVerification, AudioName.Loading);
    }

    internal void StartVerification()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NVerification2);
        loadingEnvoirnment.SetActive(false);
        btnLoading.transform.gameObject.SetActive(false);
        verificationEnvoirnment.SetActive(true);
        btnVerification.transform.gameObject.SetActive(true);
    }
    internal void StartDefOfVerification()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NVerification2, StartShipping, AudioName.Verification2);
    }

    internal void StartShipping()
    {
        NarratorPanel.Instance.BringInNarrator(NarratorPanel.Instance.NShipping);
        verificationEnvoirnment.SetActive(false);
        btnVerification.transform.gameObject.SetActive(false);
        shippingEnvoirnment.SetActive(true);
        btnShipping.transform.gameObject.SetActive(true);
    }
    internal void StartDefOfShipping()
    {
        NarratorPanel.Instance.BringOutNarrator();
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NShipping,CallLevelComplete, AudioName.Shipping);
    }
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
    private void CallLevelComplete()
    {
        LevelComplete.Instance.BringIn();
    }
}
