using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlComplete : MonoBehaviour
{
    [SerializeField] private int numObjects;
    [SerializeField] private int takenObjects;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        takenObjects = 0;
        
        numObjects= GameObject.FindGameObjectsWithTag("Object").Length;
    }

    private void ActivateExit()
    {
        animator.SetTrigger("Activar");
    }

    public void ObjectsTaken()
    {
        takenObjects++;

        if (takenObjects == numObjects)
        {
            ActivateExit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && takenObjects == numObjects)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
