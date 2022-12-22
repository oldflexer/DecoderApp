using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DecoderApp.Model;

public abstract class DecryptionMethod : INotifyPropertyChanged
{
    protected string? _title;

    public string? Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
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
    
    public virtual byte[] Decrypt(byte[] data, string argument)
    {
        return data;
    }
}