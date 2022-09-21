using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;

    public TextMeshProUGUI scoreText;
    [HideInInspector] static public int score = 0;

    private void Update()
    {
        scoreText.text = "SCORE: " + score;
    }

    void FixedUpdate()
    {
        setPlayerMovement();
    }

    void setPlayerMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }
}
