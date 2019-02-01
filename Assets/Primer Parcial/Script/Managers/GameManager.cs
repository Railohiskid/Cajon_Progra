using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                //nstance = AvatarIKGoal.GetComponent<GameManager>();
            }
            return _instance;
        }

            
        private set { _instance = value; }
    }

    private LevelManager m_levelManager;

    public void StartLevel (LevelManager levelManager)
    {
        m_levelManager = levelManager;
    }


    public Transform Upperlimit
    {
        get { return m_levelManager.limiteSuperior; }
    }


    public Transform Bottomlimit
    {
        get { return m_levelManager.limiteInferior; }
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
