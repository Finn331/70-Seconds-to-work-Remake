using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handphone : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 backPosition;
    public RectTransform handphone;
    public float timeToMove;
    public AudioSource audioSource;
    public AudioClip startAudio, moveAudio;
    // public AudioClip moveAudio;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartPhone());
    }

    public void MoveToTarget()
    {
        LeanTween.move(handphone, targetPosition, timeToMove);
        audioSource.PlayOneShot(moveAudio);
    }

    public void BackToTarget()
    {
        LeanTween.move(handphone, backPosition, timeToMove);
        audioSource.PlayOneShot(moveAudio);
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(startAudio);
    }

    IEnumerator StartPhone()
    {
        yield return new WaitForSeconds(3f);
        PlayAudio();
        StartCoroutine(MovePhone());
    }

    IEnumerator MovePhone()
    {
        yield return new WaitForSeconds(3f);
        MoveToTarget();
        StartCoroutine(BackPosition());
    }

    IEnumerator BackPosition()
    {
        yield return new WaitForSeconds(4f);
        BackToTarget();
    }
}
