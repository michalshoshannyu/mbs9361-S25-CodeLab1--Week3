using UnityEngine;
using System.IO;
using TMPro;
public class ManagerGameScript : MonoBehaviour
{

    public static ManagerGameScript instance;
    private string hit;

    public string Hit
    {
        set
        {
            hit = value;
            Debug.Log($"Manager Path updated: {hit}");
        }
        get { return hit; }
    }

    private string FilePathStpry;
    private const string DirStoryName = "/Story/";
    private const string FileName = DirStoryName + "story.txt";
    
    private string storyPath;
    public string StoryPath
    {
     
        set
        {
            storyPath = value;
            if (!File.Exists(storyPath))
            {
                string dirStoryLocation = Application.dataPath + DirStoryName;
                if (!Directory.Exists(dirStoryLocation))
                {
                    Directory.CreateDirectory(dirStoryLocation);
                }
            }
            
            File.WriteAllText(storyPath, hit + " ");
        }
        get
        {
            if (File.Exists(FilePathStpry))
            {
                string fileContent = File.ReadAllText(FilePathStpry);
                storyPath = fileContent;
            }
            return storyPath;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FilePathStpry = Application.dataPath + FileName;
        Debug.Log(FilePathStpry);
        EventManager.instance.StartListening(EventManager.GameEvent.ENTER_PATH, ChangeMainPath);
    }

    private void ChangeMainPath(object pathName)
    {
        if (pathName is string path)
        {
            Hit = path;
            Debug.Log($"Entered path: {Hit}");
            
            string dirStoryLocation = Application.dataPath + DirStoryName;
            if (!Directory.Exists(dirStoryLocation))
            {
                Directory.CreateDirectory(dirStoryLocation);
            }
            File.WriteAllText(FilePathStpry, Hit + " ");
        }
    }
}