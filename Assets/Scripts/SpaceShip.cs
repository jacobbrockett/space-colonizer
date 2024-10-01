using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] float speed = 20;
    [SerializeField] float speedLimit = 2000;

    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 10;

    [Header("Tools")]
    [SerializeField] ProjectileLauncher projectileLauncher;

    // public Transform planet;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // transform.localEulerAngles = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // AimShip(planet);
    }

    public void AimShip(Transform targetTransform)
    {
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, targetTransform.position - transform.position);

        AimShip(targetTransform.position);

    }
    public void AimShip(Vector3 aimPos)
    {
        Quaternion goalRotation = Quaternion.LookRotation(Vector3.forward, aimPos - transform.position);

        Quaternion currentRotation = transform.rotation;

        // transform.rotation = Quaternion.Lerp(currentRotation, goalRotation, Time.deltaTime * rotationSpeed); // interpolation 

        transform.rotation = Quaternion.Slerp(currentRotation, goalRotation, Time.deltaTime * rotationSpeed); // spherical interpolation
    }

    void FixedUpdate(){
        if (rb.velocity.magnitude > speedLimit){
            rb.velocity = rb.velocity.normalized * speedLimit;
        }
    }

    public void Move(Vector3 movement)
    {
        // transform.localPosition += new Vector3(x*1*Time.deltaTime, y*1*Time.deltaTime, 0); // this kind of teleports the object

        // rb.velocity = movement * speed;

        // rb.MovePosition(transform.position + (movement * speed) * Time.fixedDeltaTime); // add position to current position

        rb.AddForce(movement * speed); // adds a force to spaceship, similar to thrusters

        
    }

    public void Recoil(Vector3 amount)
    {
        rb.AddForce(amount, ForceMode2D.Impulse); // adds force all at once
    }

    public void LaunchWithShip()
    {
        Recoil(-transform.up * projectileLauncher.Launch());
    }

    public ProjectileLauncher GetProjectileLauncher()
    {
        return projectileLauncher;
    }
}
