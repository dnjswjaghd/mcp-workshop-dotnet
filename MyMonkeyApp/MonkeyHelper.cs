using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// 원숭이 데이터 관리를 위한 헬퍼 클래스
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static int randomMonkeyAccessCount = 0;

    /// <summary>
    /// 모든 원숭이 목록을 비동기로 가져옵니다.
    /// MCP 서버에서 데이터를 받아옵니다.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys != null)
            return monkeys;

        // MCP 서버에서 데이터 가져오기 (예시)
        monkeys = await MonkeyMcpClient.FetchMonkeysAsync();
        return monkeys;
    }

    /// <summary>
    /// 이름으로 원숭이 찾기
    /// </summary>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        var list = await GetMonkeysAsync();
        return list.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 랜덤 원숭이 반환 및 접근 횟수 증가
    /// </summary>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var list = await GetMonkeysAsync();
        if (list.Count == 0) return null;
        randomMonkeyAccessCount++;
        var rnd = new Random();
        return list[rnd.Next(list.Count)];
    }

    /// <summary>
    /// 랜덤 원숭이 접근 횟수 반환
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;
}

/// <summary>
/// MCP 서버와 통신하는 클라이언트 예시 (실제 구현 필요)
/// </summary>
public static class MonkeyMcpClient
{
    public static async Task<List<Monkey>> FetchMonkeysAsync()
    {
        // 실제 MCP 서버 API 호출 코드로 대체 필요
        await Task.Delay(100); // 네트워크 지연 시뮬레이션
        return new List<Monkey> {
            // 예시 데이터 (실제 데이터는 MCP 서버에서 받아옴)
            new Monkey { Name = "Baboon", Location = "Africa & Asia", Details = "Baboons are African and Arabian Old World monkeys...", Image = "", Population = 10000, Latitude = -8.783195, Longitude = 34.508523 },
            // ... 추가 데이터 ...
        };
    }
}
