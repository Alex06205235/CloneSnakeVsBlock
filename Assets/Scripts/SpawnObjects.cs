using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

interface ISpawnChunk
{
    List<GameObject> Blocks { get; set; }
    List<GameObject> Foods { get; set; }
    (float start, float end) Distance { get; set; }
    GameObject GameObject { get; set; } 
}

class SpawnChunk : ISpawnChunk
{
    List<GameObject> _blocks = new List<GameObject>();
    List<GameObject> _foods = new List<GameObject>();
    public List<GameObject> Blocks
    {
        get { return _blocks; }
        set { _blocks = value; }
    }
    public List<GameObject> Foods
    {
        get { return _foods; }
        set { _foods = value; }
    }
    public (float start, float end) Distance { get; set; }
    public GameObject GameObject { get; set; }
}

public class SpawnObjects : MonoBehaviour
{
    GameObject _spawnArea;
    BoxCollider _box;
    Vector3 _startPosition;
    public GameObject blockPrefab;
    public int dof;
    public GameObject foodPrefab;
    public int maxFoodCount;
    public int maxFoodPerLine;
    public int maxBlockPerLine;
    public float distance;
    public Snake snake;
    List<ISpawnChunk> _chunks = new List<ISpawnChunk>();

    void Start()
    {
        _spawnArea = GameObject.FindGameObjectWithTag("SpawnArea");
        _box = _spawnArea.GetComponent<BoxCollider>();
        _startPosition = _box.bounds.min;
        CreateObjects();
        StartCoroutine(GarbageCollectorObjects());
    }

    IEnumerator GarbageCollectorObjects()
    {
        while (_chunks.Count > 0)
        {
            List<ISpawnChunk> newChunks = new List<ISpawnChunk>();
            foreach(ISpawnChunk chunk in _chunks)
            {
                if (snake.transform.position.z > chunk.Distance.end)
                {
                    Destroy(chunk.GameObject);
                }
                else
                {
                    newChunks.Add(chunk);
                }
            }
            
            _chunks = newChunks;
            yield return new WaitForSeconds(1f);
        }
    }
    
    void Update()
    {
        if (snake.transform.position.z < _startPosition.z)
            return;
        _startPosition.Set(_startPosition.x, _startPosition.y, _startPosition.z + (distance * dof));
        CreateObjects();
    }

    void CreateObjects()
    {
        Bounds boxBounds = _box.bounds;
        Vector3 blockPrefabScale = blockPrefab.transform.localScale;
        Vector3 foodPrefabScale = foodPrefab.transform.localScale;
        float startZ = _startPosition.z;
        for (int i = 0; i < dof; i++)
        {
            if (boxBounds.max.z < startZ + distance) continue;
            GameObject spawnChunkObject = new GameObject("SpawnChunk");
            spawnChunkObject.transform.parent = _spawnArea.transform;
            spawnChunkObject.tag = "SpawnChunk";
            _chunks.Add(new SpawnChunk());

            ISpawnChunk targetChunk = _chunks[^1];
            
            List<Vector3> foodPositions = new List<Vector3>();
            float foodStartZ = startZ + blockPrefabScale.z * 4;
            float foodEndZ = startZ + distance - blockPrefabScale.z * 2;
            
            for (int x = 0; x < Random.Range(1, maxFoodCount); x++)
            {
                for (int j = 0; j < Random.Range(1, maxFoodPerLine); j++)
                {
                    foodPositions.Add(new Vector3(Random.Range(boxBounds.min.x + foodPrefabScale.x, boxBounds.max.x - foodPrefabScale.x), foodPrefabScale.y / 2, Random.Range(foodStartZ, foodEndZ)));
                }
            }
            foreach(Vector3 foodPosition in foodPositions)
            {
                GameObject food = Instantiate(foodPrefab, foodPosition, Quaternion.identity);
                food.transform.parent = spawnChunkObject.transform;
                targetChunk.Foods.Add(food);
            }
            
            List<Vector3> blockPositions = new List<Vector3>();
            float offset = 0;
            for (int x = 0; x < maxBlockPerLine; x++)
            {
                offset += x > 0 ? blockPrefab.transform.localScale.x : 0;
                blockPositions.Add(new Vector3(boxBounds.min.x + (blockPrefabScale.x / 2) + offset, (blockPrefabScale.y / 2), startZ));
            }
            for (int x = 0; x < blockPositions.Count; x++)
            {
                int emptyIndex = Random.Range(0, maxBlockPerLine - 1);
                if (emptyIndex == x)
                    continue;
                GameObject block = Instantiate(blockPrefab, blockPositions[x], Quaternion.identity);
                block.transform.parent = spawnChunkObject.transform;
                targetChunk.Blocks.Add(block);
            }
            targetChunk.GameObject = spawnChunkObject;
            targetChunk.Distance = (startZ, startZ + distance);
            startZ += distance;
        }
    }
}

