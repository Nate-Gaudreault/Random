/**
@file RandomWELL.cs
@brief 
@date 2016/03/03 create
@author sakai_takuro
*/

//----------------------------------------------------------------------------
/**
@brief RandomWELL
*/
public class RandomWELL
{
    private const int N = 16;
    private const uint M0 = 0x3F800000U;
    private const uint M1 = 0x007FFFFFU;

    private uint seed_ = 12345678;
    private int index_ = 0;
    private uint[] state_ = new uint[N]
    {
        12345678, 277759943, 96845755, 1019000778, 861248694, 580794835, 399519109, 312451493,
        476862699, 301038016, 229543161, 1467734034, 307044411, 318946322, 857734790, 336374701,
    };

    private byte[] bytes_ = new byte[4];

    public int srand()
    {
    	return (int)seed_;
    }
    
    public void srand(int seed)
    {
        index_ = 0;
        seed_ = (uint)(seed & 0x7FFFFFFF);
        state_[0] = seed_;
        for(uint i = 1; i < N; ++i) {
            state_[i] = (1812433253 * (state_[i-1] ^ (state_[i-1] >> 30)) + i);
            state_[i] &= 0x7FFFFFFF;
        }
    }

    // (0.0 1.0]
    public float frand()
    {
        uint t = rand_();
        t = M0|(t&M1);
        bytes_[0] = (byte)((t>> 0)&0xFF);
        bytes_[1] = (byte)((t>> 8)&0xFF);
        bytes_[2] = (byte)((t>>16)&0xFF);
        bytes_[3] = (byte)((t>>24)&0xFF);
        return System.BitConverter.ToSingle(bytes_, 0) - 0.999999881f;
    }

    // [0.0 1.0)
    public float frand2()
    {
        uint t = rand_();
        t = M0|(t&M1);
        bytes_[0] = (byte)((t>> 0)&0xFF);
        bytes_[1] = (byte)((t>> 8)&0xFF);
        bytes_[2] = (byte)((t>>16)&0xFF);
        bytes_[3] = (byte)((t>>24)&0xFF);
        return System.BitConverter.ToSingle(bytes_, 0) - 1.0f;
    }

    public int rand()
    {
        return (int)(rand_() & 0x7FFFFFFF);
    }

    private uint rand_()
    {
        uint a, b, c, d;

        a = state_[index_];
        c = state_[(index_ + 13) & 15];
        b = a ^ c ^ (a << 16) ^ (c << 15);
        c = state_[(index_ + 9) & 15];
        c ^= c >> 11;
        a = state_[index_] = b ^ c;
        d = a ^ ((a << 5) & 0xDA442D24U);
        index_ = (index_ + 15) & 15;
        a = state_[index_];
        state_[index_] = a ^ b ^ d ^ (a << 2) ^ (b << 18) ^ (c << 28);
        return state_[index_];
    }

    public float Range(float min, float max)
    {
        return (min - max) * frand() + min;
    }

    public int Range(int min, int max)
    {
        return (int)((min - max) * frand2() + min);
    }
int n;
    n = int.Parse(Console.ReadLine());
    for (int i=0; i<=n; i++) {
      double r;
      r = Math.Exp(Math.Log(2)*i);
      Console.Write(Math.Round(r));
      Console.Write(" ");
}
