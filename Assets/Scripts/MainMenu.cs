using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MainMenu : MonoBehaviour
{

    #region Singleton
    public static MainMenu Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Show in editor
    [SerializeField]
    private TMP_Dropdown filesDropdown;
    private List<string> filesList = new List<string>();
    public string selectedFilePath;
    #endregion

    public void LoadButton()
    {
        filesList.Clear();
        Debug.Log("List cleared");
        filesDropdown.ClearOptions();
        Debug.Log("Dd cleared");
        filesDropdown.RefreshShownValue();
        string path = Application.persistentDataPath + "/Maps";
        string[] jsonFilesPaths = Directory.GetFiles(@path, "*.json");
        string[] pngFilesPaths = Directory.GetFiles(@path, "*.png");
        foreach (string file in jsonFilesPaths)
        {
            filesList.Add(Path.GetFileName(file));
        }
        foreach (string file in pngFilesPaths)
        {
            filesList.Add(Path.GetFileName(file));
        }
        filesDropdown.AddOptions(filesList);
        Debug.Log("Items added");
        filesDropdown.RefreshShownValue();
    }

    public void DropdownSelect(int index)
    {
        string filePath = Application.persistentDataPath + "/Maps";
        selectedFilePath = filePath + "/" + filesDropdown.options[filesDropdown.value].text;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
