﻿using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet_csharp_sdk.main.Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the Row object.
	/// </summary>
	public abstract class AbstractRow<TColumn, TCell> : IdentifiableModel where TColumn:Column where TCell:Cell
	{
		/// <summary>
		/// Represents the Sheet ID. </summary>
		private long? sheetId;

		/// <summary>
		/// Represents the row number. </summary>
		private int? rowNumber;

		/// <summary>
		/// Represents the parent row number. </summary>
		private int? parentRowNumber;

		/// <summary>
		/// Represents the Cells for this row. </summary>
		private IList<TCell> cells;

		/// <summary>
		/// Represents the Discussions for this row. </summary>
		private IList<Discussion> discussions;

		/// <summary>
		/// Represents the Attachments for this row. </summary>
		private IList<Attachment> attachments;

		/// <summary>
		/// Represents the Columns for this row. </summary>
		private IList<TColumn> columns;

		/// <summary>
		/// Represents the date and time the row was created. </summary>
		private DateTime? createdAt;

		/// <summary>
		/// Represents the date and time the row was modified. </summary>
		private DateTime? modifiedAt;

		/// <summary>
		/// A read-only flag To indicate if the row is Expanded or collapsed. </summary>
		private bool? expanded;

		/// <summary>
		/// The Version number that is incremented every time a sheet is modified. </summary>
		private int? version;

		/// <summary>
		/// The user's permissions on the sheet. </summary>
		private AccessLevel? accessLevel;

		/// <summary>
		/// Gets the user's permissions on the sheet.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? AccessLevel
		{
			get
			{
				return accessLevel;
			}
			set
			{
				this.accessLevel = value;
			}
		}


		/// <summary>
		/// Gets the Version number that is incremented every time a sheet is modified.
		/// </summary>
		/// <returns> the Version </returns>
		public virtual int? Version
		{
			get
			{
				return version;
			}
			set
			{
				this.version = value;
			}
		}


		/// <summary>
		/// Checks if the row is Expanded.
		/// </summary>
		/// <returns> true, if is Expanded </returns>
		public virtual bool? Expanded
		{
			get
			{
				return expanded;
			}
			set
			{
				this.expanded = value;
			}
		}


		/// <summary>
		/// Get a column by it's Index.
		/// </summary>
		/// <param name="index"> the column Index </param>
		/// <returns> the column by Index </returns>
		public virtual TColumn GetColumnByIndex(int index)
		{
			if (columns == null)
			{
				return null;
			}

			TColumn result = null;
			foreach (TColumn column in columns)
			{
				if (column.Index == index)
				{
					result = column;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Get a column by it's ID.
		/// </summary>
		/// <param name="columnId"> the column Id </param>
		/// <returns> the column by Id </returns>
		public virtual TColumn GetColumnById(long columnId)
		{
			if (columns == null)
			{
				return null;
			}

			TColumn result = null;
			foreach (TColumn column in columns)
			{
				if (column.ID == columnId)
				{
					result = column;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Gets the Id of the sheet.
		/// </summary>
		/// <returns> the sheet Id </returns>
		public virtual long? SheetId
		{
			get
			{
				return sheetId;
			}
			set
			{
				this.sheetId = value;
			}
		}


		/// <summary>
		/// Gets the row number.
		/// </summary>
		/// <returns> the row number </returns>
		public virtual int? RowNumber
		{
			get
			{
				return rowNumber;
			}
			set
			{
				this.rowNumber = value;
			}
		}


		/// <summary>
		/// Gets the parent row number.
		/// </summary>
		/// <returns> the parent row number </returns>
		public virtual int? ParentRowNumber
		{
			get
			{
				return parentRowNumber;
			}
			set
			{
				this.parentRowNumber = value;
			}
		}


		/// <summary>
		/// Gets the Cells.
		/// </summary>
		/// <returns> the Cells </returns>
		public virtual IList<TCell> Cells
		{
			get
			{
				return cells;
			}
			set
			{
				this.cells = value;
			}
		}


		/// <summary>
		/// Gets the Discussions.
		/// </summary>
		/// <returns> the Discussions </returns>
		public virtual IList<Discussion> Discussions
		{
			get
			{
				return discussions;
			}
			set
			{
				this.discussions = value;
			}
		}


		/// <summary>
		/// Gets the Attachments.
		/// </summary>
		/// <returns> the Attachments </returns>
		public virtual IList<Attachment> Attachments
		{
			get
			{
				return attachments;
			}
			set
			{
				this.attachments = value;
			}
		}


		/// <summary>
		/// Gets the Columns.
		/// </summary>
		/// <returns> the Columns </returns>
		public virtual IList<TColumn> Columns
		{
			get
			{
				return columns;
			}
			set
			{
				this.columns = value;
			}
		}


		/// <summary>
		/// Gets the date and time a row was created.
		/// </summary>
		/// <returns> the created at </returns>
		public virtual DateTime? CreatedAt
		{
			get
			{
				return createdAt;
			}
			set
			{
				this.createdAt = value;
			}
		}


		/// <summary>
		/// Gets the date and time a row was modified.
		/// </summary>
		/// <returns> the modified at </returns>
		public virtual DateTime? ModifiedAt
		{
			get
			{
				return modifiedAt;
			}
			set
			{
				this.modifiedAt = value;
			}
		}

	}
}
