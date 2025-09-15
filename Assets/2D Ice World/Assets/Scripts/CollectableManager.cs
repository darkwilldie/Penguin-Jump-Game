using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    public Transform starContainer; // Assign in Inspector (e.g., a Horizontal Layout Group)
    public GameObject StarPrefab;   // Assign in Inspector (Prefab with Image component using your PNG)
    private int collectedCount = 0;
    private List<GameObject> stars = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCollectable()
    {
        collectedCount++;
        if (starContainer != null && StarPrefab != null)
        {
            GameObject newStar = Instantiate(StarPrefab, starContainer);
            stars.Add(newStar);
        }
    }
}
