using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAudio : MonoBehaviour
    {
        private static AudioSource _playerAudio;
        
        [SerializeField] private AudioClip _itemCollected;

        void Start()
        {
            _playerAudio = GetComponent<AudioSource>();
            PlayerInventory.OnItemCollected += OnItemCollected;
        }

        private void OnItemCollected() => _playerAudio.PlayOneShot(_itemCollected);
    }
}