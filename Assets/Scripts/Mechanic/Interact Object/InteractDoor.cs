using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractDoor : MonoBehaviour
{
    bool door = false;
    Animator anim;
    // public UnityEvent onOpen, onClose;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        door = false;
    }

    public void ToggleDoor()
    {
        if (door)
        {
            anim.SetTrigger("Close");
        }
        else
        {
            anim.SetTrigger("Open");
        }

        door = !door;
    }
}
