using System;
using TMPro;
using UnityEngine;
using Utilities;

public class NarratorPanel : MonoSingleton<NarratorPanel>
{
    private static Action _onCompleteNarrator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI panelText;
    private string _narratorText;
    private float _fadeDuration = 0.2f;

    internal string NInbound = "";
    internal string NTransport = "";
    internal string NAssignGate = "";
    internal string NVerification = "";
    void Start()
    {
        NInbound = "<b>Inbound Processes</b>";
        NTransport = "<b>Transport</b>";
        NAssignGate = "<b>Assign Lane</b>";
        NVerification = "<b>Verificationb>";
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
