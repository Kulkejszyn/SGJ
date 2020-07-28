using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[System.Serializable]
public class SpriteSet
{
    public Sprite[] sprites;
}

public class SpriteSetMovementAnimResolver : MovementAnimResolver
{
    public float _spriteTime;
    public SpriteRenderer sr;
    public SpriteSet[] sprites;

    private int _prevSide = -1;

    private float _timer;

    private void Awake()
    {
        Setup();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Calculate();
        Resolve();
        ApplySprite();
    }

    private void ApplySprite()
    {
        int count = sprites[Side].sprites.Length;

        if (_prevSide != Side || Mag < movementThreshold)
        {
            // direction changed or stopped

            _timer = 0;

            sr.sprite = sprites[Side].sprites[0];
        }
        else
        {
            // same direction

            _timer += Time.deltaTime * (minAnimSpeed + animSpeedMod);// * Mag);

            sr.sprite = sprites[Side].sprites[Mathf.FloorToInt(_timer / _spriteTime) % count];
        }

        _prevSide = Side;
    }
}
