using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
        private string level;                                   //Current level.
        public bool debugMode = true;
        public Vector3 playerPosition;


        //Awake is always called before any Start functions
        void Awake()
        {

            ////ensure _preload scene is loaded first
            //GameObject check = GameObject.Find("_app");
            //if (check == null)
            //{
            //    SceneManager.LoadScene("_preload");

            //    if (debugMode)
            //    {
            //        Debug.Log("Scene " + SceneManager.GetActiveScene());
            //    }
            //}

            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            //Get a component reference to the attached BoardManager script
            //boardScript = GetComponent<BoardManager>();

            playerPosition = new Vector3(0f, 0.1f, 0f);

            //Call the InitGame function to initialize the first level 
            InitGame();
        }

        //Initializes the game for each level.
        void InitGame()
        {
            //Call the SetupScene function of the BoardManager script, pass it current level number.
            //boardScript.SetupScene(level);

            SceneManager.LoadScene("Past");
            instance.level = SceneManager.GetActiveScene().name;
            Debug.Log("Scene " + SceneManager.GetActiveScene().name);

            if (debugMode)
            {
                DevDebugMsg("Scene " + SceneManager.GetActiveScene().name);
            }

        }

        public void SceneLoader(string scene)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
            instance.level = SceneManager.GetActiveScene().name;

            if (debugMode)
            {
                DevDebugMsg("Scene " + SceneManager.GetActiveScene().name);
            }
        }

        public void DevDebugMsg(string msg)
        {
            Debug.Log(msg);
        }
    }
}