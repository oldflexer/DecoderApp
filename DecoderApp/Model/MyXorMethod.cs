using System;
using System.Windows;

namespace DecoderApp.Model;

public class MyXorMethod : DecryptionMethod
{
    public override byte[] Decrypt(byte[] data, string argument)
    {
        try
        {
            var key = byte.MaxValue;

            if (Convert.ToDouble(argument) <= 255 && Convert.ToDouble(argument) >= 0)
            {
                key = Convert.ToByte(argument);
            }

            MessageBox.Show(messageBoxText:key.ToString());
            for (var i = 0; i < data.Length; i++)
            {
                data[i] ^= key;
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(messageBoxText:e.ToString());
            return data;
        }
        
        return data;
    }
}