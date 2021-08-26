using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

#if UNITY_EDITOR
public class MenuEditor : EditorWindow
{
    public GameObject GameTitle;
    Texture2D texture;
    Texture2D rulesScreen;
    Texture2D controlsScreen;
    string windowLabel = "This is used to edit the menu workspace";
    string myString = "Game Title Here!";
    [MenuItem("Window/Editor/Menu")]


    public static void ShowWindow()
    {
        //GetWindow<WindowGUI>("Background");

        var window = GetWindow<MenuEditor>("Menu");
        window.position = new Rect(0, 0, 400, 200);
        window.Show();

    }

    void OnGUI()
    {
        //GUILayout.Label(windowLabel, EditorStyles.boldLabel);

        myString = EditorGUILayout.TextField("Title", myString);

        if (GUILayout.Button("Add Title"))
        {
         EditText();
         AssetDatabase.Refresh();
         }

        if (GameObject.Find("BackgroundImage").GetComponent<RawImage>().IsActive())
        {
            editMenuBG();
        }
      
        if (GameObject.Find("ControlsBG").GetComponent<RawImage>().IsActive())
        {
            editControlsBG();
        }

        if (GameObject.Find("RulesBG").GetComponent<RawImage>().IsActive())
        {
            editRulesBG();
        }



    }

    void EditText()
    {
        Text gameTitle = GameObject.Find("GameTitle").GetComponent<Text>();
        Debug.Log(gameTitle.text);
        gameTitle.text = myString;
    }

    void editMenuBG()
    {
        texture = (Texture2D)EditorGUI.ObjectField(new Rect(3, 40, 200, 40),
          "Edit Menu Background:",
          texture,
          typeof(Texture2D));
        RawImage background = GameObject.Find("ControlsBG").GetComponent<RawImage>();
        if (texture)
        {
            background.texture = texture;
            if (GUI.Button(new Rect(3, 90, position.width - 6, 20), "Clear Menu Background"))
            {
                texture = EditorGUIUtility.whiteTexture;
            }
        }
    }

    void editControlsBG()
    {
        controlsScreen = (Texture2D)EditorGUI.ObjectField(new Rect(3, 120, 200, 40),
          "Edit Controls Background:",
          controlsScreen,
          typeof(Texture2D));
        RawImage background = GameObject.Find("BackgroundImage").GetComponent<RawImage>();
        if (controlsScreen)
        {
            background.texture = controlsScreen;
            if (GUI.Button(new Rect(3, 160, position.width - 6, 20), "Clear Controls Background"))
            {
                controlsScreen = EditorGUIUtility.whiteTexture;
            }
        }
    }

    void editRulesBG()
    {
        rulesScreen = (Texture2D)EditorGUI.ObjectField(new Rect(3, 180, 200, 40),
        "Edit Rules Background:",
        rulesScreen,
        typeof(Texture2D));
        RawImage background = GameObject.Find("RulesBG").GetComponent<RawImage>();
        if (rulesScreen)
        {
            background.texture = rulesScreen;
            if (GUI.Button(new Rect(3, 240, position.width - 6, 20), "Clear Rules Background"))
            {
                rulesScreen = EditorGUIUtility.whiteTexture;
            }
        }
    }

    void editBackground(Texture2D background)
    {
        
    }
}
#endif