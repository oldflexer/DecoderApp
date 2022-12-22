using System;
using System.Windows;

namespace DecoderApp.Model;

public class MyCaesarMethod : DecryptionMethod
{
    public override byte[] Decrypt(byte[] data, string argument)
    {
        try
        {
            if (Convert.ToDouble(argument) <= 255 && Convert.ToDouble(argument) >= 0)
            {
                byte key = Convert.ToByte(argument);
                MessageBox.Show(key.ToString());
                for (var i = 0; i < data.Length; i++)
                {
                    data[i] += key;
                }
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