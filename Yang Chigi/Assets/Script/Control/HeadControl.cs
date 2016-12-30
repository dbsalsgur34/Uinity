using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour {

    //공개 항목
    public float Maxspeed;
    public float Accel;
    public float speed;
    public Rigidbody2D Target;
    public List<GameObject> SheepList;

    //비공개 항목
    float xx;
    float yy;
    Vector3 LookDirection;
    Vector2 towardvector;
    
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
