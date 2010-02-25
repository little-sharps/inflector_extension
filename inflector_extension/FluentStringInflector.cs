using inflector_extension.Inflector;

namespace inflector_extension
{
	public class FluentStringInflector
	{
	    private readonly string value;
	    private readonly IInflector inflector;

	    internal FluentStringInflector (string value, IInflector inflector) {
	        this.value = value;
	        this.inflector = inflector;
	    }

        /// <summary>
        /// Pluralizes nouns.
        /// </summary>
        /// <returns>Plural noun.</returns>
        public string Pluralize() {
            return inflector.Pluralize(value);
        }

	    /// <summary>
        /// Singularizes nouns.
        /// </summary>
        /// <returns>Singular noun.</returns>
	    public string Singularize() {
	        return inflector.Singularize(value);
	    }

	    /// <summary>
        /// Converts an underscored or CamelCase word into a sentence.
        /// </summary>
        /// <returns>Titleized word.</returns>
        /// <remarks>
        /// The titleize function converts text like "WelcomePage","welcome_page" or  "welcome page" 
        /// to this "Welcome Page".
        /// </remarks>
	    public string Titleize() {
	        return inflector.Titleize(value);
	    }

	    /// <summary>
        /// Returns a human-readable string from word Returns a human-readable string from word, 
        /// by replacing underscores with a space, and by upper-casing the initial character by default.
        /// </summary>
        /// <returns>human-readable string</returns>
	    public string Humanize() {
	        return inflector.Humanize(value);
	    }

	    /// <summary>
        /// Returns given word as pascalCased
        /// </summary>
        /// <returns>
        /// Converts a word like "send_email" to "SendEmail". 
        /// </returns>
        string Pascalize() {
	        return inflector.Pascalize(value);
	    }

	    /// <summary>
        /// Returns given word as CamelCased
        /// </summary>
        /// <returns>
        /// Converts a word like "send_email" to "sendEmail". 
        /// </returns>
	    public string Camelize() {
	        return inflector.Camelize(value);
	    }

	    public string Underscore() {
	        return inflector.Underscore(value);
	    }

	    public string Capitalize() {
            return inflector.Capitalize(value);
	    }

	    public string Uncapitalize() {
            return inflector.Uncapitalize(value);
	    }

	    public string Ordinalize() {
            return inflector.Ordinalize(value);
	    }

        /// <summary>
        /// Replaces underscores (_) with dashes (-)
        /// </summary>
        /// <returns></returns>
	    public string Dasherize() {
            return inflector.Dasherize(value);
	    }

	    /// <summary>
        /// Transforms a string to its unaccented version.
        /// </summary>
        /// <returns>unaccented version</returns>
	    public string Unaccent() {
            return inflector.Unaccent(value);
	    }
	}
}
