using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BaseGun))]
public class Player_Input : MonoBehaviour
{
    private BaseGun myGun;
    // Start is called before the first frame update
    void Start()
    {
        myGun = GetComponent<BaseGun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            myGun.Shoot();
        }
    }
}
