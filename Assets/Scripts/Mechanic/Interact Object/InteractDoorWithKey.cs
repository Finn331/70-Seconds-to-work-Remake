using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractDoorWithKey : MonoBehaviour
{
    HUDController hUDController;
    public GameObject UIKey;
    //tambahin aja bool nya kalo pintu nya nambah
    public bool doorKeyA, doorKeyB, doorKeyC, doorkeyD = false;
    bool door = false;
    PlayerInteraction playerInteraction;
    Animator anim;

    void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        hUDController = FindObjectOfType<HUDController>();
        anim = GetComponent<Animator>();
        door = false;
    }

    public void ToogleDoor()
    {
        if (playerInteraction.getKey || doorKeyA || doorKeyB || doorKeyC || doorkeyD)
        {
            if (door)
            {
                //Masing masing door buat Animator sendiri, dengan Parameter Trigger, sesuaikan dengan nama "Close" "Open"
                anim.SetTrigger("Close");
            }
            else
            {
                anim.SetTrigger("Open");
            }

            // Cek nama GameObject yang punya script ini
            if (gameObject.name == "doorKeyA")
            {
                doorKeyA = true;
            }
            else if (gameObject.name == "doorKeyB")
            {
                doorKeyB = true;
            }
            else if (gameObject.name == "doorKeyC")
            {
                doorKeyC = true;
            }
            else if (gameObject.name == "doorkeyD")
            {
                doorkeyD = true;
            }

            UIKey.SetActive(false);
            playerInteraction.getKey = false;
            door = !door;
        }
        else
        {
            ShowText();
            hUDController.text.text = "Need a Key";
            Debug.Log("Kamu Butuh Kunci");
        }
    }

    private void ShowText()
    {
        hUDController.objectText.SetActive(true);
        hUDController.ShowTextt();
    }

}
