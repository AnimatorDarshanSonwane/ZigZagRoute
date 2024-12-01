using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Reference to the parent GameObject
    GameObject parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can go here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic can go here if needed
    }

    // Method called when another collider exits this object's trigger collider
    private void OnTriggerExit(Collider col)
    {
        // Check if the object that exited the trigger has the tag "Ball"
        if (col.gameObject.tag == "Ball")
        {
            // Schedule the FallDown method to be called after a 0.5 second delay
            Invoke("FallDown", 0.5f);
        }
    }

    // Method to make the parent object fall down
    private void FallDown()
    {
        // Enable gravity and disable kinematic mode on the parent's Rigidbody
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;

        // Check if the GameObject has a parent
        if (transform.parent != null)
        {
            // Store the parent GameObject reference
            parentGameObject = transform.parent.gameObject;
        }
        else
        {
            // Log a message if the GameObject has no parent
            Debug.Log("This GameObject has no parent");
        }

        // Destroy the parent GameObject after 2 seconds
        Destroy(parentGameObject, 2f);
    }
}
