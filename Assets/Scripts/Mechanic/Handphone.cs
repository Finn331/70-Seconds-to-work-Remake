using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Handphone : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 backPosition;
    public RectTransform handphone;
    public float timeToMove;
    public AudioClip startAudio, moveAudio;
    AudioSource audioSource;
    public TMP_Text text;
    [SerializeField] string startText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(StartPhone());

        text.enabled = false;
        text.text = startText;
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
        yield return new WaitForSeconds(2f);
        PlayAudio();
        StartCoroutine(MovePhone());
    }

    IEnumerator MovePhone()
    {
        yield return new WaitForSeconds(2f);
        MoveToTarget();
        StartCoroutine(BackPosition());
    }

    IEnumerator BackPosition()
    {
        yield return new WaitForSeconds(4f);
        BackToTarget();

        text.enabled = true;
        StartCoroutine(Text());
    }

    IEnumerator Text()
    {
        yield return new WaitForSeconds(4f);
        text.enabled = false;
    }
}
