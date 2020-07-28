using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] ParticleSystem blockDestroyedVFX;
    [SerializeField] int maxHits;
    [SerializeField] GameObject[] hitSprites;
    
    Level level;
    GameSession gameStatus;

    int timesHit;
    int damageIndex = 0;

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
            HandleHit();

        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {       
        hitSprites[damageIndex].SetActive(true);
        damageIndex++;
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
