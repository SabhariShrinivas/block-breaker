using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
   
    LevelLoader level;


    private void Start()
    {
        level = FindObjectOfType<LevelLoader>();
    }
    public void countBreakbleBlocks()
    {
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            level.LoadNextScene();
        }
    }
    

}
