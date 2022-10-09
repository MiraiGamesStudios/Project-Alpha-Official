using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Status status;
    public static GameManager Instance;
    public static GameObject[] SpawnPoints;
    public static Player player;

    public static Dinosaur[] enemigos;



    // Start is called before the first frame update
    void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        Instance = this;
        status = Status.Mainmenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 GetSpawnPoint()
    {
        int aux = Random.Range(0, SpawnPoints.Length - 1);
        Vector3 pos = SpawnPoints[aux].transform.position;
        return pos;
    }

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
