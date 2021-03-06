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

namespace Analiza_isplativosti_projekta.LINQ
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ekonomska_isplativost")]
	public partial class PrihTrosDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblPrihTro(tblPrihTro instance);
    partial void UpdatetblPrihTro(tblPrihTro instance);
    partial void DeletetblPrihTro(tblPrihTro instance);
    #endregion
		
		public PrihTrosDataContext() : 
				base(global::Analiza_isplativosti_projekta.Properties.Settings.Default.ekonomska_isplativostConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PrihTrosDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PrihTrosDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PrihTrosDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PrihTrosDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblPrihTro> tblPrihTros
		{
			get
			{
				return this.GetTable<tblPrihTro>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblPrihTros")]
	public partial class tblPrihTro : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private int _year;
		
		private int _years_in_progress;
		
		private int _povecanje_zarade;
		
		private int _smanjenje_troskova;
		
		private int _troskovi_rada;
		
		private int _troskovi_razvoja;
		
		private int _ukupni_prihodi;
		
		private int _ukupni_troskovi;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnyearChanging(int value);
    partial void OnyearChanged();
    partial void Onyears_in_progressChanging(int value);
    partial void Onyears_in_progressChanged();
    partial void Onpovecanje_zaradeChanging(int value);
    partial void Onpovecanje_zaradeChanged();
    partial void Onsmanjenje_troskovaChanging(int value);
    partial void Onsmanjenje_troskovaChanged();
    partial void Ontroskovi_radaChanging(int value);
    partial void Ontroskovi_radaChanged();
    partial void Ontroskovi_razvojaChanging(int value);
    partial void Ontroskovi_razvojaChanged();
    partial void Onukupni_prihodiChanging(int value);
    partial void Onukupni_prihodiChanged();
    partial void Onukupni_troskoviChanging(int value);
    partial void Onukupni_troskoviChanged();
    #endregion
		
		public tblPrihTro()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_year", DbType="Int NOT NULL")]
		public int year
		{
			get
			{
				return this._year;
			}
			set
			{
				if ((this._year != value))
				{
					this.OnyearChanging(value);
					this.SendPropertyChanging();
					this._year = value;
					this.SendPropertyChanged("year");
					this.OnyearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_years_in_progress", DbType="Int NOT NULL")]
		public int years_in_progress
		{
			get
			{
				return this._years_in_progress;
			}
			set
			{
				if ((this._years_in_progress != value))
				{
					this.Onyears_in_progressChanging(value);
					this.SendPropertyChanging();
					this._years_in_progress = value;
					this.SendPropertyChanged("years_in_progress");
					this.Onyears_in_progressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_povecanje_zarade", DbType="Int NOT NULL")]
		public int povecanje_zarade
		{
			get
			{
				return this._povecanje_zarade;
			}
			set
			{
				if ((this._povecanje_zarade != value))
				{
					this.Onpovecanje_zaradeChanging(value);
					this.SendPropertyChanging();
					this._povecanje_zarade = value;
					this.SendPropertyChanged("povecanje_zarade");
					this.Onpovecanje_zaradeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_smanjenje_troskova", DbType="Int NOT NULL")]
		public int smanjenje_troskova
		{
			get
			{
				return this._smanjenje_troskova;
			}
			set
			{
				if ((this._smanjenje_troskova != value))
				{
					this.Onsmanjenje_troskovaChanging(value);
					this.SendPropertyChanging();
					this._smanjenje_troskova = value;
					this.SendPropertyChanged("smanjenje_troskova");
					this.Onsmanjenje_troskovaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_troskovi_rada", DbType="Int NOT NULL")]
		public int troskovi_rada
		{
			get
			{
				return this._troskovi_rada;
			}
			set
			{
				if ((this._troskovi_rada != value))
				{
					this.Ontroskovi_radaChanging(value);
					this.SendPropertyChanging();
					this._troskovi_rada = value;
					this.SendPropertyChanged("troskovi_rada");
					this.Ontroskovi_radaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_troskovi_razvoja", DbType="Int NOT NULL")]
		public int troskovi_razvoja
		{
			get
			{
				return this._troskovi_razvoja;
			}
			set
			{
				if ((this._troskovi_razvoja != value))
				{
					this.Ontroskovi_razvojaChanging(value);
					this.SendPropertyChanging();
					this._troskovi_razvoja = value;
					this.SendPropertyChanged("troskovi_razvoja");
					this.Ontroskovi_razvojaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ukupni_prihodi", DbType="Int NOT NULL")]
		public int ukupni_prihodi
		{
			get
			{
				return this._ukupni_prihodi;
			}
			set
			{
				if ((this._ukupni_prihodi != value))
				{
					this.Onukupni_prihodiChanging(value);
					this.SendPropertyChanging();
					this._ukupni_prihodi = value;
					this.SendPropertyChanged("ukupni_prihodi");
					this.Onukupni_prihodiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ukupni_troskovi", DbType="Int NOT NULL")]
		public int ukupni_troskovi
		{
			get
			{
				return this._ukupni_troskovi;
			}
			set
			{
				if ((this._ukupni_troskovi != value))
				{
					this.Onukupni_troskoviChanging(value);
					this.SendPropertyChanging();
					this._ukupni_troskovi = value;
					this.SendPropertyChanged("ukupni_troskovi");
					this.Onukupni_troskoviChanged();
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
