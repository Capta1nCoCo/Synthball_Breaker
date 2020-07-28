using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] ParticleSystem blockDestroyedVFX;

    Level level;
    GameSession gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        gameStatus.AddToScore();
        PlayBlockDestroyedSFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerBlockDestroyedVFX();
    }

    private void PlayBlockDestroyedSFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 2f);
    }

    private void TriggerBlockDestroyedVFX()
    {
        var fx = Instantiate(blockDestroyedVFX, transform.position, transform.rotation);
        fx.Play();
    }
}
