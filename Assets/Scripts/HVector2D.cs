using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HVector2D : MonoBehaviour{

    float x;
    float y;
    float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1;
    }
    public static HVector2D operator +(HVector2D left, HVector2D right)
    {
        return new HVector2D(left.x + right.x, left.y + right.y);
    }
   /* public static HVector2D operator +( HVector2D right)
    {
        return new HVector2D(x + right.x, y + right.y);
    }*/

    public static HVector2D operator -(HVector2D left, HVector2D right)
    {
        return new HVector2D(left.x - right.x, left.y - right.y);
    }

    public static HVector2D operator *(HVector2D left, float scalar)
    {

        return new HVector2D(left.x * scalar, left.y * scalar);
    }
 

    public static HVector2D operator /(HVector2D left, float scalar)
    {
        return new HVector2D(left.x / scalar, left.y / scalar);
    }

    public float magnitude()
    {
        float sqrt = new float();
        sqrt = Mathf.Sqrt(x * x + y * y);
        return sqrt;

    }

    public void Normalize()
    {
        float mag = this.magnitude();
        x = x / mag;
        y = y / mag;
       // new HVector2D(x / mag, y / mag);
    }

    public float dotProduct(HVector2D vec)
    {
        return (x * vec.x + y * vec.y);
    }

    public HVector2D projection(HVector2D vec)
    {
        
        return new HVector2D(((x * vec.x + y * vec.y) / (vec.x * vec.x * vec.y * vec.y)) * vec.x, ((x * vec.x + y * vec.y) / (vec.x * vec.x * vec.y * vec.y)) * vec.y);
    }

    public float findAngle(HVector2D vec)
    {

        float angle = Mathf.Acos(this.dotProduct(vec) / (this.magnitude() * vec.magnitude()) * (180 / Mathf.PI));
        return angle;

    }

    public void print()
    {
        Debug.Log("x ="+x);
        Debug.Log("y ="+y);

    }




    // Use this for initialization
    void Start() {
        HVector2D alpha = new HVector2D(2, 3);
        alpha.print();
        HVector2D beta = new HVector2D(5, 5);
        beta.print();
        HVector2D sum= alpha + beta;

        alpha.Normalize();
        alpha.print();
        sum.print();




}

    




    // Update is called once per frame
    void Update()
    {

    }
}



   /* public static HVector2D operator *(HVector2D current, HVector2D b)
    {
        return float((current.x * b.x) + (current.y * b.y));
    }*/

