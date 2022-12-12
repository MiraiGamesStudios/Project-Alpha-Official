using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bulletA;
    public GameObject bulletB;
    public Transform spawnDireccion;
    public Transform spawnRotacionVirote;
    public Transform spawnRotacion;

    public float shotForce = 1000;
    public float shotRate = 0.5f;

    GameObject newBullet;
    public bool haMuerto;

    void Update()
    {

    }

    private void OnEnable()
    {
        Arquero.disparoArco += disparo;
    }
    private void OnDisable()
    {
        Arquero.disparoArco -= disparo;
    }

    public void disparo(Transform pos, Transform rot, GameObject bullet)
    {
        newBullet = Instantiate(bullet, pos.position, rot.rotation);
        newBullet.GetComponent<Rigidbody>().useGravity = false;
        newBullet.transform.localScale = new Vector3(50, 50, 50);
        newBullet.GetComponent<Rigidbody>().AddForce(pos.forward * shotForce);
        StartCoroutine(caida(newBullet));
        
        Destroy(newBullet, 5);
    }

    public void disparoArco()
    {
        if (!haMuerto)
        {
            newBullet = Instantiate(bulletA, spawnDireccion.position, spawnRotacion.rotation);
            newBullet.GetComponent<Rigidbody>().useGravity = false;
            newBullet.transform.localScale = new Vector3(50, 50, 50);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccion.forward * shotForce);
            StartCoroutine(caida(newBullet));

            Destroy(newBullet, 5);
        }
        
    }

    public void disparoBallesta()
    {
        if (!haMuerto)
        {
            newBullet = Instantiate(bulletB, spawnDireccion.position, spawnRotacionVirote.rotation);
            newBullet.GetComponent<Rigidbody>().useGravity = false;
            //newBullet.transform.localScale = new Vector3(50, 50, 50);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccion.forward * shotForce);
            StartCoroutine(caida(newBullet));

            Destroy(newBullet, 5);
        }
        
    }

    IEnumerator caida(GameObject go)
    {
        yield return new WaitForSeconds(0.75f);
        go.GetComponent<Rigidbody>().useGravity = true;
        yield return null;
    }
}
