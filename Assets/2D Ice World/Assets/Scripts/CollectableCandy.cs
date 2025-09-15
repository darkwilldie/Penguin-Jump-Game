using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCandy : MonoBehaviour
{
    public GameObject collectEffect; // Assign in Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }
            // Find and notify the manager
            CollectableManager manager = FindObjectOfType<CollectableManager>();
            if (manager != null)
            {
                manager.AddCollectable();
            }
            Destroy(gameObject);
        }
    }
}
