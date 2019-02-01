using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PlayerController : MonoBehaviour
{
    public float speed;
    public Transform limiteSuperior;
    public Transform limiteInferior;
    public Transform limiteIzquierda;
    public Transform limiteDerecha;
    public Animator animComponent;
    public float idleThreshold = .02f;

    private bool death = false;
    private float moveSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        animComponent = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (death)
                return;
        if (Input.GetKeyDown(KeyCode.U))
        {
            Die();
        }
        moveSpeed = Input.GetAxis("Horizontal") * (speed * Time.deltaTime);
        transform.Translate(moveSpeed,
            0, 0);

        #region animations
        if (Mathf.Abs(moveSpeed) < idleThreshold)
            animComponent.SetBool("Moving", false);
        else if (moveSpeed < 0)
        {
            animComponent.SetBool("Moving", true);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveSpeed > 0)
        {
            animComponent.SetBool("Moving", true);
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        #endregion

        //if(Mathf.Abs(moveSpeed)<idleThreshold)
        //    animComponent.SetBool("Moving", false);
        //else
        //    animComponent.SetBool("Moving", true);

    }
    
    public void Die()
    {
        animComponent.SetTrigger("Death");
        death = true;
    }
     
    private void LateUpdate()
    {
        float up = limiteSuperior.position.y;
        float bottom = limiteInferior.position.y;
        float left = limiteIzquierda.position.x;
        float right = limiteDerecha.position.x;

        Vector3 desirePosition = transform.position;

        if (up < desirePosition.y)
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
