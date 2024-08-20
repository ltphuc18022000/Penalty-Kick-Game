using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public static string goal = null;
    GUIStyle fontSize;
    public AudioSource playSoundGoal;
    // Start is called before the first frame update
    void Start()
    {
        fontSize = new GUIStyle();
        fontSize.fontSize = 70;
        fontSize.fontStyle = FontStyle.Bold;
        fontSize.fontStyle = FontStyle.Italic;
        fontSize.normal.textColor = Color.blue;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnCollisionEnter(Collision Target)
    //{
    //    if (Target.gameObject.tag == "target")
    //    {
    //        GameObject.Find("Score").GetComponent<addscore>().addpoint();

    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Ball")
        {
            GameObject.Find("Score").GetComponent<addscore>().addpoint();
            goal = "GOAL!!!!!!";
            playSoundGoal.Play();
        }
    }
    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width / 2 - 50, 75, 100, 200), goal, fontSize);
        GUI.Label(new Rect(Screen.width / 2 - 110, 50, 100, 200), goal, fontSize);
    }
}
