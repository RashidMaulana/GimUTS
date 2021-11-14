using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigasi : MonoBehaviour
{
    public void pindahHalaman(string namaHalaman){
        SceneManager.LoadScene(namaHalaman);
        SFXScript.sfx.Audio.PlayOneShot(SFXScript.sfx.click);
    }
}
