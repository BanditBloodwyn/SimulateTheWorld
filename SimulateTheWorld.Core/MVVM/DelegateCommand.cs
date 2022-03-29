using System;
using System.Windows.Input;

namespace SimulateTheWorld.Core.MVVM;

public class DelegateCommand : ICommand
{
    private readonly Predicate<object?>? _canExecute;
    private readonly Action<object?> _execute;

    public event EventHandler? CanExecuteChanged;

    public DelegateCommand(Predicate<object?>? canExecute, Action<object?> execute)
    {
        _canExecute = canExecute;
        _execute = execute;
    }

    public DelegateCommand(Action<object?> execute) 
        : this(null, execute) {}

    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => _execute.Invoke(parameter);

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}