using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour 
{
    void Start()
    {
        
    }

    void Update()
    {
        if(OptionValues.GameRunning)
        {
            gameObject.SetActive(false);
        }
    }

    void OnMouseOver()
    {

    }
}
