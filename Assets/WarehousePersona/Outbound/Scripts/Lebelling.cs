using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace WarehousePersona.Outbound.Scripts
{
    public class Lebelling : MonoBehaviour
    {
        [SerializeField] private Button btnLebelling;
        [SerializeField] private TextMeshProUGUI checkText;
        [SerializeField] private Animator animator1;
        private static readonly int AnimIdle1 = Animator.StringToHash("Idle1");
        private static readonly int AnimLebelling1 = Animator.StringToHash("Lebelling1");

        [SerializeField] private Animator animator2;
        private static readonly int AnimIdle2 = Animator.StringToHash("Idle2");
        private static readonly int AnimLebelling2 = Animator.StringToHash("Lebelling2");
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
            animator1.SetTrigger(AnimLebelling1);
            animator2.SetTrigger(AnimLebelling2);
            yield return new WaitForSeconds(animator1.GetAnimatorClipLength(AnimLebelling1) + 0.2f);
            btnLebelling.GetComponentInChildren<TextMeshProUGUI>().text = "Items Labelled";
            yield return new WaitForSeconds(2f);
            animator1.SetTrigger(AnimIdle1);
            //animator2.SetTrigger(AnimIdle2);
            checkText.text = "Labels Checked";
            yield return new WaitForSeconds(1f);
            OutboundManager.Instance.StartDefOfLebelling();
        }
    }
}
