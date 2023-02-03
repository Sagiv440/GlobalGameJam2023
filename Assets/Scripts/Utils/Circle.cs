using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Circle : MonoBehaviour
{
    public int segments;
    public Color col;
    public float xradius;
    public float zradius;
    public Vector3 rotationOffset;  //Offset rotation
    public Vector3 positionOffset;  //Offset position
    public float scaleFac = 1;

    void Start()
    {
        if (scaleFac != 0f) { } else { scaleFac = 1f; }
        col.a = 1;  // cause the object not been transparent at start
    }

    void Update()
    {

        circle();
    }

    void circle()
    {
        float x = 0f;
        float xo = 0f;
        float y = 0f;
        float yo = 0f;
        float z = 0f;
        float zo = 0f;
        float angle = 0f;

        /*Quaternion rto = Quaternion.Euler(rotationOffset) * transform.rotation;
        Vector3 circleOffset = transform.position + positionOffset;
        Vector3 newCenter = rto * circleOffset;*/
        Vector3 newCenter = transform.position + positionOffset;

        var vo = Vector3.zero;
        var vn = Vector3.zero;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * zradius;

            vo.x = newCenter.x + xo;
            vo.y = newCenter.y + yo;
            vo.z = newCenter.z + zo;

            vn.x = newCenter.x + x;
            vn.y = newCenter.y + y;
            vn.z = newCenter.z + z;

            if (i > 0) Debug.DrawLine(vo, vn, col);

            xo = x;
            yo = y;
            zo = z;
            angle += (360f / segments);
        }
    }
}