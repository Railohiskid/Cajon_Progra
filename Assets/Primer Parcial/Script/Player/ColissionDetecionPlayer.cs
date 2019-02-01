using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionDetecionPlayer : MonoBehaviour

{
    public int life = 1;
    public GameObject prefabExplosión;
    public GameObject Respawn;
    private void OnTriggerEnter(Collider obj)
    {
        switch (obj.tag)
        {
            case "Enemy":
                if (life>0)
                {
                    life--;
                }
                else
                {
                    Instantiate(prefabExplosión, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
                break;

            case "Bullet":
                Destroy(obj);
                if (life > 0)
                {
                    life--;//life = life -1;
                    gameObject.GetComponent<Animator>().Play("Respawn");
                }
                else
                {
                    Instantiate(prefabExplosión,
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
        
    }
}
