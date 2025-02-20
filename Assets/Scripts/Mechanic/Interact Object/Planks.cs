using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planks : MonoBehaviour
{
    private Rigidbody rb;
    PickupObject pickupObject;
    SoundsManager soundsManager;
    // HUDController hUDController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupObject = FindObjectOfType<PickupObject>();
        soundsManager = FindObjectOfType<SoundsManager>();
        // hUDController = FindObjectOfType<HUDController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemovePlank()
    {
        if (pickupObject.objectBool)
        {
            rb.isKinematic = false;
            soundsManager.PlankSound();
        }
        else
        {
            ShowText();
            HUDController.instance.infoText.text = "Need Something";
            Debug.Log("Butuh Sesuatu");
        }
    }

    private void ShowText()
    {
        HUDController.instance.objectInfoText.SetActive(true);
        HUDController.instance.ShowTextt();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(RemoveObject());
            Debug.Log("Object Destroy");
        }
    }

    IEnumerator RemoveObject()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
