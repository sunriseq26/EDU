using System;
using UnityEngine;
using static UnityEngine.Debug;

namespace Code.Objects
{
    public class DoorController : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Log("Enter");
            if (other.gameObject.CompareTag("Player"))
            {
                var textLines = GameController._textLines;
                var keys = textLines[3].CountField;
                Log(keys);
                if (keys > 0)
                {
                    Log("Enter");
                    _animator.SetBool("isOpen", true);
                }
            }
        }
    }
}