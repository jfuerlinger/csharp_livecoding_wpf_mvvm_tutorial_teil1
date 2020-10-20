using System;
using System.Windows.Input;

namespace ActReport.ViewModel
{
  public class RelayCommand : ICommand
  {
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    public RelayCommand(Action<object> execute) : this(execute, null) { }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
      _execute = execute;
      _canExecute = canExecute;
    }

    /// <summary>
    /// Ist das Kommando ausführbar?
    /// </summary>
    public bool CanExecute(object parameter) => _canExecute != null && _canExecute(parameter);

    /// <summary>
    /// Führe das Kommando durch
    /// </summary>
    public void Execute(object parameter) => _execute(parameter);

    /// <summary>
    /// Event zur Benachrichtigung, wenn CanExecute sich geändert hat
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
      add => CommandManager.RequerySuggested += value;
      remove => CommandManager.RequerySuggested -= value;
    }
  }
}




