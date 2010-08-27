# -*- encoding: utf-8 -*-
lib = File.expand_path('../lib/', __FILE__)
$:.unshift lib unless $:.include?(lib)

Gem::Specification.new do |s|
  s.name        = "inflector_extension"
  s.version     = "0.0.5"
  s.platform    = Gem::Platform::RUBY
  s.authors     = ["Brendan Erwin"]
  s.email       = ["brendanjerwin@gmail.com"]
  s.homepage    = "http://github.com/littlebits/inflector_extension/"
  s.summary     = "Extension Methods for Inflector in C#"
  s.description = "Provides a nice set of extension methods offering tons of useful inflections of various types. Strings, Ints, Decimals, etc. For example: `37849590678.InflectTo().Phrase` outputs: Six Hundred and Thirty Seven Billion, Eight Hundred and Forty Nine Million, Five Hundred and Ninety Thousand, Six Hundred and Seventy Eight"

  s.required_rubygems_version = ">= 1.3.5"

  s.files        = Dir.glob("{external_source}/**/*") << "inflector_extension/bin/Release/inflector_extension.dll" << "README.markdown"
  s.require_path = 'inflector_extension/bin/Release'
  
end