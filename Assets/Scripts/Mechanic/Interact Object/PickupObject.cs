using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private PlayerInteraction playerInteraction;
    [SerializeField] private Transform objectPoint;
    public bool objectBool = false;
    private Rigidbody rb;
    Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        outline = GetComponent<Outline>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        objectBool = false;
    }

    public void Grab()
    {
        if (Input.GetKeyDown(playerInteraction.pickKey) && !objectBool)
        {
            objectBool = true;
            if (objectBool)
            {
                transform.position = objectPoint.position;

                rb.useGravity = false;
                rb.isKinematic = true;
                Debug.Log("Pick Object");
            }
        }
    }

    private void FixedUpdate()
    {
        if (objectBool)
        {
            rb.MovePosition(objectPoint.position);
            rb.MoveRotation(objectPoint.rotation);

            outline.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.G) && objectBool)
        {
            rb.useGravity = true;
            rb.isKinematic = false;

            rb.MovePosition(transform.position);
            rb.MoveRotation(transform.rotation);

            objectBool = false;
            Debug.Log("Drop Object");
        }
    }
}
