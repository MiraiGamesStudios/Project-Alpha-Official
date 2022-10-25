using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameObject[] SpawnVelo;
    public static GameObject[] SpawnTrice;
    public static GameObject[] SpawnAlpha;
    public static Player player;

    private enum Status { Mainmenu, Playing, Finished };
    Status statusPartida = Status.Mainmenu;

    public int round = 0;
    public float round1 = 150;

    public List<GameObject> barreras;
    public List<GameObject> enemys;



    // Start is called before the first frame update
    void Start()
    {
        SpawnVelo = GameObject.FindGameObjectsWithTag("SpawnVelo");
        SpawnTrice = GameObject.FindGameObjectsWithTag("SpawnTrice");
        SpawnAlpha = GameObject.FindGameObjectsWithTag("SpawnAlpha");
        Instance = this;

        //Generamos dinosaurios en los spawns de la primero area. 
        GameObject newDinosaur = Instantiate(enemys[0]);
        newDinosaur.transform.position = SpawnVelo[0].transform.position;

        GameObject newTri = Instantiate(enemys[1]);
        newTri.transform.position = SpawnTrice[0].transform.position;

        GameObject newAlpha = Instantiate(enemys[2]);
        newAlpha.transform.position = SpawnAlpha[0].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(round == 5)
        {
            barreras[0].SetActive(false);
        }else if (round == 10)
        {
            barreras[1].SetActive(false);
        }

        //FinishedCondition();
    }

    public void FinishedCondition()
    {
        //Si el jugador pierde toda la vida se termina la partida
        if (player.Health <=0)
        {
            statusPartida = Status.Finished;
        }
    }
}
