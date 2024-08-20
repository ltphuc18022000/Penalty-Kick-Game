using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KickScript : MonoBehaviour
{
    //public AudioSource playSound;

    GameObject rightFoot;
    GameObject leftFoot;
    GameObject leftHip;
    GameObject rightHip;
    GameObject ball;

    float posOfFoot1;
    float posOfFoot2;
    Vector3 differenceOfFoot;
    Vector3 angleOfKick1;
    Vector3 angleOfKick2;


    float time;
    float timeTaken;
    float maxDistanceofKick;

    List<float> timeList;
    List<float> footPos1;
    List<float> footPos2;
    List<Vector3> angleDetect1;
    List<Vector3> angleDetect2;
    float angle = 0;

    bool kickStarted = false;

    BallScript bs;

 

    void Start()
    {
        leftFoot = GameObject.Find("15_Foot_Left");
        rightFoot = GameObject.Find("19_Foot_Right");
        ball = GameObject.Find("Ball");
        leftHip = GameObject.Find("12_Hip_Left");
        rightHip = GameObject.Find("16_Hip_Right");
        time = 0;
        timeTaken = 0;
        maxDistanceofKick = 0;
  
        bs = GameObject.Find("Ball").GetComponent<BallScript>();
        footPos1 = new List<float>();
        footPos2 = new List<float>();
        timeList = new List<float>();
        angleDetect1 = new List<Vector3>();
        angleDetect2 = new List<Vector3>();
        
       
    }
  
    
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 250, 50), leftFoot.transform.position.ToString());
        GUI.Label(new Rect(20, 20, 250, 50), rightFoot.transform.position.ToString());
    }
    void Update()
    {
        posOfFoot1 = Mathf.Floor((leftFoot.transform.position.z -leftHip.transform.position.z) * 100) / 100;
        if (posOfFoot1 < -0.1 && !kickStarted)
        {
            angleDetect1.Add(leftFoot.transform.position);
            kickStarted = true;

            time = 0;
        }

        posOfFoot2 = Mathf.Floor((rightFoot.transform.position.z - rightHip.transform.position.z) * 100) / 100;
        if (posOfFoot2 > 0.1 && !kickStarted)
        {
            angleDetect2.Add(rightFoot.transform.position);
            kickStarted = true;

            time = 0;
        }

        if (kickStarted)
        {
            
            DetectKick();
        }
    }

    void DetectKick()
    {
        
        time = time + Time.deltaTime;
        footPos1.Add(posOfFoot1);
        footPos2.Add(posOfFoot2);
        timeList.Add(time);
        
        //Vector3 max;
        //Vector3 min;
        //float dec = 0;
        //float inc = 0;
        // -0.9, 0.3, -11.9    -1.4, 0.5, -12.6
        // 
        kickStarted = false;
        //playSound.Play();
        if (posOfFoot1 > 0.4 )
        {
            angleDetect1.Add(leftFoot.transform.position);
            angleOfKick1 = (leftFoot.transform.position - leftHip.transform.position);

            //Debug.Log(angle);
            //foreach (Vector3 a in angleDetect)
            //    Debug.Log(a);
            angleOfKick1.Normalize();

            Debug.Log(angleOfKick1);
            GoalieAI.angle = angleOfKick1;
  
            KickParameters1();
            
        }
        if (posOfFoot2 > 0.4  )
        {
            angleDetect2.Add(rightFoot.transform.position);
            angleOfKick2 = (rightFoot.transform.position - rightHip.transform.position);

            //Debug.Log(angle);
            //foreach (Vector3 a in angleDetect)
            //    Debug.Log(a);
            angleOfKick2.Normalize();

            Debug.Log(angleOfKick2);
            GoalieAI.angle = angleOfKick2;
      
            KickParameters2();
        }

    }


    void KickParameters1()
    {
        
        float maxTime = 0;
        float minTime = 0;
        float maxDistance = 0;
        float minDistance = 0;

        float initialVelocity = 0;
        float finalVelocity = 0;

        foreach (float t in timeList)
        {
            maxTime = Mathf.Max(maxTime, t);
            minTime = Mathf.Min(minTime, t);
        }
        foreach (float d1 in footPos1)
        {
            maxDistance = Mathf.Max(maxDistance, d1);
            minDistance = Mathf.Min(minDistance, d1);
        }
      
        timeTaken = maxTime - minTime;
        maxDistanceofKick = maxDistance - minDistance;

        initialVelocity = (maxDistance / 2) / (maxTime / 2);
        finalVelocity = maxDistanceofKick / timeTaken;

        float[] kickParams = new float[5];
        kickParams[0] = timeTaken;
        kickParams[1] = maxDistanceofKick;
        kickParams[2] = angleOfKick1.x;
        kickParams[3] = initialVelocity;
        kickParams[4] = finalVelocity;

        GameObject.Find("Ball").SendMessage("KickForce", kickParams, SendMessageOptions.DontRequireReceiver);
       
    }

    void KickParameters2()
    {
        float maxTime = 0;
        float minTime = 0;
        float maxDistance = 0;
        float minDistance = 0;

        float initialVelocity = 0;
        float finalVelocity = 0;

        foreach (float t in timeList)
        {
            maxTime = Mathf.Max(maxTime, t);
            minTime = Mathf.Min(minTime, t);
        }

        foreach (float d2 in footPos2)
        {
            maxDistance = Mathf.Max(maxDistance, d2);
            minDistance = Mathf.Min(minDistance, d2);
        }
        timeTaken = maxTime - minTime;
        maxDistanceofKick = maxDistance - minDistance;

        initialVelocity = (maxDistance / 2) / (maxTime / 2);
        finalVelocity = maxDistanceofKick / timeTaken;

        float[] kickParams = new float[5];
        kickParams[0] = timeTaken;
        kickParams[1] = maxDistanceofKick;
        kickParams[2] = angleOfKick2.x;
        kickParams[3] = initialVelocity;
        kickParams[4] = finalVelocity;

        GameObject.Find("Ball").SendMessage("KickForce", kickParams, SendMessageOptions.DontRequireReceiver);
 
    }

}
