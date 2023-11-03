using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreCount : MonoBehaviour
{
    Transform player;
    Text scoreText;
    float startingHeight = 0;
    float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startingHeight = player.position.y;
        score = player.position.y - startingHeight; //0
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        if (score < player.position.y - startingHeight - 1.78f)
        {
            score = player.position.y - startingHeight - 1.78f;
            scoreText.text = score.ToString("F2") + "cm";
        }
    }
}
