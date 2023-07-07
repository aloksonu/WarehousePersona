﻿using UnityEngine;

namespace WarehousePersona.Inbound.Scripts.Audio
{
    [CreateAssetMenu(fileName = "AudioData_", menuName = "Audio/AudioData", order = 1)]
    public class AudioData : ScriptableObject
    {
        public AudioElement[] data;
    }
}