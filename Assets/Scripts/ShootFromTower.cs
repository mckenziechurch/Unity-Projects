using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromTower : MonoBehaviour
{
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
