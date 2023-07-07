using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace WarehousePersona.Inbound.Scripts
{
    public class Checking : MonoBehaviour
    {
        [SerializeField] private Button btnChecking;
        [SerializeField] private Animator animator;
        private static readonly int AnimIdle = Animator.StringToHash("Idle");
        private static readonly int AnimVerification = Animator.StringToHash("Verification");
        // Start is called before the first frame update
        void Start()
        {
            btnChecking.onClick.AddListener(OnClickCheckingButton);
        }
        private void OnDestroy()
        {
            btnChecking.onClick.RemoveAllListeners();
        }
        private void OnClickCheckingButton()
        {
            StartCoroutine(OnClickCheckingButtonE());
        }

        private IEnumerator OnClickCheckingButtonE()
        {
            btnChecking.enabled = false;
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger(AnimVerification);
            yield return new WaitForSeconds(2f);
            animator.SetTrigger(AnimIdle);
            yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimVerification) + 0.2f);
            btnChecking.GetComponentInChildren<TextMeshProUGUI>().text = "Checked";
            yield return new WaitForSeconds(1f);
            InboundManager.Instance.StartDefOfChecking();
            //InboundManager.Instance.callReceiving();
        }
    }
}
