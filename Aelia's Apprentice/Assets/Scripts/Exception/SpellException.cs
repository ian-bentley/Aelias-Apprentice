using System;
using UnityEngine;

public class InvalidSpellException : Exception
{
    public InvalidSpellException(string message) : base(message) { }
}
