using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Background : MonoBehaviour
{
    private SpriteRenderer _sprite;

    [SerializeField] private float _scaleCoeff;

    // Use this for initialization
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        float cameraHeight = Camera.main.orthographicSize * _scaleCoeff;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = _sprite.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.localScale = scale;
    }
}
