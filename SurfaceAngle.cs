using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceAngle : MonoBehaviour
{
    public Vector3 raypos1;
    public Vector3 forpos;
    public Vector3 backpos;
    public float playrot;
    Vector3 directions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        raypos1 = transform.TransformPoint(Vector3.forward * transform.localScale.x / 2 );

        if (Physics.Raycast(new Vector3(raypos1.x, transform.position.y, raypos1.z), transform.up * -1, out RaycastHit hit1))
        {
            forpos = hit1.point;
        }
        raypos1 = transform.TransformPoint(Vector3.back * transform.localScale.x / 2 /*이거 나중에 콜리아더로*/);

        if (Physics.Raycast(new Vector3(raypos1.x, transform.position.y, raypos1.z), transform.up * -1, out RaycastHit hit2))
        {
            backpos = hit2.point;
        }
        if (backpos.y == forpos.y)
        {
            playrot = 0;
            print("0");
        }
        else
        {
            playrot = Vector3.Angle(forpos, backpos);
        }
        transform.localRotation = Quaternion.Euler(playrot, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        print(transform.rotation.eulerAngles);
    }
}
