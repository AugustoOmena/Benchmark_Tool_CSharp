```

BenchmarkDotNet v0.13.12, macOS Ventura 13.4 (22F66) [Darwin 22.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.5 (8.0.524.21615), Arm64 RyuJIT AdvSIMD


```
| Method         | Mean     | Error     | StdDev    |
|--------------- |---------:|----------:|----------:|
| solucaoAtual   | 2.872 ns | 0.0074 ns | 0.0069 ns |
| solucaoAntica  | 1.056 ns | 0.0028 ns | 0.0025 ns |
| solucaoColegas | 5.772 ns | 0.0029 ns | 0.0027 ns |
