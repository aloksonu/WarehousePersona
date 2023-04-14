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
    [SerializeField] private Button btnOutbound;
    private float _fadeDuration = 0.2f;
    private string _currentSceneName = "Inbound";
    void Start()
    {
        btnInbound.onClick.AddListener(()=>OnInboundButtonPressed("Inbound"));
        btnOutbound.onClick.AddListener(() => OnInboundButtonPressed("Outbound"));
    }

    internal void OnInboundButtonPressed(string currentSceneName)
    {
        _canvasGroup.UpdateState(false, _fadeDuration, () => {
            StartCoroutine(_loadGame(currentSceneName));
        });
    }

    private IEnumerator _loadGame(string currentSceneName)
    {
        LoadingPanel.Instance.BringIn();
        yield return SceneManager.LoadSceneAsync(currentSceneName, LoadSceneMode.Additive);
        LoadingPanel.Instance.BringOut();
    }
}
