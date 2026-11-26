using UnityEngine;
using UnityEngine.InputSystem;

public class CloseOnAnyKey : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
            gameObject.SetActive(false);
    }
}