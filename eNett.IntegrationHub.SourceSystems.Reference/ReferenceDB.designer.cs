﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eNett.IntegrationHub.SourceSystems.Reference
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Reference")]
	public partial class ReferenceDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertClientType(ClientType instance);
    partial void UpdateClientType(ClientType instance);
    partial void DeleteClientType(ClientType instance);
    partial void InsertCountry(Country instance);
    partial void UpdateCountry(Country instance);
    partial void DeleteCountry(Country instance);
    #endregion
		
		public ReferenceDBDataContext() : 
				base(global::eNett.IntegrationHub.SourceSystems.Reference.Properties.Settings.Default.ReferenceConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ReferenceDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReferenceDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReferenceDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReferenceDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ClientType> ClientTypes
		{
			get
			{
				return this.GetTable<ClientType>();
			}
		}
		
		public System.Data.Linq.Table<Country> Countries
		{
			get
			{
				return this.GetTable<Country>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ClientType")]
	public partial class ClientType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ClientTypeID;
		
		private string _ClientTypeName;
		
		private bool _Active;
		
		private string _ClientTypeDesc;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnClientTypeIDChanging(int value);
    partial void OnClientTypeIDChanged();
    partial void OnClientTypeNameChanging(string value);
    partial void OnClientTypeNameChanged();
    partial void OnActiveChanging(bool value);
    partial void OnActiveChanged();
    partial void OnClientTypeDescChanging(string value);
    partial void OnClientTypeDescChanged();
    #endregion
		
		public ClientType()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClientTypeID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ClientTypeID
		{
			get
			{
				return this._ClientTypeID;
			}
			set
			{
				if ((this._ClientTypeID != value))
				{
					this.OnClientTypeIDChanging(value);
					this.SendPropertyChanging();
					this._ClientTypeID = value;
					this.SendPropertyChanged("ClientTypeID");
					this.OnClientTypeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="ClientType", Storage="_ClientTypeName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ClientTypeName
		{
			get
			{
				return this._ClientTypeName;
			}
			set
			{
				if ((this._ClientTypeName != value))
				{
					this.OnClientTypeNameChanging(value);
					this.SendPropertyChanging();
					this._ClientTypeName = value;
					this.SendPropertyChanged("ClientTypeName");
					this.OnClientTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit NOT NULL")]
		public bool Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClientTypeDesc", DbType="VarChar(100)")]
		public string ClientTypeDesc
		{
			get
			{
				return this._ClientTypeDesc;
			}
			set
			{
				if ((this._ClientTypeDesc != value))
				{
					this.OnClientTypeDescChanging(value);
					this.SendPropertyChanging();
					this._ClientTypeDesc = value;
					this.SendPropertyChanged("ClientTypeDesc");
					this.OnClientTypeDescChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Country")]
	public partial class Country : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CountryID;
		
		private string _CountryCode2;
		
		private string _CountryCode3;
		
		private string _CountryName;
		
		private string _PhonePrefix;
		
		private System.Nullable<int> _DefaultCurrencyID;
		
		private System.Nullable<int> _DefaultRegionID;
		
		private string _Locale;
		
		private bool _Active;
		
		private string _TaxType;
		
		private string _TimeZone;
		
		private System.Nullable<short> _TimeOffset;
		
		private System.Nullable<int> _TestECN;
		
		private decimal _TestAmount;
		
		private System.Nullable<System.DateTime> _DebitCutOffTime;
		
		private System.Nullable<int> _DefaultTimeZoneID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCountryIDChanging(int value);
    partial void OnCountryIDChanged();
    partial void OnCountryCode2Changing(string value);
    partial void OnCountryCode2Changed();
    partial void OnCountryCode3Changing(string value);
    partial void OnCountryCode3Changed();
    partial void OnCountryNameChanging(string value);
    partial void OnCountryNameChanged();
    partial void OnPhonePrefixChanging(string value);
    partial void OnPhonePrefixChanged();
    partial void OnDefaultCurrencyIDChanging(System.Nullable<int> value);
    partial void OnDefaultCurrencyIDChanged();
    partial void OnDefaultRegionIDChanging(System.Nullable<int> value);
    partial void OnDefaultRegionIDChanged();
    partial void OnLocaleChanging(string value);
    partial void OnLocaleChanged();
    partial void OnActiveChanging(bool value);
    partial void OnActiveChanged();
    partial void OnTaxTypeChanging(string value);
    partial void OnTaxTypeChanged();
    partial void OnTimeZoneChanging(string value);
    partial void OnTimeZoneChanged();
    partial void OnTimeOffsetChanging(System.Nullable<short> value);
    partial void OnTimeOffsetChanged();
    partial void OnTestECNChanging(System.Nullable<int> value);
    partial void OnTestECNChanged();
    partial void OnTestAmountChanging(decimal value);
    partial void OnTestAmountChanged();
    partial void OnDebitCutOffTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnDebitCutOffTimeChanged();
    partial void OnDefaultTimeZoneIDChanging(System.Nullable<int> value);
    partial void OnDefaultTimeZoneIDChanged();
    #endregion
		
		public Country()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CountryID
		{
			get
			{
				return this._CountryID;
			}
			set
			{
				if ((this._CountryID != value))
				{
					this.OnCountryIDChanging(value);
					this.SendPropertyChanging();
					this._CountryID = value;
					this.SendPropertyChanged("CountryID");
					this.OnCountryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryCode2", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string CountryCode2
		{
			get
			{
				return this._CountryCode2;
			}
			set
			{
				if ((this._CountryCode2 != value))
				{
					this.OnCountryCode2Changing(value);
					this.SendPropertyChanging();
					this._CountryCode2 = value;
					this.SendPropertyChanged("CountryCode2");
					this.OnCountryCode2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryCode3", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string CountryCode3
		{
			get
			{
				return this._CountryCode3;
			}
			set
			{
				if ((this._CountryCode3 != value))
				{
					this.OnCountryCode3Changing(value);
					this.SendPropertyChanging();
					this._CountryCode3 = value;
					this.SendPropertyChanged("CountryCode3");
					this.OnCountryCode3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CountryName
		{
			get
			{
				return this._CountryName;
			}
			set
			{
				if ((this._CountryName != value))
				{
					this.OnCountryNameChanging(value);
					this.SendPropertyChanging();
					this._CountryName = value;
					this.SendPropertyChanged("CountryName");
					this.OnCountryNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhonePrefix", DbType="VarChar(5)")]
		public string PhonePrefix
		{
			get
			{
				return this._PhonePrefix;
			}
			set
			{
				if ((this._PhonePrefix != value))
				{
					this.OnPhonePrefixChanging(value);
					this.SendPropertyChanging();
					this._PhonePrefix = value;
					this.SendPropertyChanged("PhonePrefix");
					this.OnPhonePrefixChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DefaultCurrencyID", DbType="Int")]
		public System.Nullable<int> DefaultCurrencyID
		{
			get
			{
				return this._DefaultCurrencyID;
			}
			set
			{
				if ((this._DefaultCurrencyID != value))
				{
					this.OnDefaultCurrencyIDChanging(value);
					this.SendPropertyChanging();
					this._DefaultCurrencyID = value;
					this.SendPropertyChanged("DefaultCurrencyID");
					this.OnDefaultCurrencyIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DefaultRegionID", DbType="Int")]
		public System.Nullable<int> DefaultRegionID
		{
			get
			{
				return this._DefaultRegionID;
			}
			set
			{
				if ((this._DefaultRegionID != value))
				{
					this.OnDefaultRegionIDChanging(value);
					this.SendPropertyChanging();
					this._DefaultRegionID = value;
					this.SendPropertyChanged("DefaultRegionID");
					this.OnDefaultRegionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Locale", DbType="VarChar(10)")]
		public string Locale
		{
			get
			{
				return this._Locale;
			}
			set
			{
				if ((this._Locale != value))
				{
					this.OnLocaleChanging(value);
					this.SendPropertyChanging();
					this._Locale = value;
					this.SendPropertyChanged("Locale");
					this.OnLocaleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit NOT NULL")]
		public bool Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaxType", DbType="VarChar(20)")]
		public string TaxType
		{
			get
			{
				return this._TaxType;
			}
			set
			{
				if ((this._TaxType != value))
				{
					this.OnTaxTypeChanging(value);
					this.SendPropertyChanging();
					this._TaxType = value;
					this.SendPropertyChanged("TaxType");
					this.OnTaxTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeZone", DbType="VarChar(20)")]
		public string TimeZone
		{
			get
			{
				return this._TimeZone;
			}
			set
			{
				if ((this._TimeZone != value))
				{
					this.OnTimeZoneChanging(value);
					this.SendPropertyChanging();
					this._TimeZone = value;
					this.SendPropertyChanged("TimeZone");
					this.OnTimeZoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeOffset", DbType="SmallInt")]
		public System.Nullable<short> TimeOffset
		{
			get
			{
				return this._TimeOffset;
			}
			set
			{
				if ((this._TimeOffset != value))
				{
					this.OnTimeOffsetChanging(value);
					this.SendPropertyChanging();
					this._TimeOffset = value;
					this.SendPropertyChanged("TimeOffset");
					this.OnTimeOffsetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TestECN", DbType="Int")]
		public System.Nullable<int> TestECN
		{
			get
			{
				return this._TestECN;
			}
			set
			{
				if ((this._TestECN != value))
				{
					this.OnTestECNChanging(value);
					this.SendPropertyChanging();
					this._TestECN = value;
					this.SendPropertyChanged("TestECN");
					this.OnTestECNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TestAmount", DbType="Decimal(18,2) NOT NULL")]
		public decimal TestAmount
		{
			get
			{
				return this._TestAmount;
			}
			set
			{
				if ((this._TestAmount != value))
				{
					this.OnTestAmountChanging(value);
					this.SendPropertyChanging();
					this._TestAmount = value;
					this.SendPropertyChanged("TestAmount");
					this.OnTestAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DebitCutOffTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> DebitCutOffTime
		{
			get
			{
				return this._DebitCutOffTime;
			}
			set
			{
				if ((this._DebitCutOffTime != value))
				{
					this.OnDebitCutOffTimeChanging(value);
					this.SendPropertyChanging();
					this._DebitCutOffTime = value;
					this.SendPropertyChanged("DebitCutOffTime");
					this.OnDebitCutOffTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DefaultTimeZoneID", DbType="Int")]
		public System.Nullable<int> DefaultTimeZoneID
		{
			get
			{
				return this._DefaultTimeZoneID;
			}
			set
			{
				if ((this._DefaultTimeZoneID != value))
				{
					this.OnDefaultTimeZoneIDChanging(value);
					this.SendPropertyChanging();
					this._DefaultTimeZoneID = value;
					this.SendPropertyChanged("DefaultTimeZoneID");
					this.OnDefaultTimeZoneIDChanged();
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
}
#pragma warning restore 1591
