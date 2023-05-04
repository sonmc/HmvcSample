
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace HmvcSample.Helper
{
    public static class Common
    {
        public const string phone_pattern = @"^\(?([0-9]{3})\)?([0-9]{3})?([0-9]{4})$";
        public const string DEFAULT_PASSWORD = "abc123";
        private static Random random = new Random();
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GetRandom(int from, int to)
        {
            Random rand = new();
            string strGenerated = rand.Next(from, to).ToString();
            return strGenerated;
        }

        public static string GeneratePassword(this string inValue)
        {
            string result = "";
            byte[] data;
            MD5 hashMd5 = new MD5CryptoServiceProvider();
            data = hashMd5.ComputeHash(Encoding.ASCII.GetBytes(inValue.ToCharArray()));

            for (int i = 0; i < data.Length; i++)
            {
                result += data[i].ToString("X2");
            }
            return result;
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new();
            MD5CryptoServiceProvider md5provider = new();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static string GenerateJwtToken(int userId, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static bool IsPhoneNbr(string number)
        {
            if (number != null) return Regex.IsMatch(number, phone_pattern);
            else return false;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }


        public static int GetCurrentTimeUnix()
        {
            return Convert.ToInt32(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        }


        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, DateTimeKind.Utc);
        }

        public static string Encode(string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        public static string Decode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }


        public static string FormatPhoneNumber(string phoneNumber)
        {
            bool isZeroFirst = phoneNumber.StartsWith("0");
            return isZeroFirst ? phoneNumber : phoneNumber.Substring(0);
        }

    }
}
