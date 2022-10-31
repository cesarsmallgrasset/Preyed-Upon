using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class WristMenu : MonoBehaviour
{
    [SerializeField] InputActionReference menupopup;
    [SerializeField] Animator animator;
    [SerializeField] GameObject menuObject;
    private bool open;
    private void Awake()
    {
        menupopup.action.performed += OnMenu;
    }


    void OnMenu(InputAction.CallbackContext obj)
    {
        pause();

    }
    public void pause()
    {
        if (!open)
        {
            Time.timeScale = 0;
            menuObject.SetActive(true);
            animator.SetBool("Appear", true);
            open = true;
            Debug.Log("Opened menu");
        }
        else
        {
            Time.timeScale = 1;
            animator.SetBool("Appear", false);
            open = false;
            float timer = 5;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                menuObject.SetActive(false);
            }
        }
        
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
