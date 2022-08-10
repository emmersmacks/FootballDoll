using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnimationController : MonoBehaviour
{
    [SerializeField] private float _minSizeValue;
    [SerializeField] private float _maxSizeValue;

    [SerializeField] private float _animationStepNumber;

    private bool _isReverse = false;

    private void FixedUpdate()
    {
        if(transform.localScale.x < _maxSizeValue && !_isReverse)
        {
            var currentSize = transform.localScale.x;
            transform.localScale = new Vector3(currentSize + _animationStepNumber, currentSize + _animationStepNumber, currentSize + _animationStepNumber);
        }
        else if(transform.localScale.x > _minSizeValue && _isReverse)
        {
            var currentSize = transform.localScale.x;
            transform.localScale = new Vector3(currentSize - _animationStepNumber, currentSize - _animationStepNumber, currentSize - _animationStepNumber);
        }
        else
        {
            _isReverse = !_isReverse;
        }
    }
}
