using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    //singleton
    public static LevelManager sharedInstance;

    public List<LevelBlock> allLevelBlocks = new List<LevelBlock>();

    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();

    public Transform levelStartPosition;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Add a Level Block
    public void AddLevelBlock()
    {
        int randomIdx = Random.Range(0,allLevelBlocks.Count);

        LevelBlock block;

        Vector3 spawnPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0)
        {
            block = Instantiate(allLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;
        }
        else
        {
            block = Instantiate(allLevelBlocks[randomIdx]);
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }

        block.transform.SetParent(this.transform,false);

        Vector3 correction = new Vector3(spawnPosition.x-block.startPoint.position.x,spawnPosition.y-block.startPoint.position.y,0);

        block.transform.position = correction;

        currentLevelBlocks.Add(block);
    }

    public void RemoveLevelBlock()
    {

    }

    public void RemoveAllLevelBlock()
    {

    }

    public void GenerateInitialBlocks()
    {
        for(int i=0; i < 2;i++)
        {
            AddLevelBlock();
        }
    }
}
