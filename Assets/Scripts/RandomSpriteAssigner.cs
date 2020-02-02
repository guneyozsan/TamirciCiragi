using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteAssigner : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteIndex = Random.Range(0, sprites.Count);
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}