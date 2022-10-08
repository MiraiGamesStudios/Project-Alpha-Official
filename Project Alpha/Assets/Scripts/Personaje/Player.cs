using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerState State;
    public float Health;
    public bool Dead;
    public string Name;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum PlayerState
    {
        Grounded = 0,
        Jumping = 1,
    }
}
