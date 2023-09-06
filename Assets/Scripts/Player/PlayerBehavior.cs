using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] UseJoinStick JoinStick;

    Spawn spawn;

    int Anim_Speed;
    int Anim_Plant;
    float CharSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        Anim_Speed = Animator.StringToHash("Speed");
        Anim_Plant = Animator.StringToHash("Plant");

        spawn = FindObjectOfType<Spawn>();

        AudioManager.Instance.PlayBackGroundMusic(BackgroundMusic.BACKGROUND_MUSIC_01);
        AudioManager.Instance.SetSoundEffect(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn.isSpawnState() == true)
        {
            animator.SetBool(Anim_Plant, true);
        }
        if (spawn.isSpawnState() == false)
        {
            animator.SetBool(Anim_Plant, false);
        }
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)||JoinStick.isEnableJoStickState())
        {
            CharSpeed = 3;
            animator.SetFloat(Anim_Speed, CharSpeed);
        }
        else
        {
            CharSpeed = 0;
            animator.SetFloat(Anim_Speed, CharSpeed);
        }
    }
    public void StopAndPlayMusic()
    {
        if (AudioManager.Instance.isPlayBackgroundMusic())
        {
            AudioManager.Instance.StopBackgroundMusic();
        }
        else
        {
            AudioManager.Instance.PlayBackGroundMusic(BackgroundMusic.BACKGROUND_MUSIC_01);
        }
    }
    public void SetSoundEffect()
    {
        if (AudioManager.Instance.isSoundOn())
        {
            AudioManager.Instance.SetSoundEffect(false);
            AudioManager.Instance.StopSoundEffect();
        }
        else { AudioManager.Instance.SetSoundEffect(true); }
    }
    
}
