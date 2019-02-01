using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public Transform limiteSuperior, limiteInferior;
    public Vector2 inputAxis = new Vector2();

    //COLISIONES
    public GameObject prefabExplosion;
    private void OnTriggerEnter(Collider obj)
    {
        switch (obj.tag)
        {
            case "Player":

                {
                    Instantiate(prefabExplosion,
                        transform.position, Quaternion.identity);
                    //obj.gameObject.GetComponent<A_PlayerController>().Die();
                    Destroy(obj);//TODO cambiar a gameover
                }
                break;
            case "Bullet":
                Destroy(obj);
                {
                    Instantiate(prefabExplosion,
                        transform.position, Quaternion.identity);
                    Destroy(this.gameObject);//TODO cambiar a gameover
                }
                break;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(inputAxis.x*(speed * Time.deltaTime),
                inputAxis.y*(speed * Time.deltaTime),0);


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
            desirePosition = new Vector3(desirePosition.x, bottom);
        }
        else if (bottom > desirePosition.y)
        {
            desirePosition = new Vector3(UnityEngine.Random.Range(left,right), up);
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
