using System.Collections.Generic;
using Systems.Persistence;
using UnityEngine;

namespace Systems.Inventory {
    public class Inventory : MonoBehaviour, IBind<InventoryData> {
        [SerializeField] InventoryView view;
        [SerializeField] int capacity = 20;
        [SerializeField] List<ItemDetails> startingItems = new();
        [field: SerializeField] public SerializableGuid Id { get; set; } = SerializableGuid.NewGuid();
        

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