using System.Collections.Generic;

namespace inflector_extension.Inflector
{
    /// <summary>
    /// Inflector for pluralize and singularize nouns.
    /// It also provides method for helping to create programs 
    /// based on common used naming conventions (like on Ruby on Rails).
    /// </summary>
    /// <remarks>
    /// Inspired from Bermi Ferrer Martinez python implementation.
    /// </remarks>
    public interface IInflector
    {
        /// <summary>
        /// Pluralizes nouns.
        /// </summary>
        /// <param name="word">Singular noun.</param>
        /// <returns>Plural noun.</returns>
        string Pluralize(string word);

        /// <summary>
        /// Singularizes nouns.
        /// </summary>
        /// <param name="word">Plural noun.</param>
        /// <returns>Singular noun.</returns>
        string Singularize(string word);

        /// <summary>
        /// Converts an underscored or CamelCase word into a sentence.
        /// </summary>
        /// <param name="word">sentence to convert.</param>
        /// <returns>Titleized word.</returns>
        /// <remarks>
        /// The titleize function converts text like "WelcomePage","welcome_page" or  "welcome page" 
        /// to this "Welcome Page".
        /// </remarks>
        string Titleize(string word);

        /// <summary>
        /// Returns a human-readable string from word Returns a human-readable string from word, 
        /// by replacing underscores with a space, and by upper-casing the initial character by default.
        /// </summary>
        /// <param name="lowercaseAndUnderscoredWord">string to convert.</param>
        /// <returns>human-readable string</returns>
        string Humanize(string lowercaseAndUnderscoredWord);

        /// <summary>
        /// Returns given word as pascalCased
        /// </summary>
        /// <param name="lowercaseAndUnderscoredWord">string to convert.</param>
        /// <returns>
        /// Converts a word like "send_email" to "SendEmail". 
        /// </returns>
        string Pascalize(string lowercaseAndUnderscoredWord);

        /// <summary>
        /// Returns given word as CamelCased
        /// </summary>
        /// <param name="lowercaseAndUnderscoredWord">string to convert.</param>
        /// <returns>
        /// Converts a word like "send_email" to "sendEmail". 
        /// </returns>
        string Camelize(string lowercaseAndUnderscoredWord);

        string Underscore(string pascalCasedWord);
        string Capitalize(string word);
        string Uncapitalize(string word);
        string Ordinalize(string number);
        string Dasherize(string underscoredWord);

        /// <summary>
        /// Transforms a string to its unaccented version.
        /// </summary>
        /// <param name="word">string to transform.</param>
        /// <returns>unaccented version</returns>
        string Unaccent(string word);

        /// <summary>
        /// Converts a class name to its table name.
        /// </summary>
        /// <param name="className">The class name (unqualified)</param>
        /// <returns>The table name.</returns>
        /// <remarks>
        /// Convetion :
        /// CostomerOrder -> CostomerOrders
        /// Costomer_Order -> Costomer_Orders
        /// </remarks>
        string Tableize(string className);

        /// <summary>
        /// Converts a class name to its ForeignKey column name.
        /// </summary>
        /// <param name="className">The class name (unqualified)</param>
        /// <param name="separateClassNameAndId">true if an underscore is needed before "id"</param>
        /// <returns><paramref name="className"/>, with "id" tacked on at the end.</returns>
        string ForeignKey(string className, bool separateClassNameAndId);

        /// <summary>
        /// Contains numbers 0 - 19
        /// </summary>
        IDictionary<long, string> SimpleNumberCases { get; }

        /// <summary>
        /// Contains the name of the tens place from 20 - 90
        /// </summary>
        IDictionary<long, string> TensNumberCases { get; }

        /// <summary>
        /// Contains the set name for numbers
        /// </summary>
        string[] ScaleNumberWords { get; }

        /// <summary>
        /// Language specific word for 'Hundreds'
        /// </summary>
        string HundredsGroupWord { get; }

        /// <summary>
        /// Language specific word for 'Negative'
        /// </summary>
        string NegativeWord { get; }

        /// <summary>
        /// Language specific word for 'And'
        /// </summary>
        string AndWord { get; }
    }
}