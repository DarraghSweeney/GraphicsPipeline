using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphics_pipeline : MonoBehaviour
{

    model d;

    Outcode A = new Outcode(new Vector2(0.1f, 3));

    Outcode B = new Outcode(new Vector2(-2, -2));

    // Start is called before the first frame update
    void Start()
    {
        d = new model();


        A.print(A);
        B.print(B);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
