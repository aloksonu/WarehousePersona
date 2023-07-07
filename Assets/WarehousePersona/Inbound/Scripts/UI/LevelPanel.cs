using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;
using WarehousePersona.Inbound.Scripts.Audio;

namespace WarehousePersona.Inbound.Scripts.UI
{
    public class LevelPanel : MonoSingleton<LevelPanel>
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button btnInbound;
        [SerializeField] private Button btnOutbound;
        private float _fadeDuration = 0.2f;
        internal string _currentSceneName = "Inbound";
        void Start()
        {
            btnInbound.onClick.AddListener(()=>OnInboundButtonPressed("Inbound"));
            btnOutbound.onClick.AddListener(() => OnInboundButtonPressed("Outbound"));
        }

        internal void OnInboundButtonPressed(string currentSceneName)
        {
            _currentSceneName = currentSceneName;
            GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            _canvasGroup.UpdateState(false, _fadeDuration, () => {
                StartCoroutine(_loadGame(currentSceneName));
            });
        }

        private IEnumerator _loadGame(string currentSceneName)
        {
            //GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            //yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(AudioName.ButtonClick));
            LoadingPanel.Instance.BringIn();
            yield return SceneManager.LoadSceneAsync(currentSceneName, LoadSceneMode.Additive);
            LoadingPanel.Instance.BringOut();
            _canvasGroup.UpdateState(true);
        }
        internal void BringIn()
        {
            _canvasGroup.UpdateState(true, _fadeDuration);
        }
    }

    public enum LevelsName
    {

        NotSet = -1,
        Inbound = 0,
        Outbound = 1,
    }
}