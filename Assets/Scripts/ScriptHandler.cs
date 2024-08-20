using UnityEngine;
using System.Collections;
using TrailsFX;

public class ScriptHandler : MonoBehaviour {

    GameObject Ball;
    public AudioSource playSound;

    Vector3 ballPosition;

    public GameObject Kick;
    string kick;

    GUIStyle fontSize;
    void Start()
    {
        fontSize = new GUIStyle();
        Ball = GameObject.Find("Ball");
        ballPosition = Ball.transform.position;
        kick = "KICK!";
        
        
        fontSize.fontSize = 50;
        fontSize.normal.textColor = Color.black;
        fontSize.fontStyle = FontStyle.Bold;
        
        
    }
    IEnumerator NextKick()
    {//Ball = GameObject.Find("Ball");

        //Destroy(Kick);
        playSound.Play();
        kick = null;
        
        yield return new WaitForSeconds(4.0f);
        Ball.transform.position = ballPosition;
        Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(1.5f);
        
        kick = "KICK!";

        Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Kick.SetActive(true);
        target.goal = null;
        //target.playSoundGoal.Stop();

        GameObject.Find("Goalie").SendMessage("reset", SendMessageOptions.DontRequireReceiver);
  
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2 - 50, 75, 100, 200), kick, fontSize);
    }
}
