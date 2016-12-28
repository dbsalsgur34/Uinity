using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepControl : MonoBehaviour
{
    // 항상 일정 거리를 유지하도록!
    public GameObject target;
    public List<Vector3> positions;
    public int distance_permitted;
    public float speed;
    private Vector3 lastLeaderPosition;
    // Use this for initialization
    void Start()
    {
        positions.Add(target.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lastLeaderPosition != positions[positions.Count - 1])
        {
            positions.Add(target.transform.position);
        }

        if (positions.Count >= distance_permitted)
        {
            if (gameObject.transform.position != positions[0])
            {

                transform.position = Vector3.MoveTowards(transform.position, positions[0], Time.deltaTime * speed);

            }
            else
            {
                positions.Remove(positions[0]);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        lastLeaderPosition = target.transform.position;
    }
}

