using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbehaviour : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    float gravity = -9.81f;
    public float x;
    public float z;
    public float lastclick = 0f;
    public float doubleclicktime = 0.25f;
    public pistolabehaviour pistolabehaviour;


    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
    }

    public void Move()
    {
        speed = 6f;
        Vector3 move = transform.right * x + transform.forward * z;

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * speed * Time.deltaTime);
    }

    public void Running()
    {
        speed = 12f;
        Vector3 move = transform.right * x + transform.forward * z;

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * speed * Time.deltaTime);
    }

    public void Equipweapon()
    {
        pistolabehaviour.gameObject.SetActive(true);
    }

    public void Unequipweapon()
    {
        pistolabehaviour.gameObject.SetActive(false);
    }
}
