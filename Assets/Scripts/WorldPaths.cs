using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPaths : MonoBehaviour {

    [SerializeField] private bool isLoaded;
    [SerializeField] private bool isActive;
    public int currentIndex;
    public int pathCount;
    public int pathAmount = 6;
    public int prevIndex;
    public int nextIndex;

    void Start ()
    {
        GetComponentsInChildren<PathBehaviour>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLoaded && !isActive)
        {
            LoadAdjacentTiles();
        }
    }
    void LoadAdjacentTiles()
    {
        int prevIndex = currentIndex - 1 < 0 ? pathCount : currentIndex - 1;
        int nextIndex = currentIndex + 1;
    }
}
