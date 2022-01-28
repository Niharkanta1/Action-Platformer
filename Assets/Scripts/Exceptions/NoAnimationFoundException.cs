using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NoAnimationFoundException : Exception {
    
    public NoAnimationFoundException() {  }

    public NoAnimationFoundException(string animationName)
        : base($"Invalid Animation Name: {animationName}") { }
    
    public NoAnimationFoundException(string animationName, object actualValue, string message)
        : base($"Invalid Animation Name: {animationName}, Actual Value: {actualValue}, Message: {message}") { }
}
