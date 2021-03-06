﻿using System;

namespace Palindrome.Models
{
    public interface IPalindrome
    {
        Guid PalindromeId { get; set; }
        string PalindromeValue { get; set; }
        DateTime CreateTS { get; set; }
        DateTime? UpdatedTS { get; set; }
        DateTime? InactivatedTS { get; set; }
    }
}