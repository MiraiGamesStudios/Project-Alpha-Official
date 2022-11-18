using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohete : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject ExplosionParticula;
    public int dañoCohete;

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        Explosion.GetComponent<Explosion>().hacerGrande();
        ExplosionParticula.SetActive(true);
    }
}
