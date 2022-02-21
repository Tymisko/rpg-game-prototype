using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class LeverController : MonoBehaviour
    {
        private float _angularChange = -90f;
        
        private Quaternion _startRotation;
        private Quaternion _endRotation;
        private Vector3 _tmpEuler;

        private bool _isSlerping;
        private float _timeStartedSlerping;
        private float _timeTakenDuringSlerp = 1f;

        private bool _leverLowered;

        public static event Action OnLeverLowered;
        
        private void OnMouseDown()
        {
            if (!_leverLowered)
            {
                OnLeverLowered?.Invoke();
                _leverLowered = true;
                RotateLever();
            }
        }

        private void RotateLever()
        {
            _isSlerping = true;
            _timeStartedSlerping = Time.time;
            
            _startRotation = transform.rotation;
            
            _tmpEuler = new Vector3(
                _startRotation.eulerAngles.x,
                _startRotation.eulerAngles.y,
                _startRotation.eulerAngles.z  + _angularChange);
            
            _endRotation = Quaternion.Euler(_tmpEuler);
        }

        void FixedUpdate()
        {
            if (_isSlerping)
            {
                float timeSinceStarted = Time.time - _timeStartedSlerping;
                float percentageComplete = timeSinceStarted / _timeTakenDuringSlerp;
                
                transform.rotation = Quaternion.Slerp (_startRotation, _endRotation, percentageComplete);
                
                if(percentageComplete >= 1f)
                {
                    _isSlerping = false;
                }
            }
        }
    }
}

