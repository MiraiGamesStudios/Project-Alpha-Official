using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerContemporaneo : MonoBehaviour
{
    public static GameManagerContemporaneo Instance;
    int workers;
    int suits;
    int policias;
    int militares;
    public int enemigosVivos = 0;
    bool spawneados = false;

    public static Player player;

    public int round = 0;
    public int zona = 0;

    public List<GameObject> barreras;
    public List<GameObject> enemys;


    public List<GameObject> workArea1;
    public List<GameObject> suitArea1;
    public List<GameObject> polArea1;
    public List<GameObject> milArea1;

    public List<GameObject> workArea2;
    public List<GameObject> suitArea2;
    public List<GameObject> polArea2;
    public List<GameObject> milArea2;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        enemysPerRound(round);

        if (zona == 0 && spawneados == false)
        {
            //Generamos dinosaurios en los spawns de la primera area.
            for (int i = 0; i < workers; i++)
            {
                if (workArea1[0] != null)
                {
                    workArea1[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < suits; i++)
            {
                if (suitArea1[0] != null)
                {
                    suitArea1[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < policias; i++)
            {
                if (polArea1[0] != null)
                {
                    polArea1[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < militares; i++)
            {
                if (milArea1[0] != null)
                {
                    milArea1[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            spawneados = true;
        }

        if (zona == 1 && spawneados == false)
        {
            //Generamos dinosaurios en los spawns de la primera area.
            for (int i = 0; i < workers; i++)
            {
                if (workArea2[0] != null)
                {
                    workArea2[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < suits; i++)
            {
                if (suitArea2[0] != null)
                {
                    suitArea2[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < policias; i++)
            {
                if (polArea2[0] != null)
                {
                    polArea2[i].SetActive(true);
                    esperarSpawn();
                }
                enemigosVivos++;
            }

            for (int i = 0; i < militares; i++)
            {
                if (milArea2[0] != null)
                {
                    milArea2[i].SetActive(true);
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
                workers = 2;
                suits = 2;
                policias = 0;
                militares = 0;
                break;
            case 1:
                workers = 4;
                suits = 0;
                policias = 1;
                militares = 0;
                break;
            case 2:
                workers = 0;
                suits = 4;
                policias = 0;
                militares = 1;
                break;
            case 3:
                workers = 0;
                suits = 0;
                policias = 1;
                militares = 1;
                break;
            case 4:
                workers = 2;
                suits = 2;
                policias = 1;
                militares = 1;
                break;
            case 5:
                workers = 0;
                suits = 0;
                policias = 2;
                militares = 2;
                break;
        }
    }

    public IEnumerator esperarSpawn()
    {
        yield return new WaitForSeconds(2f);
        yield return null;
    }
}
