using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PendulumHit : MonoBehaviour
{
    [Header("Knockback")]
    public float knockbackForce = 25f;
    public float upwardForce = 8f;
    [Header("Rotation")]
    public float torqueForce = 20f;
    public Vector3 torqueMultiplier = new Vector3(1f, 1f, 1f);
    [Header("Reload")]
    public float reloadDelay = 3f;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var player = other.gameObject;
        var controller = player.GetComponent<CharacterController>();
        var rb = player.GetComponent<Rigidbody>();
        var playerScript = player.GetComponent<PlayerController>();
        if (controller != null) controller.enabled = false;
        if (playerScript != null) playerScript.enabled = false;
        var cameraScript = Object.FindAnyObjectByType<ThirdPersonCamera>();
        if (cameraScript != null)
            cameraScript.DisableRotationFollow();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            Vector3 knockDir = (player.transform.position - transform.position).normalized;
            knockDir.y = 0;
            Vector3 force = knockDir * knockbackForce + Vector3.up * upwardForce;
            rb.AddForce(force, ForceMode.Impulse);
            Vector3 torque = new Vector3(
                Random.Range(-2f, 2f) * torqueMultiplier.x,
                Random.Range(-2f, 2f) * torqueMultiplier.y,
                Random.Range(-2f, 2f) * torqueMultiplier.z
            ).normalized * torqueForce;
            rb.AddTorque(torque, ForceMode.Impulse);
        }
        StartCoroutine(ReloadAfterDelay());
    }
    IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(reloadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}