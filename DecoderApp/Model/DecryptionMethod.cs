using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DecoderApp.Model;

public abstract class DecryptionMethod : INotifyPropertyChanged
{
    private string? _title;

    public string? Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public virtual byte[] Decrypt(byte[] data, string argument)
    {
        return data;
    }
}