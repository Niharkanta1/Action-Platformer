using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CustomException : Exception {

    public CustomException() {  }

    public CustomException(string message)
        : base($"Exception : {message}") { }
    
    public CustomException(string param, object actualValue, string message)
        : base($"Exception for param: {param}, Actual Value: {actualValue}, Message: {message}") { }
}


