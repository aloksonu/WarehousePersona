using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class OutboundVerification : MonoBehaviour
{
    [SerializeField] private Button btnVerification;
    [SerializeField] private Animator animator1;
    private static readonly int AnimIdle1 = Animator.StringToHash("Idle1");
    private static readonly int AnimVerification1 = Animator.StringToHash("Lebelling1");

    [SerializeField] private Animator animator2;
    private static readonly int AnimIdle2 = Animator.StringToHash("Idle2");
    private static readonly int AnimVerification2 = Animator.StringToHash("Lebelling2");
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
        animator1.SetTrigger(AnimVerification1);
        animator2.SetTrigger(AnimVerification2);
        yield return new WaitForSeconds(4f);
        animator1.SetTrigger(AnimIdle1);
        animator2.SetTrigger(AnimIdle2);
        btnVerification.GetComponentInChildren<TextMeshProUGUI>().text = "Verified";
        yield return new WaitForSeconds(1f);
        OutboundManager.Instance.StartDefOfVerification();
    }
}
