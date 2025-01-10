using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractKey : MonoBehaviour
{
    PlayerInteraction playerInteraction;
    public GameObject UIKey;

    private void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        UIKey.SetActive(false);
    }
    public void GetKey()
    {
        Destroy(gameObject);
        playerInteraction.getKey = true;
        UIKey.SetActive(true);
    }
}
