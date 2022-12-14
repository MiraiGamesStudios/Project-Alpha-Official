using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public int Disp = 0;

    public CinemachineFreeLook cm;

    public Vector2 touchDeltaPosition;
    public float speedRotationCamera;

    public Joystick joystick;

    private void Awake()
    {
        Disp = FindObjectOfType<Dispositivo>().dispositivo;
    }

    void Update()
    {
        if(Disp == 1)
        {
            if (Input.touchCount == 1 && joystick.Horizontal == 0 && joystick.Vertical == 0)
            {
                Touch touchZero = Input.GetTouch(0);
                if (touchZero.phase == TouchPhase.Moved)
                {
                    touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    cm.m_XAxis.Value += -touchDeltaPosition.x * speedRotationCamera;
                }
            }
            else if(Input.touchCount == 2 && joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                Touch touchZero = Input.GetTouch(1);
                if (touchZero.phase == TouchPhase.Moved)
                {
                    touchDeltaPosition = Input.GetTouch(1).deltaPosition;
                    cm.m_XAxis.Value += -touchDeltaPosition.x * speedRotationCamera;
                }
            }
        }
    }
}
