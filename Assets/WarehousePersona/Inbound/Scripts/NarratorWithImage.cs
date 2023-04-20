using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class NarratorWithImage : MonoSingleton<NarratorWithImage>
{
    private static Action _onCompleteNarrator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private Button btnClose;
    private string _narratorText;
    private float _fadeDuration = 0.2f;

    internal string NInbound = "";
    internal string NTransport = "";
    internal string NAssignLane = "";
    internal string NVerification = "";
    internal string NUnload = "";
    internal string NChecking = "";
    internal string NReceiving = "";
    internal string NPutAway = "";

    internal string NOrderReceiving = "";
    internal string NPicking = "";
    internal string NSorting = "";
    internal string NLebelling = "";
    internal string NLoading = "";
    internal string NVerification2 = "";
    internal string NShipping = "";
    void Start()
    {
        NInbound = "<b>Inbound Processes</b>";
        NTransport = "<b>Transport</b><br>The movement of goods from one location to another using various modes of transportation such as trucks , plane, or ships.";
        NAssignLane = "<b>Assign Lane</b><br>Large number of shipments or carriers being used every day";
        NVerification = "<b>Verification</b><br>Process in a warehouse involves confirming the accuracy and completeness of information related to the movement and storage of goods";
        NUnload = "<b>Unload</b><br>The process of removing or taking out packages or cargo from a vehicle or container upon arrival at its destination.";
        NChecking = "<b>Checking</b><br>Initiate, implement and enforce Quality control";
        NReceiving = "<b>Receiving</b><br>The process of replenishing stocked inventory in the warehouse";
        NPutAway = "<b>Put Away</b><br>It is a broad term that encompasses every stage in the process of receiving goods";

        NOrderReceiving = "<b>Order Receiving</b><br>The process of requesting a shipment to be sent to a specific location.";
        NPicking = "<b>Picking</b><br>The process of selecting and retrieving the items from the inventory to fulfill the order.";
        NSorting = "<b>Sorting</b><br>The process of organising the items based on their destination and shipment method.";
        NLebelling = "<b>Lebelling</b><br>The process of attaching shipping labels and other necessary information to the package.";
        NLoading = "<b>Loading</b><br>The process of placing the packages onto the transportation vehicle , such as a truck or cargo ship , in a secure and organized manner to ensure safe transport.";
        NVerification2 = "<b>Verification</b><br>The process of checking all the labels and other information before shipping.";
        NShipping = "<b>Shipping</b><br>Sending to an outbound loading gate for the assigned shipping/mailing container to load.";

        btnClose.onClick.AddListener(() => BringOutNarrator());
    }

    internal void BringInNarrator(string narratorText,
             Action onCompleteNarrator = null)
    {
        _narratorText = narratorText;
        panelText.text = _narratorText;
        _onCompleteNarrator = onCompleteNarrator;
        _canvasGroup.UpdateState(true, _fadeDuration);
    }

    internal void BringOutNarrator()
    {
        if (_onCompleteNarrator != null)
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {

                _onCompleteNarrator();
                _onCompleteNarrator = null;
            });

        }
    }
}
