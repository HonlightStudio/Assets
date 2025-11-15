using UnityEngine;

public class Tower : MonoBehaviour
{

    public Transform Gun;
    
    private Transform player;
    
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Gun.forward = player.position - Gun.position;
    }
}
