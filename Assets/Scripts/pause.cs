
using UnityEngine;

public class pause : MonoBehaviour
{
    bool pauseGame;
    bool resumeGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pauseGame = Input.GetKeyDown(KeyCode.Escape);
        if (pauseGame)
        {
            PauseGame();
        }
        resumeGame = Input.GetKeyDown(KeyCode.Space);
        if (resumeGame)
        {
            ResumeGame();
        }
            
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
