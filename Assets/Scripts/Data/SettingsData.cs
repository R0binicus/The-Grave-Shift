using Unity.VisualScripting;
using UnityEngine;

public class SettingsData
{
    [field:SerializeField] public float SFX { get; private set; }
    [field:SerializeField] public float Music { get; private set; }
    [field:SerializeField] public float CharactersPerSec { get; private set; }
    [field:SerializeField] public int ResolutionWidth { get; private set; }

    public SettingsData(float SFX, float Music, float CharactersPerSec, int ResolutionWidth)
    {
        this.SFX = SFX;
        this.Music = Music;
        this.CharactersPerSec = CharactersPerSec;
        this.ResolutionWidth = ResolutionWidth;
    }
};