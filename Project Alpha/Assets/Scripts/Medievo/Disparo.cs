using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnDireccion;
    public Transform spawnRotacion;

    public float shotForce = 1000;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    void Update()
    {
        if (Input.GetKey("r"))
        {
            if(Time.time > shotRateTime)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnDireccion.position, spawnRotacion.rotation);
                newBullet.GetComponent<Rigidbody>().useGravity = false;
                newBullet.transform.localScale = new Vector3(50,50,50);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccion.forward * shotForce);
                StartCoroutine(caida(newBullet));
                //newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccion.up * 250);

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 5);
            }
        }
    }

    IEnumerator caida(GameObject go)
    {
        yield return new WaitForSeconds(2);
        print(go);
        go.GetComponent<Rigidbody>().useGravity = true;
        yield return null;
    }
}
