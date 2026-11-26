using UnityEngine;

public class PushableBox : MonoBehaviour
{
    public float pushForce = 8f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDir = (transform.position - collision.transform.position).normalized;
            rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
        }
    }
}
