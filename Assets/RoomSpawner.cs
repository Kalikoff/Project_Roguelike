using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    static private RoomVariants variants;
    static private RoomVariants example;
    private int rand;
    private bool spawned = false;
    private float waitTime = 5f;
    [HideInInspector] static public int count = 0;

    [HideInInspector] static public int maxOneWayRooms = 0; // 0
    [HideInInspector] static public int maxTwoWayRooms = 5; // 1 2 3
    [HideInInspector] static public int maxThreeWayRooms = 2; // 4 5 6
    [HideInInspector] static public int maxFourWayRooms = 0; // 7

    [HideInInspector] static public bool isMaxOneWayRooms = true; // 0
    [HideInInspector] static public bool isMaxTwoWayRooms = false; // 1 2 3
    [HideInInspector] static public bool isMaxThreeWayRooms = false; // 4 5 6
    [HideInInspector] static public bool isMaxFourWayRooms = false; // 7

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        example = GameObject.FindGameObjectWithTag("RoomsCopy").GetComponent<RoomVariants>();
        
        Destroy(gameObject, waitTime);

        Invoke("Spawn", 0.2f);

        count++;
    }

    public void Spawn()
    {
        if (count < 150)
        {
            if (maxOneWayRooms <= 0 && !isMaxOneWayRooms)
            {
                variants.upRooms.Remove(example.upRooms[0]);
                variants.downRooms.Remove(example.downRooms[0]);
                variants.leftRooms.Remove(example.leftRooms[0]);
                variants.rightRooms.Remove(example.rightRooms[0]);

                isMaxOneWayRooms = true;
            }

            if (maxTwoWayRooms <= 0 && !isMaxTwoWayRooms)
            {
                for (int i = 1; i <= 3; i++)
                {
                    variants.upRooms.Remove(example.upRooms[i]);
                    variants.downRooms.Remove(example.downRooms[i]);
                    variants.leftRooms.Remove(example.leftRooms[i]);
                    variants.rightRooms.Remove(example.rightRooms[i]);
                }

                isMaxTwoWayRooms = true;

            }

            if (maxThreeWayRooms <= 0 && !isMaxThreeWayRooms)
            {
                for (int i = 4; i <= 6; i++)
                {
                    variants.upRooms.Remove(example.upRooms[i]);
                    variants.downRooms.Remove(example.downRooms[i]);
                    variants.leftRooms.Remove(example.leftRooms[i]);
                    variants.rightRooms.Remove(example.rightRooms[i]);
                }

                isMaxThreeWayRooms = true;
            }

            if (maxFourWayRooms <= 0 && !isMaxFourWayRooms)
            {
                variants.upRooms.Remove(example.upRooms[7]);
                variants.downRooms.Remove(example.downRooms[7]);
                variants.leftRooms.Remove(example.leftRooms[7]);
                variants.rightRooms.Remove(example.rightRooms[7]);

                isMaxFourWayRooms = true;
            }

            if (!spawned)
            {
                if (direction == Direction.Up)
                {
                    rand = Random.Range(0, variants.upRooms.Count);
                    Instantiate(variants.upRooms[rand], transform.position, variants.upRooms[rand].transform.rotation);
                }
                else if (direction == Direction.Down)
                {
                    rand = Random.Range(0, variants.downRooms.Count);
                    Instantiate(variants.downRooms[rand], transform.position, variants.downRooms[rand].transform.rotation);
                }
                else if (direction == Direction.Left)
                {
                    rand = Random.Range(0, variants.leftRooms.Count);
                    Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
                }
                else if (direction == Direction.Right)
                {
                    rand = Random.Range(0, variants.rightRooms.Count);
                    Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
                }

                if (rand == 0)
                    maxOneWayRooms--;
                else if (rand >= 1 && rand <= 3)
                    maxTwoWayRooms--;
                else if (rand >= 4 && rand <= 6)
                    maxThreeWayRooms--;
                else if (rand == 7)
                    maxFourWayRooms--;

                spawned = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Room_Point") && collision.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }
}