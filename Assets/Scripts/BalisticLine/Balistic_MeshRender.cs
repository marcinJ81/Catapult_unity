using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://www.youtube.com/watch?v=iLlWirdxass
/// https://en.wikipedia.org/wiki/Projectile_motion
/// </summary>
[RequireComponent(typeof(MeshFilter))]
public class BalisticMeshRender : MonoBehaviour
{
    private Mesh mesh;
    public float meshwidth = 0.5f;

    public float velocity = 10;
    public float angle = 45;
    public int resolution = 20;
    private float g;
    private float radianAngle;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        g = Mathf.Abs(Physics2D.gravity.y);
    }
    // Start is called before the first frame update
    void Start()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        if (mesh != null && Application.isPlaying)
            MakeArcMesh(CalculateArcArray());
    }

    private void MakeArcMesh(Vector3[] arcVerts)
    {
        mesh.Clear();
        Vector3[] vertices = new Vector3[(resolution + 1) * 2];
        int[] triangles = new int[resolution * 6 * 2];

        for (int i = 0; i <= resolution; i++)
        {
            vertices[i * 2] = new Vector3(meshwidth * 0.5f, arcVerts[i].y, arcVerts[i].x);
            vertices[i * 2 + 1] = new Vector3(meshwidth * -0.5f, arcVerts[i].y, arcVerts[i].x);

            if (i != resolution)
            {
                triangles[i * 12] = i * 2;
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = i * 2 + 1;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = (i + 1) * 2;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;

                triangles[i * 12 + 6] = i * 2;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = (i + 1) * 2;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = i * 2 + 1;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1;
            }
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
    /// <summary>
    /// krzywa sklada sie z wielu odcinkow
    /// parametr resolution okresla ile ich jest
    /// </summary>
    /// <returns></returns>
    public Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        //Gdy obiekt zostanie wystrzelony z powierzchni Ziemi (wysokosc poczatkowa jest rowna zero), przebyta droga jest rowna:
        //d = (V * V * sin(2 * radianAngle)) / g
        //d - droga
        //V - predkosc
        //radianAngle - kat w radianach
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }
        return arcArray;
    }
    public Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }

    /// <summary>
    /// nie wiem czy dziala bo to ja pisalem
    /// po za tym trzeba wziasc pod uwage odcinki czyli resolution
    /// </summary>
    /// <returns></returns>
    public float CalculateTimeOfFly()
    {
        float result;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;
        result = maxDistance / velocity * Mathf.Cos(radianAngle);
        return result;
    }
}
