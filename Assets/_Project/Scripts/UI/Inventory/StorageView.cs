using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Systems.Inventory
{
    public abstract class StorageView : MonoBehaviour
    {
        public Slot[] Slots;

        [SerializeField] protected UIDocument document;
        [SerializeField] protected StyleSheet styleSheet;

        protected static VisualElement ghostIcon;

        static bool isDragging;
        static Slot originalSlot;

        protected VisualElement root;
        protected VisualElement container;
        
        public event Action<Slot, Slot> OnDrop;

        IEnumerator Start()
        {
            yield return InitializeView();
            
            ghostIcon.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            ghostIcon.RegisterCallback<PointerUpEvent>(OnPointerUp);

            foreach (var slot in Slots)
            {
                slot.OnStartDrag += OnPointerDown;
            }
        }

        public abstract IEnumerator InitializeView(int size = 20);
        
        void OnPointerDown(Vector2 position, Slot slot)
        {
            isDragging = true;
            originalSlot = slot;

            StartCoroutine(FollowMouse());
           // SetGhostIconPosition(position);
            
            ghostIcon.style.backgroundImage = originalSlot.BaseSprite.texture;
            originalSlot.Icon.image = null;
            originalSlot.StackLabel.visible = false;

            ghostIcon.style.opacity = 0.8f;
            ghostIcon.style.visibility = Visibility.Visible;
        }

        void OnPointerMove(PointerMoveEvent evt)
        {
            if (!isDragging) return;
            
            //SetGhostIconPosition(evt.position);
        }

        void OnPointerUp(PointerUpEvent evt)
        {
            if (!isDragging) return;

            var closetSlot = Slots
                .Where(slot => slot.worldBound.Overlaps(ghostIcon.worldBound))
                .OrderBy(slot => Vector2.Distance(slot.worldBound.position, ghostIcon.worldBound.position))
                .FirstOrDefault();

            if (closetSlot != null)
            {
                OnDrop?.Invoke(originalSlot, closetSlot);
            }
            else
            {
                originalSlot.Icon.image = originalSlot.BaseSprite.texture;
            }

            isDragging = false;
            originalSlot = null;
            ghostIcon.style.visibility = Visibility.Hidden;
        }

        IEnumerator FollowMouse()
        {
            while (isDragging)
            { 
                Vector2 mousePosition = Input.mousePosition;
                mousePosition.y = Screen.height - mousePosition.y;
                SetGhostIconPosition(mousePosition);
                yield return null;
            }
        }
        
        static void SetGhostIconPosition(Vector2 position)
        {
            ghostIcon.style.top = position.y - ghostIcon.layout.height / 2;
            ghostIcon.style.left = position.x - ghostIcon.layout.width / 2;
        }
    }
}