using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] EnemyTypes;
    public GameObject[] BoxTypes;
    public GameObject[] Walls;

    [HideInInspector] public List<GameObject> Enemies;

    private bool isPlayerEnter = false;
    public Transform[] spawnPoint;
    public Transform[] boxSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            isPlayerEnter = true;

            foreach (Transform spawner in spawnPoint)
            {
                int type = Random.Range(0, EnemyTypes.Length);
                GameObject enemy = Instantiate(EnemyTypes[type], spawner.position, transform.rotation);

                Enemies.Add(enemy);
            }

            foreach(Transform spawner in boxSpawnPoint)
            {
                int isSpawn = Random.Range(0, 2);

                //if (isSpawn == 1)
                //{
                    int type = Random.Range(0, BoxTypes.Length);
                    Instantiate(BoxTypes[type], spawner.position, transform.rotation);
                //}
            }

            SetWallsActive(true);
            StartCoroutine(CheckEnemies());
        }
    }

    private void Update()
    {
        if (isPlayerEnter)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i] == null)
                    Enemies.RemoveAt(i);
            }
        }
    }

    private void SetWallsActive(bool status)
    {
        for (int i = 0; i < Walls.Length; i++)
        {
            if (Walls[i] != null)
                Walls[i].SetActive(status);
        }
    }

    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(() => Enemies.Count == 0);

        SetWallsActive(false);
        gameObject.SetActive(false);

        LevelControl.roomsCompleted++;
        PlayerInfo.score += 10;
    }
}
