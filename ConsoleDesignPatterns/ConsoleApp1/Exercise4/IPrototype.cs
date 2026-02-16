using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Exercise4;

// ── IPrototype.cs ──
public interface IPrototype<T>
{
    T DeepCopy();
}
