using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    PlayerInteraction playerInteraction;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
    }

    [SerializeField] TMP_Text interactionText;

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + (" ") + playerInteraction.pickKey;
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
