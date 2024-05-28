using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[Serializable]
public class SaveManager
{
    public SaveManager()
    {
        Read();
    }

    public List<bool> Level1 { get; set; } = new(3);
    public List<bool> Level2 { get; set; } = new(4);
    public List<bool> Level3 { get; set; } = new(6);

    public void Save()
    {

    }

    public void Read()
    {
        
    }
}
