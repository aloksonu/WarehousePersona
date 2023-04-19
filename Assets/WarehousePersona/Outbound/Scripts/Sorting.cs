using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Sorting : MonoBehaviour
{
    [SerializeField] private Button btnSorting;
    [SerializeField] private Animator animator;
    private static readonly int AnimIdle = Animator.StringToHash("Idle");
    private static readonly int AnimSorting = Animator.StringToHash("Sorting");
    void Start()
    {
        btnSorting.onClick.AddListener(OnClickAnimSortingButton);
    }
    private void OnDestroy()
    {
        btnSorting.onClick.RemoveAllListeners();
    }
    private void OnClickAnimSortingButton()
    {
        StartCoroutine(OnClickAnimSortingButtonE());
    }

    private IEnumerator OnClickAnimSortingButtonE()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger(AnimSorting);
        yield return new WaitForSeconds(2f);
        animator.SetTrigger(AnimIdle);
        btnSorting.GetComponentInChildren<TextMeshProUGUI>().text = "Item Sorted";
        yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimSorting) + 2f);
        //InboundManager.Instance.callChecking();
    }
}
