using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    float time;
    float distance;
    float angle;
    float initialVelocity;
    float finalVelocity;
    float force;
    float mass = 15f;
    float acceleration;

    ScriptHandler handler;
    

    public static string goal = null;
    void Start()
    {
        handler = GameObject.Find("ScriptHandler").GetComponent<ScriptHandler>();
    }
    void KickForce(float[] param)
    {
        time = param[0];
        distance = param[1];
        angle = param[2];
        initialVelocity = param[3];
        finalVelocity = param[4];


        acceleration = (finalVelocity - initialVelocity) / time;
        force = mass * finalVelocity;
        if (force < 5)
        {
        
            force = 15;
        }
        else
        {
            force = 25;
        }
        transform.GetComponent<Rigidbody>().AddForce(force * new Vector3(angle, 0.22f, 1) * 55);
        Debug.Log(force);
        GoalieAI.force = (int)force;
      
   
        handler.SendMessage("NextKick", SendMessageOptions.DontRequireReceiver);
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handler.SendMessage("NextKick", SendMessageOptions.DontRequireReceiver);
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<Collider>().tag == "Goal")
    //    {
    //        goal = "Goal";
           
    //    }
    //}

    //void OnGUI()
    //{
    //    GUI.Label(new Rect(50, 50, 200, 100), goal);
    //}
}
