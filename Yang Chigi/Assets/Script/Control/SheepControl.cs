using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SheepState
{
    NOOWNER,
    HAVEOWNER
}

// 항상 일정 거리를 유지하도록!
public class SheepControl : MonoBehaviour
{
    // 공개 항목
    public GameObject leader;
    public GameObject Master;

    public int distance_permitted;
    public int limit_count;
    public float speed;
    public SheepState SS;

    //비공개 항목
    public Vector3 lastLeaderPosition;
    public List<Vector3> positions;
    
    // Use this for initialization

    void Start()
    {
        positions.Add(leader.transform.position);
    }

    void FollowLeader()
    {
        if (SS == SheepState.HAVEOWNER)
        {
            if (lastLeaderPosition != positions[positions.Count - 1] && positions.Count <= limit_count)
            {
                positions.Add(leader.transform.position);
            }

            if (positions.Count >= distance_permitted)
            {
                if (gameObject.transform.position != positions[0])
                {
                    transform.position = Vector3.MoveTowards(transform.position, positions[0], Time.fixedDeltaTime * speed);
                }
                else
                {
                    positions.Remove(positions[0]);
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
            lastLeaderPosition = leader.transform.position;
        }
    }                      //리더를 따라가는 함수.

    void OnTriggerEnter2D(Collider2D col)       //부딪힌 오브젝트의 종류에 따른 반응 정리
    {
        if (col.gameObject == this.Master)
        {
            return;
        }
        else if (col.gameObject.tag == "Head")
        {
            CheckOwner(col.gameObject);
        }
    }

    void CheckOwner(GameObject target)          //태그가 Head 인 오브젝트와 부딪혔을 시에 시행하는 함수
    {
        if (SS == SheepState.NOOWNER)
        {
            this.Master = target.gameObject;
            if (Master.GetComponent<HeadControl>().SheepList.Count == 0)
            {
                this.leader = this.Master;
            }
            else
            {
                this.leader = Master.GetComponent<HeadControl>().SheepList[Master.GetComponent<HeadControl>().SheepList.Count - 1];
            }
            SS = SheepState.HAVEOWNER;
            Master.GetComponent<HeadControl>().SheepList.Add(this.gameObject);
            positions.Add(leader.transform.position);
        }
        else
        {
            
        }
    }

    // Update is called once per frame
    private void Update()
    {
        FollowLeader();
    }

}

