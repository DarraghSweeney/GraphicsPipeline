using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outcode
{

    private bool UP, DOWN, LEFT, RIGHT;

    public Outcode(Vector2 V) 
    {
        UP = (V.y > 1);

        DOWN = (V.y < -1);

        LEFT = (V.x < -1);

        RIGHT = (V.x > 1);
    }

    public Outcode(bool up, bool down, bool left, bool right)
    {

        UP = up;
        DOWN = down;
        LEFT = left;
        RIGHT = right;
    }

    public Outcode()
    {
        UP = false;
        DOWN = false;
        LEFT = false;
        RIGHT = false;
    }

    public static Outcode operator * (Outcode A, Outcode B) 
    { 
        return new Outcode (A.UP && B.UP, A.DOWN && B.DOWN, A.LEFT && B.LEFT, A.RIGHT && B.RIGHT); 
    }
    public static Outcode operator + (Outcode A, Outcode B) 
    { 
        return new Outcode(A.UP || B.UP, A.DOWN || B.DOWN, A.LEFT || B.LEFT, A.RIGHT || B.RIGHT);
    }

    public static bool operator == (Outcode A, Outcode B)
    {
        return (A.UP == B.UP) && (A.DOWN == B.DOWN) && (A.LEFT == B.LEFT) && (A.RIGHT == B.RIGHT);
    }

    public static bool operator !=(Outcode A, Outcode B)
    {
        return !(A == B);
    }

    public void print(Outcode A)
    {
        string O = (UP ? "1" : "0") + (DOWN ? "1" : "0") + (LEFT ? "1" : "0") + (RIGHT ? "1" : "0");

        Debug.Log(O);
    }
}