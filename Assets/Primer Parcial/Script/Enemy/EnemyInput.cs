using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    public float cdToShoot = 0.1f;
    private float currentCD = 0;
    private BaseGun myGun;
    // Start is called before the first frame update
    void Start()
    {
        currentCD += Time.time;
        myGun = GetComponent<BaseGun>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > currentCD)
        {
            myGun.Shoot();
            currentCD = Time.time + cdToShoot;
        }
    }
}
