using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.up * speed;
    }

    
}
