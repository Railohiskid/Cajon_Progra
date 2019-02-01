using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 DirectionalSpeed;
    public Transform limiteSuperior, limiteInferior;

    // Start is called before the first frame update
    void Start()
    {
        limiteSuperior = GameManager.Instance.Upperlimit;
        limiteInferior = GameManager.Instance.Bottomlimit;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(DirectionalSpeed.x * Time.deltaTime,
            DirectionalSpeed.y * Time.deltaTime, 0);
    }

    private void LateUpdate()
    {
        float up = limiteSuperior.position.y;
        float bottom = limiteInferior.position.y;
        float left = limiteSuperior.position.x;
        float right = limiteInferior.position.x;

        Vector3 desirePosition = transform.position;

        if (up < desirePosition.y)
        {
            Destroy(this.gameObject);
        }
        else if (bottom > desirePosition.y)
        {
            Destroy(this.gameObject);
        }

        //LO MISMO APLICADO A LOS LADOS

        if (right < desirePosition.x)
        {
            Destroy(this.gameObject);
        }
        else if (left > desirePosition.x)
        {
            Destroy(this.gameObject);
        }


        
    }
}
