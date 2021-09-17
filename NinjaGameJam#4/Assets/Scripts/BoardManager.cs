using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    /*
    public static BoardManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }*/
    
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 50;
    public int rows = 50;
    public Count treeCount = new Count(500, 1000);
    public Count enemyCount = new Count(10, 20);
    public GameObject spawn;
    public GameObject[] decorTiles;
    public GameObject[] trees;
    public GameObject[] enemySpawns;
    public GameObject[] outerBarrier;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();
   

    void InitialiseList()
    {
        gridPositions.Clear();

        for(int x = 1; x < columns - 1; x++)
        {
            for(int y = 1; y < rows-1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    public void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for(int x = -1; x < columns + 1; x++)
        {
            for(int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = decorTiles[Random.Range(0, decorTiles.Length-1)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerBarrier[Random.Range(0, outerBarrier.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);

        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();

            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene()
    {
        BoardSetup();
        InitialiseList();

        LayoutObjectAtRandom(trees, treeCount.minimum, treeCount.maximum);
        LayoutObjectAtRandom(enemySpawns, enemyCount.minimum, enemyCount.maximum);

        Instantiate(spawn, new Vector3(25, 5, 0f), Quaternion.identity);
    }

}