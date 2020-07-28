using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    public float dist;
    public float avgTime;
    public float timeRand;

    private const float ignoreDist = 0.1f;
    private const float moveAwayDist = 0.01f;

    private Vector2 _startPos;
    private Vector2 _aimPos;

    private float _time;
    private float _timer;

    private void Awake()
    {
        _startPos = transform.position;
        _aimPos = _startPos;

        SetNewTime();
    }

    void Start()
    {
        
    }


    void Update()
    {
        // move to aimPos
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 diffPos = _aimPos - pos;

        if (diffPos.magnitude >= ignoreDist)
            rb.velocity = (_aimPos - pos).normalized * speed;
        else
            rb.velocity = Vector2.zero;

        // timer
        _timer += Time.deltaTime;
        if(_timer >= _time)
        {
            _timer = 0;
            SetNewTime();

            // set new aim pos
            float x = _startPos.x + Random.Range(-dist, dist);
            float y = _startPos.y + Random.Range(-dist, dist);
            _aimPos = new Vector2(x, y);
        }
    }

    private void SetNewTime()
    {
        _time = avgTime + Random.Range(-timeRand, timeRand);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        // stop movement if collided with something

        _aimPos = transform.position;

        // move a bit away from the object

        Vector2 diffPos = collision.transform.position - transform.position;

        transform.Translate(-diffPos.normalized * moveAwayDist);
    }

}
