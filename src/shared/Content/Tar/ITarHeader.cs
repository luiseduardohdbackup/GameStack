using System;

namespace GameStack.Content
{
    public interface ITarHeader
    {
        string FileName { get; set; }
        int Mode { get; set; }
        int UserId { get; set; }
        string UserName { get; set; }
        int GroupId { get; set; }
        string GroupName { get; set; }
        long SizeInBytes { get; set; }
        DateTime LastModification { get; set; }
        int HeaderSize { get; }
    }
}