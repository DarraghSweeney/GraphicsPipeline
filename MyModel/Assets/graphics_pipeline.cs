using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphics_pipeline : MonoBehaviour
{

    model d;

    Outcode A = new Outcode(new Vector2(0.1f, 3));

    Outcode B = new Outcode(new Vector2(-2, -2));

    Texture2D ourScreen;
    Renderer screenPlane;
    float z = 5, angle;

    bool line_clip( ref Vector2 start, ref Vector2 end)
    {
        Outcode startOutcode = new Outcode(start);
        Outcode endOutcode = new Outcode(end);

        Outcode inScreen = new Outcode();

        if ((startOutcode + endOutcode) == inScreen)
        {
            //print("Trivial Accept");
            return true;
        }

        if ((startOutcode * endOutcode) != inScreen)
        {
            //print("Trivial Reject");
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


  


    // Start is called before the first frame update
    void Start()
    {
        d = new model();
        screenPlane = FindObjectOfType<Renderer>();

       
        
    }
    // Update is called once per frame
    void Update()
    {
        List<Vector3> verts = d.vertices;

        Matrix4x4 translate = Matrix4x4.TRS(new Vector3(0, 0, 10), Quaternion.identity, Vector3.one);
        Matrix4x4 rotate = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(angle, Vector3.right), Vector3.one);
        Matrix4x4 projection = Matrix4x4.Perspective(90, 1, 0, 1000);
        z += 0.05f;
        angle++;

        Matrix4x4 AllTrans = projection * rotate * translate;

        List<Vector3> imageafter = d.get_image(verts, AllTrans);
        if (ourScreen)
            Destroy(ourScreen);
        ourScreen = new Texture2D(512, 512);
        screenPlane.material.mainTexture = ourScreen;

        foreach (Vector3Int face in d.faces)
        {
            drawline(imageafter[face.x], imageafter[face.y]);

            drawline(imageafter[face.y], imageafter[face.z]);

            drawline(imageafter[face.z], imageafter[face.x]);
        }

        ourScreen.Apply();
    }




    private void drawline(Vector3 v13dH, Vector3 v23dH)
    {
       // print(v13dH.ToString());

        if((v13dH.z < 0) && (v23dH.z < 0))
        {
            Vector2 v1 = new Vector2(v13dH.x / v13dH.z, v13dH.y / v13dH.z);
            Vector2 v2 = new Vector2(v23dH.x / v23dH.z, v23dH.y / v23dH.z);
            if(line_clip(ref v1, ref v2))
            {
                //print("Line from " + v1.ToString() + " to " + v2.ToString());
                plot(Bresh(Convert(v1), (Convert(v2))));
            }
        }
    }
}


