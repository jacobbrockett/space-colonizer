using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for basic movement, health and damage, basic info storing
public class Creature : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int currentHealthPoints = 3;
    [SerializeField] int maxHealthPoints = 3;

    [Header("Movement")]
    [SerializeField] float speed = 10.0f; // f neccessary for float in C# after decimal place
    
    [Header("Naming")]
    [SerializeField] string creatureName = "Sheepis";

    [Header("Tracked Information")]
    [SerializeField] bool isDead = false;

    [Header("Vanity")]
    [SerializeField] Color baseColor = Color.white;

    SpriteRenderer sr;

    void Awake() // goes before start
    {
        sr = GetComponent<SpriteRenderer>(); // cache variable
    }


    // Start is called before the first frame update; NOT a constructor
    void Start()
    {
        // Debug.Log("Creature Start! " + creatureName);

        // Change Color:
        sr.color = baseColor;
    }

    // Update is called once per frame (runs continuously); be careful what you put in here!
    void Update()
    {
        // Debug.Log("Creature Update! " + creatureName);
        // GetComponent is O(n), which is NOT good for update method; Transform is O(1), so that's gucci

        
    }

    public void Move(Vector3 movement)
    {
        // TODO: update move to take a Vector 3 object
        // Change Position:
        // GetComponent<Transform>().localPosition += new Vector3(x*speed*Time.deltaTime, y*speed*Time.deltaTime, 0);
        
        // transform.localPosition += new Vector3(x*speed*Time.deltaTime, y*speed*Time.deltaTime, 0);
        transform.localPosition += movement * speed * Time.deltaTime;

    
    }
}
