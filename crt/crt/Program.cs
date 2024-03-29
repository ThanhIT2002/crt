using System;
using System.Numerics;

public class CRT
{
    // Tính nghịch đảo modulo của a trong modulo m bằng thuật toán Euclid mở rộng
    private static BigInteger ModInverse(BigInteger a, BigInteger m)
    {
        BigInteger m0 = m;
        BigInteger y = 0;
        BigInteger x = 1;

        while (a > 1)
        {
            BigInteger q = a / m;
            BigInteger t = m;
            m = a % m;
            a = t;
            t = y;
            y = x - q * y;
            x = t;
        }

        if (x < 0)
            x += m0;

        return x;
    }

    // Tính z = C^((p + 1)/4) mod p
    private static BigInteger CalculateZ(BigInteger C, BigInteger p)
    {
        BigInteger exponent = (p + 1) / 4;
        return BigInteger.ModPow(C, exponent, p);
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Nhập giá trị của C, p và q
        BigInteger C, p, q;
        Console.WriteLine("Nhập giá trị của C:");
        C = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine("Nhập giá trị của p (số nguyên tố):");
        p = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine("Nhập giá trị của q (số nguyên tố kế tiếp của p):");
        q = BigInteger.Parse(Console.ReadLine());

        // Tính nghịch đảo modulo của q trong modulo p và ngược lại
        BigInteger u = ModInverse(q, p);
        BigInteger v = ModInverse(p, q);

        // Tính z theo CRT
        BigInteger zp = CalculateZ(C, p);
        BigInteger zq = CalculateZ(C, q);

        // Tính z bằng CRT
        BigInteger z = BigInteger.ModPow((zq * p * v + zp * q * u),1, (p * q));

        Console.WriteLine("u : " + u + " , v : " + v + " , zp : " + zp + " , zq "+zq);
        Console.WriteLine("Nghiệm của phương trình đồng dư là: " + z);
    }
}
