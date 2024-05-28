using System;

class Program
{
    static void Main(string[] args)
    {
        // Email addresses for testing
        string[] testEmails = { "basant@teacher.com", "avery.hogan@testmail.com", "charlie.brown@gmail.com", "david@email.gov", "eve.johnson@yahoo.com", "frank@example.com", "testing not an email", "notanemail" };

        foreach (string email in testEmails)
        {
            string obfuscatedEmail = ObfuscateEmail(email);
            if (obfuscatedEmail != null)
            {
                Console.WriteLine($"Obfuscated: {obfuscatedEmail}");
            }
            else
            {
                Console.WriteLine($"Invalid: {email}");
            }
        }
    }

    static string ObfuscateEmail(string email)
    {
        // Validate email
        int atIndex = email.IndexOf('@');
        if (atIndex <= 0 || atIndex == email.Length - 1)
        {
            return null; // Invalid email
        }

        string localPart = email.Substring(0, atIndex);
        string domainPart = email.Substring(atIndex);

        if (localPart.Length > 2)
        {
            string obfuscatedLocalPart = localPart[0] + new string('*', localPart.Length - 2) + localPart[localPart.Length - 1];
            return obfuscatedLocalPart + domainPart;
        }
        else
        {
            return email;
        }
    }
}
