using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutawayEvent : MonoBehaviour
{
    public GameObject spriteRenderer;
    void Start()
    {
        
    }

    public void CallEvent()
    {
        spriteRenderer.SetActive(true);
    }
}
