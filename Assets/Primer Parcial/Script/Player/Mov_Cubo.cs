using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Cubo : MonoBehaviour
{
    public float speed;
    public Transform limiteSuperior;
    public Transform limiteInferior;
    public Transform limiteIzquierda;
    public Transform limiteDerecha;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
            transform.Translate(Input.GetAxis("Horizontal") * (speed * Time.deltaTime),
                Input.GetAxis("Vertical") * (speed * Time.deltaTime), 0);
      
    }
    private void LateUpdate()
    {
        float up = limiteSuperior.position.y;
        float bottom = limiteInferior.position.y;
        float left = limiteIzquierda.position.x;
        float right = limiteDerecha.position.x;

        Vector3 desirePosition = transform.position;

        if(up < desirePosition.y)
        {
            desirePosition = new Vector3(desirePosition.x, bottom);
        }
        else if (bottom > desirePosition.y)
        {
            desirePosition = new Vector3(desirePosition.x, up);
        }

        //LO MISMO APLICADO A LOS LADOS

        if (right < desirePosition.x)
        {
            desirePosition = new Vector3(left, desirePosition.y);
        }
        else if (left > desirePosition.x)
        {
            desirePosition = new Vector3(right, desirePosition.y);
        }


        transform.position = desirePosition;

    }
}
