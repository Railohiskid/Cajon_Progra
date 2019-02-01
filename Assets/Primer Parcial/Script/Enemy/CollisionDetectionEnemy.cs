using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionEnemy : MonoBehaviour
{
    public GameObject prefabExplosion; //esto es la explosion son particulas
    private void OnTriggerEnter(Collider obj)
    {
        switch (obj.tag)
        {
            case "Player":
                Instantiate(prefabExplosion,
                        transform.position, Quaternion.identity);
                Destroy(this.gameObject);//TODO cambiar a gameover

                break;
            case "Bullet":
                Destroy(obj);
                Instantiate(prefabExplosion,
                    transform.position, Quaternion.identity);
                Destroy(this.gameObject);//TODO cambiar a gameover
                break;
        }

    }

}