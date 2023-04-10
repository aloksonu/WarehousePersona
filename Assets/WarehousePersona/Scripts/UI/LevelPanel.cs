using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnInbound;
    private float _fadeDuration = 0.2f;
    private string _currentSceneName = "Inbound";
    void Start()
    {
        btnInbound.onClick.AddListener(OnInboundButtonPressed);
    }

    internal void OnInboundButtonPressed()
    {
        _canvasGroup.UpdateState(false, _fadeDuration, () => {
            StartCoroutine(_loadGame());
        });
    }

    private IEnumerator _loadGame()
    {
        LoadingPanel.Instance.BringIn();
        yield return SceneManager.LoadSceneAsync(_currentSceneName, LoadSceneMode.Additive);
        LoadingPanel.Instance.BringOut();
    }
}
