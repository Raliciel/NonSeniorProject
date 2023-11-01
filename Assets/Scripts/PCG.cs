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
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = player.transform.position.y;

        ChunkScript firstChunk = SelectRandomChunk();
        ChunkScript prevChunk = Instantiate(firstChunk, Vector3.up * (playerLevel + margin + firstChunk.GetSize().y), Quaternion.identity);
        Debug.Log(prevChunk.GetSize() + "," + prevChunk.gameObject.transform.position.y);

        if (chunkList != null)
        {
            for (int i = 1; i < startChunkNum; i++)
            {
                ChunkScript chunk = SelectRandomChunk();
                prevChunk = Instantiate(chunk, Vector3.up * (prevChunk.transform.position.y + margin + chunk.GetSize().y / 2 + prevChunk.GetSize().y / 2), Quaternion.identity);
                Debug.Log(prevChunk.transform.position.y + margin + chunk.GetSize().y / 2 + prevChunk.GetSize().y / 2 + "," + prevChunk.gameObject.transform.position.y);
            }
        }
    }

    ChunkScript SelectRandomChunk()
    {
        return chunkList[Random.Range(0, chunkList.Count)];
    }

    void Update()
    {

    }

    // Update is called once per frame
}
