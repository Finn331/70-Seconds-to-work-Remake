using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 70;
    private int currentHealth;
    public HealthBar healthBar;
    Handphone handphone;
    [SerializeField] string hitText;
    bool hit = false;
    [SerializeField] CanvasGroup healthBarCanvasGroup;

    void Start()
    {
        handphone = FindObjectOfType<Handphone>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // Opacity awal di-set 0 agar tidak terlihat
        if (healthBarCanvasGroup != null)
        {
            healthBarCanvasGroup.alpha = 0f;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Die!");
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Basement"))
        {
            InvokeRepeating("TakeDamage", 0f, 1f);
            FadeHealthBar(true);

            if (!hit)
            {
                handphone.text.text = hitText;
                handphone.text.enabled = true;
                StartCoroutine(RemoveText());

                HUDController.instance.UIPoisonMark.SetActive(true);
                hit = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Basement"))
        {
            CancelInvoke("TakeDamage");
        }
    }

    IEnumerator RemoveText()
    {
        yield return new WaitForSeconds(4f);
        handphone.text.enabled = false;
    }

    void FadeHealthBar(bool fadeIn)
    {
        float targetAlpha = fadeIn ? 1f : 0f;
        LeanTween.alphaCanvas(healthBarCanvasGroup, targetAlpha, 1f).setEase(LeanTweenType.easeOutQuad);
    }
}
