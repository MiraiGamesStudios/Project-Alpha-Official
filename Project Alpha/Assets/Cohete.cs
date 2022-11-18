using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohete : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject ExplosionParticula;
    public int da�oCohete;

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;

        Explosion.GetComponent<Explosion>().hacerGrande();
        ExplosionParticula.SetActive(true);
    }
}
