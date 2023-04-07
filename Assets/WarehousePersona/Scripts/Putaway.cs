using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Putaway : MonoBehaviour
{
    [SerializeField] private Button btnPutaway;
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
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger(AnimPutaway);
    }
}
