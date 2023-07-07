using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace WarehousePersona.Outbound.Scripts
{
    public class OrderReceiving : MonoBehaviour
    {
        [SerializeField] private Button btnOrderReceiving;
        [SerializeField] private Animator animator;
        private static readonly int AnimIdle = Animator.StringToHash("Idle");
        private static readonly int AnimOrderReceiving = Animator.StringToHash("OrderReceiving");
        void Start()
        {
            btnOrderReceiving.onClick.AddListener(OnClickAnimOrderReceivingButton);
        }
        private void OnDestroy()
        {
            btnOrderReceiving.onClick.RemoveAllListeners();
        }
        private void OnClickAnimOrderReceivingButton()
        {
            StartCoroutine(OnClickAnimOrderReceivingButtonE());
        }

        private IEnumerator OnClickAnimOrderReceivingButtonE()
        {
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger(AnimOrderReceiving);
            yield return new WaitForSeconds(4f);
            animator.SetTrigger(AnimIdle);
            btnOrderReceiving.GetComponentInChildren<TextMeshProUGUI>().text = "Order Received";
            yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimOrderReceiving) + 2f);
            OutboundManager.Instance.StartDefOfOrderReceiving();
        }
    }
}
