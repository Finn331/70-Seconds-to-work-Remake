using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    PlayerInteraction playerInteraction;
    public TMP_Text infoText;
    public GameObject objectInfoText;

    public GameObject UIPoisonMark;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        UIPoisonMark.SetActive(false);
    }

    [SerializeField] TMP_Text interactionObjectText;

    public void EnableInteractionText(string text)
    {
        interactionObjectText.text = text + (" ") + playerInteraction.pickKey;
        interactionObjectText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionObjectText.gameObject.SetActive(false);
    }

    IEnumerator Text()
    {
        yield return new WaitForSeconds(2);
        objectInfoText.SetActive(false);
    }

    public void ShowTextt()
    {
        StartCoroutine(Text());
    }
}
