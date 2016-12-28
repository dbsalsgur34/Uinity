using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour {

    public Vector3 LookDirection;

    public float Maxspeed;
    public float Accel;

    public float speed;

    public float xx;
    public float yy;

    public Vector2 towardvector;
    public Rigidbody2D Target;

    private void Start()
    {
        Target = this.GetComponent<Rigidbody2D>();
    }

    void KeyboardInput()
    {
        xx = Input.GetAxisRaw("Horizontal");
        yy = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.RightArrow))
        {
            LookDirection = xx * Vector3.forward;
            Target.AddForce(Vector2.right * Accel);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LookDirection = xx * Vector3.forward;
            Target.AddForce(Vector2.left * Accel);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Target.AddForce(Vector2.up * Accel);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Target.AddForce(Vector2.down * Accel);
        }

    }

    void LookUpdate()
    {
        Quaternion R = Quaternion.LookRotation(LookDirection);
        transform.rotation = R;
    }

    private void FixedUpdate()
    {
        KeyboardInput();
        LookUpdate();
    }
}
