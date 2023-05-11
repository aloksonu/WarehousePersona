using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Receiving : MonoBehaviour
{
    [SerializeField] private Button btnReceiving;
    //[SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Animator animator;
    private static readonly int AnimIdle = Animator.StringToHash("Idle");
    private static readonly int AnimPutaway = Animator.StringToHash("Putaway");
    void Start()
    {
        btnReceiving.onClick.AddListener(OnClickReceivingButton);
    }
    private void OnDestroy()
    {
        btnReceiving.onClick.RemoveAllListeners();
    }
    private void OnClickReceivingButton()
    {
        StartCoroutine(OnClickReceivingButtonE());
    }

    private IEnumerator OnClickReceivingButtonE()
    {
        btnReceiving.enabled = false;
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger(AnimPutaway);
        yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimPutaway) + 0.2f);
        btnReceiving.GetComponentInChildren<TextMeshProUGUI>().text = "Receiving Completed";
        yield return new WaitForSeconds(1f);
        InboundManager.Instance.StartDefOfReceiving();
        //InboundManager.Instance.StartPutaway();

    }
}
