using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class GraphicsController : MonoBehaviour
{
    [SerializeField] public Slider CameraSpeedESP;
    [SerializeField] public TextMeshProUGUI SpeedValueESP;
    [SerializeField] public Slider CameraSpeedENG;
    [SerializeField] public TextMeshProUGUI SpeedValueENG;
    [SerializeField] public CambiarIdioma controladorIdioma;
    [SerializeField] public CinemachineFreeLook cam;
    public float maxSpeedValue = 1000;
    public float minSpeedValue = 100;
    void Start()
    {
        float valuenorm = (cam.m_XAxis.m_MaxSpeed - minSpeedValue) / (maxSpeedValue - minSpeedValue);
        CameraSpeedESP.value = valuenorm;
        CameraSpeedENG.value = valuenorm;
    }

    public void ChangeCameraSpeed(float speed)
    {
        float speedNm = (speed * 900)+100;
        setCameraSpeed(speedNm);
        float speedInt = speed* 100;
        SpeedValueESP.text = speedInt.ToString("0");
        SpeedValueENG.text = speedInt.ToString("0");
    }

    public void setCameraSpeed(float speed)
    {
        cam.m_XAxis.m_MaxSpeed = speed;
    }
}
