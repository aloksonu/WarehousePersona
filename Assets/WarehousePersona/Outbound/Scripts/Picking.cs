using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Picking : MonoBehaviour
{
    [SerializeField] private Button btnPicking;
    [SerializeField] private Animator animator;
    private static readonly int AnimIdle = Animator.StringToHash("Idle");
    private static readonly int AnimPicking = Animator.StringToHash("Picking");
    void Start()
    {
        btnPicking.onClick.AddListener(OnClickPickingButton);
    }
    private void OnDestroy()
    {
        btnPicking.onClick.RemoveAllListeners();
    }
    private void OnClickPickingButton()
    {
        StartCoroutine(OnClickPickingButtonE());
    }

    private IEnumerator OnClickPickingButtonE()
    {
        btnPicking.enabled = false;
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger(AnimPicking);
        yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimPicking) + 0.2f);
        btnPicking.GetComponentInChildren<TextMeshProUGUI>().text = "Picking Completed";
        OutboundManager.Instance.StartDefOfPicking();

    }
}
