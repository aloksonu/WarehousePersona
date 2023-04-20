using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class OutboundVerification : MonoBehaviour
{
    [SerializeField] private Button btnVerification;
    [SerializeField] private Animator animator;
    private static readonly int AnimIdle = Animator.StringToHash("Idle");
    private static readonly int AnimVerification = Animator.StringToHash("Verification");
    void Start()
    {
        btnVerification.onClick.AddListener(OnClickAnimVerificationButton);
    }
    private void OnDestroy()
    {
        btnVerification.onClick.RemoveAllListeners();
    }
    private void OnClickAnimVerificationButton()
    {
        StartCoroutine(OnClickAnimVerificationButtonE());
    }

    private IEnumerator OnClickAnimVerificationButtonE()
    {
        yield return new WaitForSeconds(0.2f);
        //animator.SetTrigger(AnimVerification);
        yield return new WaitForSeconds(4f);
        //animator.SetTrigger(AnimIdle);
        btnVerification.GetComponentInChildren<TextMeshProUGUI>().text = "Verified";
        //yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimVerification) + 2f);
        OutboundManager.Instance.StartDefOfVerification();
    }
}
