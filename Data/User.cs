﻿namespace CHAT_APP.DATA;

[MessagePackObject(true)]
public record User(
    Guid Id,
    string Username,
    string Password_hash
)
{
    public User(string username, string password_hash): this(Guid.NewGuid(), username, password_hash)
    {
    }
}