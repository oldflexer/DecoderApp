using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DecoderApp.Model;
using Microsoft.Win32;

namespace DecoderApp;

public class ApplicationViewModel : INotifyPropertyChanged
{
    private FileHandler _fileHandler;

    public ObservableCollection<DecryptionMethod> DecryptionMethods { get; set; }
    public DecryptionMethod _selectedDecryptionMethod;
    public int SelectedIndex { get; set; }

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
            OnPropertyChanged(nameof(SelectedDecryptionMethod));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    // {
    //     if (EqualityComparer<T>.Default.Equals(field, value)) return false;
    //     field = value;
    //     OnPropertyChanged(propertyName);
    //     return true;
    // }

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
        byte[] data;

        if (argument == string.Empty) argument = "1";
        
        switch (SelectedDecryptionMethod)
        {
            case MyXorMethod:
                MessageBox.Show(SelectedDecryptionMethod.ToString());
                data = _fileHandler.OpenFile(filenameToOpen);
                data = SelectedDecryptionMethod.Decrypt(data, argument);
                _fileHandler.SaveFile(filenameToSave, data);
                return;
            case MyInversionMethod:
                MessageBox.Show(SelectedDecryptionMethod.ToString());
                data = _fileHandler.OpenFile(filenameToOpen);
                data = SelectedDecryptionMethod.Decrypt(data, argument);
                _fileHandler.SaveFile(filenameToSave, data);
                return;
            case MyCaesarMethod:
                MessageBox.Show(SelectedDecryptionMethod.ToString());
                data = _fileHandler.OpenFile(filenameToOpen);
                data = SelectedDecryptionMethod.Decrypt(data, argument);
                _fileHandler.SaveFile(filenameToSave, data);
                return;
        }
    }
}