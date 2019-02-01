using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform limiteSuperior, limiteInferior;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.StartLevel(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
