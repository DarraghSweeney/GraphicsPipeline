using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class model 
{


    // Start is called before the first frame update


    List<Vector3> vertices;

    List<Vector3Int> faces;


    public model()
    {   
        load_vertices();
        load_faces();
        CreateUnityGameObject();
    }

    private void load_faces()
    {
        faces = new List<Vector3Int>();
        //Front

        faces.Add(new Vector3Int(4, 5, 1));
        faces.Add(new Vector3Int(4, 1, 0));
        faces.Add(new Vector3Int(4, 0, 2));
        faces.Add(new Vector3Int(4, 2, 3));
        faces.Add(new Vector3Int(4, 3, 9));
        faces.Add(new Vector3Int(9, 3, 12));
        faces.Add(new Vector3Int(9, 12, 13));
        faces.Add(new Vector3Int(9, 13, 10));
        faces.Add(new Vector3Int(10, 13, 11));
        faces.Add(new Vector3Int(10, 11, 8));
        faces.Add(new Vector3Int(8, 11, 6));
        faces.Add(new Vector3Int(7, 8, 6));
        faces.Add(new Vector3Int(7, 6, 5));
        faces.Add(new Vector3Int(5, 6, 1));

        //Back
        faces.Add(new Vector3Int(18, 15, 19));
        faces.Add(new Vector3Int(18, 14, 15));
        faces.Add(new Vector3Int(18, 16, 14));
        faces.Add(new Vector3Int(18, 17, 16));
        faces.Add(new Vector3Int(18, 23, 17));
        faces.Add(new Vector3Int(23, 26, 17));
        faces.Add(new Vector3Int(23, 27, 26));
        faces.Add(new Vector3Int(23, 24, 27));
        faces.Add(new Vector3Int(24, 25, 27));
        faces.Add(new Vector3Int(24, 22, 25));
        faces.Add(new Vector3Int(22, 20, 25));
        faces.Add(new Vector3Int(22, 21, 20));
        faces.Add(new Vector3Int(21, 19, 20));
        faces.Add(new Vector3Int(19, 15, 20));

        //left
        faces.Add(new Vector3Int(0, 14, 16));
        faces.Add(new Vector3Int(0, 16, 2));
        faces.Add(new Vector3Int(2, 16, 17));
        faces.Add(new Vector3Int(2, 17, 3));
        faces.Add(new Vector3Int(3, 17, 26));
        faces.Add(new Vector3Int(3, 26, 12));
        faces.Add(new Vector3Int(5, 19, 21));
        faces.Add(new Vector3Int(5, 21, 7));
        faces.Add(new Vector3Int(7, 21, 8));
        faces.Add(new Vector3Int(8, 21, 22));
        faces.Add(new Vector3Int(22, 24, 10));
        faces.Add(new Vector3Int(22, 10, 8));

        //right
        faces.Add(new Vector3Int(15, 1, 6));
        faces.Add(new Vector3Int(15, 6, 20));
        faces.Add(new Vector3Int(20, 6, 11));
        faces.Add(new Vector3Int(20, 11, 25));
        faces.Add(new Vector3Int(11, 13, 27));
        faces.Add(new Vector3Int(11, 27, 25));
        faces.Add(new Vector3Int(18, 4, 23));
        faces.Add(new Vector3Int(23, 4, 9));

        //top
        faces.Add(new Vector3Int(0, 1, 15));
        faces.Add(new Vector3Int(0, 15, 14));
        faces.Add(new Vector3Int(24, 23, 10));
        faces.Add(new Vector3Int(10, 23, 9));

        //bottom
        faces.Add(new Vector3Int(26, 27, 13));
        faces.Add(new Vector3Int(26, 13, 12));
        faces.Add(new Vector3Int(5, 4, 19));
        faces.Add(new Vector3Int(4, 18, 19));
    }

    private void load_vertices()
    {
        vertices = new List<Vector3>();

        //Front
        vertices.Add(new Vector3(-4,5,0.5f)); //0
        vertices.Add(new Vector3(2, 5, 0.5f)); //1
        vertices.Add(new Vector3(-4, 4, 0.5f)); //2
        vertices.Add(new Vector3(-3, 3, 0.5f)); //3
        vertices.Add(new Vector3(-1, 3, 0.5f)); //4
        vertices.Add(new Vector3(1, 3, 0.5f)); //5
        vertices.Add(new Vector3(4, 3, 0.5f)); //6
        vertices.Add(new Vector3(2, 2, 0.5f)); //7
        vertices.Add(new Vector3(2, -3, 0.5f)); //8
        vertices.Add(new Vector3(-1, -4, 0.5f)); //9
        vertices.Add(new Vector3(1, -4, 0.5f)); //10
        vertices.Add(new Vector3(4, -4, 0.5f)); //11
        vertices.Add(new Vector3(-3, -6, 0.5f)); //12
        vertices.Add(new Vector3(2, -6, 0.5f)); //13

        //Back
        vertices.Add(new Vector3(-4, 5, 1.5f));  //14
        vertices.Add(new Vector3(2, 5, 1.5f)); //15
        vertices.Add(new Vector3(-4, 4, 1.5f)); //16
        vertices.Add(new Vector3(-3, 3, 1.5f)); //17
        vertices.Add(new Vector3(-1, 3, 1.5f)); //18
        vertices.Add(new Vector3(1, 3, 1.5f)); //19
        vertices.Add(new Vector3(4, 3, 1.5f)); //20
        vertices.Add(new Vector3(2, 2, 1.5f)); //21
        vertices.Add(new Vector3(2, -3, 1.5f));//22
        vertices.Add(new Vector3(-1, -4, 1.5f)); //23
        vertices.Add(new Vector3(1, -4, 1.5f)); //24
        vertices.Add(new Vector3(4, -4, 1.5f)); //25
        vertices.Add(new Vector3(-3, -6, 1.5f)); //26
        vertices.Add(new Vector3(2, -6, 1.5f)); //27
    }


    public GameObject CreateUnityGameObject()

            {

                Mesh mesh = new Mesh();

                GameObject newGO = new GameObject();

                MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();

                MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();









                List<Vector3> coords = new List<Vector3>();

                List<int> dummy_indices = new List<int>();

                List<Vector2> text_coords = new List<Vector2>();

                List<Vector3> normalz = new List<Vector3>();



                for (int i = 0; i < faces.Count; i++)

                {

                   // Vector3 normal_for_face = normals[i / 3];

                   // normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

                    coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3);// text_coords.Add(_texture_coordinates[_texture_index_list[i].x]); normalz.Add(normal_for_face);

                    coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2);// text_coords.Add(_texture_coordinates[_texture_index_list[i].y]); normalz.Add(normal_for_face);

                    coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1);// text_coords.Add(_texture_coordinates[_texture_index_list[i].z]); normalz.Add(normal_for_face);

                }



                mesh.vertices = coords.ToArray();

                mesh.triangles = dummy_indices.ToArray();

                mesh.uv = text_coords.ToArray();

                mesh.normals = normalz.ToArray(); ;



                mesh_filter.mesh = mesh;

                return newGO;



            }


    


}
