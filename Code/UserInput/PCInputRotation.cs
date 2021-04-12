﻿using System;
using UnityEngine;

namespace Code
{
    public sealed class PCInputRotation : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.ROTATION));
        }
    }
}