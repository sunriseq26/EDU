using UnityEngine;

namespace Code.Player
{
    public class PlayerHealth : Health
    {
        protected override void Die()
        {
            var animator = GetComponent<Animator>();
            animator.SetBool("isDied", true);
        }
    }
}