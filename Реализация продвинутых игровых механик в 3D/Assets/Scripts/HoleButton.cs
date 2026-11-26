using UnityEngine;

public class HoleButton : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var controller = other.GetComponent<CharacterController>();
        if (controller != null)
            controller.enabled = false;
        Collider[] colliders = other.GetComponents<Collider>();
        foreach (var col in colliders)
        {
            col.enabled = false;
        }
        var rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.linearVelocity = Vector3.down * 2f;
        }
        Debug.Log("Hole triggered! Player should fall now.");
    }
}