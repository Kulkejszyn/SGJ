using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementAnimResolver : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    private const string animSideIntName = "side";
    private const string animIdleBoolName = "idle";
    public const float movementThreshold = 0.9f;
    private const float posChangeThreshold = 0.001f;
    public const float animSpeedMod = 1f;
    public const float minAnimSpeed = 0f;

    private List<Vector2> _sides = new List<Vector2>();

    private Vector2 _vel;
    private Vector2 _prevPos;
    private float _posChange;

    public float Mag { get; private set; }
    public int Side { get; private set; } = 2;
    public bool Idle { get; private set; } = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        Setup();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Calculate();
        Resolve();
        Apply();
    }

    private void FixedUpdate()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        _posChange = (pos - _prevPos).magnitude;
        _prevPos = pos;
    }

    public void Setup()
    {
        _sides.Add(new Vector2(0, 1)); // up/back - 0
        _sides.Add(new Vector2(1, 0)); // right - 1
        _sides.Add(new Vector2(0, -1)); // down/front - 2
        _sides.Add(new Vector2(-1, 0)); // left - 3
    }

    public void Calculate()
    {
        _vel = rb.velocity;
        Mag = _vel.magnitude;

    }

    public void Resolve()
    {
        if(Mag < movementThreshold || _posChange < posChangeThreshold)
        {
            Idle = true;
        }
        else
        {
            Idle = false;

            List<float> dotProducts = new List<float>();

            foreach (var side in _sides)
            {
                dotProducts.Add(Vector2.Dot(_vel, side));
            }

            int index = dotProducts.IndexOf(dotProducts.Max());

            Side = index;
        }
    }

    private void Apply()
    {
        anim.SetInteger(animSideIntName, Side);

        anim.SetBool(animIdleBoolName, Idle);

        anim.speed = minAnimSpeed + animSpeedMod;// * Mag;
    }

    public void TurnToObject(Vector2 pos)
    {
        List<float> dotProducts = new List<float>();

        Vector2 vect = pos - new Vector2(transform.position.x, transform.position.y);

        foreach (var side in _sides)
        {
            dotProducts.Add(Vector2.Dot(vect, side));
        }

        int index = dotProducts.IndexOf(dotProducts.Max());

        Side = index;
    }

}
