﻿namespace Placely.Data.Models;

public class TwoFactorAuthenticationModel
{
    public required string ManualEntryKey { get; set; }
    public string? QrImageUrl { get; set; }
}