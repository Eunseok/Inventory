using Managers;
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
        void Awake()
        {
            uiDocument = GetComponent<UIDocument>();
            
            statusButton = uiDocument.rootVisualElement.Q<Button>("statusButton");
            inventoryButton = uiDocument.rootVisualElement.Q<Button>("inventoryButton");

            inventoryButton.clicked += OnInventoryButtonClick;
            statusButton.clicked += OnStatButtonClick;
        }

        void OnInventoryButtonClick()
        {
            Debug.Log("Inventory Button Clicked");
            UIManager.Instance.ShowPopup<Inventory>();
        }

        void OnStatButtonClick()
        {
            
        }
    }
}