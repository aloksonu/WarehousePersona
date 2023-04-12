using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Verification : MonoBehaviour
{
    [SerializeField] private Button btnVarification;
    void Start()
    {
        btnVarification.onClick.AddListener(OnClickVerificationButton);
    }

    private void OnDestroy()
    {
        btnVarification.onClick.RemoveAllListeners();
    }
    private void OnClickVerificationButton()
    {
        StartCoroutine(OnClickVerificationButtonE());
    }

    private IEnumerator OnClickVerificationButtonE()
    {
        yield return new WaitForSeconds(1f);
        btnVarification.GetComponentInChildren<TextMeshProUGUI>().text = "Varification Completed";
        yield return new WaitForSeconds(1f);
        InboundManager.Instance.callUnload();
    }
}
