using UnityEngine;
using System.Collections;
using static GoalieAI;

public class GoalieAI : MonoBehaviour {
    public AudioSource playSound;

    public enum GoalKeeper_State
    {
        RESTING,
       
        GET_BALL_DOWN,

        JUMP_LEFT,
        JUMP_RIGHT,
        JUMP_LEFT_DOWN,
        JUMP_RIGHT_DOWN
    };

    public GoalKeeper_State state;
    public Sphere sphere;

    public Transform hand_bone;
    
    public CapsuleCollider capsuleCollider;

    
    public static int force
    {
        get;
        set;
    }


    public static Vector3 angle
    {
        get;
        set;
    }

    GameObject goalie;
    Vector3 goaliePos;
    BallScript bs;


    void Start () {
        goalie = GameObject.Find("Goalie");
        goaliePos = goalie.transform.position;
        bs = GameObject.Find("Ball").GetComponent<BallScript>();
        force = 0;

        state = GoalKeeper_State.RESTING;

        GetComponent<Animation>()["goalkeeper_get_ball_front"].speed = 1.0f;
        GetComponent<Animation>()["goalkeeper_clear_right_up"].speed = 1.3f;
        GetComponent<Animation>()["goalkeeper_clear_left_up"].speed = 1.3f;
        GetComponent<Animation>()["goalkeeper_clear_right_down"].speed = 1.2f;
        GetComponent<Animation>()["goalkeeper_clear_left_down"].speed = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case GoalKeeper_State.JUMP_LEFT:

                capsuleCollider.direction = 0;

                if (GetComponent<Animation>()["goalkeeper_clear_left_up"].normalizedTime < 0.6f)
                {
                    transform.position -= transform.right * Time.deltaTime * 8f;
         
                }


                if (!GetComponent<Animation>().IsPlaying("goalkeeper_clear_left_up"))
                {
                   
                    capsuleCollider.direction = 1;
                    state = GoalKeeper_State.RESTING;

                }
                force = 0;

                break;

            case GoalKeeper_State.JUMP_RIGHT:

                capsuleCollider.direction = 0;

                if (GetComponent<Animation>()["goalkeeper_clear_right_up"].normalizedTime < 0.6f)
                {
                    transform.position += transform.right * Time.deltaTime * 8f;
         
                }
                if (!GetComponent<Animation>().IsPlaying("goalkeeper_clear_right_up"))
                {
                    capsuleCollider.direction = 1;
                    state = GoalKeeper_State.RESTING;

                }

                force = 0;
       
                break;

            case GoalKeeper_State.JUMP_LEFT_DOWN:


                capsuleCollider.direction = 0;

                if (GetComponent<Animation>()["goalkeeper_clear_left_down"].normalizedTime < 0.6f)
                {
                    transform.position -= transform.right * Time.deltaTime * 5f;
                
                }


                if (!GetComponent<Animation>().IsPlaying("goalkeeper_clear_left_down"))
                {
                    
                    capsuleCollider.direction = 1;
                    state = GoalKeeper_State.RESTING;


                }
                force = 0;
              
                break;

            case GoalKeeper_State.JUMP_RIGHT_DOWN:

                capsuleCollider.direction = 0;

                if (GetComponent<Animation>()["goalkeeper_clear_right_down"].normalizedTime < 0.6f)
                {
                    transform.position += transform.right * Time.deltaTime * 5f;
           
                }
                if (!GetComponent<Animation>().IsPlaying("goalkeeper_clear_right_down"))
                {
                  
                    capsuleCollider.direction = 1;
                    state = GoalKeeper_State.RESTING;


                }

                force = 0;
         
                break;




            case GoalKeeper_State.GET_BALL_DOWN:
                if (!GetComponent<Animation>().IsPlaying("goalkeeper_get_ball_front"))
                {
                    
                    state = GoalKeeper_State.RESTING;
                }

                force = 0;

                break;


            case GoalKeeper_State.RESTING:
   
                capsuleCollider.direction = 1;
                if (!GetComponent<Animation>().IsPlaying("goalkeeper_rest"))
                {
             
                    GetComponent<Animation>().Play("goalkeeper_rest");
                }

                    

                break;

    
        }
        

    }

    void OnCollisionStay(Collision coll)
    {
       
        if (coll.collider.transform.gameObject.tag == "Ball" && state != GoalKeeper_State.GET_BALL_DOWN &&
                state != GoalKeeper_State.JUMP_LEFT && state != GoalKeeper_State.JUMP_RIGHT &&
                state != GoalKeeper_State.JUMP_LEFT_DOWN && state != GoalKeeper_State.JUMP_RIGHT_DOWN)
        {
            if (GetComponent<Animation>()["goalkeeper_get_ball_front"].normalizedTime < 0.45f)
            {        
                GetComponent<Animation>().Play("goalkeeper_get_ball_front");
                transform.position += transform.up * Time.deltaTime * 4.0f;
            }
            if (!GetComponent<Animation>().IsPlaying("goalkeeper_get_ball_front"))
            {
                GetComponent<Animation>().Play("jump_backwards_bucle");
                transform.position += transform.up * Time.deltaTime * 3.0f;

            }
            playSound.Play();
            state = GoalKeeper_State.GET_BALL_DOWN;
            
            force = 0;
        }

    }
    
    void reset()
    {
        goalie.transform.position = goaliePos;
    }
    
}
