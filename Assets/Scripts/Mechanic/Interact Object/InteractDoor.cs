using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour
{
    private bool door = false;
    private bool isAnimating = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        if (isAnimating) return; // Mencegah konflik animasi

        isAnimating = true;
        if (door)
        {
            anim.SetTrigger("Close");
        }
        else
        {
            anim.SetTrigger("Open");
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