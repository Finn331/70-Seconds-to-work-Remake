using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    [Header("Teleport Setting")]
    [SerializeField] Transform teleportPos; // Posisi tujuan teleportasi
    [SerializeField] GameObject blurImage; // Gambar blur untuk efek transisi

    private bool isTrigger;
    private Transform playerObj; // Pemain
    // Script Reference
    private FirstPersonController playerController;

    // Start is called before the first frame update
    void Start()
    {
        if (blurImage != null)
        {
            blurImage.SetActive(false); // Nonaktifkan blurImage di awal
        }
        else
        {
            Debug.LogWarning("blurImage is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (playerController != null)
            {
                playerController.enabled = false; // Nonaktifkan kontrol pemain selama teleportasi
            }

            if (blurImage != null)
            {
                blurImage.SetActive(true); // Aktifkan blurImage
                LeanTween.alpha(blurImage.GetComponent<RectTransform>(), 1, 0.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
                {
                    playerObj.transform.position = teleportPos.position; // Teleportasi pemain
                    LeanTween.alpha(blurImage.GetComponent<RectTransform>(), 0, 0.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
                    {
                        blurImage.SetActive(false); // Nonaktifkan blurImage setelah selesai
                        if (playerController != null)
                        {
                            playerController.enabled = true; // Aktifkan kembali kontrol pemain
                        }
                    });
                });
            }
            else
            {
                Debug.LogWarning("blurImage is not assigned!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = true;
            playerController = other.GetComponent<FirstPersonController>(); // Ambil komponen FirstPersonController dari pemain
            if (playerController == null)
            {
                Debug.LogWarning("FirstPersonController component not found on the player!");
            }
            playerObj = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }
}