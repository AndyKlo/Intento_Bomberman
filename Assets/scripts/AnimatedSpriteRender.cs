using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRender : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Sprite idleSprite;

    public float animationTime = 0.25f;
    public int frame;

    public bool loop = true;
    public bool idle = true;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void Start()
    {
        InvokeRepeating("CambiarImagen", animationTime, animationTime);
        /*
        sprites = Resources.LoadAll<Sprite>("Sprites/Player");
        CambiarImagen();
        */
    }
    void CambiarImagen()
    {
        frame++;
        if (loop && frame >= sprites.Length)
        {
            frame = 0;
        }
            if (idle)
            {
                spriteRenderer.sprite = idleSprite;
            }
            else if (frame >= 0 && frame < sprites.Length)
            {
                spriteRenderer.sprite = sprites[frame];
            }
    }

    private void Update()
    {
    }
    private void PutBomb()
    {
    }
    
}
