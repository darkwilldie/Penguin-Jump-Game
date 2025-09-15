using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCandy : MonoBehaviour
{
    public GameObject collectEffect; // Assign a visual effect prefab in Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure your player GameObject is tagged "Player"
        {
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject); // Remove the candy
        }
    }
}
