using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    // public static SoundsManager instance;

    [Header("Plank Sound")]
    public AudioClip plankSound;

    [Header("Door Sound")]
    public AudioClip openDoor, closeDoor, basementDoor;

    [Header("Key Sound")]
    public AudioClip keySound;

    [Header("Lamp Sound")]
    public AudioClip lampSound;


    public void PlankSound()
    {
        AudioManager.instance.PlaySound(plankSound);
    }

    public void OpenDoorSound()
    {
        AudioManager.instance.PlaySound(openDoor);
    }

    public void CloseDoorSound()
    {
        AudioManager.instance.PlaySound(closeDoor);
    }

    public void BasementDoorSound()
    {
        AudioManager.instance.PlaySound(basementDoor);
    }

    public void GetKeySound()
    {
        AudioManager.instance.PlaySound(keySound);
    }


}
