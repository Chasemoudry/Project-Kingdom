using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3.0f;
    GameObject contact = null;
    List<string> inventory = new List<string>();

    void Start()
    {
        ;
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown("f") && contact != null)
        {
            Debug.Log("Picked up hammer.");
            inventory.Add(contact.name);
            Destroy(contact);
        }
        if (Input.GetKeyDown("i"))
        {
            foreach (var item in inventory)
                Debug.Log(item);
        }
    }

    void Move()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            if (Input.GetKey("d"))
            {
                pos.z += speed * Time.deltaTime * Mathf.Sqrt(2) / 2;
                pos.x += speed * Time.deltaTime * Mathf.Sqrt(2) / 2;
            }
            else if (Input.GetKey("a"))
            {
                pos.z += speed * Time.deltaTime * Mathf.Sqrt(2) / 2;
                pos.x -= speed * Time.deltaTime * Mathf.Sqrt(2) / 2;
            }
            else
                pos.z += speed * Time.deltaTime;
        }
        else if (Input.GetKey("s"))
        {
            if (Input.GetKey("d"))
            {
                pos.z -= speed * Time.deltaTime * Mathf.Sqrt(2) / 2;
                pos.x += speed * Time.deltaTime * Mathf.Sqrt(2) / 2;
            }
            else if (Input.GetKey("a"))
            {
                pos.z -= speed * Time.deltaTime * Mathf.Sqrt(2) / 2;
                pos.x -= speed * Time.deltaTime * Mathf.Sqrt(2) / 2;
            }
            else
                pos.z -= speed * Time.deltaTime;
        }
        else if (Input.GetKey("d"))
            pos.x += speed * Time.deltaTime;
        else if (Input.GetKey("a"))
            pos.x -= speed * Time.deltaTime;
        transform.Rotate(Vector3.up * Time.deltaTime * 1000000.0f, Space.World);
        transform.position = pos;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Interactible")
        {
            Debug.Log("Enter");
            contact = col.gameObject;
            GetComponent<Renderer>().material = Resources.Load("Materials/Debug") as Material;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Interactible")
        {
            Debug.Log("Exit");
            contact = null;
            GetComponent<Renderer>().material = Resources.Load("Materials/Player") as Material;
        }
    }
}

