using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace DecoderApp.Model;

public class FileHandler
{
    private byte[]? _fileData;
    private string? _fileName;
    private readonly OpenFileDialog _openFileDialog;
    private readonly SaveFileDialog _saveFileDialog;

    public FileHandler(OpenFileDialog openFileDialog, SaveFileDialog saveFileDialog)
    {
        _fileData = null;
        _fileName = string.Empty;
        _openFileDialog = openFileDialog;
        _saveFileDialog = saveFileDialog;
        _openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        _saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        _saveFileDialog.CreatePrompt = true;
        _saveFileDialog.OverwritePrompt = true;
    }

    public string? ChooseFilenameToOpen()
    {
        if (_openFileDialog.ShowDialog() != true) return null;
        _fileName = _openFileDialog.FileName;
        return _fileName;
    }

    public string? ChooseFilenameToSave()
    {
        if (_saveFileDialog.ShowDialog() != true) return null;
        _fileName = _saveFileDialog.FileName;
        return _fileName;
    }

    public byte[] OpenFile(string filename)
    {
        _fileData = File.ReadAllBytes(filename);
        return _fileData;
    }
    
    public static void SaveFile(string filename, byte[] data)
    {
        if (File.Exists(filename)) File.WriteAllText(filename, string.Empty);
        
        try
        {
            using (var fileStream = File.Create(filename))
            {
                fileStream.Write(data, 0, data.Length);
            }
            MessageBox.Show("File saved!");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
            throw;
        }
    }
}