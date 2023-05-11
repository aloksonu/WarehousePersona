using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Unload : MonoBehaviour
{
    [SerializeField] private Button btnUnload;
    [SerializeField] private Animator animator;
    private static readonly int AnimIdle = Animator.StringToHash("Idle");
    private static readonly int AnimUnload = Animator.StringToHash("Unload");
    void Start()
    {
        btnUnload.onClick.AddListener(OnClickUnloadButton);
    }

    private void OnDestroy()
    {
        btnUnload.onClick.RemoveAllListeners();
    }
    private void OnClickUnloadButton()
    {
        StartCoroutine(OnClickVerificationButtonE());
    }

    private IEnumerator OnClickVerificationButtonE()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger(AnimUnload);
        yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimUnload) + 2f);
        InboundManager.Instance.StartDefOfUnload();
        //InboundManager.Instance.StartChecking();
    }
}
