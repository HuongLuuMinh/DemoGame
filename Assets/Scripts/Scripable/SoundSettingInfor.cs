using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GameBackGroundMusic
{
    public BackgroundMusic id;
    public AudioClip AudioClip;
}

[Serializable]
public class GameSFX
{
    public SoundEffect id;
    public AudioClip AudioClip;
}

[CreateAssetMenu(fileName = "SoundSettingInfor",
    menuName = "ScriptableObject/SoundSettingInfor",order = 1)]
public class SoundSettingInfor : ScriptableObject
{
    public List<GameBackGroundMusic> gameBackGroundMusic;
    [field: SerializeField] public List<GameSFX> gameSFX { get; set; }
}
