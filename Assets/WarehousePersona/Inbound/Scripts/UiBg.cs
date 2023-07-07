using UnityEngine;
using Utilities;

namespace WarehousePersona.Inbound.Scripts
{
    public class UiBg : MonoSingleton<UiBg>
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        private float _fadeDuration = 0.2f;
        void Start()
        {
            _canvasGroup.UpdateState(false, 0);
        }
        internal void BringIn()
        {
            _canvasGroup.UpdateState(true, _fadeDuration);
        }
        internal void BringOut()
        {
            _canvasGroup.UpdateState(false, _fadeDuration);
        }
    }
}
