using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class model 
{


    // Start is called before the first frame update


    internal List<Vector3> vertices;

    internal List<Vector3Int> faces;


    public model()
    {   
        load_vertices();
        load_faces();
       // CreateUnityGameObject();
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
        vertices.Add(new Vector3(-4, 5, 0.5f)); //0
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



        print_verts(vertices);

        Vector3 axis = new Vector3(16, 0, 0);
        axis.Normalize();
        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 rotation_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(-22, axis), Vector3.one);

        print_matrix(rotation_matrix);

        List<Vector3> image_after_rotation = get_image(vertices, rotation_matrix);

        print_verts(image_after_rotation);


        //Scale

        Vector3 Scale = new Vector3(5, 3, 2);


        Matrix4x4 Scale_Matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Scale);

        print_matrix(Scale_Matrix);

        List<Vector3> image_after_scale = get_image(image_after_rotation, Scale_Matrix);

        print_verts(image_after_scale);

        //Transform

        Vector3 Tranform = new Vector3(3, -3, 1);

        Matrix4x4 Transformation_Matrix = Matrix4x4.TRS(Tranform, Quaternion.identity, Vector3.one);

        print_matrix(Transformation_Matrix);

        List<Vector3> image_after_Transformation = get_image(image_after_scale, Transformation_Matrix);

        print_verts(image_after_Transformation);


        //SingleMatrix

        Matrix4x4 SingleMatrix = (Transformation_Matrix * Scale_Matrix * rotation_matrix);

        print_matrix(SingleMatrix);

        List<Vector3> image_after_all = get_image(vertices, SingleMatrix);

        print_verts(image_after_all);


        Matrix4x4 ViewingMatrix = Matrix4x4.LookAt(new Vector3(18, 3, 50), (new Vector3(0, 16, 0).normalized), (new Vector3(1, 0, 16)).normalized);

        print_matrix(ViewingMatrix);

        List<Vector3> Image_after_Viewing = get_image(image_after_all, ViewingMatrix);

        print_verts(Image_after_Viewing);

        Matrix4x4 ProjectionMatrix = Matrix4x4.Perspective(120, 1, 1, 1000);
        print_matrix(ProjectionMatrix);

        List<Vector3> Image_After_Projection = get_image(Image_after_Viewing, ProjectionMatrix);
        print_verts(Image_After_Projection);

        Matrix4x4 MatrixForEverything = (ProjectionMatrix * ViewingMatrix * SingleMatrix);
        print_matrix(MatrixForEverything);

        List<Vector3> Final_Image = get_image(vertices, MatrixForEverything);
        print_verts(Final_Image);

        List<Vector2> ProjectionByHand = new List<Vector2>();
        foreach(Vector3 MyVector in Image_after_Viewing)
        {
            ProjectionByHand.Add(new Vector2(MyVector.x / MyVector.z, MyVector.y / MyVector.z));
        }

        print_2D(ProjectionByHand);

        void print_matrix(Matrix4x4 matrix)
        {
            string path = "Assets/test.txt";
            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);

            for (int i = 0; i < 4; i++)
            {
                Vector4 row = matrix.GetRow(i);
                writer.WriteLine(row.x.ToString() + "   ,   " + row.y.ToString() + "   ,   " + row.z.ToString() + "   ,   " + row.w.ToString());


            }

            writer.Close();

        }

        void print_verts(List<Vector3> v_list)
        {
            string path = "Assets/test.txt";
            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            foreach (Vector3 v in v_list)
            {
                writer.WriteLine(v.x.ToString() + "   ,   " + v.y.ToString() + "   ,   " + v.z.ToString() + "   ,   ");

            }
            writer.Close();
        }

         void print_2D(List<Vector2> v_list)
        {
            string path = "Assets/2D.txt";
            StreamWriter writer = new StreamWriter(path, true);
            foreach (Vector2 v in v_list)
            {
                writer.WriteLine(v.x.ToString() + "   ,   " + v.y.ToString());

            }
            writer.Close();
        }
    }

    internal List<Vector3> get_image(List<Vector3> list_verts, Matrix4x4 transform_matrix)
    {
        List<Vector3> hold = new List<Vector3>();

        foreach (Vector3 v in list_verts)
        {
            Vector4 v2 = new Vector4(v.x, v.y, v.z, 1);
            hold.Add(transform_matrix * v2);
        }
        return hold;

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
