using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour {

    public float mass = 1f;
    float radius;
    public float friction = 0.95f;

    float velocityX;
    float accelerationX;
    float velocityZ;
    float accelerationZ;

    private void Awake()
    {
        radius = transform.localScale.x * 0.5f;
    }

    // Use this for initialization
    void Start () {
        velocityX = 0.0f;
        accelerationX = 0f;
        velocityZ = 0.0f;
        accelerationZ = 0f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void HandlePhysics()
    {
        HandleSUVA(ref velocityX, ref accelerationX, Vector3.right);
        HandleSUVA(ref velocityZ, ref accelerationZ, Vector3.forward);

    }

    void HandleSUVA(ref float velocity, ref float acceleration, Vector3 direction)
    {



        // v= u + at
        velocity = velocity + acceleration * Time.fixedDeltaTime;


        

        //resistance
        velocity = velocity * friction;

        //s = ut + 0.Satt
        float displacement = velocity + 0.5f * acceleration * Time.fixedDeltaTime * Time.fixedDeltaTime;

        //Update position
        transform.position = transform.position + direction * displacement;

    }
}
