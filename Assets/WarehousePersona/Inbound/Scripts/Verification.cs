using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Verification : MonoBehaviour
{
    [SerializeField] private Button btnVerification;
    [SerializeField] private Animator animator;
    private static readonly int AnimIdle = Animator.StringToHash("Idle");
    private static readonly int AnimVerification = Animator.StringToHash("Verification");
    void Start()
    {
        btnVerification.onClick.AddListener(OnClickVerificationButton);
    }

    private void OnDestroy()
    {
        btnVerification.onClick.RemoveAllListeners();
    }
    private void OnClickVerificationButton()
    {
        StartCoroutine(OnClickVerificationButtonE());
    }

    private IEnumerator OnClickVerificationButtonE()
    {
        btnVerification.enabled = false;
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger(AnimVerification);
        yield return new WaitForSeconds(2f);
        animator.SetTrigger(AnimIdle);
        yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimVerification) + 0.2f);
        btnVerification.GetComponentInChildren<TextMeshProUGUI>().text = "Verified";
        yield return new WaitForSeconds(1f);
        InboundManager.Instance.StartDefOfVarification();
        //InboundManager.Instance.StartUnload();
    }
}
