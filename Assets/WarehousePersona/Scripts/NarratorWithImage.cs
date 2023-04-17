using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

public class NarratorWithImage : MonoSingleton<NarratorPanel>
{
    private static Action _onCompleteNarrator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI panelText;
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
    void Start()
    {
        NInbound = "<b>Inbound Processes</b>";
        NTransport = "<b>Transport</b>";
        NAssignLane = "<b>Assign Lane</b><\n>Process in a warehouse involves confirming the accuracy and completeness of information related to the movement and storage of goods";
        NVerification = "<b>Verification</b>";
        NUnload = "<b>Unload</b>";
        NChecking = "<b>Checking</b>";
        NReceiving = "<b>Receiving</b>";
        NPutAway = "<b>Put Away</b>";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
