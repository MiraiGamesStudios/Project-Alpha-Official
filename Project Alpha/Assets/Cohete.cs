using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohete : MonoBehaviour
{
    public GameObject Explosion;
    public int dañoCohete;

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        Explosion.SetActive(true);
    }
}
