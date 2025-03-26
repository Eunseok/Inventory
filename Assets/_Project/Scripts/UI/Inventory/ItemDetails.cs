﻿using System;
using UnityEngine;
    
namespace Systems.Inventory {
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    [Serializable]
    public class ItemDetails : ScriptableObject {
        
        public string Name;
        public int maxStack = 1;
        public SerializableGuid Id = SerializableGuid.NewGuid();

        void AssignNewGuid() {
            Id = SerializableGuid.NewGuid();
        }
        
        public Sprite Icon;
        
        [TextArea]
        public string Description;
        
        public Item Create(int quantity) {
            return new Item(this, quantity);
        }
    }
}