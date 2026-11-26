using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;
    public GameObject messagePanel;
    public string message = "You teleported to a new location!";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = destination.position;
            other.transform.rotation = destination.rotation;
            if (messagePanel != null)
            {
                messagePanel.SetActive(true);
                var text = messagePanel.GetComponentInChildren<TMPro.TMP_Text>();
                if (text != null) text.text = message;
            }
            if (Wallet.Instance != null)
                Wallet.Instance.Show();
        }
    }
}
