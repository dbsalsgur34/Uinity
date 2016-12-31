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
    Vector3 LookDirection;
    Vector2 towardvector;
    
    private void Start()
    {
        Target = this.GetComponent<Rigidbody2D>();
    }

    void KeyboardInput()
    {
        xx = Input.GetAxisRaw("Horizontal");

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

    public void AddSheepList(GameObject Sheep)
    {
        SheepList.Add(Sheep);
    }

    public void ChangeMaster(GameObject Sheep, GameObject target)
    {
        int index = SheepList.IndexOf(Sheep);

        for (int temp = index ; temp <= SheepList.Count - 1; temp++)
        {
            SheepList[temp].GetComponent<SheepControl>().Master = target;
            target.GetComponent<HeadControl>().SheepList.Add(this.SheepList[temp]);
        }
        SheepList.RemoveRange(index, SheepList.Count - index);
    } 

    private void FixedUpdate()
    {
        KeyboardInput();
        LookUpdate();
    }
}
