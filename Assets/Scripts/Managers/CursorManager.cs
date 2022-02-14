using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private Texture2D _cursorTexture;
        private CursorMode cursorMode = CursorMode.Auto;
        private readonly Vector2 _hotSpot = Vector2.zero;

        public CursorManager(Texture2D cursorTexture)
        {
            _cursorTexture = cursorTexture;
        }

        void Awake()
        {
            Cursor.SetCursor(_cursorTexture, _hotSpot, cursorMode);
        }
    }
}