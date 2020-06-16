﻿using System;
using System.Collections.Generic;

// Add nuget reference to smartsheet-csharp-sdk (https://www.nuget.org/packages/smartsheet-csharp-sdk/)
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace sdk_csharp_sample
{
   class Program
   {
      public static void Main(string[] args)
      {
         // Initialize client
         SmartsheetClient smartsheet = new SmartsheetBuilder()
                .SetAccessToken("bf3rn6qxu0if45zzcop66i2lk6")       // TODO: Set your API access in environment variable SMARTSHEET_ACCESS_TOKEN or else here
                .SetHttpClient(new RetryHttpClient())
                .Build();

         // List all sheets
         PaginatedResult<Sheet> sheets = smartsheet.SheetResources.ListSheets(new List<SheetInclusion> { SheetInclusion.SHEET_VERSION }, null, null);
         //Console.WriteLine("Found " + sheets.TotalCount + " sheets");

         //*****************************************************************************************Added Extras 1

         long sheetId;
         Console.WriteLine("Please Enter Sheet Name");
         string sheetName = Console.ReadLine();

         foreach (var searchSheet in sheets.Data)
         {
            if (searchSheet.Name == sheetName)
            {
               Console.WriteLine("Found Sheet " + sheetName + " ID = " + searchSheet.Id);
               sheetId = searchSheet.Id.Value;

               var sheet = smartsheet.SheetResources.GetSheet(sheetId, null, null, null, null, null, null, null);
               var csv = new StringBuilder();
               var columnNames = "";

               foreach (Column column in sheet.Columns.Take(sheet.Columns.Count))
               {
                  if (columnNames == "")
                  {
                     columnNames = string.Format(column.Title);
                  }
                  else
                  {
                     columnNames = string.Format("{0}|{1}", columnNames, column.Title);
                  }
               }
               csv.AppendLine(columnNames);
               foreach (Row row in sheet.Rows.Take(sheet.Rows.Count))
               {
                  var rowValues = "";
                  foreach (var cell in row.Cells)
                  {
                     if (cell.Value != null)
                     {
                        if (rowValues == "")
                        {
                           rowValues = string.Format(cell.Value.ToString());
                        }
                        else
                        {
                           rowValues = string.Format("{0}|{1}", rowValues, cell.Value.ToString());
                        }
                     }
                     else
                     {
                        rowValues = string.Format(rowValues + "|");
                     }
                  }
                  csv.AppendLine(rowValues);
               }

               File.WriteAllText("C:/DevOps/" + sheetName + ".csv", csv.ToString());
               Console.WriteLine("Exported to C:/DevOps/" + sheetName + ".csv (Hit enter to Continue)");  // Keep console window open
               Console.ReadLine();
               //jba2zbq7uaiwtrwyopamlstx2fpncd4zxoweshnc7jbaygcgab5q
            }
         }
      }
   }

         //getSheetID(sheetName, sheets, sheetId);

         //*****************************************************************************************Added Extras 1

      //   if (sheets.TotalCount > 0)
      //   {
      //      //long sheetId = (long)sheets.Data[0].Id;                // Default first sheet
      //      //sheetId = 2236714631620484;                         // TODO: Uncomment if you wish to read a specific sheet

      //      Console.WriteLine("Loading sheet id: " + sheetId);

      //      // Load the entire sheet
      //      var sheet = smartsheet.SheetResources.GetSheet(sheetId, null, null, null, null, null, null, null);
      //      Console.WriteLine("Loaded " + sheet.Rows.Count + " rows from sheet: " + sheet.Name);

      //      //*****************************************************************************************Added Extras 2

      //      //var csv = new StringBuilder();
      //      //var columnNames = "";


      //      //foreach (Column column in sheet.Columns.Take(sheet.Columns.Count))
      //      //{
      //      //   if (columnNames == "")
      //      //   {
      //      //      columnNames = string.Format(column.Title);
      //      //   }
      //      //   else
      //      //   {
      //      //      columnNames = string.Format("{0}|{1}", columnNames, column.Title);
      //      //   }
      //      //}
      //      //csv.AppendLine(columnNames);
      //      //foreach (Row row in sheet.Rows.Take(sheet.Rows.Count))
      //      //{
      //      //   var rowValues = "";
      //      //   foreach (var cell in row.Cells)
      //      //   {
      //      //      if (cell.Value != null)
      //      //      {
      //      //         if (rowValues == "")
      //      //         {
      //      //            rowValues = string.Format(cell.Value.ToString());
      //      //         }
      //      //         else
      //      //         {
      //      //            rowValues = string.Format("{0}|{1}", rowValues, cell.Value.ToString());
      //      //         }
      //      //      }
      //      //      else
      //      //      {
      //      //         rowValues = string.Format(rowValues + "|");
      //      //      }
      //      //   }
      //      //   csv.AppendLine(rowValues);
      //      //}

      //      //File.WriteAllText("C:/DevOps/Test.csv", csv.ToString());

      //      //*****************************************************************************************Added Extras 2

      //      // Display the first 5 rows
      //      foreach (Row row in sheet.Rows.Take(sheet.Rows.Count))
      //      {
      //         //dumpRow(row, sheet.Columns);
      //      }
      //   }
      //   //foreach (var asheet in sheets.Data)
      //   //{
      //   //   if (asheet.Name == "DevOps Testing")
      //   //   {
      //   //      Console.WriteLine(asheet.Id);
      //   //   }
      //   //   Console.WriteLine(asheet.Id + ": " + asheet.Name + ": " + asheet.ModifiedAt);
      //   //}

      //   Console.WriteLine("Done (Hit enter)");                      // Keep console window open
      //   Console.ReadLine();
      //}

   //   static public void getSheetID(string sheetName, PaginatedResult<Sheet> sheets, long sheetId)
   //   {
   //      foreach (var searchSheet in sheets.Data)
   //      {
   //         if (searchSheet.Name == sheetName)
   //         {
   //            Console.WriteLine("Found Sheet " + sheetName + " ID = " + searchSheet.Id);
   //            sheetId = searchSheet.Id.Value;
   //         }
   //      }
   //   }

   //   // Display row contents
   //   static void dumpRow(Row row, IList<Column> columns)
   //   {
   //      Console.WriteLine("Row # " + row.RowNumber + ":");
   //      foreach (var cell in row.Cells)
   //      {
   //         // Find column name by Id in column collection
   //         var columName = columns.First(column => column.Id == cell.ColumnId).Title;
   //         Console.WriteLine("    " + columName + ": " + cell.Value);
   //      }
   //   }
   //}
}

