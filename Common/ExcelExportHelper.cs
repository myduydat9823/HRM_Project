using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace QuanLyNhanSu.Common
{
    public static class ExcelExportHelper
    {
        private const string SpreadsheetNs = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
        private const string RelationshipNs = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
        private const string ContentTypesNs = "http://schemas.openxmlformats.org/package/2006/content-types";
        private const string PackageRelationshipsNs = "http://schemas.openxmlformats.org/package/2006/relationships";

        public static void ExportDataGridViewToXlsx(DataGridView grid, string filePath, string sheetName)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));

            List<DataGridViewColumn> columns = grid.Columns
                .Cast<DataGridViewColumn>()
                .Where(column => column.Visible)
                .OrderBy(column => column.DisplayIndex)
                .ToList();

            List<DataGridViewRow> rows = grid.Rows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .ToList();

            if (columns.Count == 0 || rows.Count == 0)
                throw new InvalidOperationException("Không có dữ liệu để xuất Excel.");

            if (File.Exists(filePath))
                File.Delete(filePath);

            using (FileStream stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
            using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Create))
            {
                WriteContentTypes(archive);
                WriteRootRelationships(archive);
                WriteWorkbook(archive, SanitizeSheetName(sheetName));
                WriteWorkbookRelationships(archive);
                WriteStyles(archive);
                WriteWorksheet(archive, grid, columns, rows);
            }
        }

        private static void WriteContentTypes(ZipArchive archive)
        {
            using (XmlWriter writer = CreateXmlWriter(archive, "[Content_Types].xml"))
            {
                writer.WriteStartElement("Types", ContentTypesNs);
                writer.WriteStartElement("Default", ContentTypesNs);
                writer.WriteAttributeString("Extension", "rels");
                writer.WriteAttributeString("ContentType", "application/vnd.openxmlformats-package.relationships+xml");
                writer.WriteEndElement();

                writer.WriteStartElement("Default", ContentTypesNs);
                writer.WriteAttributeString("Extension", "xml");
                writer.WriteAttributeString("ContentType", "application/xml");
                writer.WriteEndElement();

                WriteOverride(writer, "/xl/workbook.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
                WriteOverride(writer, "/xl/worksheets/sheet1.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml");
                WriteOverride(writer, "/xl/styles.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml");

                writer.WriteEndElement();
            }
        }

        private static void WriteOverride(XmlWriter writer, string partName, string contentType)
        {
            writer.WriteStartElement("Override", ContentTypesNs);
            writer.WriteAttributeString("PartName", partName);
            writer.WriteAttributeString("ContentType", contentType);
            writer.WriteEndElement();
        }

        private static void WriteRootRelationships(ZipArchive archive)
        {
            using (XmlWriter writer = CreateXmlWriter(archive, "_rels/.rels"))
            {
                writer.WriteStartElement("Relationships", PackageRelationshipsNs);
                writer.WriteStartElement("Relationship", PackageRelationshipsNs);
                writer.WriteAttributeString("Id", "rId1");
                writer.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
                writer.WriteAttributeString("Target", "xl/workbook.xml");
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        private static void WriteWorkbook(ZipArchive archive, string sheetName)
        {
            using (XmlWriter writer = CreateXmlWriter(archive, "xl/workbook.xml"))
            {
                writer.WriteStartElement("workbook", SpreadsheetNs);
                writer.WriteAttributeString("xmlns", "r", null, RelationshipNs);

                writer.WriteStartElement("sheets", SpreadsheetNs);
                writer.WriteStartElement("sheet", SpreadsheetNs);
                writer.WriteAttributeString("name", sheetName);
                writer.WriteAttributeString("sheetId", "1");
                writer.WriteAttributeString("r", "id", RelationshipNs, "rId1");
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }

        private static void WriteWorkbookRelationships(ZipArchive archive)
        {
            using (XmlWriter writer = CreateXmlWriter(archive, "xl/_rels/workbook.xml.rels"))
            {
                writer.WriteStartElement("Relationships", PackageRelationshipsNs);

                writer.WriteStartElement("Relationship", PackageRelationshipsNs);
                writer.WriteAttributeString("Id", "rId1");
                writer.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet");
                writer.WriteAttributeString("Target", "worksheets/sheet1.xml");
                writer.WriteEndElement();

                writer.WriteStartElement("Relationship", PackageRelationshipsNs);
                writer.WriteAttributeString("Id", "rId2");
                writer.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles");
                writer.WriteAttributeString("Target", "styles.xml");
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }

        private static void WriteStyles(ZipArchive archive)
        {
            using (XmlWriter writer = CreateXmlWriter(archive, "xl/styles.xml"))
            {
                writer.WriteStartElement("styleSheet", SpreadsheetNs);

                writer.WriteStartElement("fonts", SpreadsheetNs);
                writer.WriteAttributeString("count", "2");
                WriteFont(writer, false);
                WriteFont(writer, true);
                writer.WriteEndElement();

                writer.WriteStartElement("fills", SpreadsheetNs);
                writer.WriteAttributeString("count", "2");
                writer.WriteStartElement("fill", SpreadsheetNs);
                writer.WriteStartElement("patternFill", SpreadsheetNs);
                writer.WriteAttributeString("patternType", "none");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("fill", SpreadsheetNs);
                writer.WriteStartElement("patternFill", SpreadsheetNs);
                writer.WriteAttributeString("patternType", "gray125");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("borders", SpreadsheetNs);
                writer.WriteAttributeString("count", "1");
                writer.WriteStartElement("border", SpreadsheetNs);
                writer.WriteElementString("left", SpreadsheetNs, string.Empty);
                writer.WriteElementString("right", SpreadsheetNs, string.Empty);
                writer.WriteElementString("top", SpreadsheetNs, string.Empty);
                writer.WriteElementString("bottom", SpreadsheetNs, string.Empty);
                writer.WriteElementString("diagonal", SpreadsheetNs, string.Empty);
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("cellStyleXfs", SpreadsheetNs);
                writer.WriteAttributeString("count", "1");
                WriteXf(writer, 0);
                writer.WriteEndElement();

                writer.WriteStartElement("cellXfs", SpreadsheetNs);
                writer.WriteAttributeString("count", "2");
                WriteXf(writer, 0);
                WriteXf(writer, 1);
                writer.WriteEndElement();

                writer.WriteStartElement("cellStyles", SpreadsheetNs);
                writer.WriteAttributeString("count", "1");
                writer.WriteStartElement("cellStyle", SpreadsheetNs);
                writer.WriteAttributeString("name", "Normal");
                writer.WriteAttributeString("xfId", "0");
                writer.WriteAttributeString("builtinId", "0");
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }

        private static void WriteFont(XmlWriter writer, bool bold)
        {
            writer.WriteStartElement("font", SpreadsheetNs);

            if (bold)
                writer.WriteElementString("b", SpreadsheetNs, string.Empty);

            writer.WriteStartElement("sz", SpreadsheetNs);
            writer.WriteAttributeString("val", "11");
            writer.WriteEndElement();

            writer.WriteStartElement("name", SpreadsheetNs);
            writer.WriteAttributeString("val", "Calibri");
            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        private static void WriteXf(XmlWriter writer, int fontId)
        {
            writer.WriteStartElement("xf", SpreadsheetNs);
            writer.WriteAttributeString("numFmtId", "0");
            writer.WriteAttributeString("fontId", fontId.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("fillId", "0");
            writer.WriteAttributeString("borderId", "0");
            writer.WriteAttributeString("xfId", "0");

            if (fontId > 0)
                writer.WriteAttributeString("applyFont", "1");

            writer.WriteEndElement();
        }

        private static void WriteWorksheet(ZipArchive archive, DataGridView grid, List<DataGridViewColumn> columns, List<DataGridViewRow> rows)
        {
            using (XmlWriter writer = CreateXmlWriter(archive, "xl/worksheets/sheet1.xml"))
            {
                int totalRows = rows.Count + 1;
                string lastCell = GetCellReference(columns.Count, totalRows);

                writer.WriteStartElement("worksheet", SpreadsheetNs);

                writer.WriteStartElement("dimension", SpreadsheetNs);
                writer.WriteAttributeString("ref", "A1:" + lastCell);
                writer.WriteEndElement();

                writer.WriteStartElement("sheetViews", SpreadsheetNs);
                writer.WriteStartElement("sheetView", SpreadsheetNs);
                writer.WriteAttributeString("workbookViewId", "0");
                writer.WriteStartElement("pane", SpreadsheetNs);
                writer.WriteAttributeString("ySplit", "1");
                writer.WriteAttributeString("topLeftCell", "A2");
                writer.WriteAttributeString("activePane", "bottomLeft");
                writer.WriteAttributeString("state", "frozen");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("sheetFormatPr", SpreadsheetNs);
                writer.WriteAttributeString("defaultRowHeight", "15");
                writer.WriteEndElement();

                writer.WriteStartElement("cols", SpreadsheetNs);
                for (int i = 1; i <= columns.Count; i++)
                {
                    writer.WriteStartElement("col", SpreadsheetNs);
                    writer.WriteAttributeString("min", i.ToString(CultureInfo.InvariantCulture));
                    writer.WriteAttributeString("max", i.ToString(CultureInfo.InvariantCulture));
                    writer.WriteAttributeString("width", "18");
                    writer.WriteAttributeString("customWidth", "1");
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteStartElement("sheetData", SpreadsheetNs);
                WriteHeaderRow(writer, columns);

                int excelRowIndex = 2;
                foreach (DataGridViewRow row in rows)
                {
                    WriteDataRow(writer, grid, columns, row, excelRowIndex);
                    excelRowIndex++;
                }

                writer.WriteEndElement();

                writer.WriteStartElement("autoFilter", SpreadsheetNs);
                writer.WriteAttributeString("ref", "A1:" + GetCellReference(columns.Count, 1));
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }

        private static void WriteHeaderRow(XmlWriter writer, List<DataGridViewColumn> columns)
        {
            writer.WriteStartElement("row", SpreadsheetNs);
            writer.WriteAttributeString("r", "1");

            for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
            {
                string header = string.IsNullOrWhiteSpace(columns[columnIndex].HeaderText)
                    ? columns[columnIndex].Name
                    : columns[columnIndex].HeaderText;

                WriteTextCell(writer, columnIndex + 1, 1, header, "1");
            }

            writer.WriteEndElement();
        }

        private static void WriteDataRow(XmlWriter writer, DataGridView grid, List<DataGridViewColumn> columns, DataGridViewRow row, int excelRowIndex)
        {
            writer.WriteStartElement("row", SpreadsheetNs);
            writer.WriteAttributeString("r", excelRowIndex.ToString(CultureInfo.InvariantCulture));

            for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
            {
                DataGridViewColumn column = columns[columnIndex];
                object value = row.Cells[column.Index].Value;

                if (value == null || value == DBNull.Value)
                {
                    WriteTextCell(writer, columnIndex + 1, excelRowIndex, string.Empty, null);
                }
                else if (IsNumericValue(value) && !ShouldKeepAsText(column))
                {
                    WriteNumberCell(writer, columnIndex + 1, excelRowIndex, value);
                }
                else if (value is DateTime dateValue)
                {
                    WriteTextCell(writer, columnIndex + 1, excelRowIndex, dateValue.ToString("dd/MM/yyyy"), null);
                }
                else
                {
                    string text = value.ToString();

                    if (grid.Columns[column.Index].DefaultCellStyle.Format == "N0"
                        && decimal.TryParse(text, out decimal decimalValue))
                    {
                        text = decimalValue.ToString("N0");
                    }

                    WriteTextCell(writer, columnIndex + 1, excelRowIndex, text, null);
                }
            }

            writer.WriteEndElement();
        }

        private static bool ShouldKeepAsText(DataGridViewColumn column)
        {
            return string.Equals(column.Name, "So_tai_khoan", StringComparison.OrdinalIgnoreCase)
                || string.Equals(column.DataPropertyName, "So_tai_khoan", StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsNumericValue(object value)
        {
            return value is byte
                || value is short
                || value is int
                || value is long
                || value is float
                || value is double
                || value is decimal;
        }

        private static void WriteTextCell(XmlWriter writer, int columnIndex, int rowIndex, string value, string styleIndex)
        {
            writer.WriteStartElement("c", SpreadsheetNs);
            writer.WriteAttributeString("r", GetCellReference(columnIndex, rowIndex));

            if (!string.IsNullOrWhiteSpace(styleIndex))
                writer.WriteAttributeString("s", styleIndex);

            writer.WriteAttributeString("t", "inlineStr");
            writer.WriteStartElement("is", SpreadsheetNs);
            writer.WriteElementString("t", SpreadsheetNs, value ?? string.Empty);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private static void WriteNumberCell(XmlWriter writer, int columnIndex, int rowIndex, object value)
        {
            writer.WriteStartElement("c", SpreadsheetNs);
            writer.WriteAttributeString("r", GetCellReference(columnIndex, rowIndex));
            writer.WriteElementString("v", SpreadsheetNs, Convert.ToDecimal(value).ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
        }

        private static XmlWriter CreateXmlWriter(ZipArchive archive, string entryName)
        {
            ZipArchiveEntry entry = archive.CreateEntry(entryName);

            return XmlWriter.Create(entry.Open(), new XmlWriterSettings
            {
                Encoding = System.Text.Encoding.UTF8,
                Indent = true,
                CloseOutput = true
            });
        }

        private static string GetCellReference(int columnIndex, int rowIndex)
        {
            return GetColumnName(columnIndex) + rowIndex.ToString(CultureInfo.InvariantCulture);
        }

        private static string GetColumnName(int columnIndex)
        {
            string columnName = string.Empty;

            while (columnIndex > 0)
            {
                int modulo = (columnIndex - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnIndex = (columnIndex - modulo) / 26;
            }

            return columnName;
        }

        private static string SanitizeSheetName(string sheetName)
        {
            if (string.IsNullOrWhiteSpace(sheetName))
                return "Sheet1";

            char[] invalidChars = { '\\', '/', '?', '*', '[', ']', ':' };

            foreach (char invalidChar in invalidChars)
            {
                sheetName = sheetName.Replace(invalidChar, ' ');
            }

            sheetName = sheetName.Trim();

            if (sheetName.Length == 0)
                sheetName = "Sheet1";

            return sheetName.Length > 31 ? sheetName.Substring(0, 31) : sheetName;
        }
    }
}
