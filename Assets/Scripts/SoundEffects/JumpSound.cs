using UnityEngine;

namespace Assets.Scripts.SoundEffects
{
    public class JumpSound : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _landSound;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Jump()
        {
            _audioSource.PlayOneShot(_jumpSound);
        }

        private void Land()
        {
            _audioSource.PlayOneShot(_landSound);
        }
    }
}

