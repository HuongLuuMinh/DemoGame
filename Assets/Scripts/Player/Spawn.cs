using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Tree1Pref;
    public GameObject Tree2Pref;
    public GameObject Tree3Pref;
    public GameObject Tree4Pref;

    float SpawnTime, m_SpawnTime;
    int PlaySFX;
    bool isSpawn;
    bool spawn1, spawn2, spawn3, spawn4;

    public Transform PlayerPos;

    Vector3 SpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = 7.567f;
        isSpawn = false; spawn1 = false; spawn2 = false; spawn3 = false; spawn4 = false; 
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPos = PlayerPos.position + new Vector3(0, 0.03f, 0);
        if (isSpawn)
        {
            m_SpawnTime += Time.deltaTime;
            PlaySFX++;
        }
        else 
        {
            NotificationManager.Instance.SendPN("Thong bao", "Hoan thanh viec trong cay", m_SpawnTime);
            m_SpawnTime = 0; PlaySFX = 0; 
        }
        if (isSpawn && PlaySFX == 1)
        {
            AudioManager.Instance.PlaySoundEffect(SoundEffect.ACTION_PLAY);
            PlayerProfile.Instance.DecreaseCoin(500);
        }
        if (m_SpawnTime >= SpawnTime && spawn1)
        {
            GameObject Tree1 = Instantiate(Tree1Pref, SpawnPos, Quaternion.identity);
            isSpawn = false;
            spawn1 = false;
        }
        if (m_SpawnTime >= SpawnTime && spawn2)
        {
            GameObject Tree2 = Instantiate(Tree2Pref, SpawnPos, Quaternion.identity);
            isSpawn = false;
            spawn2 = false;
        }
        if (m_SpawnTime >= SpawnTime && spawn3)
        {
            GameObject Tree3 = Instantiate(Tree3Pref, SpawnPos, Quaternion.identity);
            isSpawn = false;
            spawn3 = false;
        }
        if (m_SpawnTime >= SpawnTime && spawn4)
        {
            GameObject Tree4 = Instantiate(Tree4Pref, SpawnPos, Quaternion.identity);
            isSpawn = false;
            spawn4 = false;
        }
    }
    public void SpawnTree1()
    {
        bool rs = PlayerProfile.Instance.DecreaseCoin(500);
        bool rs1 = PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_01);

        if(rs1 && rs)
        {
            isSpawn = true;
            spawn1 = true;
            spawn2 = false; spawn3 = false; spawn4 = false;
        }
        else
        {
            Debug.LogWarning("Khong du tien hoac hat giong");
        }
        
    }
    public void SpawnTree2()
    {
        bool rs = PlayerProfile.Instance.DecreaseCoin(500);
        bool rs2 = PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_02);

        if (rs2 && rs)
        {
            isSpawn = true;
            spawn2 = true;
            spawn1 = false; spawn3 = false; spawn4 = false;
        }
        else
        {
            Debug.LogWarning("Khong du tien hoac hat giong");
        }
    }
    public void SpawnTree3()
    {
        bool rs = PlayerProfile.Instance.DecreaseCoin(500);
        bool rs3 = PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_03);

        if (rs3 && rs)
        {
            isSpawn = true;
            spawn3 = true;
            spawn2 = false; spawn1 = false; spawn4 = false;
        }
        else
        {
            Debug.LogWarning("Khong du tien hoac hat giong");
        }
    }
    public void SpawnTree4()
    {
        bool rs = PlayerProfile.Instance.DecreaseCoin(500);
        bool rs4 = PlayerProfile.Instance.UseGameItem(GameItemId.ITEM_04);

        if (rs4 && rs)
        {
            isSpawn = true;
            spawn4 = true;
            spawn2 = false; spawn3 = false; spawn1 = false;
        }
        else
        {
            Debug.LogWarning("Khong du tien hoac hat giong");
        }
    }
    public bool isSpawnState()
    {
        return isSpawn;
    }
    public void SetSpawnState(bool state)
    {
        isSpawn = state;
    }
}
