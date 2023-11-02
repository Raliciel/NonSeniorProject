using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCG : MonoBehaviour
{
    private GameObject player;
    private float playerLevel;
    [SerializeField] List<ChunkScript> chunkList;
    [SerializeField] private int startChunkNum = 3;
    [SerializeField] private float margin = 0;

    private ChunkScript templateChunk, prevChunk, currentChunk;
    private Vector2 deltaFromCenter;

    ChunkScript SelectRandomChunk()
    {
        return chunkList[Random.Range(0, chunkList.Count)];
    }

    void GenerateChunk(int chunkNum)
    {
        for (int i = 1; i < chunkNum; i++)
        {
            templateChunk = SelectRandomChunk();
            deltaFromCenter = Vector3.zero - templateChunk.GetBound().center;
            currentChunk = Instantiate(templateChunk, (prevChunk.GetBound().center.y + templateChunk.GetBound().size.y / 2 + prevChunk.GetBound().size.y / 2 + margin) * Vector2.up + deltaFromCenter, Quaternion.identity);
            prevChunk = currentChunk;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = player.transform.position.y;

        templateChunk = SelectRandomChunk();
        deltaFromCenter = Vector3.zero - templateChunk.GetBound().center;
        currentChunk = Instantiate(templateChunk, (playerLevel + templateChunk.GetBound().size.y / 2) * Vector2.up + deltaFromCenter, Quaternion.identity);
        Debug.Log(templateChunk.GetBound().center * Vector2.up + deltaFromCenter + "," + currentChunk.GetBound().center);
        prevChunk = currentChunk;

        GenerateChunk(startChunkNum);
    }

    void Update()
    {
        if (player != null && prevChunk.GetBound().center.y < player.transform.position.y)
        {
            GenerateChunk(startChunkNum);
        }
    }

    // Update is called once per frame
}
