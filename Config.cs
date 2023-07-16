using Exiled.API.Interfaces;

namespace ZombiesConvert
{
     public sealed class Config : IConfig
     {
          public bool IsEnabled { get; set; } = true;
          public bool Debug { get; set; } = true;
          public ushort Chance { get; set; } = 100;
     }
}