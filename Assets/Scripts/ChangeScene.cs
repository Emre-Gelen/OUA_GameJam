using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) { 
        
            SceneManager.LoadScene(sceneName);
        }
    }

    public void cS() {

        SceneManager.LoadScene(sceneName);
    }

}
