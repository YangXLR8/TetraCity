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

    void Awake()
    {
        if (System.IO.Directory.Exists("\\Saves"))
        {
            System.IO.Directory.CreateDirectory("\\Saves");
        }
    }

    public static bool GetClearedStatus(int level, int stage)
    {
        return level switch
        {
            1 => progress.Level1[stage - 1].isCompleted,
            2 => progress.Level2[stage - 1].isCompleted,
            3 => progress.Level3[stage - 1].isCompleted,
            _ => false,
        };
    }

    public static void SetClearedStatus(int level, int stage, bool status)
    {
        switch (level)
        {
            case 1: progress.Level1[stage - 1].isCompleted = status; break;
            case 2: progress.Level2[stage - 1].isCompleted = status; break;
            case 3: progress.Level3[stage - 1].isCompleted = status; break;
        }
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

    public static void Save()
    {
        System.IO.File.WriteAllText(GetSavePath(), JsonUtility.ToJson(progress, true));
    }

    public static void Read()
    {
        if (!System.IO.File.Exists(GetSavePath()))
        {
            Save();
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
        for (int i = 0; i < 3; i++) Level1.Add(new LevelStage { level = 1, id = i, isCompleted = false });
        // 4 levels for level 2
        for (int i = 0; i < 4; i++) Level2.Add(new LevelStage { level = 2, id = i, isCompleted = false });
        // 9 levels for level 3
        for (int i = 0; i < 9; i++) Level3.Add(new LevelStage { level = 3, id = i, isCompleted = false });
    }

    public List<LevelStage> Level1 = new();
    public List<LevelStage> Level2 = new();
    public List<LevelStage> Level3 = new();
}

[Serializable]
public class LevelStage
{
    public int level;
    public int id;
    public bool isCompleted;
}

[Serializable]
public class StageSetting
{
    public int level;
    public int id;
    public float height;
    public List<GameObject> blocks;
}