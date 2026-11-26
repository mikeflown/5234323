using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public Transform spawnPoint;
    private bool hasSpawned = false;
    void OnTriggerEnter(Collider other)
    {
        if (hasSpawned) return;
        if (!other.CompareTag("Player")) return;
        hasSpawned = true;
        if (fallingObjectPrefab != null && spawnPoint != null)
        {
            Instantiate(fallingObjectPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            hasSpawned = false;
    }
}