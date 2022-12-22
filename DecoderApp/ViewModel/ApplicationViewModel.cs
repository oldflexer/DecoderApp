using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DecoderApp.Model;
using Microsoft.Win32;

namespace DecoderApp.ViewModel;

public sealed class ApplicationViewModel : INotifyPropertyChanged
{
    private readonly FileHandler _fileHandler;

    public ObservableCollection<DecryptionMethod> DecryptionMethods { get; set; }
    private DecryptionMethod _selectedDecryptionMethod = null!;
    private int _selectedIndex;

    public ApplicationViewModel()
    {
        DecryptionMethods = new ObservableCollection<DecryptionMethod>
        {
            new MyXorMethod { Title = "XOR cipher" },
            new MyInversionMethod { Title = "Inverse cipher" },
            new MyCaesarMethod { Title = "Caesar cipher" }
        };

        _fileHandler = new FileHandler(new OpenFileDialog(), new SaveFileDialog());
    }

    public DecryptionMethod SelectedDecryptionMethod
    {
        get => _selectedDecryptionMethod;
        set
        {
            _selectedDecryptionMethod = value;
            OnPropertyChanged();
        }
    }
    
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public string? OpenFile()
    {
        return _fileHandler.ChooseFilenameToOpen();
    }

    public string? SaveFile()
    {
        return _fileHandler.ChooseFilenameToSave();
    }

    public void DecryptFile(string filenameToOpen, string filenameToSave, string argument)
    {
        if (argument == string.Empty) argument = "0";

        try
        {
            var data = _fileHandler.OpenFile(filenameToOpen);
            data = SelectedDecryptionMethod.Decrypt(data, argument);
            FileHandler.SaveFile(filenameToSave, data);
        }
        catch (Exception e)
        {
            MessageBox.Show(messageBoxText:e.ToString());
            throw;
        }
    }
}