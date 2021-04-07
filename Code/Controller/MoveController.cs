using UnityEngine;

namespace Code
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly IUnit _unitData;
        private float _horizontal;
        private float _vertical;
        private float _rotation;
        private Vector3 _move;
        private Vector3 _angelRotation;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private IUserInputProxy _rotationInputProxy;


        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputRotation) input,
            Transform unit, IUnit unitData)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _rotationInputProxy = input.inputRotation;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            _rotationInputProxy.AxisOnChange += RotationOnAxisOnChange;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }
        
        private void RotationOnAxisOnChange(float value)
        {
            _rotation = value;
        }

        public void Execute(float deltaTime)
        {
            if (_rotation != 0)
            {
                var sensitivity = _unitData.MouseSensitivity * deltaTime;
                _angelRotation.Set(0f, _rotation * sensitivity, 0f);
                _unit.transform.Rotate(_angelRotation);
            }
            var speed = deltaTime * _unitData.Speed;
            _move.Set(_horizontal * speed, 0.0f, _vertical * speed);
            _unit.transform.Translate(_move);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}