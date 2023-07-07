using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;
using WarehousePersona.Inbound.Scripts.Audio;
using WarehousePersona.Inbound.Scripts.UI;

namespace WarehousePersona.GameComplete
{
    public class LevelComplete : MonoSingleton<LevelComplete>
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button btnNext, btnHome;
        [SerializeField] private TextMeshProUGUI gameCompleteTextMeshProUGUI;
        private float _fadeDuration = 0.2f;

        private string _gameCompleteText = "Congratulation To Complete";
        void Start()
        {
            _canvasGroup.UpdateState(false, 0);
            btnNext.onClick.AddListener(OnNextButtonPressed);
            btnHome.onClick.AddListener(OnHomeButtonPressed);
        }
        private void OnDestroy()
        {
            btnNext.onClick.RemoveAllListeners();
            btnHome.onClick.RemoveAllListeners();
        }
        internal void BringIn(float fadeDuration = 0.2f)
        {
            _fadeDuration = fadeDuration;
            gameCompleteTextMeshProUGUI.text = _gameCompleteText + " " + LevelPanel.Instance._currentSceneName;
            _canvasGroup.UpdateState(true, _fadeDuration);
            //UnlockNextLevel();
        }
        internal void BringOut()
        {
            _canvasGroup.UpdateState(false, _fadeDuration);
        }
        internal void OnNextButtonPressed()
        {
            GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            //_canvasGroup.UpdateState(false, _fadeDuration);
            StartCoroutine(LoadNextScene());
        }
        internal void OnHomeButtonPressed()
        {
            GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            StartCoroutine(UnloadScene());
        }


        IEnumerator UnloadScene()
        {
            yield return SceneManager.UnloadSceneAsync(LevelPanel.Instance._currentSceneName.ToString());
            _canvasGroup.UpdateState(false, 0);
            LevelPanel.Instance.BringIn();
        }
        IEnumerator LoadNextScene()
        {
    
            yield return SceneManager.UnloadSceneAsync(LevelPanel.Instance._currentSceneName.ToString());

            if (LevelPanel.Instance._currentSceneName == "Inbound")
            {
                LevelPanel.Instance._currentSceneName = "Outbound";
                yield return SceneManager.LoadSceneAsync(LevelPanel.Instance._currentSceneName.ToString(), LoadSceneMode.Additive);
            }
            else
            {
                // LevelPanel.Instance._currentSceneName = LevelsName.CETinterface;
            }
            _canvasGroup.UpdateState(false, 0);
        }
    }
}
