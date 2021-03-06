﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RESTfulChat.Database
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="KMSupportChat")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertChat(Chat instance);
    partial void UpdateChat(Chat instance);
    partial void DeleteChat(Chat instance);
    partial void InsertChatUser(ChatUser instance);
    partial void UpdateChatUser(ChatUser instance);
    partial void DeleteChatUser(ChatUser instance);
    partial void InsertMessage(Message instance);
    partial void UpdateMessage(Message instance);
    partial void DeleteMessage(Message instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::RESTfulChat.Database.Properties.Settings.Default.KMSupportChatConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Chat> Chats
		{
			get
			{
				return this.GetTable<Chat>();
			}
		}
		
		public System.Data.Linq.Table<ChatUser> ChatUsers
		{
			get
			{
				return this.GetTable<ChatUser>();
			}
		}
		
		public System.Data.Linq.Table<Message> Messages
		{
			get
			{
				return this.GetTable<Message>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Chat")]
	public partial class Chat : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private EntitySet<ChatUser> _ChatUsers;
		
		private EntitySet<Message> _Messages;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Chat()
		{
			this._ChatUsers = new EntitySet<ChatUser>(new Action<ChatUser>(this.attach_ChatUsers), new Action<ChatUser>(this.detach_ChatUsers));
			this._Messages = new EntitySet<Message>(new Action<Message>(this.attach_Messages), new Action<Message>(this.detach_Messages));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Chat_ChatUser", Storage="_ChatUsers", ThisKey="Id", OtherKey="ChatId")]
		public EntitySet<ChatUser> ChatUsers
		{
			get
			{
				return this._ChatUsers;
			}
			set
			{
				this._ChatUsers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Chat_Message", Storage="_Messages", ThisKey="Id", OtherKey="ChatId")]
		public EntitySet<Message> Messages
		{
			get
			{
				return this._Messages;
			}
			set
			{
				this._Messages.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChatUsers(ChatUser entity)
		{
			this.SendPropertyChanging();
			entity.Chat = this;
		}
		
		private void detach_ChatUsers(ChatUser entity)
		{
			this.SendPropertyChanging();
			entity.Chat = null;
		}
		
		private void attach_Messages(Message entity)
		{
			this.SendPropertyChanging();
			entity.Chat = this;
		}
		
		private void detach_Messages(Message entity)
		{
			this.SendPropertyChanging();
			entity.Chat = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ChatUser")]
	public partial class ChatUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ChatId;
		
		private int _UserId;
		
		private EntityRef<Chat> _Chat;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnChatIdChanging(int value);
    partial void OnChatIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    #endregion
		
		public ChatUser()
		{
			this._Chat = default(EntityRef<Chat>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChatId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ChatId
		{
			get
			{
				return this._ChatId;
			}
			set
			{
				if ((this._ChatId != value))
				{
					if (this._Chat.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnChatIdChanging(value);
					this.SendPropertyChanging();
					this._ChatId = value;
					this.SendPropertyChanged("ChatId");
					this.OnChatIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Chat_ChatUser", Storage="_Chat", ThisKey="ChatId", OtherKey="Id", IsForeignKey=true)]
		public Chat Chat
		{
			get
			{
				return this._Chat.Entity;
			}
			set
			{
				Chat previousValue = this._Chat.Entity;
				if (((previousValue != value) 
							|| (this._Chat.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Chat.Entity = null;
						previousValue.ChatUsers.Remove(this);
					}
					this._Chat.Entity = value;
					if ((value != null))
					{
						value.ChatUsers.Add(this);
						this._ChatId = value.Id;
					}
					else
					{
						this._ChatId = default(int);
					}
					this.SendPropertyChanged("Chat");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ChatUser", Storage="_User", ThisKey="UserId", OtherKey="Id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.ChatUsers.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.ChatUsers.Add(this);
						this._UserId = value.Id;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Message")]
	public partial class Message : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ChatId;
		
		private System.DateTime _CreatedAt;
		
		private int _FromUserId;
		
		private string _Text;
		
		private EntityRef<Chat> _Chat;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnChatIdChanging(int value);
    partial void OnChatIdChanged();
    partial void OnCreatedAtChanging(System.DateTime value);
    partial void OnCreatedAtChanged();
    partial void OnFromUserIdChanging(int value);
    partial void OnFromUserIdChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    #endregion
		
		public Message()
		{
			this._Chat = default(EntityRef<Chat>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChatId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ChatId
		{
			get
			{
				return this._ChatId;
			}
			set
			{
				if ((this._ChatId != value))
				{
					if (this._Chat.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnChatIdChanging(value);
					this.SendPropertyChanging();
					this._ChatId = value;
					this.SendPropertyChanged("ChatId");
					this.OnChatIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedAt", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
		public System.DateTime CreatedAt
		{
			get
			{
				return this._CreatedAt;
			}
			set
			{
				if ((this._CreatedAt != value))
				{
					this.OnCreatedAtChanging(value);
					this.SendPropertyChanging();
					this._CreatedAt = value;
					this.SendPropertyChanged("CreatedAt");
					this.OnCreatedAtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromUserId", DbType="Int NOT NULL")]
		public int FromUserId
		{
			get
			{
				return this._FromUserId;
			}
			set
			{
				if ((this._FromUserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFromUserIdChanging(value);
					this.SendPropertyChanging();
					this._FromUserId = value;
					this.SendPropertyChanged("FromUserId");
					this.OnFromUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Chat_Message", Storage="_Chat", ThisKey="ChatId", OtherKey="Id", IsForeignKey=true)]
		public Chat Chat
		{
			get
			{
				return this._Chat.Entity;
			}
			set
			{
				Chat previousValue = this._Chat.Entity;
				if (((previousValue != value) 
							|| (this._Chat.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Chat.Entity = null;
						previousValue.Messages.Remove(this);
					}
					this._Chat.Entity = value;
					if ((value != null))
					{
						value.Messages.Add(this);
						this._ChatId = value.Id;
					}
					else
					{
						this._ChatId = default(int);
					}
					this.SendPropertyChanged("Chat");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Message", Storage="_User", ThisKey="FromUserId", OtherKey="Id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Messages.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Messages.Add(this);
						this._FromUserId = value.Id;
					}
					else
					{
						this._FromUserId = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FirstName;
		
		private string _LastName;
		
		private System.Nullable<System.DateTime> _Birthdate;
		
		private string _Email;
		
		private string _Company;
		
		private EntitySet<ChatUser> _ChatUsers;
		
		private EntitySet<Message> _Messages;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnBirthdateChanging(System.Nullable<System.DateTime> value);
    partial void OnBirthdateChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnCompanyChanging(string value);
    partial void OnCompanyChanged();
    #endregion
		
		public User()
		{
			this._ChatUsers = new EntitySet<ChatUser>(new Action<ChatUser>(this.attach_ChatUsers), new Action<ChatUser>(this.detach_ChatUsers));
			this._Messages = new EntitySet<Message>(new Action<Message>(this.attach_Messages), new Action<Message>(this.detach_Messages));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(MAX)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(MAX)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthdate", DbType="Date")]
		public System.Nullable<System.DateTime> Birthdate
		{
			get
			{
				return this._Birthdate;
			}
			set
			{
				if ((this._Birthdate != value))
				{
					this.OnBirthdateChanging(value);
					this.SendPropertyChanging();
					this._Birthdate = value;
					this.SendPropertyChanged("Birthdate");
					this.OnBirthdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(MAX)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Company", DbType="NVarChar(MAX)")]
		public string Company
		{
			get
			{
				return this._Company;
			}
			set
			{
				if ((this._Company != value))
				{
					this.OnCompanyChanging(value);
					this.SendPropertyChanging();
					this._Company = value;
					this.SendPropertyChanged("Company");
					this.OnCompanyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ChatUser", Storage="_ChatUsers", ThisKey="Id", OtherKey="UserId")]
		public EntitySet<ChatUser> ChatUsers
		{
			get
			{
				return this._ChatUsers;
			}
			set
			{
				this._ChatUsers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Message", Storage="_Messages", ThisKey="Id", OtherKey="FromUserId")]
		public EntitySet<Message> Messages
		{
			get
			{
				return this._Messages;
			}
			set
			{
				this._Messages.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChatUsers(ChatUser entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_ChatUsers(ChatUser entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
		
		private void attach_Messages(Message entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Messages(Message entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
}
#pragma warning restore 1591
