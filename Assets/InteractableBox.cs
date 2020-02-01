using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    Renderer rend;
    int colorPicker = 0;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        colorPicker = Random.Range(0, 10);

        switch (colorPicker)
        {
            case 0: rend.material.color = Color.white; break;
            case 1: rend.material.color = Color.cyan; break;
            case 2: rend.material.color = Color.blue; break;
            case 3: rend.material.color = Color.black; break;
            case 4: rend.material.color = Color.red; break;
            case 5: rend.material.color = Color.green; break;
            case 6: rend.material.color = Color.grey; break;
            case 7: rend.material.color = Color.magenta; break;
            case 8: rend.material.color = Color.yellow; break;
            case 9: rend.material.color = Color.gray; break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollision(Collision collision)
    {
        print("Name: " + collision.collider.name + " Tag: " + collision.collider.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        colorPicker = Random.Range(0, 10);
        print("Trigger entered");
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        print("Trigger exit");
        switch (colorPicker)
        {
            case 0: rend.material.color = Color.white; break;
            case 1: rend.material.color = Color.cyan; break;
            case 2: rend.material.color = Color.blue; break;
            case 3: rend.material.color = Color.black; break;
            case 4: rend.material.color = Color.red; break;
            case 5: rend.material.color = Color.green; break;
            case 6: rend.material.color = Color.grey; break;
            case 7: rend.material.color = Color.magenta; break;
            case 8: rend.material.color = Color.yellow; break;
            case 9: rend.material.color = Color.gray; break;
        }
    }
}