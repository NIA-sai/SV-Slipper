using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public bool direction;
    public float speed;
    public byte carID;

    public SpriteRenderer sr;

    private double existTime;
    public void RandomInitial(bool direction, float speed, byte carID, Vector2 positon)
    {
        this.speed = speed;
        this.direction = direction;
        this.carID = carID;
        transform.localScale = new Vector2(2.5f, 2.5f);
        transform.position = positon;
    }
    // Start is called before the first frame update
    void Start()
    {
        existTime = Time.time;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Resources.LoadAll<Sprite>("Sprites/Object/car")[carID];
        sr.flipX = direction;
        sr.sortingOrder = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - existTime >= 10)
        {
            Destroy(gameObject);
        }
        transform.Translate(new Vector2((direction ? 1 : -1) * speed * Time.deltaTime, 0));
    }
}
