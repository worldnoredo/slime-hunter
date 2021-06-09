using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class audiosetting : MonoBehaviour
{
    public AudioMixer allmusic;
    void Awake()
    {
        LoadData();
    }
    public void setMusic(float value){
        allmusic.SetFloat("music",value);
    }
    public void setBGM(float value){
        allmusic.SetFloat("bgm",value);
    }
    public void setSFX(float value){
        allmusic.SetFloat("sfx",value);
    }

    public void LoadData(){
        if (File.Exists(Application.persistentDataPath 
                + "/SoundSetting.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                        File.Open(Application.persistentDataPath 
                        + "/SoundSetting.dat", FileMode.Open);
            SoundData data = (SoundData)bf.Deserialize(file);
            file.Close();
            allmusic.SetFloat("music",data.musicValue);
            allmusic.SetFloat("bgm",data.bgmValue);
            allmusic.SetFloat("sfx",data.sfxValue);
            Debug.Log("Sound data loaded!");
        }
        else {
            SaveData(0,0,0);
            LoadData();
        }
    }
    void SaveData(float s_music, float s_bgm, float s_sfx){
        BinaryFormatter bf = new BinaryFormatter(); 
	    FileStream file = File.Create(Application.persistentDataPath 
                 + "/SoundSetting.dat");
        SoundData data = new SoundData() {
            musicValue = s_music,
            bgmValue = s_bgm,
            sfxValue = s_sfx
        };
        bf.Serialize(file, data);
        file.Close();
	    Debug.Log("Sound data saved!");
    }
    public void save_click(){
        float music;
        float bgm;
        float sfx;
        allmusic.GetFloat("music",out music);
        allmusic.GetFloat("bgm",out bgm);
        allmusic.GetFloat("sfx",out sfx);
        SaveData(music,bgm,sfx);
        SceneManager.UnloadSceneAsync("musicsetting");
    }
}
