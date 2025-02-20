using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractKey : MonoBehaviour
{
    SoundsManager soundsManager;
    PlayerInteraction playerInteraction;
    public GameObject UIKey;

    private void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        soundsManager = FindObjectOfType<SoundsManager>();
        UIKey.SetActive(false);
    }
    public void GetKey()
    {
        UIKey.SetActive(true);
        Destroy(gameObject);
        playerInteraction.getKey = true;
        soundsManager.GetKeySound();
    }
}
