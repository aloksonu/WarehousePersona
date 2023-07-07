using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace WarehousePersona.Outbound.Scripts
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] private Button btnLoading;
        [SerializeField] private Animator animator;
        private static readonly int AnimIdle = Animator.StringToHash("Idle");
        private static readonly int AnimLoading = Animator.StringToHash("Loading");
        void Start()
        {
            btnLoading.onClick.AddListener(OnClickLoadingButton);
        }
        private void OnDestroy()
        {
            btnLoading.onClick.RemoveAllListeners();
        }
        private void OnClickLoadingButton()
        {
            StartCoroutine(OnClickLoadingButtonE());
        }

        private IEnumerator OnClickLoadingButtonE()
        {
            btnLoading.enabled = false;
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger(AnimLoading);
            yield return new WaitForSeconds(animator.GetAnimatorClipLength(AnimLoading) + 0.2f);
            btnLoading.GetComponentInChildren<TextMeshProUGUI>().text = "Loading Completed";
            OutboundManager.Instance.StartDefOfLoading();

        }
    }
}
