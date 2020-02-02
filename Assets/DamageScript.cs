using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScript : MonoBehaviour
{
    public GameObject RepariedObject;
    public GameObject DamagedObject;
    public float TimeUntilBroken = 5.0f;
    public float TimeUntilRepair = 3.0f;
    public float TextDespanwTime = 1.0f;
    private float CurrentTime = 0.0f;
    private float CurrentRepairTime = 3.0f;
    private float CurrentVisTime = 0.0f;
    private bool IsDamaged = false;
    private bool Repairing = false;
    private bool TextVis = false;
    private bool HasBeenRepaired = false;
    private float RepairProgress = 1.0f;
    public bool ShouldBreakAgain = false;
    private Slider progressSlider;	
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().color = Color.green;
        //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().text = "Repaired";
        //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().GetComponent<Renderer>().enabled = false;
        TimeUntilBroken = Random.Range(TimeUntilBroken, (TimeUntilBroken * 2));
        CurrentTime = TimeUntilBroken;
	progressSlider = GetComponentsInChildren<Slider>()[0];
	progressSlider.value = 1.0f;
    }
    void SetRepairedState()
    {
        //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().color = Color.green;
        //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().text = "Repaired";
        TextVis = true;
        CurrentVisTime = TextDespanwTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(HasBeenRepaired)
        {
            return;
        }
        if (IsDamaged)
        {
            if(Repairing)
            {
                CurrentRepairTime -= Time.deltaTime;
                if(CurrentRepairTime <= 0.1f)
                {

                    IsDamaged = false;
                    GetComponent<MeshFilter>().sharedMesh = RepariedObject.GetComponent<MeshFilter>().sharedMesh;
                    if (!ShouldBreakAgain)
                    {
                        HasBeenRepaired = true;
                    }
                    Repairing = false;
                    SetRepairedState();
                    print("repair complete");
                    CurrentTime = TimeUntilBroken;
                    RepairProgress = 1.0f;
                    GameObject go = GameObject.FindWithTag("ScoreText");
                    ScoreRegister other = (ScoreRegister)go.GetComponent(typeof(ScoreRegister));
                    if(ShouldBreakAgain)
                    {
                        other.EngineFixed();

                    }
                    else
                    {
                        other.DamageFixed();

                    }
                }
                RepairProgress = CurrentRepairTime / TimeUntilRepair;
	
		
		progressSlider.value = 1.0f - RepairProgress;
            }
            return;
        }
        else if(TextVis)
        {
            CurrentVisTime -= Time.deltaTime;
            if(CurrentVisTime < 0.1f)
            {
                TextVis = false;
                //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().GetComponent<Renderer>().enabled = false;

            }
        }
        else
        {

        }
        CurrentTime -= Time.deltaTime;
        if (CurrentTime < 0.1f)
        {

            //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().color = Color.red;
            //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().text = "Damaged";
            //GameObject.FindWithTag("DamageText").GetComponent<TextMesh>().GetComponent<Renderer>().enabled = true;
            IsDamaged = true;
            RepairProgress = 0.0f;
	        progressSlider.value = 0.0f;
            GetComponent<MeshFilter>().sharedMesh = DamagedObject.GetComponent<MeshFilter>().sharedMesh;
            CurrentRepairTime = TimeUntilRepair;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(IsDamaged && !Repairing)
            {
                print("Starting repair");
                Repairing = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(IsDamaged && Repairing)
            {
                CurrentRepairTime = TimeUntilRepair;
                print("Stopping repair");
                Repairing = false;
            }
        }
    }
}
