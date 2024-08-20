using UnityEngine;
using System.Collections;

public class GoalKeeperJump_Down : MonoBehaviour {
    int keyDown;
    //bool keyDown2;

    public GoalieAI goalKeeper;
	// Use this for initialization
	void Start () {
        StartCoroutine(NumberGen());
    }
	
	// Update is called once per frame
	void Update () {
   
    }

    IEnumerator NumberGen()
    {
        while (true)
        {
            keyDown = Random.Range(0, 2);
            yield return new WaitForSeconds(4.5f);
            Debug.Log(keyDown);
        }
    }

    void OnTriggerEnter( Collider other ) {
	

		// Box triggers are used to know if goalkeeper need to throw to catch the ball
		if (keyDown==0 && other.tag == "Ball" ) {
		
			Vector3 dir_goalkeeper = goalKeeper.transform.forward;
			Vector3 dir_ball = other.gameObject.GetComponent<Rigidbody>().velocity;
			dir_ball.Normalize();
			
			float det = Vector3.Dot( dir_goalkeeper, dir_ball );
						
			Debug.Log("det " + Mathf.Acos(det) * 57.0f + " speed " + other.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
			float degree = Mathf.Acos(det) * 57.0f;
			
			if ( degree > 90.0f && degree < 270.0f && other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 5.0f && !other.gameObject.GetComponent<Rigidbody>().isKinematic) {
			
                    if (tag == "GoalKeeper_Jump_Left")
					{

						goalKeeper.state = GoalieAI.GoalKeeper_State.JUMP_LEFT_DOWN;
						goalKeeper.gameObject.GetComponent<Animation>().Play("goalkeeper_clear_left_down");

                    //					Debug.Log("Left");
                }

					if (tag == "GoalKeeper_Jump_Right")
					{

						goalKeeper.state = GoalieAI.GoalKeeper_State.JUMP_RIGHT_DOWN;
						goalKeeper.gameObject.GetComponent<Animation>().Play("goalkeeper_clear_right_down");

                    //					Debug.Log("Right");

                }

			}
		
		}
        if (keyDown==1 && other.tag == "Ball")
        {

            Vector3 dir_goalkeeper = goalKeeper.transform.forward;
            Vector3 dir_ball = other.gameObject.GetComponent<Rigidbody>().velocity;
            dir_ball.Normalize();

            float det = Vector3.Dot(dir_goalkeeper, dir_ball);

            Debug.Log("det " + Mathf.Acos(det) * 57.0f + " speed " + other.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
            float degree = Mathf.Acos(det) * 57.0f;

            if (degree > 90.0f && degree < 270.0f && other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 5.0f && !other.gameObject.GetComponent<Rigidbody>().isKinematic)
            {

                if (tag == "GoalKeeper_Jump_Right")
                {

                    goalKeeper.state = GoalieAI.GoalKeeper_State.JUMP_LEFT_DOWN;
                    goalKeeper.gameObject.GetComponent<Animation>().Play("goalkeeper_clear_left_down");

                    //					Debug.Log("Left");
                }

                if (tag == "GoalKeeper_Jump_Left")
                {

                    goalKeeper.state = GoalieAI.GoalKeeper_State.JUMP_RIGHT_DOWN;
                    goalKeeper.gameObject.GetComponent<Animation>().Play("goalkeeper_clear_right_down");
                    //					Debug.Log("Right");

                }



            }

        }


    }
	
}
