// Photon Networking ���� �����ϴ� �⺻ ��Ʈ��ũ ����� ����
using ExitGames.Client.Photon;
using UnityEngine;

// ����(Color)�� ��ũ��ũ ���ۿ����� ��ȯ�ϴ� Ŭ����
public class ColorSerialization
{
    // Color�� float �� 4�� (����) (r,g,b,a)�� byte ���·� ������ �ӽ� �޸� ����
    // 4 byte * 4�� = 16 byte
    private static byte[] colorMemory = new byte[4 * 4];

    // Unity�� Color�� byte[] �� ��ȯ�Ͽ� ��Ʈ��ũ ��Ʈ���� ��� (����ȭ)
    public static short SerializeColor(StreamBuffer outStream, object targetObject)
    {
        // object Ÿ������ ���� �����͸� Color�� ��ȯ
        Color color = (Color)targetObject;

        // (��Ƽ) ������ ȯ�濡�� colorMemory �迭�� ���ÿ� �������� ���ϵ��� ���: lock
        lock (colorMemory)
        {
            byte[] bytes = colorMemory; // �ӽ� ����Ʈ �迭
            int index = 0; // �迭�� ���� �� ��ġ �ε���

            // �� float ���� ����Ʈ �迭�� ������� ����ȭ
            Protocol.Serialize(color.r, bytes, ref index);
            Protocol.Serialize(color.g, bytes, ref index);
            Protocol.Serialize(color.b, bytes, ref index);
            Protocol.Serialize(color.a, bytes, ref index);

            // ��ȯ�� ����Ʈ �����͸� ��Ʈ��Ʈ ��Ʈ���� ���
            outStream.Write(bytes, 0, 4 * 4); // 16byte ���
        }

        return 4 * 4; // �� ����Ʈ ��(16)�� ��ȯ
    }

    // byte[] ���·� ���� ��Ʈ��ũ �����͸� Color�� ���� (������ȭ)
    public static object DeserializeColor(StreamBuffer inStream, short length)
    {
        Color color = new Color(); // ������ Color ��ü ����

        // (��Ƽ)������ ȯ�濡�� colorMemory �迭�� ���ÿ� �������� ���ϵ��� ���: lock
        lock (colorMemory)
        {
            // ��Ʈ��ũ���� 16����Ʈ �����͸� �о colorMemory �迭�� ����
            inStream.Read(colorMemory, 0, 4 * 4);
            int index = 0; // �迭���� ���� ���� ��ġ �ε���

            // ������� float ���� �����Ͽ� color ��ü�� ����
            Protocol.Deserialize(out color.r, colorMemory, ref index);
            Protocol.Deserialize(out color.g, colorMemory, ref index);
            Protocol.Deserialize(out color.b, colorMemory, ref index);
            Protocol.Deserialize(out color.a, colorMemory, ref index);
        }

        // ���������� ������ Color ��ü ��ȯ
        return color;
    }
}
