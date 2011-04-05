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
	    /// <value>Plural noun.</value>
	    public string Pluralized {
	        get { return this.inflector.Pluralize(this.value); }
	    }

	    /// <summary>
	    /// Singularizes nouns.
	    /// </summary>
	    /// <value>Singular noun.</value>
	    public string Singularized {
	        get { return this.inflector.Singularize(this.value); }
	    }

	    /// <summary>
	    /// Converts an underscored or CamelCase word into a sentence.
	    /// </summary>
	    /// <value>Titleized word.</value>
	    /// <remarks>
	    /// The titleize function converts text like "WelcomePage","welcome_page" or  "welcome page" 
	    /// to this "Welcome Page".
	    /// </remarks>
	    public string Titleized {
	        get { return this.inflector.Titleize(this.value); }
	    }

	    /// <summary>
	    /// Returns a human-readable string from word Returns a human-readable string from word, 
	    /// by replacing underscores with a space, and by upper-casing the initial character by default.
	    /// </summary>
	    /// <value>human-readable string</value>
	    public string Humanized {
	        get { return this.inflector.Humanize(this.value); }
	    }

	    /// <summary>
	    /// Returns given word as pascalCased
	    /// </summary>
	    /// <value>
	    /// 	Converts a word like &quot;send_email&quot; to &quot;SendEmail&quot;. 
	    /// </value>
	    public string Pascalized {
	        get { return this.inflector.Pascalize(this.value); }
	    }

	    /// <summary>
	    /// Returns given word as CamelCased
	    /// </summary>
	    /// <value>
	    /// 	Converts a word like &quot;send_email&quot; to &quot;sendEmail&quot;. 
	    /// </value>
	    public string Camelized {
	        get { return this.inflector.Camelize(this.value); }
	    }

	    public string Underscored {
	        get { return this.inflector.Underscore(this.value); }
	    }

	    public string Capitalized {
	        get { return this.inflector.Capitalize(this.value); }
	    }

	    public string Uncapitalized {
	        get { return this.inflector.Uncapitalize(this.value); }
	    }

	    public string Ordinalized {
	        get { return this.inflector.Ordinalize(this.value); }
	    }

	    /// <summary>
	    /// Replaces underscores (_) with dashes (-)
	    /// </summary>
	    /// <value></value>
	    public string Dasherized {
	        get { return this.inflector.Dasherize(this.value); }
	    }

	    /// <summary>
	    /// Transforms a string to its unaccented version.
	    /// </summary>
	    /// <value>unaccented version</value>
	    public string Unaccented {
	        get { return this.inflector.Unaccent(this.value); }
	    }
	}
}
