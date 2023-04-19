using System.Collections;
using TMPro;
using Ui.ScoreSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class QuizCompletePanel : MonoSingleton<QuizCompletePanel>
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI messegeTextMeshProUGUI;
    [SerializeField] private Button homeBtn;
    void Start()
    {
        canvasGroup.UpdateState(false, 0);
        homeBtn.onClick.AddListener(OnHomeButtonPressed);
    }
    private void OnDestroy()
    {
        homeBtn.onClick.RemoveListener(OnHomeButtonPressed);
        canvasGroup.UpdateState(false, 0);
    }

    internal void BringPanel()
    {
        messegeTextMeshProUGUI.text = "You have scored " + ScoreManager.Instance.GetScore().ToString() + "out of" + ScoreManager.Instance.GetMaxScore().ToString();
        canvasGroup.UpdateState(true);
    }

    internal void OnHomeButtonPressed()
    {
        StartCoroutine(UloadScene());
    }

    IEnumerator UloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("Inbound");
    }
}
