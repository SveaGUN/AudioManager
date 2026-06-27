using UnityEngine;

namespace AkaneTools
{
    [CreateAssetMenu(fileName = "AudioClipsData", menuName = "Scriptable Objects/AudioClipsData")]
    public class AudioClipsData : ScriptableObject
    {
        public SerializableDictionary<string, AudioClip> ClipsDict = new();
    }
}