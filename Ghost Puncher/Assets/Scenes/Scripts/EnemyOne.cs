using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    //Código base para los enemigos.

    private Vector2 movement;
    //Velocidad
    [SerializeField] private float moveSpeed; 

    //Vida
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;

    //Sprite
    private Rigidbody2D rb;

    //Para permitir tener un objetivo al cual seguir.
    private Transform target;

    void Start() 
    {
        //Vida
        healthPoint = maxHealthPoint;

        //Estableciendo el objetivo del enemigo.
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
    }

    //Movimiento automatico.
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        //Para que el enemigo vea correctamente al jugador.
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
}
