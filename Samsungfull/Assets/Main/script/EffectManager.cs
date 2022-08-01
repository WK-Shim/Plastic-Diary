using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentscale = gameObject.transform.localScale;
        transform.localScale = transform.localScale + new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, -speed * Time.deltaTime);
        Material mat = gameObject.GetComponent<Renderer>().material;
        mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - Time.deltaTime / 5));
        if (gameObject.transform.localScale.x <= 1)
        {
            Destroy(gameObject);
        }
    }
}