using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehaviour : MonoBehaviour
{

    [SerializeField] private bool isLoaded;
    [SerializeField] private bool isActive;
    public int pathCount;
    public int currentIndex;
    public int pathAmount = 6;
    public GameObject path0;
    public GameObject path1;
    public GameObject path2;
    public GameObject path3;
    public GameObject path4;
    public GameObject path5;


    void Start()
    {
        GetComponentsInChildren<WorldPaths>();

    }

    void LoadAdjacentTiles()
    {
        int prevIndex = currentIndex - 1 < 0 ? pathCount : currentIndex - 1;
        int nextIndex = currentIndex + 1;

        //if (!tiles[prevIndex].isLoaded)
        //{
        //    //aktivieren und so
        //    tiles[prevIndex].transform.position = tiles[currentIndex].transform.position; //muss um 31 nach links verschoben werden
        //    //bla.setActive =true;
        //    isLoaded = true;
        //}

        //if (!tiles[nextIndex].isLoaded)
        //{
        //    tiles[nextIndex].transform.position = tiles[currentIndex].transform.position; //muss um 31 nach rechts verschoben werden
        //    //bla.setActive =true;
        //    isLoaded = true;
        //    //aktivieren und so
        //}

    }
    void ActivePath()
    {

    }
    
    

    
}
