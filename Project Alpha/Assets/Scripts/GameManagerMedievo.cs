using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMedievo : MonoBehaviour
{
    public static GameManagerMedievo Instance;
    int caballeros;
    int arqueros;
    int escuderos;
    public int enemigosVivos = 0;
    bool spawneados = false;

    public static Player player;

    public int round = 0;
    public int zona = 0;

    public List<GameObject> barreras;
    public List<GameObject> enemys;


    public List<GameObject> cabArea1;
    public List<GameObject> arqArea1;
    public List<GameObject> escArea1;

    public List<GameObject> cabArea2;
    public List<GameObject> arqArea2;
    public List<GameObject> escArea2;

    public GameObject boos;
    public GameObject panelVictoria;

    // Start is called before the first frame update
    void Start()
    {
       Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (boos.GetComponent<Mago>().life <=0)
        {
            panelVictoria.SetActive(true);
        }
        enemysPerRound(round);

        if (zona == 0 && spawneados == false)
        {
            //Generamos dinosaurios en los spawns de la primera area.
            for (int i = 0; i < caballeros; i++)
            {
                if (cabArea1[0] != null)
                {
                    cabArea1[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < arqueros; i++)
            {
                if (arqArea1[0] != null)
                {
                    arqArea1[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < escuderos; i++)
            {
                if (escArea1[0] != null)
                {
                    escArea1[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }
            spawneados = true;
        }

        if (zona == 1 && spawneados == false)
        {
            //Generamos dinosaurios en los spawns de la primera area.
            for (int i = 0; i < caballeros; i++)
            {
                if (cabArea2[0] != null)
                {
                    cabArea2[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < arqueros; i++)
            {
                if (arqArea2[0] != null)
                {
                    arqArea2[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < escuderos; i++)
            {
                if (escArea2[0] != null)
                {
                    escArea2[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }
            spawneados = true;
        }

        if (enemigosVivos == 0) { round++; spawneados = false; }

        if (round == 3)
        {
            zona = 1;
            barreras[0].SetActive(false);
        }
        else if (round == 6)
        {
            zona = 2;
            barreras[1].SetActive(false);
        }

    }

    public void enemysPerRound(int r)
    {
        switch (r)
        {
            case 0:
                caballeros = 1;
                arqueros = 1;
                escuderos = 0;
                break;
            case 1:
                caballeros = 0;
                arqueros = 2;
                escuderos = 1;
                break;
            case 2:
                caballeros = 1;
                arqueros = 1;
                escuderos = 2;
                break;
            case 3:
                caballeros = 1;
                arqueros = 2;
                escuderos = 1;
                break;
            case 4:
                caballeros = 3;
                arqueros = 1;
                escuderos = 0;
                break;
            case 5:
                caballeros = 2;
                arqueros = 2;
                escuderos = 2;
                break;
        }
    }

    public IEnumerator esperarSpawn()
    {
        yield return new WaitForSeconds(2f);
        yield return null;
    }
}
