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

        if ((startOutcode + endOutcode) == inScreen)
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


    // Start is called before the first frame update
    void Start()
    {
        d = new model();

        Vector2 Start = new Vector2(0.7f, 0.6f);
        Vector2 end = new Vector2(0.5f, -0.2f);
        line_clip(ref Start, ref end);

    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
