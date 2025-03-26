using System;
using System.Collections.Generic;
using Platformer;
using Scripts.UI;
using Systems.Persistence;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Systems.Inventory {
    public class Inventory : UIPopup, IBind<InventoryData> {
        [SerializeField] InventoryView view;
        [SerializeField] int capacity = 20;
        [SerializeField] List<ItemDetails> startingItems = new();
        [field: SerializeField] public SerializableGuid Id { get; set; } = SerializableGuid.NewGuid();
        [SerializeField] EventChannel<float> coinChannel;

        InventoryController controller;
        
        void Awake() {
            controller = new InventoryController.Builder(view)
                .WithStartingItems(startingItems)
                .WithCapacity(capacity)
                .Build();
        }

        public void Bind(InventoryData data) {
            Debug.Log($"Binding inventory {Id} to data {data.Id}");
            controller.Bind(data);
            data.Id = Id;
        }
    }
}