using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarIdioma : MonoBehaviour
{
    public int Language = 0;
    public GameObject Spanish;
    public GameObject English;

    public GameObject[] PanelesIdioma = new GameObject[5];

    public AudioSource audioManagement;
    [SerializeField]
    public AudioClip buttonSound;

    // Start is called before the first frame update
    private void Awake()
    {
        Language = FindObjectOfType<Dispositivo>().Language;
        //English.GetComponent<RawImage>().color = new Color(1, 1, 1, 0.5f);
        audioManagement = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLanguage();
    }

    public void EngButton()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        //Spanish.SetActive(true);
        //English.SetActive(false);
        Spanish.GetComponent<RawImage>().color = new Color(1, 1, 1, 0.5f);
        English.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
        Language = 1;
        FindObjectOfType<Dispositivo>().Language = Language;
    }

    public void SpanishButton()
    {
        audioManagement.PlayOneShot(buttonSound, 0.8f);
        //English.SetActive(true);
        //Spanish.SetActive(false);
        Spanish.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
        English.GetComponent<RawImage>().color = new Color(1, 1, 1, 0.5f);
        Language = 0;
        FindObjectOfType<Dispositivo>().Language = Language;
    }


    public void ChangeLanguage()
    {
        switch (Language)
        {
            case 1:
                foreach (GameObject panel in PanelesIdioma)
                {
                    panel.transform.Find("PanelEspaņol").gameObject.SetActive(false);
                    panel.transform.Find("PanelEnglish").gameObject.SetActive(true);
                }
                break;

            case 0:
                foreach (GameObject panel in PanelesIdioma)
                {
                    panel.transform.Find("PanelEspaņol").gameObject.SetActive(true);
                    panel.transform.Find("PanelEnglish").gameObject.SetActive(false);
                }
                break;
        }
    }
}
