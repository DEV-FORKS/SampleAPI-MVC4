﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bucket.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Bucket.Resources.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to User with this email already exists.
        /// </summary>
        internal static string DuplicateEmail {
            get {
                return ResourceManager.GetString("DuplicateEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There was an error confirming friendship.
        /// </summary>
        internal static string ErrorConfirmingFriend {
            get {
                return ResourceManager.GetString("ErrorConfirmingFriend", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There was an error sending friend request.
        /// </summary>
        internal static string ErrorSendingFriendRequest {
            get {
                return ResourceManager.GetString("ErrorSendingFriendRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Congrats, you are now friends.
        /// </summary>
        internal static string FriendConfirmed {
            get {
                return ResourceManager.GetString("FriendConfirmed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Friend request has been sent.
        /// </summary>
        internal static string FriendRequestSent {
            get {
                return ResourceManager.GetString("FriendRequestSent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please provide valid data.
        /// </summary>
        internal static string MissingData {
            get {
                return ResourceManager.GetString("MissingData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more fields are empty.
        /// </summary>
        internal static string MissingFeilds {
            get {
                return ResourceManager.GetString("MissingFeilds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more required fields are empty.
        /// </summary>
        internal static string MissingFields {
            get {
                return ResourceManager.GetString("MissingFields", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing friend details.
        /// </summary>
        internal static string MissingFriendObject {
            get {
                return ResourceManager.GetString("MissingFriendObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login model is required.
        /// </summary>
        internal static string MissingLogOnModel {
            get {
                return ResourceManager.GetString("MissingLogOnModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing Registration Model.
        /// </summary>
        internal static string MissingRegistrationModel {
            get {
                return ResourceManager.GetString("MissingRegistrationModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing search string.
        /// </summary>
        internal static string MissingSearchString {
            get {
                return ResourceManager.GetString("MissingSearchString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Signup model is required.
        /// </summary>
        internal static string MissingSignUpModel {
            get {
                return ResourceManager.GetString("MissingSignUpModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wrong Username Or Password.
        /// </summary>
        internal static string WrongUserNameOrPassword {
            get {
                return ResourceManager.GetString("WrongUserNameOrPassword", resourceCulture);
            }
        }
    }
}
