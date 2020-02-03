using System.Collections.Generic;
using UnityEngine;

public class DialogRandomizer : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;

    private SpriteRenderer spriteRenderer;
    private float timeToUpdateState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeToUpdateState = 0;
    }

    private void Start()
    {
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad < timeToUpdateState)
        {
            return;
        }

        spriteRenderer.enabled = !spriteRenderer.enabled;

        if (spriteRenderer.enabled)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
            timeToUpdateState += 2;
            return;
        }

        timeToUpdateState += Random.Range(4, 8);
    }
}