using UnityEngine;
using System.Collections;

public class OptionValues
{
    static bool hotbarEnabled = true;
    static bool chatEnabled = true;
    static bool chatBarEnabled = false;
    static bool gameRunning = false;
    static bool escapeMenuOpen = false;

    public static bool ChatBarEnabled
    {
        get
        {
            return chatBarEnabled;
        }

        set
        {
            chatBarEnabled = value;
        }
    }

    public static bool GameRunning
    {
        get
        {
            return gameRunning;
        }

        set
        {
            gameRunning = value;
        }
    }

    public static bool EscapeMenuOpen
    {
        get
        {
            return escapeMenuOpen;
        }

        set
        {
            escapeMenuOpen = value;
        }
    }

    public static bool isHotbarEnabled()
    {
        return hotbarEnabled;
    }

    public static void toggleHotBar()
    {
        hotbarEnabled = !hotbarEnabled;
    }


    public static bool isChatEnabled()
    {
        return chatEnabled;
    }

    public static void toggleChat()
    {
        chatEnabled = !chatEnabled;
    }

    public static void toggleChatBar()
    {
        ChatBarEnabled = !ChatBarEnabled;
    }

    public static void toggleGameRunning()
    {
        gameRunning = !gameRunning;
    }
    public static void toggleEscapeMenu()
    {
        escapeMenuOpen = !escapeMenuOpen;
    }
}
