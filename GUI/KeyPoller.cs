using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPoller : MonoBehaviour
{
    private bool isPaused = false;
    private bool chatOpen = true;
    private bool invOpen = false;
    private int heldSlot = 0;

    public bool ChatOpen
    {
        get
        {
            return chatOpen;
        }

        set
        {
            chatOpen = value;
        }
    }

    public bool IsPaused
    {
        get
        {
            return isPaused;
        }

        set
        {
            isPaused = value;
        }
    }

    public bool InvOpen
    {
        get
        {
            return invOpen;
        }

        set
        {
            invOpen = value;
        }
    }

    public int HeldSlot
    {
        get
        {
            return heldSlot;
        }

        set
        {
            heldSlot = value;
        }
    }

    public void pollMenuKeys()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("LOADING!");
            GameObject obj = (GameObject)Instantiate(Resources.Load("Goblins/GoblinA"));
            obj.transform.position = Camera.main.transform.position;
            Debug.Log(obj.GetType());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            invOpen = !invOpen;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            OptionValues.toggleHotBar();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            OptionValues.toggleHotBar();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            OptionValues.toggleChat();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            chatOpen = !chatOpen;
        }
    }

    public void tick()
    {
        pollMenuKeys();
        pollHeldItemKeys();
    }

    public void pollHeldItemKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("startmenu");
            heldSlot = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            heldSlot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            heldSlot = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            heldSlot = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            heldSlot = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            heldSlot = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            heldSlot = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            heldSlot = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            heldSlot = 8;
        }
    }
}