
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    public GameObject winText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (winText != null)
            {
                winText.SetActive(true);
            }
        }
    }
}
