using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

    private static SceneControl _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
