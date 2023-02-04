using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject Target;
    public bool Fire = false;

    public void setProj(float sp, GameObject t)
    {
        speed = sp;
        Target = t;
        Fire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Destroy(this.gameObject);
        }
        else if(CommonFunctions.IsClose(Target.transform.position, this.transform.position, 0.2f))
        {
            Destroy(this.gameObject);
        }

        if (Fire == true && Target != null)
        {
            this.transform.LookAt(Target.transform);
            this.transform.position += (Vector3)(Matrix4x4.Rotate(this.transform.rotation) * (Vector4)(Vector3.forward * speed));
        }
    }
}
