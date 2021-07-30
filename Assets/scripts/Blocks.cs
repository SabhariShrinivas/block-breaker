using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    Level level;
    GameStatus gameStatus;
    [SerializeField] GameObject sparkleVFX;
    [SerializeField] int maxHit = 0;
    [SerializeField] Sprite[] hitSprites;
    int hit = 0;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.countBreakbleBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit++;
        if (hit >= maxHit)
        {
            Destroy(gameObject);
            level.BlockDestroyed();
            gameStatus.AddScore();
            TriggerSparkleVFX();
        }
        else
        {
            int spriteIndex = hit-1;
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

    }
    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(sparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
