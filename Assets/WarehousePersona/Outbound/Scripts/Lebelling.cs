using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Lebelling : MonoBehaviour
{
    [SerializeField] private Button btnLebelling;
    [SerializeField] private Animator animator;
    private static readonly int AnimIdle = Animator.StringToHash("Idle");
    private static readonly int AnimLebelling = Animator.StringToHash("Lebelling");
    void Start()
    {
        btnLebelling.onClick.AddListener(OnClickAnimLebellingButton);
    }
    private void OnDestroy()
    {
        btnLebelling.onClick.RemoveAllListeners();
    }
    private void OnClickAnimLebellingButton()
    {
        StartCoroutine(OnClickAnimLebellingButtonE());
    }

    private IEnumerator OnClickAnimLebellingButtonE()
    {
        yield return new WaitForSeconds(0.2f);
        //animator.SetTrigger(AnimLebelling);
        yield return new WaitForSeconds(4f);
        //animator.SetTrigger(AnimIdle);
        btnLebelling.GetComponentInChildren<TextMeshProUGUI>().text = "Lebelled";
        //yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimLebelling) + 2f);
        OutboundManager.Instance.StartDefOfLebelling();
    }
}
