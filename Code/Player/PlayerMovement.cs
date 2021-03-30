using UnityEngine;

namespace Code.Player
{
    public class PlayerMovement
        {
            
            #region Methods

            public static void MovePlayer(GameObject other, Rigidbody rgPlayer, 
                Animator animatorPlayer, Transform groundCheck, 
                LayerMask whatIsGround)
            {
                Vector3 direction = new Vector3();
                float _mouseX;
                float _mouseSensitivity = 500.0f;
                float _speed = 2.0f;
                float _rotation = 0f;
                float _rotationSpeed = 40.0f;
            
                direction.z = Input.GetAxis("Vertical");
                direction.x = Input.GetAxis("Horizontal");


                if (Input.GetAxis("Mouse X") != 0)
                {
                    _mouseX = Input.GetAxis("Mouse X");
                    other.transform.Rotate(new Vector3(0f, _mouseX * _mouseSensitivity * Time.deltaTime, 0f));
                }

                if (Input.GetKeyDown(KeyCode.Space))
                    Jump(other, rgPlayer, groundCheck, whatIsGround);
                
                var speed = direction * _speed * Time.deltaTime;

                if (speed != Vector3.zero)
                    animatorPlayer.SetBool("isMove", true);
                else
                    animatorPlayer.SetBool("isMove", false);

                var angleRotation = other.transform.rotation.eulerAngles.y + _rotation * _rotationSpeed * Time.deltaTime;
        
                other.transform.Translate(speed);
                other.transform.rotation = Quaternion.Euler(0, angleRotation, 0); 
            }

            private static void Jump(GameObject other, Rigidbody rgPlayer, 
                Transform groundCheck, LayerMask whatIsGround)
            {
                float _jumpForce = 300.0f;
                float _groundRadius = 0.2f;
                bool _isGrounded = false;
            
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