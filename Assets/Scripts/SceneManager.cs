using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private int currentSceneIndex;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ChangeSceneByIndex(int targetIndex){
        if (currentSceneIndex == targetIndex)
        {
            Debug.LogWarning("trying to reload scene, you silly goose");
            return;
        }
        SceneManager.LoadScene(targetIndex);
    }
}
