using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Putaway : MonoBehaviour
{
    [SerializeField] private Button btnPutaway;
    //[SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Animator animator;
    private static readonly int AnimIdle = Animator.StringToHash("Idle");
    private static readonly int AnimPutaway = Animator.StringToHash("Putaway");
    void Start()
    {
        btnPutaway.onClick.AddListener(OnClickPutawayButton);
    }

    private void OnDestroy()
    {
        btnPutaway.onClick.RemoveAllListeners();
    }
    private void OnClickPutawayButton()
    {
        StartCoroutine(OnClickPutawayButtonE());
    }

    private IEnumerator OnClickPutawayButtonE()
    {
        btnPutaway.enabled = false;
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger(AnimPutaway);
        yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimPutaway)+0.2f);
         btnPutaway.GetComponentInChildren<TextMeshProUGUI>().text = "Putaway Completed";
        yield return new WaitForSeconds(1f);
        InboundManager.Instance.callPutawayNarrator();

    }
}
