using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    
    public Transform spawnPoint;
    public GameObject bullet;
    public float cdToShoot = 0.5f;
    private float currentCd = 0;
    public void Shoot()
    {
        if(currentCd<Time.time)
        {
            Debug.Log("Shoot)");
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            currentCd = Time.time + cdToShoot;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
