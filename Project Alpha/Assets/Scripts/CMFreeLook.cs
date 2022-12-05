using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CMFreeLook : MonoBehaviour
{
    public int Disp = 0;
    
    public CinemachineFreeLook cm;

    private void Awake()
    {
        Disp = FindObjectOfType<Dispositivo>().dispositivo;
        cm = GetComponent<CinemachineFreeLook>();
    }

    void Start()
    {
        if (Disp == 1)  //estamos jugando desde el móvil
        {
            cm.m_XAxis.m_InputAxisName = null;
            cm.m_YAxis.m_InputAxisName = null;
        }
    }

    void Update()
    {
        
    }
}
