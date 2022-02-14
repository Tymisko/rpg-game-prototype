using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAudio : MonoBehaviour
    {
        private static AudioSource _playerAudio;

        [SerializeField] private AudioClip _walkSound;
        [SerializeField] private AudioClip _jumpedSound;
        [SerializeField] private AudioClip _itemCollected;

        void Start()
        {
            _playerAudio = GetComponent<AudioSource>();
            PlayerController.OnPlayerMoved += OnPlayerMoved;
            PlayerController.OnPlayerJumped += OnPlayerJumped;
            PlayerInventory.OnItemCollected += OnItemCollected;
        }

        private void OnItemCollected() => _playerAudio.PlayOneShot(_itemCollected);

        private void OnPlayerJumped() => _playerAudio.PlayOneShot(_jumpedSound);

        private const float PlayerMovedCooldown = .4f;
        private static float _playerTimeCooldownRemaining;

        private void OnPlayerMoved()
        {
            if (_playerTimeCooldownRemaining <= 0)
            {
                _playerAudio.PlayOneShot(_walkSound);
                _playerTimeCooldownRemaining = PlayerMovedCooldown;
            }
            else
            {
                _playerTimeCooldownRemaining -= Time.deltaTime;
            }
        }
    }
}