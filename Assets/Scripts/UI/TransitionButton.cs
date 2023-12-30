using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionButton : MonoBehaviour
{
    public string TransitSceneName;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        if (!button) 
        {
            button = GetComponent<Button>();
        }

        button.onClick.AddListener(OnClicked);
    }
    public void OnClicked() 
    {
        SceneManager.LoadScene(TransitSceneName);
    }
}
