namespace Devantler.K9sCLI;

/// <summary>
/// A custom exception for K9s.
/// </summary>
[Serializable]
public class K9sException : Exception
{
  /// <summary>
  /// Constructs a new instance of <see cref="K9sException"/>.
  /// </summary>
  public K9sException()
  {
  }

  /// <summary>
  /// Constructs a new instance of <see cref="K9sException"/> with a message.
  /// </summary>
  /// <param name="message"></param>
  public K9sException(string? message) : base(message)
  {
  }

  /// <summary>
  /// Constructs a new instance of <see cref="K9sException"/> with a message and an inner exception.
  /// </summary>
  public K9sException(string? message, Exception? innerException) : base(message, innerException)
  {
  }
}
