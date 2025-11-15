using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shootPoint;
    
    private ObjectPooling _objectPooling;

    private float timer;

    private void Start()
    {
        _objectPooling = GameObject.Find("Pool").GetComponent<ObjectPooling>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            Shoot();
            timer = 0;
        }
    }


    public void Shoot()
    {
        _objectPooling.GetObject(shootPoint.position, shootPoint.rotation);
    }
}
