using UnityEngine;
using TMPro;

public class FinishZone : MonoBehaviour
{
    [Header("UI")]
    public GameObject congratulationsPanel;
    public TMP_Text congratulationsText;
    public string message = "Congratulations!";
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Time.timeScale = 0f;
        if (congratulationsPanel != null)
        {
            congratulationsPanel.SetActive(true);
            if (congratulationsText != null)
                congratulationsText.text = message;
        }
        else
        {
            Debug.Log(message);
        }
    }
}