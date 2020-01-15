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
