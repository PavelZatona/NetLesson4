using ReactiveUI;
using System.Reactive;

namespace GraphicsCalculator.ViewModels;

public class MainViewModel : ViewModelBase
{
    #region Аргумент 1

    private string _argument1;

    public string Argument1
    {
        get => _argument1;
        set => this.RaiseAndSetIfChanged(ref _argument1, value);
    }

    #endregion

    #region Аргумент 2

    private string _argument2;

    public string Argument2
    {
        get => _argument2;
        set => this.RaiseAndSetIfChanged(ref _argument2, value);
    }

    #endregion

    #region Результат

    private double _result;

    public double Result
    {
        get => _result;
        set => this.RaiseAndSetIfChanged(ref _result, value);
    }

    #endregion

    #region Команды

    /// <summary>
    /// Команда сложения
    /// </summary>
    public ReactiveCommand<Unit, Unit> AddCommandSum { get; }

    /// <summary>
    /// Команда вычитания
    /// </summary>
    public ReactiveCommand<Unit, Unit> AddCommandSub { get; }

    /// <summary>
    /// Команда деления
    /// </summary>
    public ReactiveCommand<Unit, Unit> AddCommandDiv { get; }

    /// <summary>
    /// Команда умножения
    /// </summary>
    public ReactiveCommand<Unit, Unit> AddCommandMult { get; }

    /// <summary>
    /// Команда сброса
    /// </summary>
    public ReactiveCommand<Unit, Unit> ResetCommand { get; }

    #endregion

    /// <summary>
    /// Конструктор
    /// </summary>
    public MainViewModel()
    {
        #region Настройка команд

        // Мы связали команду AddCommand с методом Add()
        AddCommandSum = ReactiveCommand.Create(Sum);
        AddCommandSub = ReactiveCommand.Create(Subtraction);
        AddCommandDiv = ReactiveCommand.Create(Division);
        AddCommandMult = ReactiveCommand.Create(Multiplication);
        ResetCommand = ReactiveCommand.Create(Reset);

        #endregion

        Result = 0;
    }

    private void Sum()
    {
        var a = double.Parse(Argument1);
        var b = double.Parse(Argument2);

        Result = a + b;
    }
    private void Subtraction()
    {
        var a = double.Parse(Argument1);
        var b = double.Parse(Argument2);

        Result = a - b;
    }
    private void Division()
    {
        var a = double.Parse(Argument1);
        var b = double.Parse(Argument2);

        Result = a / b;
    }
    private void Multiplication()
    {
        var a = double.Parse(Argument1);
        var b = double.Parse(Argument2);

        Result = a * b;
    }

    private void Reset()
    {
        Argument1 = string.Empty;
        Argument2 = string.Empty;

        Result = 0;
    }
}
