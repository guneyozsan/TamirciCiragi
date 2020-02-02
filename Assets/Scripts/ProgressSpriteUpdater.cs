using System.Collections.Generic;
using UnityEngine;

public class ProgressSpriteUpdater : MonoBehaviour
{
    private const int maxProgress = 100;

    [SerializeField] private List<Sprite> sprites;

    private IProgressUpdated progressUpdated;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        progressUpdated = GetComponent<IProgressUpdated>();
        progressUpdated.ProgressUpdated += ProgressUpdated_ProgressUpdated;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ProgressUpdated_ProgressUpdated(float v)
    {
        int sliceCount = sprites.Count - 1;

        for (int i = 0; i < sliceCount; i++)
        {
            if (v <= (i + 1) * (float)maxProgress / sliceCount)
            {
                spriteRenderer.sprite = sprites[i];
                return;
            }
        }

        spriteRenderer.sprite = sprites[sprites.Count - 1];
    }
}