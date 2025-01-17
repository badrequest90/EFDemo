using System.Security.Cryptography;
using System.Text;
using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Options;

public class PasswordHasher
{
    private CryptographyOptions _cryptoOptions;

    public PasswordHasher(IOptions<CryptographyOptions> config)
    {
        _cryptoOptions = config.Value;
    }

    public string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);


        using (var hasher = new Argon2(
            new Argon2Config
            {
                HashLength = _cryptoOptions.HashLength,
                Lanes = _cryptoOptions.Lanes,
                Salt = salt,
                MemoryCost = _cryptoOptions.MemoryCost,
                Threads = _cryptoOptions.Threads,
                Type = _cryptoOptions.Type,
                TimeCost = _cryptoOptions.TimeCost,
                Password = Encoding.UTF8.GetBytes(password)
            }
        ))
        {

            var hash = hasher.Hash();

            return $"{hash}:{Convert.ToBase64String(salt)}";
        }
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        var parts = storedHash.Split(':');
        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid stored hash format");
        }

        var storedHashBytes = Convert.FromBase64String(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);

        using (var hasher = new Argon2(
        new Argon2Config
        {
            HashLength = _cryptoOptions.HashLength,
            Lanes = _cryptoOptions.Lanes,
            Salt = salt,
            MemoryCost = _cryptoOptions.MemoryCost,
            Threads = _cryptoOptions.Threads,
            Type = _cryptoOptions.Type,
            TimeCost = _cryptoOptions.TimeCost,
            Password = Encoding.UTF8.GetBytes(password)
        }
    ))
        {
            // Compute the hash
            var computedHash = hasher.Hash();

            // Compare the computed hash with the stored hash
            return storedHashBytes.SequenceEqual(computedHash.Buffer);
        }
    }
}


public class CryptographyOptions
{
    public Argon2Type Type { get; init; } = Argon2Type.DataIndependentAddressing;
    public int TimeCost { get; init; } = 4;
    public int MemoryCost { get; init; } = 65536;
    public int Lanes { get; init; } = 4;
    public int Threads { get; init; } = 4;
    public int HashLength { get; init; } = 32;
}