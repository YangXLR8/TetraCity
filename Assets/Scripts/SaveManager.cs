using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static LevelProgress progress = new();

    public static string GetSavePath()
    {
        return System.IO.Directory.GetCurrentDirectory() + "\\Saves\\save.json";
    }

    public static int GetClearedStages(string level)
    {
        List<LevelStage> levelList = new();
        if (level.Equals("Level1")) levelList = progress.Level1;
        else if (level.Equals("Level2")) levelList = progress.Level2;
        else if (level.Equals("Level3")) levelList = progress.Level3;

        int clearedStages = 0;
        foreach (LevelStage levelStage in levelList)
        {
            if (levelStage.isCompleted) clearedStages++;
        }

        return clearedStages;
    }

    public static void Default()
    {
        System.IO.File.WriteAllText(GetSavePath(), JsonUtility.ToJson(progress));
    }

    public static void Save()
    {
        
    }

    public static void Read()
    {
        if (!System.IO.File.Exists(GetSavePath()))
        {
            Default();
        }

        progress = JsonUtility.FromJson<LevelProgress>(System.IO.File.ReadAllText(GetSavePath()));
    }
}

[Serializable]
public class LevelProgress
{
    public LevelProgress()
    {
        // 3 levels for level 1
        for (int i = 0; i < 3; i++) Level1.Add(new LevelStage { id = i, isCompleted = false });
        // 4 levels for level 2
        for (int i = 0; i < 4; i++) Level2.Add(new LevelStage { id = i, isCompleted = false });
        // 6 levels for level 3
        for (int i = 0; i < 6; i++) Level3.Add(new LevelStage { id = i, isCompleted = false });
    }

    public List<LevelStage> Level1 = new();
    public List<LevelStage> Level2 = new();
    public List<LevelStage> Level3 = new();
}

[Serializable]
public class LevelStage
{
    public int id;
    public bool isCompleted;
}