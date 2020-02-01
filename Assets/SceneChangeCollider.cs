using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneChangeCollider : MonoBehaviour
{
    //   public Camera GameCamera;
    public float Cooldown = 1.0f;
    private float CurrentCooldown = 0.0f;
    public Vector3 NextSceneOffset = new Vector3(8.0f, 0.0f, 0.0f);
    public Vector3 NextPlayerOffset = new Vector3(3.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentCooldown > 0.0f)
        {
            CurrentCooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
   {
        if (CurrentCooldown < 0.1f)
        {
            if (other.gameObject.tag == "Player")
            {
                    CurrentCooldown = Cooldown;
                    print("Moving camera");
//                    Camera.main.transform.position += NextSceneOffset;
                    //                other.gameObject.transform.position += new Vector3(2.0f, 0.0f, 0.0f);
            }
        }
    }
}
