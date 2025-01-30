using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    private Rigidbody rb;
    PickupObject pickupObject;
    HUDController hUDController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupObject = FindObjectOfType<PickupObject>();
        hUDController = FindObjectOfType<HUDController>();
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
        }
        else
        {
            ShowText();
            hUDController.text.text = "Need Something";
            Debug.Log("Butuh Sesuatu");
        }
    }

    private void ShowText()
    {
        hUDController.objectText.SetActive(true);
        hUDController.ShowTextt();
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
