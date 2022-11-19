using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reincio : MonoBehaviour
{
    public void CambiarEscena(int indice)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(indice);
    }
}
