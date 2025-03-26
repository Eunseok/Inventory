using System;
using Systems.Persistence;
using UnityEngine;

[Serializable]
public class PlayerData : ISaveable {
    [field: SerializeField] public SerializableGuid Id { get; set; }
}
