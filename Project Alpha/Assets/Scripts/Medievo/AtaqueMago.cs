using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMago : MonoBehaviour
{
    public GameObject[] hechizos;
    public Transform spawnDireccion;
    public Transform spawnRotacion;

    public float shotForce = 1000;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    GameObject newBullet;

    void Update()
    {
       
    }

    public void lanzarHechizo()
    {
        int i = Random.Range(0, 4);

        newBullet = Instantiate(hechizos[i], spawnDireccion.position, spawnRotacion.rotation);
        newBullet.GetComponent<Rigidbody>().useGravity = false;
        //newBullet.transform.localScale = new Vector3(50, 50, 50);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccion.forward * shotForce);
        StartCoroutine(caida(newBullet));
        //newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccion.up * 250);
        //shotRateTime = Time.time + shotRate;

        Destroy(newBullet, 5);
    }

    IEnumerator caida(GameObject go)
    {
        yield return new WaitForSeconds(0.75f);
        go.GetComponent<Rigidbody>().useGravity = true;
        yield return null;
    }
}
