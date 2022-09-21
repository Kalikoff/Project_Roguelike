using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public EnemyAnimation enemyAnimation;
    public Transform target;
    public float attackDistance;
    public float speed;
    public float startTimeBtwAttack;
    public int health;
    public int damage;

    private float timeBtwAttack;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        timeBtwAttack = startTimeBtwAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);

        if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
        {
            enemyAnimation.isWalkSet(true);
            enemyAnimation.isAttackSet(false);

            transform.LookAt(target.transform);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            transform.right = target.transform.position - transform.position;

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            enemyAnimation.isAttackSet(true);
            enemyAnimation.isWalkSet(false);

            timeBtwAttack -= Time.deltaTime;
        }

        if (timeBtwAttack <= 0)
        {
            PlayerController.health -= damage;
            timeBtwAttack = startTimeBtwAttack;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
        }
    }
}