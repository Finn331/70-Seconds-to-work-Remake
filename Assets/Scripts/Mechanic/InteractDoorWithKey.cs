using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractDoorWithKey : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject objectText;
    public GameObject UIKey;
    //tambahin aja bool nya kalo pintu nya nambah
    public bool doorKeyA, doorKeyB, doorKeyC, doorkeyD = false;
    bool door = false;
    PlayerInteraction playerInteraction;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();
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
            text.text = "Need A Key";
            Debug.Log("Kamu Butuh Kunci");
        }
    }

    void ShowText()
    {
        objectText.SetActive(true);
        StartCoroutine(Text());
    }

    IEnumerator Text()
    {
        yield return new WaitForSeconds(2);
        objectText.SetActive(false);
    }
}
