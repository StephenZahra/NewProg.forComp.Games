using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    Level Level;

    private void Start()
    {
        Level = FindObjectOfType<Level>();

        Level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().AddToScore();

        //play audioclip at camera's position
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        Level.BlockDestroyed();
        Destroy(gameObject);
    }
}
