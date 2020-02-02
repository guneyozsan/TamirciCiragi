using System;

public interface IProgressUpdated
{
    event Action<float> ProgressUpdated;
}
