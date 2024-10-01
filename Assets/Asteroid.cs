using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float size = 10;
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] bool canBreakApart = false;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Resize();
        RandomizeVelocity();
        RandomizeColor();
    }

    void FixedUpdate()
    {
        canBreakApart = true;
    }

    public void Resize(float newSize)
    {
        size = newSize;
        Resize();
    }

    public void Resize()
    {
        if(size < 1)
        {
            Destroy(this.gameObject);
            return;
        }
        transform.localScale = Vector3.one * size;
    }
    
    float maxSpeed = 5f;
    float randomSpeed;
    public void RandomizeVelocity()
    {
        randomSpeed = Random.Range(-maxSpeed, maxSpeed);

        GetComponent<Rigidbody2D>().velocity = new Vector3(randomSpeed, randomSpeed);
    }

    public void RandomizeColor(){
        float brightness = Random.Range(0, .25f);
        spriteRenderer.color = new Color(brightness, brightness, brightness);
    }

    void BreakApart()
    {
        if(!canBreakApart)
        {
            return;
        }
        
        float spawnRange = size/2;
        float spawnRandom = Random.Range(-spawnRange, spawnRange);
        for(int i = 0; i < 2; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(spawnRandom, spawnRandom, 0);
            
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity); // new asteroid

            newAsteroid.GetComponent<Asteroid>().Resize(size/2);
        }


        Destroy(this.gameObject);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile"))
        {
            // Debug.Log("Break Apart!");

            Destroy(other.gameObject);

            BreakApart();
        }
        // Debug.Log("Collision!");
    }
}
