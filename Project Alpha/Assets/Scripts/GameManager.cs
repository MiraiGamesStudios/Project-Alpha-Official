using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameObject[] SpawnVelo;
    public static GameObject[] SpawnTrice;
    public static GameObject[] SpawnAlpha;
    int velo;
    int trice;
    int alpha;
    int dinosVivos = 0;
    bool spawneados = false;

    public static Player player;

    private enum Status { Mainmenu, Playing, Finished };
    Status statusPartida = Status.Mainmenu;

    public int round = 0;
    public int zona = 0;

    public List<GameObject> barreras;
    public List<GameObject> enemys;



    // Start is called before the first frame update
    void Start()
    {
        SpawnVelo = GameObject.FindGameObjectsWithTag("SpawnVelo");
        SpawnTrice = GameObject.FindGameObjectsWithTag("SpawnTrice");
        SpawnAlpha = GameObject.FindGameObjectsWithTag("SpawnAlpha");
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        enemysPerRound(round);

        if (zona == 0 && spawneados==false)
        {
            //Generamos dinosaurios en los spawns de la primera area.
            for (int i = 0; i < velo; i++)
            {
                GameObject newDinosaur = Instantiate(enemys[0]);
                newDinosaur.transform.position = SpawnVelo[0].transform.position;
                newDinosaur.GetComponent<Dinosaur>().area = 1;
                dinosVivos++;
            }

            for (int i = 0; i < trice; i++)
            {
                GameObject newTri = Instantiate(enemys[1]);
                newTri.transform.position = SpawnTrice[0].transform.position;
                newTri.GetComponent<Dinosaur>().area = 1;
                dinosVivos++;
            }

            for (int i = 0; i < alpha; i++)
            {
                GameObject newAlpha = Instantiate(enemys[2]);
                newAlpha.transform.position = SpawnAlpha[0].transform.position;
                newAlpha.GetComponent<Dinosaur>().area = 1;
                dinosVivos++;
            }
            spawneados = true;
        }

        if (zona == 1 && spawneados == false)
        {
            //Generamos dinosaurios en los spawns de la primera area.
            for (int i = 0; i < velo; i++)
            {
                GameObject newDinosaur = Instantiate(enemys[0]);
                newDinosaur.transform.position = SpawnVelo[1].transform.position;
                newDinosaur.GetComponent<Dinosaur>().area = 2;
                dinosVivos++;
            }

            for (int i = 0; i < trice; i++)
            {
                GameObject newTri = Instantiate(enemys[1]);
                newTri.transform.position = SpawnTrice[1].transform.position;
                newTri.GetComponent<Dinosaur>().area = 2;
                dinosVivos++;
            }

            for (int i = 0; i < alpha; i++)
            {
                GameObject newAlpha = Instantiate(enemys[2]);
                newAlpha.transform.position = SpawnAlpha[1].transform.position;
                newAlpha.GetComponent<Dinosaur>().area = 2;
                dinosVivos++;
            }

            spawneados = true;
        }

        if (dinosVivos == 0) {round++; spawneados = false;}
            
        if (round == 5)
        {
            zona = 1;
            barreras[0].SetActive(false);
        }else if (round == 10)
        {
            zona = 2;
            barreras[1].SetActive(false);
        }

        //FinishedCondition();
    }

    public void enemysPerRound(int r)
    {
        switch (r)
        {
            case 0:
                velo = 2;
                trice = 1;
                break;
            case 1:
                velo = 1;
                trice = 2;
                break;
            case 2:
                velo = 5;
                trice = 0;
                break;
            case 3:
                velo = 0;
                trice = 4;
                break;
            case 4:
                velo = 1;
                trice = 1;
                alpha = 1;
                break;
            case 5:
                velo = 1;
                trice = 1;
                alpha = 1;
                break;
            case 6:
                velo = 1;
                trice = 1;
                alpha = 1;
                break;
            case 7:
                velo = 1;
                trice = 1;
                alpha = 1;
                break;
            case 8:
                velo = 1;
                trice = 1;
                alpha = 1;
                break;
            case 9:
                velo = 1;
                trice = 1;
                alpha = 1;
                break;
        }
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
