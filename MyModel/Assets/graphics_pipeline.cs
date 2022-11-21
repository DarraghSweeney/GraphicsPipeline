using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphics_pipeline : MonoBehaviour
{

    model d;

    Outcode A = new Outcode(new Vector2(0.1f, 3));

    Outcode B = new Outcode(new Vector2(-2, -2));

    

    bool line_clip( ref Vector2 start, ref Vector2 end)
    {
        Outcode startOutcode = new Outcode(start);
        Outcode endOutcode = new Outcode(end);

        Outcode inScreen = new Outcode();

        if ((startOutcode * endOutcode) == inScreen)
        {
            print("Trivial Accept");
            return true;
        }

        if ((startOutcode * endOutcode) != inScreen)
        {
            print("Trivial Reject");
            return false;
        }

        if(startOutcode == inScreen)
        {
            return line_clip(ref end, ref start);
        }

        List<Vector2> points = intersectEdge(start, end, startOutcode);

        foreach(Vector2 v in points)
        {
            Outcode vo = new Outcode(v);
            if(vo == inScreen)
            {
                start = v;
                return line_clip(ref start, ref end);
            }
        }

        return false;
    }

    
    List<Vector2> intersectEdge(Vector2 start, Vector2 end, Outcode pointOutcode)
    {
        float m = (end.y - start.y) / (end.x - start.x);
        List<Vector2> intersections = new List<Vector2>();

        if (pointOutcode.UP)
        {
            intersections.Add(new Vector2(start.x + (1 / m) * (1 - start.y), 1));
        }

        if (pointOutcode.DOWN)
        {
            intersections.Add(new Vector2(start.x + (1 / m) * (-1 - start.y), -1));
        }

        if (pointOutcode.LEFT)
        {
            intersections.Add(new Vector2(-1, start.y + m * (-1 - start.x)));
        }

        if (pointOutcode.RIGHT)
        {
            intersections.Add(new Vector2(1, start.y + m * (1 - start.x)));
        }

        return intersections;
    }

   
   
      private List<Vector2Int> Bresh(Vector2Int start, Vector2Int end)
        {
            List<Vector2Int> hold = new List<Vector2Int>();

            int dx = end.x - start.x;

            if (dx < 0)
                return Bresh(end, start);

            int dy = end.y - start.y;

        if (dy < 0)
            return NegateY(Bresh(NegateY(start), NegateY(end)));

        if (dy > dx)
        {
            return SwapXY(Bresh(SwapXY(start), SwapXY(end)));
        }

        int twodxdy = 2*(dy - dx);
        int twody = 2 * (dy);

        int p = twody - dx;

        int y = start.y;

        for (int x = start.x; x <= end.x; x++)
        {
            hold.Add(new Vector2Int(x, y));
            if (p <= 0)
            {
                p += twody;
            }

            else
            {
                p += twodxdy;
                y++;
            }
        }
        return hold;



        


    }
   

    private Vector2Int NegateY(Vector2Int V)
    {
       return new Vector2Int(V.x, -V.y);
    }

    private List<Vector2Int> NegateY(List<Vector2Int> Vs)
    {
        List<Vector2Int> hold = new List<Vector2Int>();
        foreach (Vector2Int v in Vs)
        {
            hold.Add(NegateY(v));
        }

        return hold;
    }


    private Vector2Int SwapXY(Vector2Int V)
    {
       return new Vector2Int(V.y, V.x);
    }

    private List<Vector2Int> SwapXY(List<Vector2Int> Vs)
    {
        List<Vector2Int> hold = new List<Vector2Int>();
        foreach (Vector2Int v in Vs)
        {
            hold.Add(SwapXY(v));
        }
        return hold;
    }


    Texture2D ourScreen;
    // Start is called before the first frame update
    void Start()
    {
        //d = new model();

        Vector2 Start = new Vector2(0.5f,0.5f);
        Vector2 end = new Vector2(0, 0);
       // line_clip(ref Start, ref end);


        ourScreen = new Texture2D(512, 512);
        Renderer screenPlane = FindObjectOfType<Renderer>();
        screenPlane.material.mainTexture = ourScreen;

        if (line_clip(ref Start, ref end))
        {
            plot(Bresh(Convert(Start), Convert(end)));
        }

        
    }

    private void plot(List<Vector2Int> Vlist)
    {
       foreach (Vector2Int v in Vlist)
        {
            ourScreen.SetPixel(v.x, v.y, Color.red);
        }
        ourScreen.Apply();
    }

    private Vector2Int Convert(Vector2 v)
    {
        return new Vector2Int((int)(511 * (v.x + 1) / 2), (int)(511 * (v.y + 1) / 2));
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
