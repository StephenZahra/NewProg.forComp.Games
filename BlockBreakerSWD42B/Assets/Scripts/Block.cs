using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    [SerializeField] int maxHits;
    [SerializeField] int currentHits = 0;

    [SerializeField] Sprite[] hitSprites;

    Level Level;

    private void Start()
    {
        Level = FindObjectOfType<Level>();
        if(gameObject.tag == "Breakable")
        {
            Level.CountBreakableBlocks();
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //play audioclip at camera's position
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        if(gameObject.tag == "Breakable")
        {
            currentHits++;

            if(currentHits >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }

    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        Level.BlockDestroyed();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, this.transform.position, this.transform.rotation);
        Destroy(sparkles, 1f);
    }

    private void ShowNextHitSprite()
    {
        int spriteindex = currentHits - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteindex];
    }
}
