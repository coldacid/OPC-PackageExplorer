﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageExplorer.AddIns.XmlEditor.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PackageExplorer.AddIns.XmlEditor.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;SyntaxDefinition name=&quot;XML&quot; extensions=&quot;.xml&quot;&gt;
        ///	&lt;RuleSets&gt;
        ///
        ///		&lt;RuleSet ignorecase=&quot;false&quot; noescapesequences=&quot;true&quot;&gt;
        ///			&lt;Span name=&quot;XmlComment&quot; bold=&quot;false&quot; italic=&quot;false&quot; color=&quot;Green&quot; stopateol=&quot;false&quot;&gt;
        ///				&lt;Begin&gt;&amp;lt;!--&lt;/Begin&gt;
        ///				&lt;End&gt;--&amp;gt;&lt;/End&gt;
        ///			&lt;/Span&gt;
        ///			&lt;Span name=&quot;XmlCDataSection&quot; bold=&quot;false&quot; italic=&quot;false&quot; color=&quot;Blue&quot; stopateol=&quot;false&quot;&gt;
        ///				&lt;Begin&gt;&amp;lt;![CDATA[&lt;/Begin&gt;
        ///				&lt;End&gt;]]&amp;gt;&lt;/End&gt;
        ///			&lt;/Span&gt;
        ///			&lt;Span name=&quot;XmlDocTypeSection&quot; bold=&quot;false&quot; italic=&quot;false&quot; color=&quot;Blue&quot; sto [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string XmlHighlighting {
            get {
                return ResourceManager.GetString("XmlHighlighting", resourceCulture);
            }
        }
    }
}