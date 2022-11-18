using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayerCont : MonoBehaviour
{
    public GameObject bullet;
    public GameObject rocket;

    public Transform spawnDireccionP;
    public Transform spawnRotacionP;
    public Transform spawnDireccionRi;
    public Transform spawnRotacionRi;
    public Transform spawnDireccionRo;
    public Transform spawnRotacionRo;

    public float shotForce = 1000;
    public float shotRate = 0.5f;

    GameObject newBullet;

    public void disparoPistola()
    {
        newBullet = Instantiate(bullet, spawnDireccionP.position, spawnRotacionP.rotation);
        newBullet.GetComponent<Rigidbody>().useGravity = false;
        newBullet.transform.localScale = new Vector3(50, 50, 50);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccionP.forward * shotForce);
        //StartCoroutine(caida(newBullet));

        Destroy(newBullet, 5);
    }

    public void disparoRifle()
    {
        newBullet = Instantiate(bullet, spawnDireccionRi.position, spawnRotacionRi.rotation);
        newBullet.GetComponent<Rigidbody>().useGravity = false;
        newBullet.transform.localScale = new Vector3(50, 50, 50);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccionRi.forward * shotForce);
        //StartCoroutine(caida(newBullet));

        Destroy(newBullet, 5);
    }

    public void disparoLanza()
    {
        newBullet = Instantiate(rocket, spawnDireccionRo.position, spawnRotacionRo.rotation);
        newBullet.GetComponent<Rigidbody>().useGravity = false;
        newBullet.transform.localScale = new Vector3(50, 50, 50);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccionRo.forward * shotForce);
        //StartCoroutine(caida(newBullet));

        Destroy(newBullet, 5);
    }

}
