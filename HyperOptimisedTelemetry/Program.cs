using System;
using System.Linq;
using System.Text;

namespace HyperOptimisedTelemetry
{
    public static class TelemetryBuffer
    {

        public static byte[] ToBuffer(long reading)
        {
            byte prefixByte;
            if (reading >= 4_294_967_296 && reading <= 9_223_372_036_854_775_807)
            {
                prefixByte = 256 - 8;
            }
            else if (reading >= 2_147_483_648 && reading <= 4_294_967_295)
            {
                prefixByte = 4;
            }
            else if (reading >= 65_536 && reading <= 2_147_483_647)
            {
                prefixByte = 256 - 4;
            }
            else if (reading >= 0 && reading <= 65_535)
            {
                prefixByte = 2;
            }
            else if (reading >= -32_768 && reading <= -1)
            {
                prefixByte = 256 - 2;
            }
            else if (reading >= -2_147_483_648 && reading <= -32_769)
            {
                prefixByte = 256 - 4;
            }
            else
            {
                prefixByte = 256 - 8;
            }

            byte[] bytes = BitConverter.GetBytes(reading);
            bool isNegative = reading < 0;
            return BuildDataArray(bytes, prefixByte, isNegative);
        }

        public static long FromBuffer(byte[] buffer)
        {
            byte prefixByte = buffer[0];
            if (prefixByte > 240)
            {
                prefixByte = (byte)(256 - prefixByte);
                if (prefixByte is not 2 and not 4 and not 8)
                {
                    return 0;
                }

                if (prefixByte == 2)
                {
                    return BitConverter.ToInt16(buffer.Skip(1).Take(prefixByte).ToArray());
                }
                else if (prefixByte == 4)
                {
                    return BitConverter.ToInt32(buffer.Skip(1).Take(prefixByte).ToArray());
                }

                else
                {
                    return BitConverter.ToInt64(buffer.Skip(1).Take(prefixByte).ToArray());
                }
            }
            else
            {
                if (prefixByte is not 2 and not 4 and not 8)
                {
                    return 0;
                }
                else if (prefixByte == 2)
                {
                    return BitConverter.ToUInt16(buffer.Skip(1).Take(prefixByte).ToArray());
                }

                else if (prefixByte == 4)
                {
                    return BitConverter.ToUInt32(buffer.Skip(1).Take(prefixByte).ToArray());
                }
                else
                {
                    return BitConverter.ToInt64(buffer.Skip(1).Take(prefixByte).ToArray());
                }
            }
        }

        private static byte[] BuildDataArray(byte[] input, byte prefixByte, bool isNegative)
        {
            byte[] output = new byte[9];

            // Put the prefix byte at position 0 (first element)
            output[0] = prefixByte;

            // Copy
            for (int index = 0; index < input.Length; index++)
            {
                output[index + 1] = input[index];
            }

            // Erase the unnecessary bytes, depending on the size of the number (in bytes)
            if (isNegative)
            {
                var bytesCount = 256 - prefixByte;
                for (int i = 1 + bytesCount; i < output.Length; i++)
                {
                    output[i] = 0;
                }
            }

            // Print the output for debugging
            foreach (var byte1 in output)
            {
                Console.Write($"0x{byte1:X} ");
            }

            return output;
        }

        public static void Main()
        {
            //FromBuffer(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f });
            FromBuffer(new byte[] { 0x2, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 });
        }
    }
}

