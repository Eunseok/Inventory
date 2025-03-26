using Managers;
using Platformer;
using Scripts.UI;
using Systems.Inventory;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Scripts.UI.HUD
{
    public class HUD : UIScene
    {
        UIDocument uiDocument;
        
        Button statusButton;
        Button inventoryButton;
        
        Label coinLabel;
        void Awake()
        {
            uiDocument = GetComponent<UIDocument>();
            
            statusButton = uiDocument.rootVisualElement.Q<Button>("statusButton");
            inventoryButton = uiDocument.rootVisualElement.Q<Button>("inventoryButton");
            inventoryButton.clicked += OnInventoryButtonClick;
            statusButton.clicked += OnStatButtonClick;
            
            coinLabel = uiDocument.rootVisualElement.Q<Label>("coinLabel");
        }

        void OnInventoryButtonClick()
        {
            Debug.Log("Inventory Button Clicked");
            UIManager.Instance.ShowPopup<Inventory>();
        }

        void OnStatButtonClick()
        {
            
        }

        void UpdateCoinLabel()
        {
            
        }
    }
}