using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    public float delay = 1.5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(ReloadAfterDelay());
    }

    IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
