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
        UIKey.SetActive(true);
        Destroy(gameObject);
        playerInteraction.getKey = true;
    }
}
