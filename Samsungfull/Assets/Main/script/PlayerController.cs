using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_speed;

    public float gravityModifier;

    public float jumpPower;
    float jump_timer;

    public CharacterController p_con;

    Vector3 p_pos;

    public Transform cam;

    public float m_sens = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

   
    // Update is called once per frame
    void Update()
    {

        float yStore = p_pos.y;


        // p_pos.x = Input.GetAxis("Horizontal") * m_speed * Time.deltaTime;
        // p_pos.z = Input.GetAxis("Vertical") * m_speed * Time.deltaTime;

        Vector3 ver_move = transform.forward * Input.GetAxis("Vertical");
        Vector3 hori_move = transform.right * Input.GetAxis("Horizontal");

        p_pos = ver_move + hori_move;
        p_pos.Normalize();
        p_pos = p_pos * m_speed * Time.deltaTime;

        p_pos.y = yStore;
        p_pos.y += Physics.gravity.y * gravityModifier * Time.deltaTime;


        p_con.Move(p_pos);

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.rotation =
            Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + mouseInput.x,
            transform.rotation.eulerAngles.z);

        cam.rotation = Quaternion.Euler(cam.rotation.eulerAngles + new Vector3(-mouseInput.y, 0, 0));

        jump_timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && jump_timer >= 1f && p_con.isGrounded)
        {
            p_pos.y = jumpPower * Time.deltaTime;
            jump_timer = 0f;
        }
    }
}