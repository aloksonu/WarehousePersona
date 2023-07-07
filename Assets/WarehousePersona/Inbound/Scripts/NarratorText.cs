using System;
using UnityEngine;
using Utilities;

namespace WarehousePersona.Inbound.Scripts
{
    public class NarratorText : MonoSingleton<NarratorText>
    {
        private static Action _onComplete;
        [SerializeField] private CanvasGroup _canvasGroup;
        private float _fadeDuration = 0.2f;
        void Start()
        {
            _canvasGroup.UpdateState(false, 0);
        }

        internal void BringIn(Action onComplete = null)
        {
            _onComplete = onComplete;
            _canvasGroup.UpdateState(true, _fadeDuration);
            Debug.Log("Start Fader");
        }

        internal void BringOut()
        {
            _canvasGroup.UpdateState(false, _fadeDuration);
        }
    }
}
