using UnityEngine;
using System.Collections;
using System;

public class PlayerGUIManager : GUIManager
{
    private GUIStyle selectedBox;
    private GUIStyle regularBox;
    private bool firstDraw = true;
    public GUIStyle SelectedBox
    {
        get
        {
            return selectedBox;
        }

        set
        {
            selectedBox = value;
        }
    }

    public GUIStyle RegularBox
    {
        get
        {
            return regularBox;
        }

        set
        {
            regularBox = value;
        }
    }

    private Texture2D makeTexture(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }


    public void initStyles()
    {
        selectedBox = new GUIStyle(GUI.skin.box);
        selectedBox.normal.background = makeTexture(2, 2, new Color(0f, 1f, 0f, 0.2f));
        regularBox = new GUIStyle(GUI.skin.box);
        selectedBox.normal.background = makeTexture(2, 2, new Color(0f, 1f, 0f, 0.2f));
    }
    /**
     * This method sets draw prescedence
     **/
    public void draw(KeyPoller poller, Player player)
    {
        if(firstDraw)
        {
            initStyles();
            firstDraw = false;
        }
        if (poller.IsPaused)
        {
            drawEscapeMenu(player);
            return;
        }
        if (poller.InvOpen)
        {
            drawInventory(player);
            return;
        }
        if (poller.ChatOpen)
        {
            drawChatBar(player);
        }
        if (OptionValues.isHotbarEnabled())
        {
            drawHotbar(player);
        }
    }

    public void drawChatOutput(Player player)
    {

    }

    public void drawInventory(Player player)
    {
        int windowWidth = 800;
        int windowHeight = 600;
        float xPos = (Screen.width / 2) - (windowWidth / 2);
        float yPos = (Screen.height / 2) - (windowHeight / 2);
        GUI.Window(0, new Rect(xPos, yPos, windowWidth, windowHeight), (t) =>{}, "Inventory");
    }

    public void drawCrossHair()
    {

    }

    public void drawChatBar(Player player)
    {
        Rect initialRect = new Rect(200, 200, 50, 50);
    }

    public void drawEscapeMenu(Player player)
    {
        int windowWidth = 500;
        int windowHeight = 500;
        float xPos = (Screen.width / 2) - (windowWidth / 2);
        float yPos = (Screen.height / 2) - (windowHeight / 2);
        GUI.Window(0, new Rect(xPos, yPos,windowWidth,windowHeight), (t) => {}, "Options");
    }

    public void drawHotbar(Player player)
    {
        Rect initialRect = new Rect((Screen.width / 2) - (400), 800, 50, 50);
        for (int x = 0; x < 9; x++)
        {
            initialRect.x += 75;
            if (x==player.inventory.getHeldSlot())
            {
                GUI.Box(initialRect, (x + 1) + "", selectedBox);
            }
            GUI.Box(initialRect, (x + 1) + "", regularBox);
        }
    }
}
