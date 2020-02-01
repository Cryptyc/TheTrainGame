using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float TimeUntilBroken = 5.0f;
    private float CurrentTime = 0.0f;
    private bool IsDamaged = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().color = Color.green;
        GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().text = "Repaired";
        GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().GetComponent<Renderer>().enabled = false;

        CurrentTime = TimeUntilBroken;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDamaged)
        {
            return;
        }
        CurrentTime -= Time.deltaTime;
        if (CurrentTime < 0.1f)
        {

            GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().color = Color.red;
            GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().text = "Damaged";
            GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().GetComponent<Renderer>().enabled = true;
            IsDamaged = true;
        }
    }
}
