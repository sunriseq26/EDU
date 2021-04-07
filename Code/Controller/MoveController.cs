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
            var speed = deltaTime * _unitData.Speed;
            var sensitivity = deltaTime * _unitData.MouseSensitivity;
            _move.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _angelRotation.Set(0f, _rotation * sensitivity, 0f);
            _unit.localPosition += _move;
            _unit.localRotation = Quaternion.Euler(_angelRotation);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}