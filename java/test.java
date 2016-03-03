import java.io.IOException;
import java.nio.ByteBuffer;


public class test {

	/**
	 * @param args
	 */
	public static void main(String[] args)
	{
		try {
			RandomWELL random = new RandomWELL();
			random.srand(7654321);
			byte[] bytes = ByteBuffer.allocate(4).array();
			java.io.FileOutputStream file = new java.io.FileOutputStream("random_java.bin", false);
			for(int i=0; i<1024*1024; ++i){
				float f = random.frand();
				int r = Float.floatToIntBits(f);
				bytes[0] = (byte) ((r>>0)&0xFF);
				bytes[1] = (byte) ((r>>8)&0xFF);
				bytes[2] = (byte) ((r>>16)&0xFF);
				bytes[3] = (byte) ((r>>24)&0xFF);
				file.write(bytes);
			}
			file.flush();
			file.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
