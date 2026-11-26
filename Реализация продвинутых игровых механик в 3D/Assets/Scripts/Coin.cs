using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public float bobHeight = 0.3f;
    public float bobSpeed = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = startPos + new Vector3(0, y, 0);
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Wallet.Instance != null)
                Wallet.Instance.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
