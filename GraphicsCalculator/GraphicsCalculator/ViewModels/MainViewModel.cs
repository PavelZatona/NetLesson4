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
    public ReactiveCommand<Unit, Unit> AddCommand { get; }

    #endregion

    /// <summary>
    /// Конструктор
    /// </summary>
    public MainViewModel()
    {
        #region Настройка команд

        // Мы связали команду AddCommand с методом Add()
        AddCommand = ReactiveCommand.Create(Add);

        #endregion

        Result = 0;
    }

    private void Add()
    {
        var a = double.Parse(Argument1);
        var b = double.Parse(Argument2);

        Result = a + b;
    }
}
