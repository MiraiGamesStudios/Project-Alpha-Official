using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class HearthStaminaBar : MonoBehaviour
{

    public Slider slide;

    public int maxHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        slide = gameObject.GetComponent<Slider>();
        print(slide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
