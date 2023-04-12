using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Checking : MonoBehaviour
{
    [SerializeField] private Button btnChecking;
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
        yield return new WaitForSeconds(1f);
        btnChecking.GetComponentInChildren<TextMeshProUGUI>().text = "Checking Completed";
        yield return new WaitForSeconds(1f);
        InboundManager.Instance.callReceiving();
    }
}
