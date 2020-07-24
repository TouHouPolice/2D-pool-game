using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D : MonoBehaviour {

    float[][] entries = new float[3][];
    public HMatrix2D(float m00, float m01, float m02,
                     float m10, float m11, float m12,
                     float m20, float m21, float m22)
    {
        entries[0][0] = m00;
        entries[0][1] = m01;
        entries[0][2] = m02;
        entries[1][0] = m10;
        entries[1][1] = m11;
        entries[1][2] = m12;
        entries[2][0] = m20;
        entries[2][1] = m21;
        entries[2][2] = m22;

    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D(left.entries[0][0] + right.entries[0][0], left.entries[0][1] + right.entries[0][1], left.entries[0][2] + right.entries[0][2],
                         left.entries[1][0] + right.entries[1][0], left.entries[1][1] + right.entries[1][1], left.entries[1][2] + right.entries[1][2],
                         left.entries[2][0] + right.entries[2][0], left.entries[2][1] + right.entries[2][1], left.entries[2][2] + right.entries[2][2]);
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D(left.entries[0][0] - right.entries[0][0], left.entries[0][1] - right.entries[0][1], left.entries[0][2] - right.entries[0][2],
                         left.entries[1][0] - right.entries[1][0], left.entries[1][1] - right.entries[1][1], left.entries[1][2] - right.entries[1][2],
                         left.entries[2][0] - right.entries[2][0], left.entries[2][1] - right.entries[2][1], left.entries[2][2] - right.entries[2][2]);
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        return new HMatrix2D(left.entries[0][0] * scalar, left.entries[0][1] * scalar, left.entries[0][2] * scalar,
                         left.entries[1][0] * scalar, left.entries[1][1] * scalar, left.entries[1][2] * scalar,
                         left.entries[2][0] * scalar, left.entries[2][1] * scalar, left.entries[2][2] * scalar);

    }

    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D((left.entries[0][0] *  right.entries[0][0] + left.entries[0][1] *  right.entries[1][0] + left.entries[0][2] *  right.entries[2][0]), (left.entries[0][0] *  right.entries[0][1] + left.entries[0][1] *  right.entries[1][1] + left.entries[0][2] *  right.entries[2][1]), (left.entries[0][0] *  right.entries[0][2] + left.entries[0][1] *  right.entries[1][2] + left.entries[0][2] *  right.entries[2][2]),
                        (left.entries[1][0] *  right.entries[0][0] + left.entries[1][1] *  right.entries[1][0] + left.entries[1][2] *  right.entries[2][0]), (left.entries[1][0] *  right.entries[0][1] + left.entries[1][1] *  right.entries[1][1] + left.entries[1][2] *  right.entries[2][1]), (left.entries[1][0] *  right.entries[0][2] + left.entries[1][1] *  right.entries[1][2] + left.entries[1][2] *  right.entries[2][2]),
                        (left.entries[2][0] *  right.entries[0][0] + left.entries[2][1] *  right.entries[1][0] + left.entries[2][2] *  right.entries[2][0]), (left.entries[2][0] *  right.entries[0][1] + left.entries[2][1] *  right.entries[1][1] + left.entries[2][2] *  right.entries[2][1]), (left.entries[2][0] *  right.entries[0][2] + left.entries[2][1] *  right.entries[1][2] + left.entries[2][2] *  right.entries[2][2]));
    }

    public static HMatrix2D operator ==(HMatrix2D left, HMatrix2D  right)
    {
        if (left.entries[0][0] ==  right.entries[0][0] && left.entries[0][1] ==  right.entries[1][0] && left.entries[0][2] ==  right.entries[2][0] &&
            left.entries[1][0] ==  right.entries[0][1] && left.entries[1][1] ==  right.entries[1][1] && left.entries[1][2] ==  right.entries[2][1] &&
            left.entries[2][0] ==  right.entries[0][2] && left.entries[2][1] ==  right.entries[1][2] && left.entries[2][2] ==  right.entries[2][2])
           {
            return true;
        }
        else
        {
            return false;
        }
    }

    public HMatrix2D transpose()
    {
        return new HMatrix2D(entries[0][0], entries[1][0],entries[2][0],
                      entries[0][1], entries[1][1], entries[2][1],
                      entries[0][2], entries[1][2], entries[2][2]);
    }

    public float getDeterminant()
    {
        return ((entries[0][0] * entries[1][1] * entries[2][2]) + (entries[0][1] * entries[1][2] * entries[2][0]) + (entries[0][2] * entries[1][0] * entries[2][1])
                - (entries[0][0] * entries[1][2] * entries[2][1]) - (entries[0][1] * entries[1][0] * entries[2][2]) - (entries[0][2] * entries[1][1] * entries[2][0]));
    }

    public void setIdentity()
    {
        entries[0][0] = 1;
        entries[0][1] = 0;
        entries[0][2] = 0;
        entries[1][0] = 0;
        entries[1][1] = 1;
        entries[1][2] = 0;
        entries[2][0] = 0;
        entries[2][1] = 0;
        entries[2][2] = 1;
        
    }
    public void setTranslationMat(float transX, float transY)
    {
        entries[0][0] = 1;
        entries[0][1] = 0;
        entries[0][2] = transX;
        entries[1][0] = 0;
        entries[1][1] = 1;
        entries[1][2] = transY;
        entries[2][0] = 0;
        entries[2][1] = 0;
        entries[2][2] = 1;
        
    }

    public void setRotationMat(float rotDeg)
    {
        entries[0][0] = Mathf.Cos(rotDeg);
        entries[0][1] = -Mathf.Sin(rotDeg);
        entries[0][2] = 0;
        entries[1][0] = Mathf.Sin(rotDeg);
        entries[1][1] = Mathf.Cos(rotDeg);
        entries[1][2] = 0;
        entries[2][0] = 0;
        entries[2][1] = 0;
        entries[2][2] = 1;
        
    }
    public void setScalingMat(float scaleX, float scaleY)
    {

        entries[0][0] = scaleX;
        entries[0][1] = 0;
        entries[0][2] = 0;
        entries[1][0] = 0;
        entries[1][1] = scaleY;
        entries[1][2] = 0;
        entries[2][0] = 0;
        entries[2][1] = 0;
        entries[2][2] = 1;

        
    }
    public void print()
    {
        Debug.Log(entries[0][0]+
        entries[0][1]+
        entries[0][2]
        );
        Debug.Log(entries[1][0]+
        entries[1][1]+
        entries[1][2]
        );
        Debug.Log(entries[2][0]+
        entries[2][1]+
        entries[2][2]
        );


    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
