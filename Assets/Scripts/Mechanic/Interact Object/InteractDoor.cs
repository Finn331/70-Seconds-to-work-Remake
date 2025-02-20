using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour
{
    private bool door = false;
    private bool isAnimating = false;
    private Animator anim;
    SoundsManager soundsManager;

    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
        anim = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        if (isAnimating) return; // Mencegah konflik animasi

        isAnimating = true;
        if (door)
        {
            anim.SetTrigger("Close");
            soundsManager.CloseDoorSound();
        }
        else
        {
            anim.SetTrigger("Open");
            soundsManager.OpenDoorSound();
        }
        StartCoroutine(ResetAnimationState());
        door = !door;
    }

    private IEnumerator ResetAnimationState()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        isAnimating = false;
    }
}