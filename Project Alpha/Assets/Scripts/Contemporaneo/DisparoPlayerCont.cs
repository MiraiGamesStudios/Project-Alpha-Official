using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayerCont : MonoBehaviour
{
    public GameObject bulletP;
    public GameObject bulletR;
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

    public AudioSource audioManagement;
    [SerializeField]
    public AudioClip PlayerRifleAttack;
    public bool noDisparo;


    private void Awake()
    {
        audioManagement = GetComponent<AudioSource>();
    }
    public void disparoPistola()
    {
        if (!noDisparo)
        {
            newBullet = Instantiate(bulletP, spawnDireccionP.position, spawnRotacionP.rotation);
            newBullet.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<CPlayerSounds>().GunAttack();
            newBullet.transform.localScale = new Vector3(50, 50, 50);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccionP.forward * shotForce);
            //StartCoroutine(caida(newBullet));

            Destroy(newBullet, 5);
        }
    }

    public void disparoRifle()
    {
        if (!noDisparo)
        {
            audioManagement.PlayOneShot(PlayerRifleAttack, 0.6f);
            newBullet = Instantiate(bulletR, spawnDireccionRi.position, spawnRotacionRi.rotation);
            newBullet.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<CPlayerSounds>().RifleAttack();
            newBullet.transform.localScale = new Vector3(50, 50, 50);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccionRi.forward * shotForce);

            Destroy(newBullet, 5);
        }
    }

    public void disparoLanza()
    {
        if (!noDisparo)
        {
            newBullet = Instantiate(rocket, spawnDireccionRo.position, spawnRotacionRo.rotation);
            newBullet.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<CPlayerSounds>().RPGAttack();
            newBullet.transform.localScale = new Vector3(50, 50, 50);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnDireccionRo.forward * shotForce);
            //StartCoroutine(caida(newBullet));

            Destroy(newBullet, 5);
        }
    }
}
