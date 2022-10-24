using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Status status;
    public static GameManager Instance;
    public static GameObject[] SpawnVelo;
    public static GameObject[] SpawnTrice;
    public static GameObject[] SpawnAlpha;
    public static Player player;

    public int round = 0;

    public List<GameObject> enemys;



    // Start is called before the first frame update
    void Start()
    {
        SpawnVelo = GameObject.FindGameObjectsWithTag("SpawnVelo");
        Instance = this;
        status = Status.Mainmenu;

        //Generamos dinosaurios en los spawns de la primero area. 
        GameObject newDinosaur = Instantiate(enemys[0]);
        newDinosaur.transform.position = SpawnVelo[0].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public static Vector3 GetSpawnPoint()
    //{
    //    int aux = Random.Range(0, SpawnPoints.Length - 1);
    //    Vector3 pos = SpawnPoints[aux].transform.position;
    //    return pos;
    //}

    public void FinishedCondition()
    {
        //Si el jugador pierde toda la vida se termina la partida
        /*if ( <= 0)
        {
            status.Value = Status.Finished;
        }*/
    }

    public enum Status
    {
        Mainmenu,
        Playing,
        Finished
    }
}
