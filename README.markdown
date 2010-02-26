Inflector Extension
======

License
----
Copyright (c) 2010, Brendan Erwin and contributors.
All rights reserved.
 
Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    
  * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
  * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
  * The names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.
 
THIS SOFTWARE IS PROVIDED BY Brendan Erwin and contributors ''AS IS'' AND ANY
EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL Brendan Erwin or contributors BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Some Portions of this code (the good parts) are copied from the [unHAddins project ](http://code.google.com/p/unhaddins/ "unhaddins - Project Hosting on Google Code").

Usage
----
  1. Reference it :: The extension classes are in the global namespace so you don't need any `usings` before they are available.
  2. Use it :: `"string".InflectTo()` or `1.InflectTo()` or, for a real blast: `637849590678.InflectTo().Word`

See the [specs](http://github.com/brendanjerwin/inflector_extension/tree/master/inflector_extension/Specs/) for example usages.

------

_In case you are wondering, that big-ass number turns into:_ `"six hundred and thirty seven billion, eight hundred and forty nine million, five hundred and ninety thousand, six hundred and seventy eight"`