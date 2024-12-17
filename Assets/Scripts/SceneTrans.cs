using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private AnimationClip finalAnimation;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    IEnumerator ChangeScene()
    {
        animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(finalAnimation.length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
