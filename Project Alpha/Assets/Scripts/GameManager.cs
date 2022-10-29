using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int velo;
    int trice;
    int alpha;
    public int dinosVivos = 0;
    bool spawneados = false;

    public static Player player;

    private enum Status { Mainmenu, Playing, Finished };
    Status statusPartida = Status.Mainmenu;

    public int round = 0;
    public int zona = 0;

    public List<GameObject> barreras;
    public List<GameObject> enemys;


    public List<GameObject> velosArea1;
    public List<GameObject> tricesArea1;
    public GameObject alphaArea1;

    public List<GameObject> velosArea2;
    public List<GameObject> tricesArea2;
    public GameObject alphaArea2;

    // Start is called before the first frame update
    void Start()
    {
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
                if (velosArea1[0] != null)
                {
                    velosArea1[i].SetActive(true);
                    esperarSpawn();
                }
                dinosVivos++;
            }

            for (int i = 0; i < trice; i++)
            {
                if (tricesArea1[0] != null)
                {
                    tricesArea1[i].SetActive(true);
                    esperarSpawn();
                }
                dinosVivos++;
            }

            for (int i = 0; i < alpha; i++)
            {
                alphaArea1.SetActive(true);
                esperarSpawn();
                dinosVivos++;
            }
            spawneados = true;
        }

        if (zona == 1 && spawneados == false)
        {
            //Generamos dinosaurios en los spawns de la segunda area.
            for (int i = 0; i < velo; i++)
            {
                
                velosArea2[i].SetActive(true);
                esperarSpawn();
               
                dinosVivos++;
            }

            for (int i = 0; i < trice; i++)
            {
                tricesArea2[i].SetActive(true);
                esperarSpawn();
                dinosVivos++;
            }

            for (int i = 0; i < alpha; i++)
            {
                alphaArea2.SetActive(true);
                esperarSpawn();
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

    }

    public void enemysPerRound(int r)
    {
        switch (r)
        {
            case 0:
                velo = 2;
                trice = 1;
                alpha = 0;
                break;
            case 1:
                velo = 1;
                trice = 2;
                alpha = 0;
                break;
            case 2:
                velo = 5;
                trice = 0;
                alpha = 0;
                break;
            case 3:
                velo = 0;
                trice = 4;
                alpha = 0;
                break;
            case 4:
                velo = 1;
                trice = 1;
                alpha = 1;
                break;
            case 5:
                velo = 2;
                trice = 1;
                alpha = 0;
                break;
            case 6:
                velo = 1;
                trice = 2;
                alpha = 0;
                break;
            case 7:
                velo = 5;
                trice = 0;
                alpha = 0;
                break;
            case 8:
                velo = 0;
                trice = 4;
                alpha = 0;
                break;
            case 9:
                velo = 1;
                trice = 1;
                alpha = 1;
                break;
        }
    }

    public IEnumerator esperarSpawn()
    {
        yield return new WaitForSeconds(2f);
        yield return null;
    }
}
