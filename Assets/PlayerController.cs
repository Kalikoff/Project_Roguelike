using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    static public int health = 100;
    public TextMeshProUGUI hpText;
    public float SPEED;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        hpText.text = "HP: " + health;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        _rb.AddForce(movement * SPEED);

        Vector3 pos = new Vector3(_rb.position.x, _rb.position.y, 0.0f);
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos;
        float playerRotatianAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        _rb.MoveRotation(playerRotatianAngle);
    }
}
