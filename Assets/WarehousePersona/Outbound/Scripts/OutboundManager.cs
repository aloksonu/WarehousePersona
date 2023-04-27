using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class OutboundManager : MonoSingleton<OutboundManager>
{
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
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NOrderReceiving, StartPicking);
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
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NPicking, StartSorting);
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
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NSorting, StartLebelling);
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
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NLebelling, StartLoading);
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
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NLoading, StartVerification);
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
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NVerification2, StartShipping);
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
        NarratorWithImage.Instance.BringInNarrator(NarratorWithImage.Instance.NShipping, BringQuizCompletePanel);
    }

    internal void BringQuizCompletePanel()
    {
        QuizCompletePanel.Instance.BringPanel();
    }
}
