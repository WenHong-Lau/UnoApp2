using System.Collections.ObjectModel;
namespace UnoApp2.Presentation;

public partial class PersonViewModel : ObservableObject
{
    private ObservableCollection<Person> _projects = new ObservableCollection<Person>();
    private INavigator _navigator;
    private Person _selectedPerson;
    private ObservableCollection<Person> _orgList = new ObservableCollection<Person>();

    public PersonViewModel(INavigator navigator)
    {
        _navigator = navigator;
        Persons =  new ObservableCollection<Person>
                    {
                        new Person { IsVIP = true, Name = "VIP Person 1" },
                        new Person { IsVIP = false, Name = "Non-VIP Person 1" },
                    };
        Main = new AsyncRelayCommand(GoMain);
    }

    public Person SelectedPerson
    {
        get => _selectedPerson;
        set
        {
            _selectedPerson = value;
            OnPropertyChanged(nameof(SelectedPerson));
            System.Diagnostics.Debug.WriteLine(_selectedPerson);
        }
    }


    public ObservableCollection<Person> Persons 
    { 
        get => _projects; 
        set 
        {
            _projects = value;
            OnPropertyChanged(nameof(Persons));
        } 
    }
    public ICommand Main { get; }

    /// <summary>
    /// Navigates to the main view. This is the entry point for the application. It does not return until the navigation is complete.
    /// </summary>
    /// <param name="token">A cancellation token that can be used to cancel the navigation.</param>
    /// <returns>A task that completes when the navigation is complete. The task will throw if there is an exception while navigating</returns>
    public async Task GoMain(CancellationToken token)
    {
        try
        {
            await _navigator.NavigateViewModelAsync<MainViewModel>(this, qualifier: Qualifiers.ClearBackStack);
        }
        catch (Exception ex)
        {
        }
    }
}
