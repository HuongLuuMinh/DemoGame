using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackgroundMusic
{
    NONE,
    BACKGROUND_MUSIC_01,
    BACKGROUND_MUSIC_02,
    BACKGROUND_MUSIC_03,
}

public enum SoundEffect
{
    NONE,

    UI_CLICK = 100,
    UI_BACK,
    UI_CONFIRM,

    ACTION_MOVE = 1000,
    ACTION_PLAY,
    ACTION_MILKING,
}

public class AudioManager : ISingletonMonoBehaviour<AudioManager>
{
    [SerializeField] private AudioSource m_MusicSource;
    [SerializeField] private AudioSource m_EffectSource;
    private SoundSettingInfor m_SoundSettingInfor;

    private bool m_SounfEffect;

    protected override void Awake()
    {
        base.Awake();
        m_SoundSettingInfor = Resources.Load<SoundSettingInfor>("SoundSettingInfor");
    }
    public void PlayBackGroundMusic(BackgroundMusic backgroundMusic)
    {
        m_MusicSource.clip = m_SoundSettingInfor.gameBackGroundMusic
            .Find(item => item.id == backgroundMusic).AudioClip;
        m_MusicSource.volume = 0.6f;
        m_MusicSource.loop = true;
        m_MusicSource.Play();
    }
    public void StopBackgroundMusic()
    {
        m_MusicSource.Stop();
    }
    public bool isPlayBackgroundMusic()
    {
        return m_MusicSource.isPlaying;
    }
    public void PlaySoundEffect(SoundEffect sfx)
    {
        if (m_SounfEffect)
        {
            m_EffectSource.PlayOneShot(m_SoundSettingInfor.gameSFX
                .Find(x => x.id == sfx).AudioClip);
        }
    }
    public void StopSoundEffect()
    {
        m_EffectSource.Stop();
    }
    public bool isPlayingSoundEffect()
    {
        return m_EffectSource.isPlaying;
    }
    public bool isSoundOn()
    {
        return m_SounfEffect;
    }
    public void SetSoundEffect(bool state)
    {
        m_SounfEffect = state;
    }
}
