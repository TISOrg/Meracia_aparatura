﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JDLMLab.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    public sealed partial class Devices : global::System.Configuration.ApplicationSettingsBase {
        
        private static Devices defaultInstance = ((Devices)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Devices())));
        
        public static Devices Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM3")]
        public string voltmeterPort {
            get {
                return ((string)(this["voltmeterPort"]));
            }
            set {
                this["voltmeterPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM4")]
        public string ampermeterPort {
            get {
                return ((string)(this["ampermeterPort"]));
            }
            set {
                this["ampermeterPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM5")]
        public string qmsPort {
            get {
                return ((string)(this["qmsPort"]));
            }
            set {
                this["qmsPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM6")]
        public string pr4000Port {
            get {
                return ((string)(this["pr4000Port"]));
            }
            set {
                this["pr4000Port"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int pr4000Freq {
            get {
                return ((int)(this["pr4000Freq"]));
            }
            set {
                this["pr4000Freq"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM7")]
        public string tpg256aPort {
            get {
                return ((string)(this["tpg256aPort"]));
            }
            set {
                this["tpg256aPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int tpg256aFreq {
            get {
                return ((int)(this["tpg256aFreq"]));
            }
            set {
                this["tpg256aFreq"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int tpg256aChannel {
            get {
                return ((int)(this["tpg256aChannel"]));
            }
            set {
                this["tpg256aChannel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM8")]
        public string tempPort {
            get {
                return ((string)(this["tempPort"]));
            }
            set {
                this["tempPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int tempFreq {
            get {
                return ((int)(this["tempFreq"]));
            }
            set {
                this["tempFreq"] = value;
            }
        }
    }
}
