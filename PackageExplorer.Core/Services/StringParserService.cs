#region [===== Using =====]
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
#endregion

namespace PackageExplorer.Core.Services
{
    /// <summary>
    /// A class for parsing token strings. 
    /// </summary>
    /// <remarks>Replacement tokens can be added by 
    /// registering a <see>StringParserService.TokenReplacementCallback</see>.</remarks>
    public class StringParserService : ServiceBase
    {
        #region [===== Delegates =====]
        /// <summary>
        /// Defines a callback method that can be used to register a new 
        /// token replacing class. A callback is registerd based on a
        /// token name. The callback is provided with the token data. A common
        /// token looks like DATE:DDMMYYYY, where DATE is the token name, and 
        /// DDMMYYYY the token specific data.
        /// </summary>
        /// <param name="tokenData">The token data.</param>
        /// <returns>The replaced data.</returns>
        public delegate string TokenReplacementCallback(string tokenData);
        #endregion
        
        #region [===== Static fields =====]
        static readonly Regex _tokenMatchingRegex = null;
        #endregion

        #region [===== Instance fields =====]
        Dictionary<string, TokenReplacementCallback> _replacements = null;
        #endregion

        #region [===== Constructors =====]
        static StringParserService()
        {
            _tokenMatchingRegex = new Regex("{([A-Za-z]+)((: *?)([A-Za-z0-9_ ,.]+))?}");
        }

        internal StringParserService()
        {
            _replacements = new Dictionary<string, TokenReplacementCallback>();
        }
        #endregion

        #region [===== Public instance methods =====]
        /// <summary>
        /// Adds a new token replacer to the string parser.
        /// </summary>
        /// <param name="tokenName">The name of the token that
        /// the replacement callback can replace.</param>
        /// <param name="callback">The callback method which performs
        /// the replacement.</param>
        /// <exception cref="ArgumentException">Thrown when the 
        /// <see cref="tokenName"/> is already registered.</exception>
        public void AddReplacementCallback(string tokenName,
            TokenReplacementCallback callback)
        {
            if (_replacements.ContainsKey(tokenName))
            {
                throw new ArgumentException("Duplicate token");
            }
            _replacements.Add(tokenName, callback);
        }

        /// <summary>
        /// Parses a token string.
        /// </summary>
        /// <param name="tokenString">The token string to parse.</param>
        /// <returns>The parsed token string.</returns>
        public string Parse(string tokenString)
        {
            string parsedValue = null;
            if (String.IsNullOrEmpty(tokenString) == false)
            {
                parsedValue = _tokenMatchingRegex.Replace(
                    tokenString,
                    delegate(Match match)
                    {
                        string replacedValue = null;
                        string tokenName = match.Groups[1].Value;
                        string tokenData = match.Groups[4].Value;

                        if (_replacements.ContainsKey(tokenName))
                        {
                            TokenReplacementCallback callback =
                                _replacements[tokenName];
                            replacedValue = callback(tokenData);
                        }
                        return replacedValue;
                    });
            }
            return parsedValue;
        }
        
        /// <summary>
        /// Parses a token string.
        /// </summary>
        /// <param name="tokenString">The token string to parse.</param>
        /// <param name="formatTokens">Extra parameters used to format the string.</param>
        /// <returns>The parsed token string.</returns>
        public string Parse(string tokenString, params object[] formatTokens)
        {
            return String.Format(Parse(tokenString), formatTokens);
        }
        #endregion

        #region [===== Protected instance methods =====]
        /// <summary>
        /// Performs the operations required for initializing a service.
        /// </summary>
        /// <remarks>This registers the RES, TIME and DATE tokens.</remarks>
        public override void InitializeService()
        {
            _replacements.Add("RES",
                delegate(string tokenData)
                {
                    ResourceService resourceService = ServiceManager.GetService<ResourceService>();
                    string value = resourceService.GetString(tokenData);
                    return Parse(value);
                });
            _replacements.Add("TIME",
                delegate(string tokenData)
                {
                    DateTime now = DateTime.Now;
                    string time = null;
                    if (String.IsNullOrEmpty(tokenData) == false)
                    {
                        time = now.ToString(tokenData);
                    }
                    else
                    {
                        time = now.ToShortTimeString();
                    }
                    return time;
                });
            _replacements.Add("DATE",
                delegate(string tokenData)
                {
                    DateTime now = DateTime.Now;
                    string date = null;
                    if (String.IsNullOrEmpty(tokenData) == false)
                    {
                        date = now.ToString(tokenData);
                    }
                    else
                    {
                        date = now.ToShortDateString();
                    }
                    return date;
                });
            base.InitializeService();
        }
        #endregion
    }
}
