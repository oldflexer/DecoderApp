using System;
using System.Windows;

namespace DecoderApp.Model;

public class MyInversionMethod : DecryptionMethod
{
    public override byte[] Decrypt(byte[] data, string argument)
    {
        try
        {
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = (byte)~data[i];
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
            return data;
        }
        
        return data;
        
    }
}