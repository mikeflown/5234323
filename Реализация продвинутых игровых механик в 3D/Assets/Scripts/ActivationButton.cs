using UnityEngine;
using TMPro;

public class ActivationButton : MonoBehaviour
{
    public enum ButtonType { Panel, Wall }
    public ButtonType type;
    public GameObject targetObject;
    public string message = "Message!";
    public GameObject panel;
    public TMP_Text messageText;
    [Header("Tags")]
    public string playerTag = "Player";
    public string boxTag = "Box";
    private int objectsOnButton = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) || other.CompareTag(boxTag))
        {
            objectsOnButton++;
            Activate();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag) || other.CompareTag(boxTag))
        {
            objectsOnButton--;
            if (objectsOnButton <= 0)
            {
                objectsOnButton = 0;
                Deactivate();
            }
        }
    }
    void Activate()
    {
        if (type == ButtonType.Panel && panel != null)
        {
            panel.SetActive(true);
            if (messageText != null) messageText.text = message;
        }
        else if (type == ButtonType.Wall && targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
    void Deactivate()
    {
        if (type == ButtonType.Panel && panel != null)
        {
            panel.SetActive(false);
        }
        else if (type == ButtonType.Wall && targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}