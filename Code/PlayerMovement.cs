using UnityEngine;

namespace Code.Player
{
    public class PlayerMovement : MonoBehaviour
        {
            #region Field

            private float _speed = 4.0f;
            private float _rotationSpeed = 40.0f;
            private float _mouseSensitivity = 500.0f;
            private float _jumpForce = 300.0f;
            private float _groundRadius = 0.2f;
            private float _rotation = 0f;
            private float _mouseX = 0f;
            private bool _isGrounded = false;
            
            
            
            private Vector3 _direction;

            #endregion
            
            
            #region Methods

            public void MovePlayer(GameObject other, Rigidbody rgPlayer, 
                Animator animatorPlayer, Transform groundCheck, 
                LayerMask whatIsGround)
            {
                _direction.z = Input.GetAxis("Vertical");
                _direction.x = Input.GetAxis("Horizontal");

                if (Input.GetAxis("Mouse X") != 0)
                {
                    _mouseX = Input.GetAxis("Mouse X");
                    other.transform.Rotate(new Vector3(0f, _mouseX * _mouseSensitivity * Time.deltaTime, 0f));
                }

                if (Input.GetKeyDown(KeyCode.Space))
                    Jump(other, rgPlayer, groundCheck, whatIsGround);
                
                var speed = _direction * _speed * Time.deltaTime;

                if (speed != Vector3.zero)
                    animatorPlayer.SetBool("isMove", true);
                else
                    animatorPlayer.SetBool("isMove", false);

                var angleRotation = other.transform.rotation.eulerAngles.y + _rotation * _rotationSpeed * Time.deltaTime;
        
                other.transform.Translate(speed);
                other.transform.rotation = Quaternion.Euler(0, angleRotation, 0); 
            }

            private void Jump(GameObject other, Rigidbody rgPlayer, 
                Transform groundCheck, LayerMask whatIsGround)
            {
                _isGrounded = Physics.CheckSphere(groundCheck.position, 
                    _groundRadius, whatIsGround);

                if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
                {
                    //var impulse = new Vector3(_direction.x, _jumpForce, _direction.z);
                    var impulse = other.transform.up * rgPlayer.mass * _jumpForce;
                    rgPlayer.AddForce(impulse);
                }
            }

            #endregion
        }
}