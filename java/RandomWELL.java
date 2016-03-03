
public class RandomWELL
{
	private static final int N = 16;
    private static final int M0 = 0x3F800000;
    private static final int M1 = 0x007FFFFF;

    private static int seed_ = 12345678;
    private static int index_ = 0;
    private static int[] state_ = new int[]
    {
        12345678, 277759943, 96845755, 1019000778, 861248694, 580794835, 399519109, 312451493,
        476862699, 301038016, 229543161, 1467734034, 307044411, 318946322, 857734790, 336374701,
    };
    
    public int srand()
    {
    	return seed_;
    }
    
    public void srand(int seed)
    {
    	seed_ = seed;
    	index_ = 0;
    	state_[0] = seed_ & 0x7FFFFFFF;
        for(int i = 1; i < N; ++i) {
            state_[i] = (1812433253 * (state_[i-1] ^ (state_[i-1] >> 30)) + i);
            state_[i] &= 0x7FFFFFFF;
        }
    }
    
    // (0.0 1.0]
	public float frand()
	{
		int t = rand_();
		t = M0 | (t & M1);
		return Float.intBitsToFloat(t) - 0.999999881f;
	}

	// [0.0 1.0)
	public float frand2()
	{
		int t = rand_();
		t = M0 | (t & M1);
		return Float.intBitsToFloat(t) - 1.0f;
	}

    public int rand()
    {
        return (int)(rand_() & 0x7FFFFFFF);
    }

    private int rand_()
    {
    	int a, b, c, d;

        a = state_[index_];
        c = state_[(index_ + 13) & 15];
        b = a ^ c ^ (a << 16) ^ (c << 15);
        c = state_[(index_ + 9) & 15];
        c ^= c >>> 11;
        a = state_[index_] = b ^ c;
        d = a ^ ((a << 5) & 0xDA442D24);
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
}
