using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using System.Collections;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.Data;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
using System.Data.SqlClient;
using System.Windows.Media;
using GemBox.Spreadsheet;
using StartsInternational.Common;
using StartsInternational.CustomUserControl;
using ObjInfo;
using MemoryData;
using Starts_Controller;

namespace StartsInternational
{
    public class CommonFunction
    {
        private CheckValidate chkValidate = new CheckValidate();

        #region common

        /// <summary>
        /// Nhập so số thập phân, đằng sau dấu . có p_number_afer_cham số 
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="p_number_afer_cham"> đằng sau dấu . có bao nhiêu số</param>
        /// <returns></returns>
        public static string NhapSoTp(TextBox txt, int p_number_afer_cham)
        {
            try
            {
                if (!CheckValidate.CheckSoThapPhan(txt.Text, p_number_afer_cham) && txt.Text != "")
                {
                    string s = txt.Text;
                    if (s.Length > 1)
                        txt.Text = s.Remove(s.Length - 1, 1);
                    else txt.Text = "";
                    txt.Select(txt.Text.Length, 0);
                }
                return txt.Text;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }


        public void FilldataToCombox(ComboBox cbo, string cdtype, string ctname)
        {
            try
            {
                //ArrayList _arr = new ArrayList();
                //_arr = Gets_AllCode_Data(cdtype, ctname, CommonData.c_AllCode);
                //cbo.DisplayMemberPath = "Content";
                //cbo.SelectedValuePath = "CdVal";
                //cbo.ItemsSource = _arr;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public void CloseForm(object sender, KeyEventArgs e)
        {
            try
            {
                Window _sender = (Window)sender;
                if (e.Key == Key.Escape)
                    _sender.Close();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// So sanh hai Date time ma ko so sanh Time chi so sanh ngay thang
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// 0 the same, 1 dt1 > dt2, -1 dt1 < dt2
        /// <returns></returns>
        public Int32 CompareTwoDate(DateTime dt1, DateTime dt2)
        {
            try
            {
                if (dt1.Year > dt2.Year)
                    return 1;
                else if (dt1.Year < dt2.Year)
                    return -1;
                else//Cung nam
                    if (dt1.Month > dt2.Month)
                        return 1;
                    else if (dt1.Month < dt2.Month)
                        return -1;
                    else//Cung thang
                        if (dt1.Day > dt2.Day)
                            return 1;
                        else if (dt1.Day < dt2.Day)
                            return -1;
                        else//Cung ngay
                            return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region GetConfig
        public static string GetConfig(string configKey)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[configKey];
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region Dangtq kết xuất excel

        public static string Getcon_Excel(string fileName, string type)
        {
            string connectionString = "";
            try
            {
                switch (type)
                {
                    case ".xls": //Excel 97-03
                        connectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;HDR=YES\";");
                        break;
                    case ".xlsx": //Excel 07
                        connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"");
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
            return connectionString;
        }

        #region FlexCelReport
        public static void SetValueExportByDataTable(ref FlexCel.Report.FlexCelReport flcReport, DataSet v_ds)
        {
            try
            {
                flcReport.AddTable(v_ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public static void SetValueExportByString(ref FlexCel.Report.FlexCelReport flcReport, string _ParamName, object _value)
        {
            try
            {
                flcReport.SetValue(_ParamName, _value);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public static void ExportExcel(FlexCel.Report.FlexCelReport flcReport, string pathFile, System.Windows.Forms.SaveFileDialog saveReport)
        {
            System.IO.FileStream _templateStream = null;
            try
            {
                flcReport.DeleteEmptyRanges = false; string _path = "";
                string exepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "");
                MemoryStream _xlsMemoryStream = new MemoryStream();

                #region Luu file xls len memory stream
                _path = exepath + "\\" + pathFile.Replace("//", "\\");
                bool ckFileIsNotOpen = true;
                //check xem file co ton tai trong duong dan ko?
                if (!System.IO.File.Exists(exepath + "\\" + pathFile.Replace("//", "\\")))
                {
                    //bao loi ko ton tai file;
                    NoteBox.Show("File excel thiết kế không tồn tại trong thư mục Run/report. Kết xuất không thành công.", "Thông báo", NoteBoxLevel.Note);
                }
                else
                {
                    //check file co dang mo hay ko
                    try
                    {
                        var stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
                        stream.Close();
                    }
                    catch
                    {
                        NoteBox.Show("File mẫu đang mở hoặc bị process khác sử dụng, bạn phải đóng file đó mới có thể kết xuất", "Error", NoteBoxLevel.Error);
                        ckFileIsNotOpen = false;
                    }

                    if (ckFileIsNotOpen == true)
                    {
                        _templateStream = new System.IO.FileStream(_path, System.IO.FileMode.Open);
                        flcReport.Run(_templateStream, _xlsMemoryStream);

                        //luu file 
                        _xlsMemoryStream.Position = 0;
                        byte[] bytes = new byte[_xlsMemoryStream.Length];
                        _xlsMemoryStream.Read(bytes, 0, (int)_xlsMemoryStream.Length);

                        try
                        {
                            FileStream OutStream;

                            OutStream = new FileStream(saveReport.FileName, FileMode.Create);

                            OutStream.Write(bytes, 0, bytes.Length);
                            OutStream.Close();
                            _xlsMemoryStream.Close();
                            _templateStream.Close();

                            Mouse.OverrideCursor = null;
                            //Neu chon mo file da luu
                            MessageBoxResult result = NoteBox.Show("Bạn có muốn mở file vừa chọn kết xuất không?", "Thông báo", NoteBoxLevel.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                Process.Start(saveReport.FileName);
                            }
                        }
                        catch (Exception)
                        {
                            _templateStream.Close();
                            NoteBox.Show("File mẫu đang mở hoặc bị process khác sử dụng, bạn phải đóng file đó mới có thể kết xuất", "Error", NoteBoxLevel.Error);
                            Mouse.OverrideCursor = null;
                            return;
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                _templateStream.Close();
                CommonData.log.Error(ex.ToString());
                NoteBox.Show("Kết xuất file excel không thành công", "Thông báo", NoteBoxLevel.Error);
            }

        }

        public static void ExportXMLFile(DataSet ds, System.Windows.Forms.SaveFileDialog saveReport)
        {
            ds.WriteXml(saveReport.FileName);
            MessageBoxResult result = NoteBox.Show("Bạn có muốn mở file vừa chọn kết xuất không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                Process.Start(saveReport.FileName);
            }
        }
        #endregion

        #region GemBox Excel

        public static void ExportToFile(DataSet ds, string NameReport, string filename, Dictionary<string, string> p_dic_format)
        {
            try
            {
                System.Windows.Forms.SaveFileDialog v_dlgSave = new System.Windows.Forms.SaveFileDialog();
                v_dlgSave.Filter = "Excel files (*.xls)|*.xls|XML files (*.xml)|*.xml";
                v_dlgSave.FileName = filename;

                //Neu luu du lieu la xls
                if (v_dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        // MessageBox.Show("Không có dữ liệu để kết xuất ");
                        Mouse.OverrideCursor = null;
                        return;
                    }

                    if (v_dlgSave.FileName.Contains(".xls"))
                    {
                        bool _ck = CommonFunction.ExportToXLS(ds, v_dlgSave, NameReport, p_dic_format);
                        if (_ck == false)
                        {
                            return;
                        }
                    }
                    else if (v_dlgSave.FileName.Contains(".xml"))
                    {
                        CommonFunction.ExportToXML(ds, v_dlgSave);
                    }
                }
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());
                //  MessageBox.Show("Lỗi! Không kết xuất dữ liệu ra file .");
            }
        }

        public static void ExportDataSet65k(ref ExcelFile p_ef, DataTable p_dt, int p_start_row, int p_to_row, string NameReport, int p_sheet, Dictionary<string, string> p_dic_format)
        {
            try
            {
                int _sheet = p_sheet;

                DataTable _new_dt = new DataTable();
                _new_dt.TableName = NameReport + "_sheet" + (_sheet + 1).ToString();
                _new_dt = p_dt.Clone();
                for (int i = p_start_row; i < p_dt.Rows.Count; i++)
                {
                    if (i <= p_to_row)
                    {
                        DataRow _dr = (DataRow)p_dt.Rows[i];
                        _new_dt.Rows.Add(_dr.ItemArray);
                    }
                }

                // Add new worksheet to the file.
                var ws = p_ef.Worksheets.Add(_new_dt.TableName);
                ws.Cells["A2"].Value = NameReport.ToUpper();
                ws.Cells["A2"].Style.Font.Weight = ExcelFont.BoldWeight;

                // Insert the data from DataTable to the worksheet starting at cell "A5".
                ws.InsertDataTable(_new_dt, "A5", true);

                int stt = _new_dt.Columns.Count;//dem so cot trong dt

                p_ef.Worksheets[0].Columns[0].Width = 4 * 256;
                for (int i = 0; i < stt; i++)
                {
                    //p_ef.Worksheets[0].Cells[4, i].Style.HorizontalAlignment = HorizontalAlignmentStyle.Fill;
                    p_ef.Worksheets[0].Cells[4, i].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    p_ef.Worksheets[0].Cells[4, i].Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    p_ef.Worksheets[0].Cells[4, i].Style.Borders.SetBorders(MultipleBorders.Top, System.Drawing.Color.FromArgb(0, 0, 0), LineStyle.Thin);
                    p_ef.Worksheets[0].Cells[4, i].Style.Borders.SetBorders(MultipleBorders.Bottom, System.Drawing.Color.FromArgb(0, 0, 0), LineStyle.Thin);
                    p_ef.Worksheets[0].Cells[4, i].Style.Borders.SetBorders(MultipleBorders.Left, System.Drawing.Color.FromArgb(0, 0, 0), LineStyle.Thin);
                    p_ef.Worksheets[0].Cells[4, i].Style.Borders.SetBorders(MultipleBorders.Right, System.Drawing.Color.FromArgb(0, 0, 0), LineStyle.Thin);
                    p_ef.Worksheets[0].Cells[4, i].Style.Font.Weight = ExcelFont.BoldWeight;

                    if (i != 0)
                        p_ef.Worksheets[0].Columns[i].AutoFit();

                    if (_new_dt.Columns[i].DataType == typeof(decimal) || _new_dt.Columns[i].DataType == typeof(int))
                    {
                        if (p_dic_format.ContainsKey(_new_dt.Columns[i].ColumnName.ToUpper()))
                        {
                            int value = Convert.ToInt16(p_dic_format[_new_dt.Columns[i].ColumnName.ToUpper()]);
                            if (value == 1)
                                p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.0";//#,#
                            else if (value == 2)
                                p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.00";//#,#
                            else if (value == 3)
                                p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.000";//#,#
                            else if (value == 4)
                                p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.0000";//#,#
                            else if (value == 5)
                                p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.00000";//#,#
                            else if (value == 6)
                                p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.000000";
                            else
                                p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0";//#,#
                        }
                        else
                            p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0";//#,#
                    }
                    if (_new_dt.Columns[i].DataType == typeof(DateTime))
                    {
                        p_ef.Worksheets[0].Columns[i].Style.NumberFormat = "dd/MM/yyyy";//#,#
                        p_ef.Worksheets[0].Columns[i].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                        p_ef.Worksheets[0].Columns[i].Width = 20 * 256;
                    }
                }

                if (p_dt.Rows.Count - _new_dt.Rows.Count > 0)
                {
                    _sheet++;
                    DataTable _dt1 = p_dt.Clone();
                    _dt1.TableName = NameReport + "_sheet" + (_sheet + 1).ToString();

                    for (int i = _new_dt.Rows.Count; i < p_dt.Rows.Count; i++)
                    {
                        DataRow _dr = (DataRow)p_dt.Rows[i];
                        _dt1.Rows.Add(_dr.ItemArray);
                    }

                    ExportDataSet65k(ref p_ef, _dt1, 0, 64999, NameReport, _sheet, p_dic_format);
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public static bool ExportToXLS(DataSet dataSet, System.Windows.Forms.SaveFileDialog v_dlgSave, string NameReport, Dictionary<string, string> p_dic_format)
        {
            try
            {
                // Create new ExcelFile.
                var ef = new ExcelFile();
                // Imports all the tables from DataSet to new file.
                foreach (DataTable dataTable in dataSet.Tables)
                {
                    dataTable.TableName = NameReport;
                    if (dataTable.Rows.Count > 65000)
                    {
                        ExportDataSet65k(ref ef, dataTable, 0, 64999, NameReport, 0, p_dic_format);
                    }
                    else
                    {
                        // Add new worksheet to the file.
                        var ws = ef.Worksheets.Add(dataTable.TableName);
                        ws.Cells["A2"].Value = NameReport.ToUpper();
                        ws.Cells["A2"].Style.Font.Weight = ExcelFont.BoldWeight;

                        CellRange cr = ef.Worksheets[0].Rows[2].Cells;
                        //cr[5].MergedRange[2, 6];

                        // Insert the data from DataTable to the worksheet starting at cell "A5".
                        ws.InsertDataTable(dataTable, "A5", true);
                        int stt = dataTable.Columns.Count;//dem so cot trong dt

                        //ef.Worksheets[0].Rows[3].Style.Borders.SetBorders(MultipleBorders.All, Color.FromArgb(252, 1, 1,1), LineStyle.Thin);


                        ef.Worksheets[0].Columns[0].Width = 4 * 256;

                        #region set forrmar cell
                        for (int i = 0; i < stt; i++)
                        {
                            ef.Worksheets[0].Cells[4, i].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                            ef.Worksheets[0].Cells[4, i].Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                            ef.Worksheets[0].Cells[4, i].Style.Borders.SetBorders(MultipleBorders.Top, System.Drawing.Color.FromArgb(0, 0, 0), LineStyle.Thin);
                            ef.Worksheets[0].Cells[4, i].Style.Borders.SetBorders(MultipleBorders.Bottom, System.Drawing.Color.FromArgb(0, 0, 0), LineStyle.Thin);
                            ef.Worksheets[0].Cells[4, i].Style.Borders.SetBorders(MultipleBorders.Left, System.Drawing.Color.FromArgb(0, 0, 0), LineStyle.Thin);
                            ef.Worksheets[0].Cells[4, i].Style.Borders.SetBorders(MultipleBorders.Right, System.Drawing.Color.FromArgb(0, 0, 0), LineStyle.Thin);
                            ef.Worksheets[0].Cells[4, i].Style.Font.Weight = ExcelFont.BoldWeight;

                            if (i != 0)
                                ef.Worksheets[0].Columns[i].AutoFit();

                            if (dataTable.Columns[i].DataType == typeof(decimal) || dataTable.Columns[i].DataType == typeof(int))
                            {
                                if (p_dic_format.ContainsKey(dataTable.Columns[i].ColumnName.ToUpper()))
                                {
                                    int value = Convert.ToInt16(p_dic_format[dataTable.Columns[i].ColumnName.ToUpper()]);
                                    if (value == 1)
                                        ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.0";//#,#
                                    else if (value == 2)
                                        ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.00";//#,#
                                    else if (value == 3)
                                        ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.000";//#,#
                                    else if (value == 4)
                                        ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.0000";//#,#
                                    else if (value == 5)
                                        ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.00000";//#,#
                                    else if (value == 6)
                                        ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0.000000";
                                    else
                                        ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0";//#,#
                                }
                                else
                                    ef.Worksheets[0].Columns[i].Style.NumberFormat = "#,##0";//#,#
                            }
                            if (dataTable.Columns[i].DataType == typeof(DateTime))
                            {
                                ef.Worksheets[0].Columns[i].Style.NumberFormat = "dd/MM/yyyy";//#,#
                                ef.Worksheets[0].Columns[i].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                                ef.Worksheets[0].Columns[i].Width = 20 * 256;
                            }
                        }

                        #endregion

                        //ef.Worksheets[0].Cells[4,0].Style.HorizontalAlignment = HorizontalAlignmentStyle.Fill;
                    }
                }

                string _strFileName = v_dlgSave.FileName;
                // Save the file to XLS format.
                string tempFolder = System.IO.Path.GetTempPath();
                string _path = System.IO.Path.GetFullPath(_strFileName);
                tempFolder = tempFolder + @"\" + System.IO.Path.GetFullPath(_strFileName);
                //tempFolder + @"\" + System.IO.Path.GetFileName(fileName)
                bool ckFileIsNotOpen = true;
                if (System.IO.File.Exists(_path))
                {
                    try
                    {
                        var stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
                        stream.Close();
                    }
                    catch
                    {
                        Mouse.OverrideCursor = null;
                        NoteBox.Show("File muốn lưu đang mở hoặc bị process khác sử dụng, bạn phải đóng file đó mới có thể lưu dữ liệu", "Error", NoteBoxLevel.Error);
                        ckFileIsNotOpen = false;
                        return false;
                    }
                }

                if (ckFileIsNotOpen == true)
                {
                    ef.SaveXls(_strFileName);

                    Mouse.OverrideCursor = null;
                    NoteBox.Show("Kết xuất dữ liệu ra file thành công", "", NoteBoxLevel.Note);
                    //Neu chon mo file da luu
                    System.Windows.MessageBoxResult result = NoteBox.Show("Bạn có muốn mở file excel vừa chọn kết xuất không?", "", NoteBoxLevel.Question);
                    if (System.Windows.MessageBoxResult.Yes == result)
                    {
                        Process.Start(_strFileName);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());

                if (ex.ToString().Contains("OutOfMemoryException"))
                    NoteBox.Show("Kết xuất không thành công. Máy không đủ bộ nhớ để kết xuất", "", NoteBoxLevel.Error);

                return false;
            }
        }

        public static void ExportToXML(DataSet dataSet, System.Windows.Forms.SaveFileDialog v_dlgSave)
        {
            try
            {
                dataSet.WriteXml(v_dlgSave.FileName);
                Mouse.OverrideCursor = null;
                NoteBox.Show("Kết xuất dữ liệu ra file thành công", "", NoteBoxLevel.Note);
                //Neu chon mo file da luu
                System.Windows.MessageBoxResult result = NoteBox.Show("Bạn có muốn mở file xml vừa chọn kết xuất không?", "", NoteBoxLevel.Question);
                if (System.Windows.MessageBoxResult.Yes == result)
                {
                    Process.Start(v_dlgSave.FileName);
                }
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                CommonData.log.Error(ex.ToString());
            }
        }
        #endregion

        #endregion

        #region SortData

        public ArrayList SortData(ArrayList arr, string NameColumn)
        {
            try
            {
                ArrayList _arr = new ArrayList();
                DataGrid _gridtemp = new DataGrid();
                _gridtemp.ItemsSource = arr;
                SortDescription sortDesCrip11 = new SortDescription(NameColumn, ListSortDirection.Ascending);
                _gridtemp.Items.SortDescriptions.Clear();
                _gridtemp.Items.SortDescriptions.Add(sortDesCrip11);
                for (int i = 0; i < _gridtemp.Items.Count - 1; i++)
                {
                    _arr.Add(_gridtemp.Items[i]);
                }
                return _arr;
            }
            catch (Exception ex)
            {

                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public ArrayList SortData(ArrayList arr, string NameColumn, int Max_Record_Number)
        {
            try
            {
                ArrayList _arr = new ArrayList();
                DataGrid _gridtemp = new DataGrid();
                _gridtemp.ItemsSource = arr;
                SortDescription sortDesCrip11 = new SortDescription(NameColumn, ListSortDirection.Ascending);
                _gridtemp.Items.SortDescriptions.Clear();
                _gridtemp.Items.SortDescriptions.Add(sortDesCrip11);
                for (int i = 0; i < Max_Record_Number; i++)
                {
                    _arr.Add(_gridtemp.Items[i]);
                }
                return _arr;
            }
            catch (Exception ex)
            {

                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public ArrayList SortData_Descending(ArrayList arr, string NameColumn, int Max_Record_Number)
        {
            try
            {
                ArrayList _arr = new ArrayList();
                DataGrid _gridtemp = new DataGrid();
                _gridtemp.ItemsSource = arr;
                SortDescription sortDesCrip11 = new SortDescription(NameColumn, ListSortDirection.Descending);
                _gridtemp.Items.SortDescriptions.Clear();
                _gridtemp.Items.SortDescriptions.Add(sortDesCrip11);
                for (int i = 0; i < Max_Record_Number; i++)
                {
                    _arr.Add(_gridtemp.Items[i]);
                }
                return _arr;
            }
            catch (Exception ex)
            {

                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public ArrayList SortData_Descending(ArrayList arr, string NameColumn)
        {
            try
            {
                ArrayList _arr = new ArrayList();
                DataGrid _gridtemp = new DataGrid();
                _gridtemp.ItemsSource = arr;
                SortDescription sortDesCrip11 = new SortDescription(NameColumn, ListSortDirection.Descending);
                _gridtemp.Items.SortDescriptions.Clear();
                _gridtemp.Items.SortDescriptions.Add(sortDesCrip11);
                for (int i = 0; i < _gridtemp.Items.Count - 1; i++)
                {
                    _arr.Add(_gridtemp.Items[i]);
                }
                return _arr;
            }
            catch (Exception ex)
            {

                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }
        #endregion

        /// <summary>
        /// insert vào trong db 1 bảng luôn
        /// </summary>
        public static bool Insert_Batch_From_DataTable(DataTable p_data, string p_ten_bang)
        {
            try
            {
                SqlBulkCopy copy = new SqlBulkCopy(CommonData.ConnectionString, SqlBulkCopyOptions.KeepIdentity);
                copy.DestinationTableName = p_ten_bang;
                copy.WriteToServer(p_data);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public static T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0)
                return null;

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);

                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindFirstElementInVisualTree<T>(child);
                    if (result != null)
                        return result;

                }
            }
            return null;
        }

        public static void Text_Change_Format_Money(TextBox p_textbox)
        {
            try
            {
                if (p_textbox.Text != "")
                {
                    p_textbox.Text = Common.ConvertData.NhapMoney(p_textbox);

                    if (p_textbox.Text == "," || p_textbox.Text == ".")
                        p_textbox.Text = "";

                    else if (p_textbox.Text != "")
                        p_textbox.Text = Convert.ToDecimal(p_textbox.Text).ToString("###,##0");
                    p_textbox.Select(p_textbox.Text.Length, 0);
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public static string ConvertVN(string chucodau)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = chucodau.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(chucodau[index]);
                chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
            }
            return chucodau;
        }

        public static void NVS_BindTextboxComplete(AutoCompleteTextBox txtControl, DataTable tbValue, string p_Propertie)
        {
            txtControl.TableList = new DataTable();
            txtControl.TableList.Columns.Add();

            foreach (DataRow item in tbValue.Rows)
            {
                DataRow objRow = txtControl.TableList.NewRow();
                objRow[0] = item[p_Propertie].ToString();
                txtControl.TableList.Rows.Add(objRow);
            }
        }

        #region Report
        public static DataTable CreateDataTableByObj(Type obj)
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc;
                foreach (PropertyInfo pp in obj.GetProperties())
                {
                    dc = new DataColumn(pp.Name, pp.PropertyType);
                    dt.Columns.Add(dc);
                }
                return dt;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        public static string GetCurrDate()
        {
            try
            {
                DateTime _dt = DateTime.Now;
                string _str = Common.ConvertData.ConvertDate2String(_dt);
                if (!_str.Equals(""))
                {
                    int length = _str.Length;
                    string[] strSplit = _str.Split('/');
                    string _ngay = strSplit[0];
                    string _thang = strSplit[1];
                    string _nam = strSplit[2];
                    return "Ngày " + _ngay + " tháng " + _thang + " năm " + _nam;
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return "";
            }
        }
        #endregion

        #region Export excel

        /// <summary>
        /// Tạo table với các cột là key của hash
        /// Sau đó đổi tên cột thành value của hash
        /// </summary>
        public static DataTable Rename_Colums_DataTable(DataTable p_dt, Dictionary<string, string> p_dic)
        {
            try
            {
                // ds_resuft.Tables[0].Columns["Str_Order_date"].ColumnName = "Ngày GD";
                // ds_resuft.Tables[0].Columns["Str_Order_date"].SetOrdinal(0);
                // if (p_dt.Columns.Contains(_colums))
                // p_dt.Columns.Remove(_colums);

                DataTable _dt = new DataTable();

                // tạo table với các cột là key của hash
                //foreach (DictionaryEntry de in p_hs_columns)
                //{
                foreach (KeyValuePair<string, string> pair in p_dic)
                {
                    string _column = (string)pair.Key;

                    DataColumn dc = new DataColumn();
                    dc.ColumnName = p_dt.Columns[_column].ColumnName;
                    dc.DataType = p_dt.Columns[_column].DataType;

                    _dt.Columns.Add(dc);
                }

                // Gán giá trị của table cũ vào table mới
                foreach (DataRow sourcerow in p_dt.Rows)
                {
                    DataRow destRow = _dt.NewRow();
                    foreach (KeyValuePair<string, string> pair in p_dic)
                    {
                        string _column = (string)pair.Key;
                        destRow[_column] = sourcerow[_column];
                    }
                    _dt.Rows.Add(destRow);
                }

                //Đổi tên cột thành value của hash
                foreach (KeyValuePair<string, string> pair in p_dic)
                {
                    string _column = (string)pair.Key;
                    string _name = (string)pair.Value;

                    _dt.Columns[_column].ColumnName = _name;
                }
                return _dt;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Kết xuất excel
        /// </summary>
        /// <param name="p_NameReport">tên kết xuất</param>
        /// <param name="p_file_name">tên kết xuất</param>
        /// <param name="p_arr">Dữ liệu cần để kết xuất</param>
        /// <param name="p_dictionary">Cột cần kết xuất</param>
        public static void Export_Excel(string p_NameReport, string p_file_name, ArrayList p_arr, Dictionary<string, string> p_dictionary)
        {
            try
            {
                if (p_arr.Count == 0)
                {
                    NoteBox.Show("Không dữ liệu có dữ liệu để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }

                if (p_dictionary.Count == 0)
                {
                    NoteBox.Show("Không có thông tin cột để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }

                // lấy những thằng mà có format là số
                Dictionary<string, string> _dictionary_format = new Dictionary<string, string>();
                Dictionary<string, string> _dictionary_colums = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in p_dictionary)
                {
                    string _column = (string)pair.Key;
                    string _name = (string)pair.Value;
                    string[] words = _column.Split(',');

                    _dictionary_colums.Add(words[0], _name);

                    if (words.Length > 1)
                    {
                        _dictionary_format.Add(_name.ToUpper(), words[1]);
                    }
                }

                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                DataTable _dt = new DataTable();
                ConvertData.ConvertArrayListToDataTable(p_arr, ref _dt);

                //Dictionary<string, string> dictionary = PrePare_Column_Name();

                DataTable _dt_export = CommonFunction.Rename_Colums_DataTable(_dt, _dictionary_colums);

                _dt_export.Columns.Add("STT");
                int index = 1;
                foreach (DataRow item in _dt_export.Rows)
                {
                    item["STT"] = index;
                    index++;
                }

                DataSet ds_resuft = new DataSet();
                ds_resuft.Tables.Add(_dt_export);
                ds_resuft.Tables[0].Columns["STT"].SetOrdinal(0);

                CommonFunction.ExportToFile(ds_resuft, p_NameReport, p_file_name, _dictionary_format);
                Mouse.OverrideCursor = null;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                NoteBox.Show(ex.Message);
                CommonData.log.Error(ex.ToString());
                NoteBox.Show("Kết xuất dữ liệu ra file không thành công", "Thông báo", NoteBoxLevel.Note);
            }
        }

        /// <summary>
        /// Kết xuất excel
        /// </summary>
        /// <param name="p_NameReport">tên kết xuất</param>
        /// <param name="p_file_name">tên kết xuất</param>
        /// <param name="p_arr">Dữ liệu cần để kết xuất</param>
        /// <param name="p_dictionary">Cột cần kết xuất</param>
        public static void Export_Excel_List<T>(string p_NameReport, string p_file_name, IList<T> p_list, Dictionary<string, string> p_dictionary)
        {
            try
            {
                if (p_list.Count == 0)
                {
                    NoteBox.Show("Không dữ liệu có dữ liệu để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }

                if (p_dictionary.Count == 0)
                {
                    NoteBox.Show("Không có thông tin cột để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }

                // lấy những thằng mà có format là số
                Dictionary<string, string> _dictionary_format = new Dictionary<string, string>();
                Dictionary<string, string> _dictionary_colums = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in p_dictionary)
                {
                    string _column = (string)pair.Key;
                    string _name = (string)pair.Value;
                    string[] words = _column.Split(',');

                    _dictionary_colums.Add(words[0], _name);

                    if (words.Length > 1)
                    {
                        _dictionary_format.Add(_name.ToUpper(), words[1]);
                    }
                }

                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                DataTable _dt = ConvertData.ConvertToDatatable(p_list);

                DataTable _dt_export = CommonFunction.Rename_Colums_DataTable(_dt, _dictionary_colums);

                _dt_export.Columns.Add("STT");
                int index = 1;
                foreach (DataRow item in _dt_export.Rows)
                {
                    item["STT"] = index;
                    index++;
                }

                DataSet ds_resuft = new DataSet();
                ds_resuft.Tables.Add(_dt_export);
                ds_resuft.Tables[0].Columns["STT"].SetOrdinal(0);

                CommonFunction.ExportToFile(ds_resuft, p_NameReport, p_file_name, _dictionary_format);
                Mouse.OverrideCursor = null;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                NoteBox.Show(ex.Message);
                CommonData.log.Error(ex.ToString());
                NoteBox.Show("Kết xuất dữ liệu ra file không thành công", "Thông báo", NoteBoxLevel.Note);
            }
        }

        /// <summary>
        /// Kết xuất excel
        /// </summary>
        /// <param name="p_NameReport">tên kết xuất</param>
        /// <param name="p_file_name">tên kết xuất</param>
        /// <param name="p_arr">Dữ liệu cần để kết xuất</param>
        /// <param name="p_dictionary">Cột cần kết xuất</param>
        public static void Export_Excel_Dataset(string p_NameReport, string p_file_name, DataTable p_dt, Dictionary<string, string> p_dictionary)
        {
            try
            {
                if (p_dt.Rows.Count == 0)
                {
                    NoteBox.Show("Không dữ liệu có dữ liệu để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }

                if (p_dictionary.Count == 0)
                {
                    NoteBox.Show("Không có thông tin cột để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }

                // lấy những thằng mà có format là số
                Dictionary<string, string> _dictionary_format = new Dictionary<string, string>();
                Dictionary<string, string> _dictionary_colums = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in p_dictionary)
                {
                    string _column = (string)pair.Key;
                    string _name = (string)pair.Value;
                    string[] words = _column.Split(',');

                    _dictionary_colums.Add(words[0], _name);

                    if (words.Length > 1)
                    {
                        _dictionary_format.Add(_name.ToUpper(), words[1]);
                    }
                }

                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                //DataTable _dt = new DataTable();
                //ConvertData.ConvertArrayListToDataTable(p_arr, ref _dt);

                //Dictionary<string, string> dictionary = PrePare_Column_Name();

                DataTable _dt_export = CommonFunction.Rename_Colums_DataTable(p_dt, _dictionary_colums);

                _dt_export.Columns.Add("STT");
                int index = 1;
                foreach (DataRow item in _dt_export.Rows)
                {
                    item["STT"] = index;
                    index++;
                }

                DataSet ds_resuft = new DataSet();
                ds_resuft.Tables.Add(_dt_export);
                ds_resuft.Tables[0].Columns["STT"].SetOrdinal(0);

                CommonFunction.ExportToFile(ds_resuft, p_NameReport, p_file_name, _dictionary_format);
                Mouse.OverrideCursor = null;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = null;
                NoteBox.Show(ex.Message);
                CommonData.log.Error(ex.ToString());
                NoteBox.Show("Kết xuất dữ liệu ra file không thành công", "Thông báo", NoteBoxLevel.Note);
            }
        }

        #endregion

        public static void Export_payment(Contract_Info _Contract_Info, Customer_Info _Customer_Info, Estate_Object_Info _Estate_Object_Info, Fees_Revenue_Info _Fees_Revenue_Info)
        {
            try
            {
                #region Kết xuất

                FlexCel.Report.FlexCelReport flcReport = new FlexCel.Report.FlexCelReport();
                string _path = CommonData.ExcelDesignFilePath;
                string _fileExcelName = "Payment_Request_VND.xls";
                if (_Contract_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                {
                    _fileExcelName = "Payment_Request_USD.xls";
                }
                _path += _fileExcelName;

                CommonFunction.SetValueExportByString(ref flcReport, "CurrentDate", DateTime.Now.ToString("dd/MM/yyyy"));

                CommonFunction.SetValueExportByString(ref flcReport, "Tenat_Name", _Customer_Info.Customer_Name);
                CommonFunction.SetValueExportByString(ref flcReport, "Address", _Customer_Info.Address);
                CommonFunction.SetValueExportByString(ref flcReport, "Users", _Contract_Info.Users);
                CommonFunction.SetValueExportByString(ref flcReport, "TaxCode", _Customer_Info.Tax_Code);

                CommonFunction.SetValueExportByString(ref flcReport, "Estate_Name", _Estate_Object_Info.Estate_Name);

                CommonFunction.SetValueExportByString(ref flcReport, "Contract_FromDate", _Contract_Info.Contract_FromDate.ToString("dd/MM/yyyy"));
                CommonFunction.SetValueExportByString(ref flcReport, "Contract_ToDate", _Contract_Info.Contract_ToDate.ToString("dd/MM/yyyy"));

                //decimal _VAT_Fee = Math.Round(_Fees_Revenue_Info.Fee_Expected * 10 / 100);
                //decimal _Fee = _Fees_Revenue_Info.Fee_Expected - _VAT_Fee;

                //decimal _p = 110 / 100;
                //decimal _Fee = _Fees_Revenue_Info.Fee_Expected / _p;
                //decimal _VAT_Fee = Math.Round(_Fee * 10 / 100);
                decimal _Fee = (_Fees_Revenue_Info.Fee_Expected /110) * 100;
                decimal _VAT_Fee = Math.Round(_Fee * 10 / 100);

                CommonFunction.SetValueExportByString(ref flcReport, "Fee", _Fee.ToString("###,##0"));
                CommonFunction.SetValueExportByString(ref flcReport, "VAT_Fee", _VAT_Fee.ToString("###,##0"));

                CommonFunction.SetValueExportByString(ref flcReport, "Total_Fee", _Fees_Revenue_Info.Fee_Expected.ToString("###,##0"));

                
                if (_Contract_Info.Contract_Type == (decimal)Enum_Contract_Type.Renter)
                {
                    CommonFunction.SetValueExportByString(ref flcReport, "KyThanhToan", "");
                }
                else
                {
                    #region Kỳ thanh toán

                    string _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                                    + " từ ngày " + _Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy") + " đến ngày " +
                                    _Fees_Revenue_Info.Pay_Date_Expected.AddDays(30).ToString("dd/MM/yyyy");

                    if (_Contract_Info.Term == (decimal)Enum_Fee_Maturity.One)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                                    + " từ ngày " + _Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy") + " đến ngày " +
                                    _Fees_Revenue_Info.Pay_Date_Expected.AddDays(30).ToString("dd/MM/yyyy");
                    }
                    else if (_Contract_Info.Term == (decimal)Enum_Fee_Maturity.One_Month)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.Pay_Date_Expected.AddMonths(1).ToString("dd/MM/yyyy");
                    }
                    else if (_Contract_Info.Term == (decimal)Enum_Fee_Maturity.Three_Month)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.Pay_Date_Expected.AddMonths(3).ToString("dd/MM/yyyy");
                    }
                    else if (_Contract_Info.Term == (decimal)Enum_Fee_Maturity.Six_Month)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.Pay_Date_Expected.AddMonths(6).ToString("dd/MM/yyyy");
                    }
                    else if (_Contract_Info.Term == (decimal)Enum_Fee_Maturity.One_Year)
                    {
                        _Kytt = "Thanh toán phí MG lần " + _Fees_Revenue_Info.Number_Payment
                        + " từ ngày " + _Fees_Revenue_Info.Pay_Date_Expected.ToString("dd/MM/yyyy") + " đến ngày " +
                        _Fees_Revenue_Info.Pay_Date_Expected.AddYears(1).ToString("dd/MM/yyyy");
                    }

                    CommonFunction.SetValueExportByString(ref flcReport, "KyThanhToan", _Kytt);

                    #endregion
                }

                if (_Contract_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                {
                    CommonFunction.SetValueExportByString(ref flcReport, "VND", _Fees_Revenue_Info.Fee_Vnd.ToString("###,##0"));
                }

                // dangtq chuyen ve datetim now

                //DateTime _dt_from = _Fees_Revenue_Info.Pay_Date_Expected;
                //DateTime _dt_To = _Fees_Revenue_Info.Pay_Date_Expected.AddDays(30);

                DateTime _dt_from = DateTime.Now;
                DateTime _dt_To = _dt_from.AddDays(30);

                CommonFunction.SetValueExportByString(ref flcReport, "From", _dt_from.ToString("dd/MM/yyyy"));
                CommonFunction.SetValueExportByString(ref flcReport, "To", _dt_To.ToString("dd/MM/yyyy"));

                if (_Contract_Info.Price != 0)
                    CommonFunction.SetValueExportByString(ref flcReport, "Price", _Contract_Info.Price.ToString("###,##0"));
                else
                    CommonFunction.SetValueExportByString(ref flcReport, "Price", "");

                string _tienBangChu = ConvertData.ConvertMoneyToStr(Convert.ToDouble(_Fees_Revenue_Info.Fee_Expected));
                if (_Contract_Info.Currency == (decimal)Enum_Contract_Currency.USD)
                {
                    Contract_Controller c_Contract_Controller = new Contract_Controller();
                    _tienBangChu = c_Contract_Controller.Convert_Dola(_Fees_Revenue_Info.Fee_Expected);
                }

                CommonFunction.SetValueExportByString(ref flcReport, "BangChu", _tienBangChu.ToLower());

                System.Windows.Forms.SaveFileDialog saveReport = new System.Windows.Forms.SaveFileDialog();
                saveReport.Filter = "Excel files (*.xls)|*.xls";
                if (saveReport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CommonFunction.ExportExcel(flcReport, _path, saveReport);
                }

                #endregion
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }
    }
}
