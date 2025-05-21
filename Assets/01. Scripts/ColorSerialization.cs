// Photon Networking 에서 제공하는 기본 네트워크 기능을 제공
using ExitGames.Client.Photon;
using UnityEngine;

// 색상(Color)을 네크워크 전송용으로 변환하는 클래스
public class ColorSerialization
{
    // Color의 float 값 4개 (원소) (r,g,b,a)를 byte 형태로 저장할 임시 메모리 공간
    // 4 byte * 4개 = 16 byte
    private static byte[] colorMemory = new byte[4 * 4];

    // Unity의 Color를 byte[] 로 변환하여 네트워크 스트림에 기록 (직렬화)
    public static short SerializeColor(StreamBuffer outStream, object targetObject)
    {
        // object 타입으로 들어온 데이터를 Color로 변환
        Color color = (Color)targetObject;

        // (멀티) 쓰레드 환경에서 colorMemory 배열을 동시에 접근하지 못하도록 잠금: lock
        lock (colorMemory)
        {
            byte[] bytes = colorMemory; // 임시 바이트 배열
            int index = 0; // 배열에 값을 쓸 위치 인덱스

            // 각 float 값을 바이트 배열에 순서대로 직렬화
            Protocol.Serialize(color.r, bytes, ref index);
            Protocol.Serialize(color.g, bytes, ref index);
            Protocol.Serialize(color.b, bytes, ref index);
            Protocol.Serialize(color.a, bytes, ref index);

            // 변환된 바이트 데이터를 네트워트 스트림에 기록
            outStream.Write(bytes, 0, 4 * 4); // 16byte 기록
        }

        return 4 * 4; // 총 바이트 수(16)을 반환
    }

    // byte[] 형태로 받은 네트워크 데이터를 Color로 복원 (역직렬화)
    public static object DeserializeColor(StreamBuffer inStream, short length)
    {
        Color color = new Color(); // 복원할 Color 객체 생성

        // (멀티)쓰레드 환경에서 colorMemory 배열을 동시에 접근하지 못하도록 잠금: lock
        lock (colorMemory)
        {
            // 네트워크에서 16바이트 데이터를 읽어서 colorMemory 배열에 저장
            inStream.Read(colorMemory, 0, 4 * 4);
            int index = 0; // 배열에서 값을 읽을 위치 인덱스

            // 순서대로 float 값을 복원하여 color 객체에 저장
            Protocol.Deserialize(out color.r, colorMemory, ref index);
            Protocol.Deserialize(out color.g, colorMemory, ref index);
            Protocol.Deserialize(out color.b, colorMemory, ref index);
            Protocol.Deserialize(out color.a, colorMemory, ref index);
        }

        // 최종적으로 복원된 Color 객체 반환
        return color;
    }
}
