﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DotNetCore.Class
//{
//    public class _LOfficeExcel
//    {
//        public _LOfficeExcel()
//        {

//        }
//        public object misValue = System.Reflection.Missing.Value;
//        bool paramOpenAfterPublish = false;
//        bool paramIncludeDocProps = true;
//        bool paramIgnorePrintAreas = true;
//        object FixedFormatExtClassPtr = System.Reflection.Missing.Value;
//        object paramFromPage = Type.Missing;
//        object paramToPage = Type.Missing;

//        #region Thứ tự cột của Excel bắt đầu từ 1
//        public static string[] ColumsCell =
//            new string[] {
//            "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
//            "AA","AB","AC","AD","AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN","AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ",
//            "BA","BB","BC","BD","BE","BF","BG","BH","BI","BJ","BK","BL","BM","BN","BO","BP","BQ","BR","BS","BT","BU","BV","BW","BX","BY","BZ",
//            "CA","CB","CC","CD","CE","CF","CG","CH","CI","CJ","CK","CL","CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV","CW","CX","CY","CZ",
//            "DA","DB","DC","DD","DE","DF","DG","DH","DI","DJ","DK","DL","DM","DN","DO","DP","DQ","DR","DS","DT","DU","DV","DW","DX","DY","DZ",
//            "EA","EB","EC","ED","EE","EF","EG","EH","EI","EJ","EK","EL","EM","EN","EO","EP","EQ","ER","ES","ET","EU","EV","EW","EX","EY","EZ",
//            "FA","FB","FC","FD","FE","FF","FG","FH","FI","FJ","FK","FL","FM","FN","FO","FP","FQ","FR","FS","FT","FU","FV","FW","FX","FY","FZ",
//            "GA","GB","GC","GD","GE","GF","GG","GH","GI","GJ","GK","GL","GM","GN","GO","GP","GQ","GR","GS","GT","GU","GV","GW","GX","GY","GZ",
//            "HA","HB","HC","HD","HE","HF","HG","HH","HI","HJ","HK","HL","HM","HN","HO","HP","HQ","HR","HS","HT","HU","HV","HW","HX","HY","HZ"
//        };
//        #endregion

//        private int ColumsMin = -1, ColumsMax = -1, RowsMin = -1, RowsMax = -1, CountMinMax = -1;
//        private void GetColumRowMinMax(object cell1, object cell2)
//        {
//            try
//            {
//                for (int i = ColumsCell.Length - 1; i > 0; i--)
//                {
//                    try
//                    {
//                        if (cell1.ToString().IndexOf(ColumsCell[i]) != -1)
//                        {
//                            ColumsMin = i;
//                            RowsMin = Convert.ToInt32(cell1.ToString().Replace(ColumsCell[i], ""));
//                            break;
//                        }
//                    }
//                    catch
//                    { }
//                }
//                for (int i = ColumsCell.Length - 1; i > 0; i--)
//                {
//                    try
//                    {
//                        if (cell2.ToString().IndexOf(ColumsCell[i]) != -1)
//                        {
//                            ColumsMax = i;
//                            RowsMax = Convert.ToInt32(cell2.ToString().Replace(ColumsCell[i], ""));
//                            break;
//                        }
//                    }
//                    catch
//                    { }
//                }
//                CountMinMax = ((ColumsMax - ColumsMin) + 1) * ((RowsMax - ColumsMin) + 1);
//            }
//            catch
//            { }
//        }

//        private DataTable GetDaTaColum(int columCount)
//        {
//            DataTable DataTable = new DataTable();
//            if (columCount > 0)
//            {
//                for (int i = 0; i < columCount; i++)
//                {
//                    DataTable.Columns.Add("Column" + (i + 1).ToString(), typeof(string));
//                }
//            }
//            return DataTable;
//        }
//        private DataTable GetDaTaColumPicture(int columCount)
//        {
//            DataTable DataTable = new DataTable();
//            if (columCount > 0)
//            {
//                for (int i = 0; i < columCount; i++)
//                {
//                    DataTable.Columns.Add("Column" + (i + 1).ToString(), typeof(Image));
//                }
//            }
//            return DataTable;
//        }

//        public bool PrinterAllFile(string pathToPdf)
//        {
//            try
//            {
//                Process process = new Process();
//                string printerName = GetDefaultPrinter();
//                process.StartInfo.FileName = pathToPdf;
//                process.StartInfo.Verb = "printto";
//                process.StartInfo.Arguments = "\"" + printerName + "\"";
//                process.Start();

//                process.WaitForInputIdle();
//                process.Kill();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//        private string GetDefaultPrinter()
//        {
//            PrinterSettings settings = new PrinterSettings();
//            foreach (string printer in PrinterSettings.InstalledPrinters)
//            {
//                settings.PrinterName = printer;
//                if (settings.IsDefaultPrinter)
//                    return printer;
//            }
//            return string.Empty;
//        }
//        #region In dữ liệu HTML.
//        public void _mPrinterFileHTML(string htmlFileName)
//        {

//        }
//        #endregion
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pathOld">Đường dẫn vật lý đến ổ đĩa. Ví dụ: C:\ABC.xls</param>
//        /// <param name="urlFolderNew">Đường dẫn vật lý tới thư mục cần copy file vào. Ví dụ: D:\newfolder</param>
//        /// <param name="fileNameNew">Tên file mới có phần mở rộng. Ví dụ ABC.xls</param>
//        /// <param name="deleteAllFileInFolderNew">True nếu muốn xóa hết file trong thư mục mới</param>
//        public void CopyFiles(string pathFileOld, string urlFolderNew, string fileNameNew, bool deleteAllFileInFolderNew)
//        {
//            string urlFolder = urlFolderNew;
//            if (!System.IO.Directory.Exists(urlFolder))
//            {
//                System.IO.Directory.CreateDirectory(urlFolder);
//            }
//            if (deleteAllFileInFolderNew == true)
//            {
//                DirectoryInfo di = new DirectoryInfo(urlFolder);
//                FileInfo[] rgFiles = di.GetFiles();
//                foreach (FileInfo fi in rgFiles)
//                {
//                    fi.Delete();
//                }
//            }
//            System.IO.File.Copy(pathFileOld, urlFolderNew + "/" + fileNameNew);
//        }
//        /// <summary>
//        /// Chuyển số kiểu Interger sang kiểu số la mã
//        /// </summary>
//        /// <param name="num">Tham số kiểu Integer</param>
//        /// <returns>string</returns>
//        public string IntToRoman(int num)
//        {
//            string[] thou = { "", "M", "MM", "MMM" };
//            string[] hun = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
//            string[] ten = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
//            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
//            string roman = "";
//            roman += thou[(int)(num / 1000) % 10];
//            roman += hun[(int)(num / 100) % 10];
//            roman += ten[(int)(num / 10) % 10];
//            roman += ones[num % 10];

//            return roman;
//        }
//        /// <summary>
//        /// Chuyển kiểu số sang kiểu chuỗi
//        /// </summary>
//        /// <param name="num">Kiểu số Integer</param>
//        /// <param name="toUpper">True nếu muốn trả về in hoa. False nếu muốn trả về in thường</param>
//        /// <returns>string</returns>
//        public string IntToAlphabet(int num, bool toUpper)
//        {
//            if (toUpper == true)
//            {
//                return ((char)(num + 64)).ToString();
//            }
//            else
//            {
//                return ((char)(num + 96)).ToString();
//            }
//        }

//        /// <summary>
//        /// Nối datatable
//        /// </summary>
//        /// <param name="dt">Danh sách table</param>
//        /// <returns></returns>
//        public DataTable JoinDataTable(object[] dt)
//        {
//            DataTable result = new DataTable();
//            for (int i = 0; i < dt.Length; i++)
//            {
//                if (i == 0)
//                {
//                    result = ((DataTable)dt[i]).Copy();
//                }
//                else
//                {
//                    if (((DataTable)dt[i]).Rows.Count > 0)
//                    {

//                        for (int j = 0; j < ((DataTable)dt[i]).Rows.Count; j++)
//                        {
//                            for (int k = 0; k < ((DataTable)dt[i]).Columns.Count; k++)
//                            {
//                                result.Rows.Add();
//                                result.Rows[result.Rows.Count - 1][j] = ((DataTable)dt[i]).Rows[j][k];
//                            }
//                        }
//                    }
//                }
//            }

//            return result;
//        }

//        public void exPortExcel1Group(ref XLWorkbook wb, DataTable tab, bool xuatGroup, int kieuXuat, string[] cotXuat, ref int dongXuat, string rangeStart, string rangeEnd, bool sum, bool sumTop, bool xuatSTT, int kieuXuatSTT, string[] cotTong)
//        {
//            _LOfficeExcel _vLOfficeExcel = new _LOfficeExcel();
//            //bien su dung
//            int stt = 0;
//            var ws = wb.Worksheet(1);
//            string nhom1 = "";
//            int sttNhom = 0;
//            int index = 0;
//            //tong dau
//            if (sum == true && sumTop == true)
//            {
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).InsertRowsBelow(1);
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).CopyTo(ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat));
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.SetBold(true).Alignment.SetWrapText(true).Border.SetTopBorder(XLBorderStyleValues.Thin).Border.SetBottomBorder(XLBorderStyleValues.Thin).Border.SetRightBorder(XLBorderStyleValues.Thin).Border.SetLeftBorder(XLBorderStyleValues.Thin);

//                ws.Cell(cotTong[0] + dongXuat).Value = cotTong[1];
//                for (int j = 2; j < cotTong.Length; j++)
//                {
//                    // ws.Cell(cotXuat[int.Parse(cotTong[j])] + dongXuat).Value = tongCot(tab, int.Parse(cotTong[j]), xuatSTT);
//                    index = int.Parse(cotTong[j].ToString());
//                    ws.Cell(cotXuat[int.Parse(cotTong[j])] + dongXuat).Value = tab.Compute("Sum(" + tab.Columns[index].ColumnName + ")", "");// tongCot(tab, int.Parse(cotTong[j]), false);
//                }
//                dongXuat += 1;
//            }
//            for (int i = 0; i < tab.Rows.Count; i++)
//            {
//                if (xuatGroup == false)
//                {//xuat khong co nhom
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).InsertRowsBelow(1);
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).CopyTo(ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat));
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Alignment.SetWrapText(true).Font.SetBold(false).Border.SetTopBorder(XLBorderStyleValues.Dotted).Border.SetBottomBorder(XLBorderStyleValues.Dotted);
//                    if (xuatSTT == true)
//                    {
//                        stt += 1;
//                        ws.Cell(cotXuat[0] + dongXuat).Value = stt.ToString();
//                        for (int j = 1; j < cotXuat.Length; j++)
//                        {
//                            ws.Cell(cotXuat[j] + dongXuat).Value = tab.Rows[i][j - 1].ToString();
//                        }
//                    }
//                    else
//                    {
//                        for (int j = 0; j < cotXuat.Length; j++)
//                        {
//                            ws.Cell(cotXuat[j] + dongXuat).Value = tab.Rows[i][j].ToString();
//                        }
//                    }
//                }
//                //xuat du lieu co nhom
//                else
//                {
//                    if (xuatSTT == true)
//                    {//xuat dong group
//                        if (nhom1 != tab.Rows[i][0].ToString())
//                        {
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).InsertRowsBelow(1);
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).CopyTo(ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat));
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.SetBold(true).Alignment.SetWrapText(true).Border.SetTopBorder(XLBorderStyleValues.Thin).Border.SetBottomBorder(XLBorderStyleValues.Thin).Border.SetRightBorder(XLBorderStyleValues.Thin).Border.SetLeftBorder(XLBorderStyleValues.Thin);
//                            nhom1 = tab.Rows[i][0].ToString();
//                            sttNhom += 1; stt = 0;
//                            if (kieuXuat == 1) ws.Cell(cotXuat[0] + dongXuat).Value = sttNhom.ToString();
//                            else
//                                if (kieuXuat == 2) ws.Cell(cotXuat[0] + dongXuat).Value = _vLOfficeExcel.IntToRoman(sttNhom).ToString();
//                            else
//                                    if (kieuXuat == 3) ws.Cell(cotXuat[0] + dongXuat).Value = _vLOfficeExcel.IntToAlphabet(sttNhom, false).ToString();
//                            else
//                                        if (kieuXuat == 4) ws.Cell(cotXuat[0] + dongXuat).Value = _vLOfficeExcel.IntToAlphabet(sttNhom, true).ToString();
//                            ws.Cell(cotXuat[1] + dongXuat).Value = nhom1;
//                            index = 0;
//                            for (int j = 2; j < cotTong.Length; j++)
//                            {
//                                index = int.Parse(cotTong[j].ToString());
//                                ws.Cell(cotXuat[int.Parse(cotTong[j])] + dongXuat).Value = tab.Compute("Sum(" + tab.Columns[index].ColumnName + ")", "tenNhom='" + nhom1 + "'");// tongCot(tab, int.Parse(cotTong[j]), false);
//                            }

//                            dongXuat += 1;
//                        }
//                        //xuat stt
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).InsertRowsBelow(1);
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).CopyTo(ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat));
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Alignment.SetWrapText(true).Border.SetTopBorder(XLBorderStyleValues.Dashed).Border.SetBottomBorder(XLBorderStyleValues.Dashed).Border.SetRightBorder(XLBorderStyleValues.Thin).Border.SetLeftBorder(XLBorderStyleValues.Thin);

//                        stt += 1;
//                        if (kieuXuatSTT == 1) ws.Cell(cotXuat[0] + dongXuat).Value = stt.ToString();
//                        else
//                            if (kieuXuatSTT == 2) ws.Cell(cotXuat[0] + dongXuat).Value = "'" + sttNhom.ToString() + "." + stt.ToString();
//                        for (int j = 1; j < cotXuat.Length; j++)
//                        {
//                            ws.Cell(cotXuat[j] + dongXuat).Value = tab.Rows[i][j].ToString();
//                        }
//                    }
//                    else
//                    {
//                        if (nhom1 != tab.Rows[i][0].ToString())
//                        {
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).InsertRowsBelow(1);
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).CopyTo(ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat));
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Alignment.WrapText = true;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = XLBorderStyleValues.Thin;

//                            nhom1 = tab.Rows[i][0].ToString();
//                            ws.Cell(cotXuat[1] + dongXuat).Value = nhom1;
//                            dongXuat += 1;
//                        }
//                        //xuat stt
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).InsertRowsBelow(1);
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).CopyTo(ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat));
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Alignment.WrapText = true;
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = XLBorderStyleValues.Dotted;
//                        for (int j = 2; j < cotXuat.Length; j++)
//                        {
//                            ws.Cell(cotXuat[j] + dongXuat).Value = tab.Rows[i][j].ToString();
//                        }
//                    }
//                }
//                dongXuat += 1;
//            }
//            //tong chan
//            if (sum == true && sumTop == false)
//            {
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).InsertRowsBelow(1);
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).CopyTo(ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat));
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Alignment.WrapText = true;
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = true;
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = XLBorderStyleValues.Thin;
//                ws.Cell(cotTong[0] + dongXuat).Value = cotTong[1];
//                index = 0;
//                for (int j = 2; j < cotTong.Length; j++)
//                {
//                    index = int.Parse(cotTong[j].ToString());
//                    ws.Cell(cotXuat[int.Parse(cotTong[j])] + dongXuat).Value = tab.Compute("Sum(" + tab.Columns[index].ColumnName + ")", "");// tongCot(tab, int.Parse(cotTong[j]), false);

//                }
//                dongXuat += 1;
//            }
//            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Delete(XLShiftDeletedCells.ShiftCellsUp);
//            ws.Range(rangeStart + (dongXuat - 1) + ":" + rangeEnd + (dongXuat - 1)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
//        }

//        public void xuatKyTen(ref XLWorkbook wb, string[] mKyTen, int dongXuat, bool hienNgayBC, string ngayIn, string diaDanh)
//        {
//            var ws = wb.Worksheet(1);
//            ws.Cell(mKyTen[0].Split('-')[0].ToString() + dongXuat).Style.Font.SetItalic(true).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
//            ws.Range(mKyTen[0].Split('-')[0].ToString() + dongXuat, mKyTen[0].Split('-')[1].ToString() + dongXuat).Merge();
//            if (hienNgayBC == true)
//            {
//                ws.Cell(mKyTen[0].Split('-')[0].ToString() + dongXuat).Value = diaDanh
//                + ", ngày " + ngayIn.Substring(0, 2)
//                + " tháng " + ngayIn.Substring(3, 2)
//                + " năm " + ngayIn.Substring(6, 4);
//            }
//            else
//            {
//                ws.Cell(mKyTen[0].Split('-')[0].ToString() + dongXuat).Value = "......., ngày.....tháng....năm.....";
//            }
//            for (int i = 1; i < mKyTen.Length; i++)
//            {
//                dongXuat += 1;
//                ws.Row(dongXuat).Style.Font.SetBold(true).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetWrapText(true);
//                ws.Range(mKyTen[i].Split('-')[0].ToString() + dongXuat, mKyTen[i].Split('-')[1].ToString() + dongXuat).Merge();
//                ws.Cell(mKyTen[i].Split('-')[0].ToString() + dongXuat).Value = mKyTen[i].Split('-')[2].ToString();
//                dongXuat += 1;
//                ws.Row(dongXuat).Style.Font.SetItalic(true).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetWrapText(true);
//                ws.Range(mKyTen[i].Split('-')[0].ToString() + dongXuat, mKyTen[i].Split('-')[1].ToString() + dongXuat).Merge();
//                ws.Cell(mKyTen[i].Split('-')[0].ToString() + dongXuat).Value = mKyTen[i].Split('-')[3].ToString();
//                dongXuat += 5;
//                ws.Row(dongXuat).Style.Font.SetBold(true).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetWrapText(true);
//                ws.Range(mKyTen[i].Split('-')[0].ToString() + dongXuat, mKyTen[i].Split('-')[1].ToString() + dongXuat).Merge();
//                ws.Cell(mKyTen[i].Split('-')[0].ToString() + dongXuat).Value = mKyTen[i].Split('-')[4].ToString();

//                dongXuat -= 7;
//            }
//        }
//        public void xuatKyTen(ref XLWorkbook wb, int sttSheet, string[] mKyTen, int dongXuat, bool hienNgayBC, string ngayIn, string diaDanh)
//        {
//            var ws = wb.Worksheet(sttSheet).SetTabActive();
//            ws.Cell(mKyTen[0].Split('-')[0].ToString() + dongXuat).Style.Font.SetItalic(true).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
//            ws.Range(mKyTen[0].Split('-')[0].ToString() + dongXuat, mKyTen[0].Split('-')[1].ToString() + dongXuat).Merge();
//            if (hienNgayBC == true)
//            {
//                ws.Cell(mKyTen[0].Split('-')[0].ToString() + dongXuat).Value = diaDanh
//                + ", ngày " + ngayIn.Substring(0, 2)
//                + " tháng " + ngayIn.Substring(3, 2)
//                + " năm " + ngayIn.Substring(6, 4);
//            }
//            else
//            {
//                ws.Cell(mKyTen[0].Split('-')[0].ToString() + dongXuat).Value = "......., ngày.....tháng....năm.....";
//            }
//            for (int i = 1; i < mKyTen.Length; i++)
//            {
//                dongXuat += 1;
//                ws.Row(dongXuat).Style.Font.SetBold(true).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetWrapText(true);
//                ws.Range(mKyTen[i].Split('-')[0].ToString() + dongXuat, mKyTen[i].Split('-')[1].ToString() + dongXuat).Merge();
//                ws.Cell(mKyTen[i].Split('-')[0].ToString() + dongXuat).Value = mKyTen[i].Split('-')[2].ToString();
//                dongXuat += 1;
//                ws.Row(dongXuat).Style.Font.SetItalic(true).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetWrapText(true);
//                ws.Range(mKyTen[i].Split('-')[0].ToString() + dongXuat, mKyTen[i].Split('-')[1].ToString() + dongXuat).Merge();
//                ws.Cell(mKyTen[i].Split('-')[0].ToString() + dongXuat).Value = mKyTen[i].Split('-')[3].ToString();
//                dongXuat += 5;
//                ws.Row(dongXuat).Style.Font.SetBold(true).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetWrapText(true);
//                ws.Range(mKyTen[i].Split('-')[0].ToString() + dongXuat, mKyTen[i].Split('-')[1].ToString() + dongXuat).Merge();
//                ws.Cell(mKyTen[i].Split('-')[0].ToString() + dongXuat).Value = mKyTen[i].Split('-')[4].ToString();

//                dongXuat -= 7;
//            }
//        }
//        public int WriteExcel(XLWorkbook wb, DataTable result, int startRows, int startColumns, bool checkInsert)
//        {
//            int rowsEpx = startRows;
//            try
//            {
//                var ws = wb.Worksheet("Sheet1");
//                if (result.Rows.Count > 0)
//                {
//                    for (int i = 0; i < result.Rows.Count; i++)
//                    {
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, result.Columns.Count).InsertRowsBelow(1);
//                        }
//                        for (int j = startColumns; j < result.Columns.Count - 3; j++)//excel tính từ dòng 1 cột 1
//                        {
//                            ws.Cell(rowsEpx, j + 1).Value = result.Rows[i][j].ToString();
//                        }
//                        if (result.Rows[i][result.Columns.Count - 3].ToString() == "True")
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, result.Columns.Count - 3).Style.Font.Bold = true;
//                        }
//                        if (result.Rows[i][result.Columns.Count - 2].ToString() == "True")
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, result.Columns.Count - 3).Style.Font.Italic = true;
//                        }
//                        if (result.Rows[i][result.Columns.Count - 1].ToString() == "True")
//                        {
//                            if (result.Rows[i - 1][result.Columns.Count - 1].ToString() == "False")
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, result.Columns.Count - 3).Style.Border.BottomBorder = XLBorderStyleValues.Dotted;
//                            }
//                            else
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, result.Columns.Count - 3).Style.Border.TopBorder = XLBorderStyleValues.Dotted;
//                            }
//                        }
//                        rowsEpx += 1;
//                        //if (i == result.Rows.Count - 1)
//                        //{
//                        //    ws.Range(i, 1, rowsEpx, result.Columns.Count - 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
//                        //    ws.Range(rowsEpx + 1, 1, rowsEpx + 1, result.Columns.Count - 3).Delete(XLShiftDeletedCells.ShiftCellsUp);
//                        //}
//                    }
//                }
//                return rowsEpx;
//            }
//            catch
//            {
//                return rowsEpx;
//            }
//        }
//        /// <summary>
//        /// Xuất dữ liệu ra excel
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="idGroup3">STT group 3</param>
//        /// <param name="idGroup4">STT group 4</param>
//        /// <param name="idGroup5">STT group 5</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel5Group(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, int idGroup3, int idGroup4, int idGroup5, bool checkSum, string labelSum)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int colEpx = startColumns;
//            int flag = 0;
//            var ws = wb.Worksheet("Sheet1");
//            try
//            {
//                string group1 = "", group2 = "", group3 = "", group4 = "", group5 = "";
//                int colContent = 6;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && flag == 0)
//                    {
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx + 1).Value = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        flag += 1;
//                    }
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {
//                        if (group2 == dt.Rows[i][2].ToString())//cot 2 chứa nhóm 2
//                        {
//                            if (group3 == dt.Rows[i][3].ToString())//cot 3 chứa nhóm 3
//                            {
//                                if (group4 == dt.Rows[i][4].ToString())//cot 4 chứa nhóm 4
//                                {
//                                    if (dt.Rows[i][5].ToString() != "")//kiểm tra nếu nhóm 5!=""
//                                    {
//                                        //    //Them dòng tên dự án
//                                        group5 = dt.Rows[i][5].ToString();
//                                        idGroup5 += 1;
//                                        if (checkInsert)
//                                        {
//                                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                                        }
//                                        ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup5, false);
//                                        colEpx += 1;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][5];
//                                        for (int c = colContent + 1; c <= colSumEnd; c++)
//                                        {
//                                            if (c < colSumStart)
//                                            {
//                                                colEpx += 1;
//                                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                                            }
//                                            else if (c > colSumStart || c <= colSumEnd)
//                                            {
//                                                colEpx += 1;
//                                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//                                            }
//                                        }
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                        rowsEpx += 1;
//                                        colEpx = startColumns;
//                                        //Kiểm tra xem dự án có 1 hay 2 dòng
//                                        if (dt.Rows[i][4].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][4].ToString() && dt.Rows[i][5].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][5].ToString() && dt.Rows.Count > 1 && dt.Rows[i][6].ToString() != "" && i < dt.Rows.Count - 1) //tên dự án dòng trên trùng tên dự án dòng dưới
//                                        {
//                                            //xuat dong nguồn trong nước
//                                            if (checkInsert)
//                                            {
//                                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                                            }
//                                            colEpx += 1;
//                                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][6];
//                                            for (int c = colSumStart; c <= colSumEnd; c++)
//                                            {
//                                                colEpx = c - colContent + 2;
//                                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                            }
//                                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                            rowsEpx += 1;
//                                            colEpx = startColumns;
//                                            //xuất tiếp nguồn ngoài nước
//                                            if (checkInsert)
//                                            {
//                                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                                            }
//                                            colEpx += 1;
//                                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i + 1][6];
//                                            for (int c = colSumStart; c <= colSumEnd; c++)
//                                            {
//                                                colEpx = c - colContent + 2;
//                                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i + 1][c];
//                                            }
//                                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                            rowsEpx += 1;
//                                            colEpx = startColumns;
//                                            i += 1;
//                                        }
//                                        else if (dt.Rows[i][6].ToString() == "")
//                                        {
//                                            //i += 1;
//                                        }
//                                        else
//                                        {
//                                            //tên dự án dòng trên khác tên dự án dòng dưới
//                                            if (checkInsert)
//                                            {
//                                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                                            }
//                                            colEpx += 1;
//                                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][6];
//                                            for (int c = colSumStart; c <= colSumEnd; c++)
//                                            {
//                                                colEpx = c - colContent + 2;
//                                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                            }
//                                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                            rowsEpx += 1;
//                                            colEpx = startColumns;
//                                        }
//                                    }
//                                    else
//                                    {
//                                        //tên dự án dòng trên khác tên dự án dòng dưới
//                                        if (checkInsert)
//                                        {
//                                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                                        }
//                                        colEpx += 1;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][6];
//                                        for (int c = colSumStart; c <= colSumEnd; c++)
//                                        {
//                                            colEpx = c - colContent + 2;
//                                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                        }
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                        rowsEpx += 1;
//                                        colEpx = startColumns;
//                                    }
//                                }
//                                else
//                                {
//                                    //Them dòng nhóm 4
//                                    group4 = dt.Rows[i][4].ToString();
//                                    if (checkInsert)
//                                    {
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                                    }
//                                    idGroup4 += 1;
//                                    idGroup5 = 0;
//                                    ws.Cell(rowsEpx, colEpx).Value = "'" + idGroup3.ToString() + "." + idGroup4.ToString();
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][4];
//                                    for (int c = colSumStart; c <= colSumEnd; c++)
//                                    {
//                                        colEpx = c - colContent + 2;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//                                    }
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Font.Bold = true;
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Font.Italic = true;
//                                    rowsEpx += 1;
//                                    colEpx = startColumns;
//                                    i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                                }
//                            }
//                            else
//                            {
//                                //Them dòng nhóm 3
//                                group3 = dt.Rows[i][3].ToString();
//                                group4 = "";
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                                }
//                                idGroup3 += 1;
//                                idGroup4 = 0;
//                                idGroup5 = 0;
//                                ws.Cell(rowsEpx, colEpx).Value = idGroup3.ToString();
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][3];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Font.Bold = true;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                                i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                            }
//                        }
//                        else
//                        {
//                            //Them dòng nhóm 2
//                            group2 = dt.Rows[i][2].ToString();
//                            group3 = "";
//                            group4 = "";
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                            }
//                            idGroup2 += 1;
//                            idGroup3 = 0;
//                            idGroup4 = 0;
//                            idGroup5 = 0;
//                            ws.Cell(rowsEpx, colEpx).Value = IntToRoman(idGroup2);
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Font.Bold = true;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        group3 = "";
//                        group4 = "";
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).InsertRowsBelow(1);
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        idGroup3 = 0;
//                        idGroup4 = 0;
//                        idGroup5 = 0;
//                        ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup1, true);
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            //ghi số tiền vào cột 7 trên file excel: colSumStart=11; colContent=6
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 5).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }
//                }
//                arr[0] = rowsEpx;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString() + "-" + idGroup3.ToString() + "-" + idGroup4.ToString() + "-" + idGroup5.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất dữ liệu 6 group
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="idGroup3">STT group 3</param>
//        /// <param name="idGroup4">STT group 4</param>
//        /// <param name="idGroup5">STT group 5</param>
//        /// <param name="idGroup6">STT group 6</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <param name="expDetailSum">Xuất nội dung sau dòng tổng cộng</param>
//        /// <param name="expDetailGroup1">Xuất nội dung sau dòng nhóm 1</param>
//        /// <param name="expDetailGroup2">Xuất nội dung sau dòng nhóm 2</param>
//        /// <param name="expDetailGroup3">Xuất nội dung sau dòng nhóm 3</param>
//        /// <param name="expDetailGroup4">Xuất nội dung sau dòng nhóm 4</param>
//        /// <param name="expDetailGroup5">Xuất nội dung sau dòng nhóm 5</param>
//        /// <param name="expDetailGroup6">Xuất nội dung sau dòng nhóm 6</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel6Group(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, int idGroup3, int idGroup4, int idGroup5, int idGroup6, bool checkSum, string labelSum, bool expDetailSum, bool expDetailGroup1, bool expDetailGroup2, bool expDetailGroup3, bool expDetailGroup4, bool expDetailGroup5, bool expDetailGroup6)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int colEpx = startColumns;
//            int flag = 0;
//            var ws = wb.Worksheet("Sheet1");
//            DataTable detail = null;
//            try
//            {
//                string group1 = "", group2 = "", group3 = "", group4 = "", group5 = "", group6 = "";
//                int colContent = 7;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && flag == 0)
//                    {
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx + 1).Value = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        //kiểm tra xuất detail của nhóm tổng cộng
//                        if (expDetailSum == true)
//                        {
//                            //xuat dong nguồn trong nước
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                            }
//                            DataView dtView = new DataView(dt);
//                            detail = dtView.ToTable(true, dt.Columns[7].ColumnName.ToString());
//                            for (int b = 0; b < detail.Rows.Count; b++)
//                            {
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = detail.Rows[b][0];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[7].ColumnName + "='" + detail.Rows[b][0] + "'");
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                            }
//                        }
//                        flag += 1;
//                    }
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {
//                        if (group2 == dt.Rows[i][2].ToString())//cot 2 chứa nhóm 2
//                        {
//                            if (group3 == dt.Rows[i][3].ToString())//cot 3 chứa nhóm 3
//                            {
//                                if (group4 == dt.Rows[i][4].ToString())//cot 4 chứa nhóm 4
//                                {
//                                    if (group5 == dt.Rows[i][5].ToString())//cot 5 chứa nhóm 5
//                                    {
//                                        if (group6 == dt.Rows[i][6].ToString())//cot 6 chứa nhóm 6
//                                        {
//                                            if (dt.Rows[i][3].ToString() == "Nguồn vốn XDCB tập trung")
//                                            {
//                                                idGroup6 += 1;
//                                                if (checkInsert)
//                                                {
//                                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                                }
//                                                ws.Cell(rowsEpx, colEpx).Value = "";
//                                                colEpx += 1;
//                                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][7];
//                                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                                {
//                                                    colEpx = c - colContent + 2;
//                                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                                }
//                                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                                rowsEpx += 1;
//                                                colEpx = startColumns;
//                                            }
//                                        }
//                                        else
//                                        {
//                                            //Them dòng nhóm 6, dòng dự án
//                                            group6 = dt.Rows[i][6].ToString();
//                                            if (checkInsert)
//                                            {
//                                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                            }
//                                            idGroup6 += 1;
//                                            ws.Cell(rowsEpx, colEpx).Value = "-";
//                                            colEpx += 1;
//                                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][6];
//                                            for (int c = colContent + 1; c <= colSumEnd; c++)
//                                            {
//                                                if (c < colSumStart)
//                                                {
//                                                    colEpx += 1;
//                                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                                                }
//                                                else if (c > colSumStart || c <= colSumEnd)
//                                                {
//                                                    colEpx += 1;
//                                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "' AND " + dt.Columns[6].ColumnName + "='" + group6 + "'");
//                                                }
//                                            }
//                                            rowsEpx += 1;
//                                            colEpx = startColumns;
//                                            //kiểm tra xuất detail của nhóm tổng cộng
//                                            if (expDetailGroup6 == true)
//                                            {
//                                                //xuat dong nguồn trong nước
//                                                if (checkInsert)
//                                                {
//                                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                                }
//                                                DataView dtView = new DataView(dt);
//                                                detail = dtView.ToTable(true, dt.Columns[1].ColumnName.ToString(), dt.Columns[7].ColumnName.ToString());
//                                                for (int b = 0; b < detail.Rows.Count; b++)
//                                                {
//                                                    colEpx += 1;
//                                                    ws.Cell(rowsEpx, colEpx).Value = detail.Rows[b][1];
//                                                    for (int c = colSumStart; c <= colSumEnd; c++)
//                                                    {
//                                                        colEpx = c - colContent + 2;
//                                                        ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "' AND " + dt.Columns[6].ColumnName + "='" + group6 + "' AND " + dt.Columns[7].ColumnName + "='" + detail.Rows[b][1] + "'");
//                                                    }
//                                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                                    rowsEpx += 1;
//                                                    colEpx = startColumns;
//                                                }
//                                            }
//                                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                                        }
//                                    }
//                                    else
//                                    {
//                                        //Them dòng nhóm 5
//                                        group5 = dt.Rows[i][5].ToString();
//                                        group6 = "";
//                                        if (checkInsert)
//                                        {
//                                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                        }
//                                        idGroup5 += 1;
//                                        idGroup6 = 0;
//                                        ws.Cell(rowsEpx, colEpx).Value = "*";
//                                        colEpx += 1;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][5];
//                                        for (int c = colSumStart; c <= colSumEnd; c++)
//                                        {
//                                            colEpx = c - colContent + 2;
//                                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//                                        }
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                        rowsEpx += 1;
//                                        colEpx = startColumns;
//                                        //kiểm tra xuất detail của nhóm tổng cộng
//                                        if (expDetailGroup5 == true)
//                                        {
//                                            //xuat dong nguồn trong nước
//                                            if (checkInsert)
//                                            {
//                                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                            }
//                                            DataView dtView = new DataView(dt);
//                                            detail = dtView.ToTable(true, dt.Columns[1].ColumnName.ToString(), dt.Columns[7].ColumnName.ToString());
//                                            for (int b = 0; b < detail.Rows.Count; b++)
//                                            {
//                                                colEpx += 1;
//                                                ws.Cell(rowsEpx, colEpx).Value = detail.Rows[b][1];
//                                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                                {
//                                                    colEpx = c - colContent + 2;
//                                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "' AND " + dt.Columns[7].ColumnName + "='" + detail.Rows[b][1] + "'");
//                                                }
//                                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                                rowsEpx += 1;
//                                                colEpx = startColumns;
//                                            }
//                                        }
//                                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                                    }
//                                }
//                                else
//                                {
//                                    //Them dòng nhóm 4
//                                    group4 = dt.Rows[i][4].ToString();
//                                    group5 = "";
//                                    group6 = "";
//                                    if (checkInsert)
//                                    {
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                    }
//                                    idGroup4 += 1;
//                                    idGroup5 = 0;
//                                    idGroup6 = 0;
//                                    ws.Cell(rowsEpx, colEpx).Value = "'" + idGroup3.ToString() + "." + idGroup4.ToString();
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][4];
//                                    for (int c = colSumStart; c <= colSumEnd; c++)
//                                    {
//                                        colEpx = c - colContent + 2;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//                                    }
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Font.Bold = true;
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Font.Italic = true;
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                    rowsEpx += 1;
//                                    colEpx = startColumns;
//                                    //kiểm tra xuất detail của nhóm tổng cộng
//                                    if (expDetailGroup4 == true)
//                                    {
//                                        //xuat dong nguồn trong nước
//                                        if (checkInsert)
//                                        {
//                                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                        }
//                                        DataView dtView = new DataView(dt);
//                                        detail = dtView.ToTable(true, dt.Columns[1].ColumnName.ToString(), dt.Columns[7].ColumnName.ToString());
//                                        for (int b = 0; b < detail.Rows.Count; b++)
//                                        {
//                                            colEpx += 1;
//                                            ws.Cell(rowsEpx, colEpx).Value = detail.Rows[b][1];
//                                            for (int c = colSumStart; c <= colSumEnd; c++)
//                                            {
//                                                colEpx = c - colContent + 2;
//                                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[7].ColumnName + "='" + detail.Rows[b][1] + "'");
//                                            }
//                                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                            rowsEpx += 1;
//                                            colEpx = startColumns;
//                                        }
//                                    }
//                                    i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                                }
//                            }
//                            else
//                            {
//                                //Them dòng nhóm 3
//                                group3 = dt.Rows[i][3].ToString();
//                                group4 = "";
//                                group5 = "";
//                                group6 = "";
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                }
//                                idGroup3 += 1;
//                                idGroup4 = 0;
//                                idGroup5 = 0;
//                                idGroup6 = 0;
//                                ws.Cell(rowsEpx, colEpx).Value = idGroup3.ToString();
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][3];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Font.Bold = true;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                                //kiểm tra xuất detail của nhóm tổng cộng
//                                if (expDetailGroup3 == true)
//                                {
//                                    //xuat dong nguồn trong nước
//                                    if (checkInsert)
//                                    {
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                    }
//                                    DataView dtView = new DataView(dt);
//                                    detail = dtView.ToTable(true, dt.Columns[1].ColumnName.ToString(), dt.Columns[7].ColumnName.ToString());
//                                    for (int b = 0; b < detail.Rows.Count; b++)
//                                    {
//                                        colEpx += 1;
//                                        ws.Cell(rowsEpx, colEpx).Value = detail.Rows[b][1];
//                                        for (int c = colSumStart; c <= colSumEnd; c++)
//                                        {
//                                            colEpx = c - colContent + 2;
//                                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[7].ColumnName + "='" + detail.Rows[b][1] + "'");
//                                        }
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                        rowsEpx += 1;
//                                        colEpx = startColumns;
//                                    }
//                                }
//                                i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                            }
//                        }
//                        else
//                        {
//                            //Them dòng nhóm 2
//                            group2 = dt.Rows[i][2].ToString();
//                            group3 = "";
//                            group4 = "";
//                            group5 = "";
//                            group6 = "";
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                            }
//                            idGroup2 += 1;
//                            idGroup3 = 0;
//                            idGroup4 = 0;
//                            idGroup5 = 0;
//                            idGroup6 = 0;
//                            ws.Cell(rowsEpx, colEpx).Value = IntToRoman(idGroup2);
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Font.Bold = true;
//                            rowsEpx += 1;
//                            colEpx = startColumns;

//                            //kiểm tra xuất detail của nhóm tổng cộng
//                            if (expDetailGroup2 == true)
//                            {
//                                //xuat dong nguồn trong nước
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                                }
//                                DataView dtView = new DataView(dt);
//                                detail = dtView.ToTable(true, dt.Columns[1].ColumnName.ToString(), dt.Columns[7].ColumnName.ToString());
//                                for (int b = 0; b < detail.Rows.Count; b++)
//                                {
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = detail.Rows[b][1];
//                                    for (int c = colSumStart; c <= colSumEnd; c++)
//                                    {
//                                        colEpx = c - colContent + 2;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[7].ColumnName + "='" + detail.Rows[b][1] + "'");
//                                    }
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                    rowsEpx += 1;
//                                    colEpx = startColumns;
//                                }
//                            }
//                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        group3 = "";
//                        group4 = "";
//                        group5 = "";
//                        group6 = "";
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        idGroup3 = 0;
//                        idGroup4 = 0;
//                        idGroup5 = 0;
//                        idGroup6 = 0;
//                        ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup1, true);
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            //ghi số tiền vào cột 7 trên file excel: colSumStart=11; colContent=6
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;

//                        //kiểm tra xuất detail của nhóm tổng cộng
//                        if (expDetailGroup1 == true)
//                        {
//                            //xuat dong nguồn trong nước
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).InsertRowsBelow(1);
//                            }
//                            DataView dtView = new DataView(dt);
//                            detail = dtView.ToTable(true, dt.Columns[1].ColumnName.ToString(), dt.Columns[7].ColumnName.ToString());
//                            for (int b = 0; b < detail.Rows.Count; b++)
//                            {
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = detail.Rows[b][1];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[7].ColumnName + "='" + detail.Rows[b][1] + "'");
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 6).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                            }
//                        }
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }
//                }
//                arr[0] = rowsEpx;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString() + "-" + idGroup3.ToString() + "-" + idGroup4.ToString() + "-" + idGroup5.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất dữ liệu ra excel
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="idGroup3">STT group 3</param>
//        /// <param name="idGroup4">STT group 4</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel4Group(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, int idGroup3, int idGroup4, bool checkSum, string labelSum)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int idSTTDuan = 0;
//            int colEpx = startColumns;
//            int flag = 0;
//            var ws = wb.Worksheet("Sheet1");
//            try
//            {
//                string group1 = "", group2 = "", group3 = "", group4 = "";
//                int colContent = 5;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && flag == 0)
//                    {
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx + 1).Value = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        flag += 1;
//                    }
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {
//                        if (group2 == dt.Rows[i][2].ToString())//cot 2 chứa nhóm 2
//                        {
//                            if (group3 == dt.Rows[i][3].ToString())//cot 3 chứa nhóm 3
//                            {
//                                if (group4 == dt.Rows[i][4].ToString())
//                                {
//                                    //Xuất dòng dự án thứ 1
//                                    if (checkInsert)
//                                    {
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).InsertRowsBelow(1);
//                                    }
//                                    idSTTDuan += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idSTTDuan, false);
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][5];
//                                    for (int c = colSumStart; c <= colSumEnd; c++)
//                                    {
//                                        colEpx = c - colContent + 2;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                    }
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                    rowsEpx += 1;
//                                    colEpx = startColumns;
//                                }
//                                else
//                                {
//                                    //Them dòng nhóm 4
//                                    group4 = dt.Rows[i][4].ToString();
//                                    if (checkInsert)
//                                    {
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).InsertRowsBelow(1);
//                                    }
//                                    idGroup4 += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = idGroup4.ToString();
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][4];
//                                    for (int c = colSumStart; c <= colSumEnd; c++)
//                                    {
//                                        colEpx = c - colContent + 2;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//                                    }
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).Style.Font.Bold = true;
//                                    rowsEpx += 1;
//                                    colEpx = startColumns;
//                                    i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                                }
//                            }
//                            else
//                            {
//                                //Them dòng nhóm 3
//                                group3 = dt.Rows[i][3].ToString();
//                                group4 = "";
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).InsertRowsBelow(1);
//                                }
//                                idGroup3 += 1;
//                                idGroup4 = 0;
//                                idSTTDuan = 0;
//                                ws.Cell(rowsEpx, colEpx).Value = idGroup3.ToString();
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][3];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).Style.Font.Bold = true;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                                i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                            }
//                        }
//                        else
//                        {
//                            //Them dòng nhóm 2
//                            group2 = dt.Rows[i][2].ToString();
//                            group3 = "";
//                            group4 = "";
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).InsertRowsBelow(1);
//                            }
//                            idGroup2 += 1;
//                            idGroup3 = 0;
//                            idGroup4 = 0;
//                            idSTTDuan = 0;
//                            ws.Cell(rowsEpx, colEpx).Value = IntToRoman(idGroup2);
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).Style.Font.Bold = true;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        group3 = "";
//                        group4 = "";
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).InsertRowsBelow(1);
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        idGroup3 = 0;
//                        idGroup4 = 0;
//                        idSTTDuan = 0;
//                        ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup1, true);
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            //ghi số tiền vào cột 7 trên file excel: colSumStart=11; colContent=6
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 4).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }
//                }
//                arr[0] = rowsEpx;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString() + "-" + idGroup3.ToString() + "-" + idGroup4.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất dữ liệu ra excel (3Group, STT [Gr1: A; Gr2: I; Gr3: 1])
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="idGroup3">STT group 3</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel3GroupA(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, int idGroup3, bool checkSum, string labelSum)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int colEpx = startColumns;
//            var ws = wb.Worksheet("Sheet1");
//            try
//            {
//                string group1 = "", group2 = "", group3 = "";
//                int colContent = 4;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {
//                        if (group2 == dt.Rows[i][2].ToString())//cot 2 chứa nhóm 2
//                        {

//                            //Them dòng tên dự án
//                            group3 = dt.Rows[i][3].ToString();
//                            idGroup3 += 1;
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).InsertRowsBelow(1);
//                            }
//                            ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup3, false);
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][3];
//                            for (int c = colContent + 1; c <= colSumEnd; c++)
//                            {
//                                if (c < colSumStart)
//                                {
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                                }
//                                else if (c > colSumStart || c <= colSumEnd)
//                                {
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                                }
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                            //Kiểm tra xem dự án có 1 hay 2 dòng
//                            if (dt.Rows[i][2].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][2].ToString() && dt.Rows[i][3].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][3].ToString() && dt.Rows.Count > 1 && i < dt.Rows.Count - 1) //tên dự án dòng trên trùng tên dự án dòng dưới
//                            {
//                                //xuat dong nguồn trong nước
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                                }
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][4];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                                //xuất tiếp nguồn ngoài nước
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                                }
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i + 1][4];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i + 1][c];
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                                i += 1;
//                            }
//                            else //tên dự án dòng trên khác tên dự án dòng dưới
//                            {
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                                }
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][4];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                            }
//                        }
//                        else
//                        {
//                            //Them dòng nhóm 2
//                            group2 = dt.Rows[i][2].ToString();
//                            group3 = "";
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                            }
//                            idGroup2 += 1;
//                            idGroup3 = 0;
//                            ws.Cell(rowsEpx, colEpx).Value = IntToRoman(idGroup2);
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Font.Bold = true;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        group3 = "";
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        idGroup3 = 0;
//                        ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup1, true);
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            //ghi số tiền vào cột 7 trên file excel: colSumStart=11; colContent=6
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }
//                }
//                arr[0] = rowsEpx;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString() + "-" + idGroup3.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất dữ liệu ra excel (3Group, STT [Gr1: 1; Gr2: 1.1; Gr3: a])
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="idGroup3">STT group 3</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel3Group1(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, int idGroup3, bool checkSum, string labelSum)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int colEpx = startColumns;
//            int flag = 0;
//            var ws = wb.Worksheet("Sheet1");
//            try
//            {
//                string group1 = "", group2 = "", group3 = "";
//                int colContent = 4;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && flag == 0)
//                    {
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx + 1).Value = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        flag += 1;
//                    }
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {
//                        if (group2 == dt.Rows[i][2].ToString())//cot 2 chứa nhóm 2
//                        {
//                            if (dt.Rows[i][3].ToString() != "")
//                            {
//                                //Xuất nhóm dự án
//                                group3 = dt.Rows[i][3].ToString();
//                                idGroup3 += 1;
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).InsertRowsBelow(1);
//                                }
//                                ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup3, false);
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][3];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                                //Kiểm tra xem dự án có 1 hay 2 dòng
//                                if (dt.Rows[i][2].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][2].ToString() && dt.Rows[i][3].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][3].ToString() && dt.Rows.Count > 1 && i < dt.Rows.Count - 1) //tên dự án dòng trên trùng tên dự án dòng dưới
//                                {
//                                    //xuat dong nguồn trong nước
//                                    if (checkInsert)
//                                    {
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                                    }
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][4];
//                                    for (int c = colContent + 1; c <= colSumEnd; c++)
//                                    {
//                                        colEpx = c - colContent + 2;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                    }
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                    rowsEpx += 1;
//                                    colEpx = startColumns;
//                                    //xuất tiếp nguồn ngoài nước
//                                    if (checkInsert)
//                                    {
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                                    }
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i + 1][4];
//                                    for (int c = colContent + 1; c <= colSumEnd; c++)
//                                    {
//                                        colEpx = c - colContent + 2;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i + 1][c];
//                                    }
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                    rowsEpx += 1;
//                                    colEpx = startColumns;
//                                    i += 1;
//                                }
//                                else //tên dự án dòng trên khác tên dự án dòng dưới
//                                {
//                                    if (checkInsert)
//                                    {
//                                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                                    }
//                                    colEpx += 1;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][4];
//                                    for (int c = colContent + 1; c <= colSumEnd; c++)
//                                    {
//                                        colEpx = c - colContent + 2;
//                                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                    }
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                    rowsEpx += 1;
//                                    colEpx = startColumns;
//                                }
//                            }
//                            else
//                            {
//                                if (checkInsert)
//                                {
//                                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                                }
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][4];
//                                for (int c = colContent + 1; c <= colSumEnd; c++)
//                                {
//                                    colEpx = c - colContent + 2;
//                                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                                }
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                                rowsEpx += 1;
//                                colEpx = startColumns;
//                            }
//                        }
//                        else
//                        {
//                            //Them dòng nhóm 2
//                            group2 = dt.Rows[i][2].ToString();
//                            group3 = "";
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                            }
//                            idGroup2 += 1;
//                            idGroup3 = 0;
//                            ws.Cell(rowsEpx, colEpx).Value = "'" + idGroup1.ToString() + "." + idGroup2.ToString();
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Font.Bold = true;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        group3 = "";
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).InsertRowsBelow(1);
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        idGroup3 = 0;
//                        ws.Cell(rowsEpx, colEpx).Value = idGroup1.ToString();
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            //ghi số tiền vào cột 7 trên file excel: colSumStart=11; colContent=6
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 3).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }
//                }
//                arr[0] = rowsEpx;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString() + "-" + idGroup3.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất dữ liệu ra excel
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel2Group(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, bool checkSum, string labelSum)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int colEpx = startColumns;
//            var ws = wb.Worksheet("Sheet1");
//            try
//            {
//                string group1 = "", group2 = "";
//                int colContent = 3;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {
//                        //Them dòng tên dự án
//                        group2 = dt.Rows[i][2].ToString();
//                        idGroup2 += 1;
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup2, false);
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                        for (int c = colContent + 1; c <= colSumEnd; c++)
//                        {
//                            if (c < colSumStart)
//                            {
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                            }
//                            else if (c > colSumStart || c <= colSumEnd)
//                            {
//                                colEpx += 1;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' ");
//                            }
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        //Kiểm tra xem dự án có 1 hay 2 dòng
//                        if (dt.Rows[i][1].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][1].ToString() && dt.Rows[i][2].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][2].ToString() && dt.Rows.Count > 1 && i < dt.Rows.Count - 1) //tên dự án dòng trên trùng tên dự án dòng dưới
//                        {
//                            //xuat dong nguồn trong nước
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).InsertRowsBelow(1);
//                            }
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][3];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                            //xuất tiếp nguồn ngoài nước
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).InsertRowsBelow(1);
//                            }
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i + 1][3];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i + 1][c];
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                            i += 1;
//                        }
//                        else //tên dự án dòng trên khác tên dự án dòng dưới
//                        {
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).InsertRowsBelow(1);
//                            }
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][3];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).InsertRowsBelow(1);
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        ws.Cell(rowsEpx, colEpx).Value = IntToAlphabet(idGroup1, true);
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            //ghi số tiền vào cột 7 trên file excel: colSumStart=11; colContent=6
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 2).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }
//                }
//                arr[0] = rowsEpx;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất dữ liệu 1 group, STT đánh số 1,2,3
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <param name="expDetailSum">Xuất chi tiết dưới dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel1GroupID1(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, int idGroup1, bool checkSum, string labelSum, bool expDetailSum)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int colEpx = startColumns;
//            int flag = 0;
//            int colContent = 2;
//            var ws = wb.Worksheet("Sheet1");
//            try
//            {
//                string group1 = "";
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && flag == 0)
//                    {
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx + 1).Value = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        //kiểm tra xuất detail của nhóm tổng cộng
//                        if (expDetailSum == true)
//                        {
//                            //xuat dong nguồn trong nước
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).InsertRowsBelow(1);
//                            }
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[2].ColumnName + "='" + dt.Rows[i][2] + "' ");
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                        }
//                        flag += 1;
//                    }
//                    if (group1 == dt.Rows[i][1].ToString())
//                    {
//                        //xuat dong nguồn trong nước
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).InsertRowsBelow(1);
//                        }
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                        for (int c = colContent + 1; c <= colSumEnd; c++)
//                        {
//                            colEpx = c;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                    }
//                    else
//                    {
//                        //Xuất dòng group
//                        group1 = dt.Rows[i][1].ToString();
//                        idGroup1 += 1;
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx).Value = idGroup1.ToString();
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1];
//                        for (int c = colContent + 1; c <= colSumEnd; c++)
//                        {
//                            if (c < colSumStart)
//                            {
//                                colEpx = c;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                            }
//                            else if (c > colSumStart || c <= colSumEnd)
//                            {
//                                colEpx = c;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' ");
//                            }
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        i -= 1;
//                    }
//                }
//                arr[0] = rowsEpx;
//                arr[1] = idGroup1.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất dữ liệu 1 group, STT đánh số 1,2,3
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <param name="expDetailSum">Xuất chi tiết dưới dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel1GroupNoneID(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, string idGroup1, bool checkSum, string labelSum, bool expDetailSum)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int colEpx = startColumns;
//            int flag = 0;
//            int colContent = 2;
//            var ws = wb.Worksheet("Sheet1");
//            try
//            {
//                string group1 = "";
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && flag == 0)
//                    {
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx + 1).Value = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            colEpx = c - colContent + 2;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        //kiểm tra xuất detail của nhóm tổng cộng
//                        if (expDetailSum == true)
//                        {
//                            //xuat dong nguồn trong nước
//                            if (checkInsert)
//                            {
//                                ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).InsertRowsBelow(1);
//                            }
//                            colEpx += 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                colEpx = c - colContent + 2;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[2].ColumnName + "='" + dt.Rows[i][2] + "' ");
//                            }
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                            rowsEpx += 1;
//                            colEpx = startColumns;
//                        }
//                        flag += 1;
//                    }
//                    if (group1 == dt.Rows[i][1].ToString())
//                    {
//                        //xuat dong nguồn trong nước
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).InsertRowsBelow(1);
//                        }
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][2];
//                        for (int c = colContent + 1; c <= colSumEnd; c++)
//                        {
//                            colEpx = c;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                    }
//                    else
//                    {
//                        //Xuất dòng group
//                        group1 = dt.Rows[i][1].ToString();
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx).Value = idGroup1.ToString();
//                        colEpx += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1];
//                        for (int c = colContent + 1; c <= colSumEnd; c++)
//                        {
//                            if (c < colSumStart)
//                            {
//                                colEpx = c;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                            }
//                            else if (c > colSumStart || c <= colSumEnd)
//                            {
//                                colEpx = c;
//                                ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' ");
//                            }
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count - 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        i -= 1;
//                    }
//                }
//                arr[0] = rowsEpx;
//                arr[1] = idGroup1.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất dữ liệu ra excel
//        /// </summary>
//        /// <param name="wb">Wordkbook cần của file excel</param>
//        /// <param name="startRows">Dòng bắt đầu ghi dữ liệu trên file excel (Tính từ 1)</param>
//        /// <param name="startColumns">Cột bắt đầu ghi dữ liệu ra file excel (Tính từ 1)</param>
//        /// <param name="checkInsert">Trước khi ghi có insert dòng trống không</param>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum trên datatable (Tính từ 0)</param>
//        /// <param name="colSumEnd">Cột kết thúc sum trên datatable</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] WriteExcel0Group(XLWorkbook wb, int startRows, int startColumns, bool checkInsert, DataTable dt, int colSumStart, int colSumEnd, int id, bool checkSum, string labelSum, bool epxID)
//        {
//            object[] arr = new object[2];
//            int rowsEpx = startRows;
//            int colEpx = startColumns;
//            var ws = wb.Worksheet("Sheet1");
//            int flag = 0;
//            try
//            {
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && flag == 0)
//                    {
//                        if (checkInsert)
//                        {
//                            ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count).InsertRowsBelow(1);
//                        }
//                        ws.Cell(rowsEpx, colEpx).Value = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            colEpx = c + 1;
//                            ws.Cell(rowsEpx, colEpx).Value = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count).Style.Font.Bold = true;
//                        rowsEpx += 1;
//                        colEpx = startColumns;
//                        flag += 1;
//                    }
//                    //Them dòng tên dự án
//                    if (checkInsert)
//                    {
//                        ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count).InsertRowsBelow(1);
//                    }
//                    //kiểm tra xuất STT
//                    if (epxID == true)
//                    {
//                        id += 1;
//                        ws.Cell(rowsEpx, colEpx).Value = id.ToString();
//                        colEpx += 1;
//                    }
//                    ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][1];
//                    for (int c = colSumStart; c <= colSumEnd; c++)
//                    {
//                        colEpx = c + 1;
//                        ws.Cell(rowsEpx, colEpx).Value = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                    }
//                    ws.Range(rowsEpx, 1, rowsEpx, dt.Columns.Count).Style.Border.TopBorder = XLBorderStyleValues.Dashed;
//                    rowsEpx += 1;
//                    colEpx = startColumns;
//                }
//                arr[0] = rowsEpx;
//                arr[1] = id.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất DataTable 5 nhóm
//        /// </summary>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="idGroup3">STT group 3</param>
//        /// <param name="idGroup4">STT group 4</param>
//        /// <param name="idGroup5">STT group 5</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] getTable5Group(DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, int idGroup3, int idGroup4, int idGroup5, bool checkSum, string labelSum)
//        {
//            object[] arr = new object[2];

//            DataTable tblDes = dt.Copy();
//            DataColumn colAddID = tblDes.Columns.Add("ID", System.Type.GetType("System.String"));
//            DataColumn colAddBold = tblDes.Columns.Add("Bold", System.Type.GetType("System.Boolean"));
//            DataColumn colAddItalic = tblDes.Columns.Add("Italic", System.Type.GetType("System.Boolean"));
//            DataColumn colAddBorder = tblDes.Columns.Add("Border", System.Type.GetType("System.Boolean"));
//            try
//            {
//                tblDes.Columns.Remove(tblDes.Columns[6]);//bỏ cột loaiNguon
//                tblDes.Columns.Remove(tblDes.Columns[0]);//bỏ cột sttSort
//                tblDes.Columns.Remove(tblDes.Columns[0]);//bỏ cột nhóm 1
//                tblDes.Columns.Remove(tblDes.Columns[0]);//bỏ cột nhóm 2
//                tblDes.Columns.Remove(tblDes.Columns[0]);//bỏ cột nhóm 3
//                tblDes.Columns.Remove(tblDes.Columns[0]);//bỏ cột nhóm 4
//                tblDes.Rows.Clear();
//                string group1 = "", group2 = "", group3 = "", group4 = "", group5 = "";
//                int colContent = 6;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {
//                        if (group2 == dt.Rows[i][2].ToString())//cot 2 chứa nhóm 2
//                        {
//                            if (group3 == dt.Rows[i][3].ToString())//cot 3 chứa nhóm 3
//                            {
//                                if (group4 == dt.Rows[i][4].ToString())//cot 4 chứa nhóm 4
//                                {
//                                    //Them dòng tên dự án
//                                    tblDes.Rows.Add();
//                                    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][5];//cột 5 chứa nhóm 5
//                                    group5 = dt.Rows[i][5].ToString();
//                                    idGroup5 += 1;
//                                    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup5, false);
//                                    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                                    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                                    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";

//                                    for (int c = colContent + 1; c <= colSumEnd; c++)
//                                    {
//                                        if (c < colSumStart)
//                                        {
//                                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                                        }
//                                        else if (c > colSumStart || c <= colSumEnd)
//                                        {
//                                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//                                        }
//                                    }
//                                    //Kiểm tra xem dự án có 1 hay 2 dòng
//                                    if (dt.Rows[i][4].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][4].ToString() && dt.Rows[i][5].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][5].ToString() && dt.Rows.Count > 1) //tên dự án dòng trên trùng tên dự án dòng dưới
//                                    {
//                                        tblDes.Rows.Add();
//                                        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][6];//cột 6 chứa nội dung
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                                        for (int c = colSumStart; c <= colSumEnd; c++)
//                                        {
//                                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//                                        }
//                                        tblDes.Rows.Add();
//                                        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i + 1][6];//cột 6 chứa nội dung
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                                        for (int c = colSumStart; c <= colSumEnd; c++)
//                                        {
//                                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i + 1][c];
//                                        }
//                                        i += 1;
//                                    }
//                                    else //tên dự án dòng trên khác tên dự án dòng dưới
//                                    {
//                                        //xảy ra lỗi khi xét dòng cuối cùng nên phải kiểm tra (i+1) với rowcount
//                                        tblDes.Rows.Add();
//                                        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][6];//cột 6 chứa nội dung
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                                        for (int c = colSumStart; c <= colSumEnd; c++)
//                                        {
//                                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//                                        }
//                                    }
//                                }
//                                else
//                                {//Them dòng nhóm 4
//                                    group4 = dt.Rows[i][4].ToString();
//                                    tblDes.Rows.Add();
//                                    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][4];
//                                    for (int c = colSumStart; c <= colSumEnd; c++)
//                                    {
//                                        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//                                    }
//                                    idGroup4 += 1;
//                                    idGroup5 = 0;
//                                    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = "'" + idGroup3.ToString() + "." + idGroup4.ToString();
//                                    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                                    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "True";
//                                    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                                    i -= 1; //xử lý tiếp dòng dữ liệu hiện hành
//                                }
//                            }
//                            else
//                            {//Them dòng nhóm 3
//                                group3 = dt.Rows[i][3].ToString();
//                                group4 = "";
//                                tblDes.Rows.Add();
//                                tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                                }
//                                idGroup3 += 1;
//                                idGroup4 = 0;
//                                idGroup5 = 0;
//                                tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = idGroup3.ToString();
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                                i -= 1; //xử lý tiếp dòng dữ liệu hiện hành
//                            }
//                        }
//                        else
//                        {
//                            //Them dòng nhóm 2
//                            group2 = dt.Rows[i][2].ToString();
//                            group3 = "";
//                            group4 = "";
//                            tblDes.Rows.Add();
//                            tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                            }
//                            idGroup2 += 1;
//                            idGroup3 = 0;
//                            idGroup4 = 0;
//                            idGroup5 = 0;
//                            tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToRoman(idGroup2);
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành1
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        group3 = "";
//                        group4 = "";
//                        tblDes.Rows.Add();
//                        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        idGroup3 = 0;
//                        idGroup4 = 0;
//                        idGroup5 = 0;
//                        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup1, true);
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }


//                    //if (checkSum == true && i == 0)
//                    //{
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = labelSum.ToUpper();
//                    //    for (int c = colSumStart; c <= colSumEnd; c++)
//                    //    {
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                    //    }
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    //}
//                    //#region "nếu nhóm 1 khác nhom 1 thì xuất nhóm 1,2,3,4,5"
//                    //if (group1 != dt.Rows[i][1].ToString() && dt.Rows[i][1].ToString()!="")//nếu nhóm 1 khác nhom 1 thì xuất nhóm 1,2,3,4,5
//                    //{
//                    //    //Them dòng nhóm 1
//                    //    group1 = dt.Rows[i][1].ToString();
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][1].ToString().ToUpper();
//                    //    for (int c = colSumStart; c <= colSumEnd; c++)
//                    //    {
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                    //    }
//                    //    idGroup1 += 1;
//                    //    idGroup2 = 0;
//                    //    idGroup3 = 0;
//                    //    idGroup4 = 0;
//                    //    idGroup5 = 0;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup1, true);
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";

//                    //    //Them dòng nhóm 2
//                    //    if (dt.Rows[i][2].ToString() != "")
//                    //    {
//                    //        group2 = dt.Rows[i][2].ToString();
//                    //        tblDes.Rows.Add();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][2];
//                    //        for (int c = colSumStart; c <= colSumEnd; c++)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                    //        }
//                    //        idGroup2 += 1;
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToRoman(idGroup2);
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    //    }

//                    //    //Them dòng nhóm 3
//                    //    if (dt.Rows[i][3].ToString() != "")
//                    //    {
//                    //        group3 = dt.Rows[i][3].ToString();
//                    //        tblDes.Rows.Add();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];
//                    //        for (int c = colSumStart; c <= colSumEnd; c++)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                    //        }
//                    //        idGroup3 += 1;
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = idGroup3.ToString();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    //    }
//                    //    //Them dòng nhóm 4
//                    //    if (dt.Rows[i][4].ToString() != "")
//                    //    {
//                    //        group4 = dt.Rows[i][4].ToString();
//                    //        tblDes.Rows.Add();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][4];
//                    //        for (int c = colSumStart; c <= colSumEnd; c++)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//                    //        }
//                    //        idGroup4 += 1;
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = "'" + idGroup3.ToString() + "." + idGroup4.ToString();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    //    }
//                    //    //Them dòng tên dự án
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][5];//cột 5 chứa nhóm 5
//                    //    group5 = dt.Rows[i][5].ToString();

//                    //    for (int c = colContent + 1; c <= colSumEnd; c++)
//                    //    {
//                    //        if (c < colSumStart)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                    //        }
//                    //        else if (c > colSumStart || c <= colSumEnd)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//                    //        }
//                    //    }
//                    //    idGroup5 += 1;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup5, false);
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                    //}
//                    //#endregion

//                    //#region "nếu nhóm 2 khác nhom 2 thì xuất nhóm 2,3,4,5"
//                    //if (group2 != dt.Rows[i][2].ToString() && dt.Rows[i][2].ToString() != "")//nếu nhóm 1 khác nhom 1 thì xuất nhóm 1,2,3,4,5
//                    //{
//                    //    //Them dòng nhóm 2
//                    //    group2 = dt.Rows[i][2].ToString();
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][2];
//                    //    for (int c = colSumStart; c <= colSumEnd; c++)
//                    //    {
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                    //    }
//                    //    idGroup2 += 1;
//                    //    idGroup3 = 0;
//                    //    idGroup4 = 0;
//                    //    idGroup5 = 0;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToRoman(idGroup2);
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";

//                    //    //Them dòng nhóm 3
//                    //    if (dt.Rows[i][3].ToString() != "")
//                    //    {
//                    //        group3 = dt.Rows[i][3].ToString();
//                    //        tblDes.Rows.Add();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];
//                    //        for (int c = colSumStart; c <= colSumEnd; c++)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                    //        }
//                    //        idGroup3 += 1;
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = idGroup3.ToString();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    //    }

//                    //    //Them dòng nhóm 4
//                    //    if (dt.Rows[i][4].ToString() != "")
//                    //    {
//                    //        group4 = dt.Rows[i][4].ToString();
//                    //        tblDes.Rows.Add();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][4];
//                    //        for (int c = colSumStart; c <= colSumEnd; c++)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//                    //        }
//                    //        idGroup4 += 1;
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = "'" + idGroup3.ToString() + "." + idGroup4.ToString();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    //    }
//                    //    //Them dòng tên dự án
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][5];//cột 5 chứa nhóm 5
//                    //    group5 = dt.Rows[i][5].ToString();

//                    //    for (int c = colContent + 1; c <= colSumEnd; c++)
//                    //    {
//                    //        if (c < colSumStart)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                    //        }
//                    //        else if (c > colSumStart || c <= colSumEnd)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//                    //        }
//                    //    }
//                    //    idGroup5 += 1;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup5, false);
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                    //}
//                    //#endregion

//                    //#region "nếu nhóm 3 khác nhom 3 thì xuất nhóm 3,4,5"
//                    //if (group3 != dt.Rows[i][3].ToString() && dt.Rows[i][3].ToString()!="")//nếu nhóm 1 khác nhom 1 thì xuất nhóm 1,2,3,4,5
//                    //{
//                    //    //Them dòng nhóm 3
//                    //    group3 = dt.Rows[i][3].ToString();
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];
//                    //    for (int c = colSumStart; c <= colSumEnd; c++)
//                    //    {
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                    //    }
//                    //    idGroup3 += 1;
//                    //    idGroup4 = 0;
//                    //    idGroup5 = 0;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = idGroup3.ToString();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";

//                    //    //Them dòng nhóm 4
//                    //    if (dt.Rows[i][4].ToString() != "")
//                    //    {
//                    //        group4 = dt.Rows[i][4].ToString();
//                    //        tblDes.Rows.Add();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][4];
//                    //        for (int c = colSumStart; c <= colSumEnd; c++)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//                    //        }
//                    //        idGroup4 += 1;
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = "'" + idGroup3.ToString() + "." + idGroup4.ToString();
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "True";
//                    //        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    //    }
//                    //    //Them dòng tên dự án
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][5];//cột 5 chứa nhóm 5
//                    //    group5 = dt.Rows[i][5].ToString();

//                    //    for (int c = colContent + 1; c <= colSumEnd; c++)
//                    //    {
//                    //        if (c < colSumStart)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                    //        }
//                    //        else if (c > colSumStart || c <= colSumEnd)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//                    //        }
//                    //    }
//                    //    idGroup5 += 1;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup5, false);
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                    //}
//                    //#endregion

//                    //#region "nếu nhóm 4 khác nhom 5 thì xuất nhóm 4,5"
//                    //if (group4 != dt.Rows[i][4].ToString() && dt.Rows[i][4].ToString() != "")//nếu nhóm 1 khác nhom 1 thì xuất nhóm 1,2,3,4,5
//                    //{
//                    //    //Them dòng nhóm 4
//                    //    group4 = dt.Rows[i][4].ToString();
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][4];
//                    //    for (int c = colSumStart; c <= colSumEnd; c++)
//                    //    {
//                    //        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//                    //    }
//                    //    idGroup4 += 1;
//                    //    idGroup5 = 0;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = "'" + idGroup3.ToString() + "." + idGroup4.ToString();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "True";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";

//                    //    //Them dòng tên dự án
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][5];//cột 5 chứa nhóm 5
//                    //    group5 = dt.Rows[i][5].ToString();

//                    //    for (int c = colContent + 1; c <= colSumEnd; c++)
//                    //    {
//                    //        if (c < colSumStart)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                    //        }
//                    //        else if (c > colSumStart || c <= colSumEnd)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//                    //        }
//                    //    }
//                    //    idGroup5 += 1;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup5, false);
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                    //}
//                    //#endregion

//                    //#region "nếu nhóm 5 khác nhom 6 thì xuất nhóm 5"
//                    //if (group5 != dt.Rows[i][5].ToString() && dt.Rows[i][5].ToString()!="")//nếu nhóm 1 khác nhom 1 thì xuất nhóm 1,2,3,4,5
//                    //{
//                    //    //Them dòng tên dự án
//                    //    tblDes.Rows.Add();
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][5];//cột 5 chứa nhóm 5
//                    //    group5 = dt.Rows[i][5].ToString();

//                    //    for (int c = colContent + 1; c <= colSumEnd; c++)
//                    //    {
//                    //        if (c < colSumStart)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                    //        }
//                    //        else if (c > colSumStart || c <= colSumEnd)
//                    //        {
//                    //            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//                    //        }
//                    //    }
//                    //    idGroup5 += 1;
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup5, false);
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                    //}
//                    //#endregion

//                    //#region "Cuối cùng xuất nội dung"
//                    ////Them dòng tên dự án
//                    //tblDes.Rows.Add();
//                    //tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][6];//cột 6 chứa nội dung
//                    //for (int c = colContent + 5; c < dt.Columns.Count; c++)
//                    //{
//                    //    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//                    //}
//                    //tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                    //tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                    //tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                    //#endregion

//                }
//                colAddID.SetOrdinal(0);//set cột STT về vị trí đầu tiên
//                arr[0] = tblDes;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString() + "-" + idGroup3.ToString() + "-" + idGroup4.ToString() + "-" + idGroup5.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        /// <summary>
//        /// Xuất DataTable 4 nhóm
//        /// </summary>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="idGroup3">STT group 3</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] getTable3Group(DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, int idGroup3, bool checkSum, string labelSum)
//        {
//            object[] arr = new object[2];

//            DataTable tblDes = dt.Copy();
//            DataColumn colAddID = tblDes.Columns.Add("ID", System.Type.GetType("System.String"));
//            DataColumn colAddBold = tblDes.Columns.Add("Bold", System.Type.GetType("System.Boolean"));
//            DataColumn colAddItalic = tblDes.Columns.Add("Italic", System.Type.GetType("System.Boolean"));
//            DataColumn colAddBorder = tblDes.Columns.Add("Border", System.Type.GetType("System.Boolean"));
//            try
//            {
//                tblDes.Columns.Remove(tblDes.Columns[4]);//bỏ cột loaiNguon
//                tblDes.Columns.Remove(tblDes.Columns[0]);//bỏ cột sttSort
//                tblDes.Columns.Remove(tblDes.Columns[0]);//bỏ cột nhom1
//                tblDes.Columns.Remove(tblDes.Columns[0]);//bỏ cột nhom2
//                tblDes.Rows.Clear();
//                string group1 = "", group2 = "", group3 = "";
//                int colContent = 4;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && i == 0)
//                    {
//                        tblDes.Rows.Add();
//                        tblDes.Rows[tblDes.Rows.Count - 1][0] = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    }
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {
//                        if (group2 == dt.Rows[i][2].ToString())//cot 2 chứa nhóm 2
//                        {
//                            //Them dòng tên dự án
//                            tblDes.Rows.Add();
//                            tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];//cột 5 chứa nhóm 5
//                            group3 = dt.Rows[i][3].ToString();
//                            idGroup3 += 1;
//                            tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup3, false);
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";

//                            for (int c = colContent + 1; c <= colSumEnd; c++)
//                            {
//                                if (c < colSumStart)
//                                {
//                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                                }
//                                else if (c > colSumStart || c <= colSumEnd)
//                                {
//                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//                                }
//                            }
//                            //Kiểm tra xem dự án có 1 hay 2 dòng
//                            if (dt.Rows[i][2].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][2].ToString() && dt.Rows[i][3].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][3].ToString() && dt.Rows.Count > 1) //tên dự án dòng trên trùng tên dự án dòng dưới
//                            {
//                                tblDes.Rows.Add();
//                                tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][4];//cột 6 chứa nội dung
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//                                }
//                                tblDes.Rows.Add();
//                                tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i + 1][4];//cột 6 chứa nội dung
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i + 1][c];
//                                }
//                                i += 1;
//                            }
//                            else //tên dự án dòng trên khác tên dự án dòng dưới
//                            {
//                                //xảy ra lỗi khi xét dòng cuối cùng nên phải kiểm tra (i+1) với rowcount
//                                tblDes.Rows.Add();
//                                tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][4];//cột 6 chứa nội dung
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                                tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                                for (int c = colSumStart; c <= colSumEnd; c++)
//                                {
//                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//                                }
//                            }
//                        }
//                        else
//                        {
//                            //Them dòng nhóm 2
//                            group2 = dt.Rows[i][2].ToString();
//                            group3 = "";
//                            tblDes.Rows.Add();
//                            tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][2];
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//                            }
//                            idGroup2 += 1;
//                            idGroup3 = 0;
//                            tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToRoman(idGroup2);
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành1
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        group3 = "";
//                        tblDes.Rows.Add();
//                        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colContent + 5; c <= colSumEnd; c++)
//                        {
//                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        idGroup3 = 0;
//                        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup1, true);
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }
//                }
//                colAddID.SetOrdinal(0);//set cột STT về vị trí đầu tiên
//                arr[0] = tblDes;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString() + "-" + idGroup3.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        public string[] cotXuat = {
//           "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
//            "AA","AB","AC","AD","AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN","AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ",
//            "BA","BB","BC","BD","BE","BF","BG","BH","BI","BJ","BK","BL","BM","BN","BO","BP","BQ","BR","BS","BT","BU","BV","BW","BX","BY","BZ",
//            "CA","CB","CC","CD","CE","CF","CG","CH","CI","CJ","CK","CL","CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV","CW","CX","CY","CZ",
//            "DA","DB","DC","DD","DE","DF","DG","DH","DI","DJ","DK","DL","DM","DN","DO","DP","DQ","DR","DS","DT","DU","DV","DW","DX","DY","DZ",
//            "EA","EB","EC","ED","EE","EF","EG","EH","EI","EJ","EK","EL","EM","EN","EO","EP","EQ","ER","ES","ET","EU","EV","EW","EX","EY","EZ",
//            "FA","FB","FC","FD","FE","FF","FG","FH","FI","FJ","FK","FL","FM","FN","FO","FP","FQ","FR","FS","FT","FU","FV","FW","FX","FY","FZ",
//            "GA","GB","GC","GD","GE","GF","GG","GH","GI","GJ","GK","GL","GM","GN","GO","GP","GQ","GR","GS","GT","GU","GV","GW","GX","GY","GZ",
//            "HA","HB","HC","HD","HE","HF","HG","HH","HI","HJ","HK","HL","HM","HN","HO","HP","HQ","HR","HS","HT","HU","HV","HW","HX","HY","HZ"
//            };
//        public void xuatBaoCao(ref XLWorkbook wb, DataTable tab, DataTable tabCauHinh, ref int dongXuat)
//        {
//            var ws = wb.Worksheet("Sheet1");
//            if (tabCauHinh.Rows.Count != 0)
//            {
//                string stringWhereNhom1 = "", stringWhereNhom2 = "", stringWhereNhom3 = "", stringWhereNhom4 = "", stringWhereNhom5 = "", stringWhereNhom6 = "", nhom7 = "", nhom8 = "", nhom9 = "";
//                DataTable dtTam1, dtTam2, dtTam3, dtTam4, dtTam5, dtTam6, dtTam7, dtTam8;
//                int sttNhom1 = 1, sttNhom2 = 1, sttNhom3 = 1, sttNhom4 = 1, sttNhom5 = 1;
//                string strSttNhom1 = "", strSttNhom2 = "", strSttNhom3 = "", strSttNhom4 = "", strSttNhom5 = "";
//                string rangeStart = "";
//                string rangeEnd = "";
//                string[] cotXuatTong = new string[int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[1].ToString()) - int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()) + 1];
//                string[] cotXuatChuoi = new string[int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatChuoi"].ToString().Split(',')[1].ToString()) - int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatChuoi"].ToString().Split(',')[0].ToString()) + 1];
//                string cotGroup = "";

//                //L?y c?t b?t d?u trong excel d? d?nh d?ng border
//                rangeStart = tabCauHinh.Rows[0]["Range"].ToString().Split(',')[0].ToString();
//                //L?y c?t k?t thúc trong excel d? d?nh d?ng border
//                rangeEnd = tabCauHinh.Rows[0]["Range"].ToString().Split(',')[1].ToString();
//                int j = 0;
//                for (int i = int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()); i <= int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[1].ToString()); i++)
//                {
//                    //T?o m?ng xu?t t?ng
//                    cotXuatTong[j] = tabCauHinh.Rows[0]["cot" + i.ToString()].ToString();
//                    j++;
//                }
//                j = 0;
//                for (int i = int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatChuoi"].ToString().Split(',')[0].ToString()); i <= int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatChuoi"].ToString().Split(',')[1].ToString()); i++)
//                {
//                    //T?o m?ng xu?t t?ng
//                    cotXuatChuoi[j] = tabCauHinh.Rows[0]["cot" + i.ToString()].ToString();
//                    j++;
//                }
//                string fillter = "";
//                string label = "";
//                DataView dtView = new DataView(tab);
//                string stringWhere = "";
//                //Xu?t n?i dung
//                foreach (DataRow drCauHinh in tabCauHinh.Rows)
//                {
//                    if (drCauHinh["label"].ToString().ToUpper() == "TRONGDO")
//                    {
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = (drCauHinh["Bold"].ToString() == "True" ? true : false);
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = (drCauHinh["Italic"].ToString() == "True" ? true : false);
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = (drCauHinh["Thin"].ToString() == "True" ? XLBorderStyleValues.Thin : XLBorderStyleValues.Dashed);
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;
//                        stringWhere = stringWhereNhom1
//                            + (stringWhereNhom2 == "" ? "" : " and " + stringWhereNhom2)
//                            + (stringWhereNhom3 == "" ? "" : " and " + stringWhereNhom3)
//                            + (stringWhereNhom4 == "" ? "" : " and " + stringWhereNhom4)
//                            + (stringWhereNhom5 == "" ? "" : " and " + stringWhereNhom5);

//                        dtView.RowFilter = stringWhere == "" ? "" : stringWhere + " " + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : "");
//                        DataTable dtTrongDo = new DataTable();
//                        dtTrongDo = dtView.ToTable();
//                        if (dtTrongDo.Rows.Count != 0)
//                        {
//                            ws.Cell(cotXuat[2].ToString() + dongXuat).Value = "Trong đó";
//                            dongXuat += 1;
//                        }
//                    }
//                    else if (drCauHinh["stringWhere"].ToString().ToUpper() == "TONGCONG")
//                    {
//                        label = drCauHinh["label"].ToString().ToUpper();
//                        xuatDongGroup(ref wb, drCauHinh, tab, "", rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);
//                        if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                        {

//                            //xu?t trong nu?c
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                            xuatDongGroup(ref wb, drCauHinh, tab, stringWhereNhom1 + "nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            //xu?t nu?c ngoài
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                            xuatDongGroup(ref wb, drCauHinh, tab, stringWhereNhom1 + "nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                        }
//                    }
//                    else if (stringWhereNhom1 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "1")
//                    {
//                        stringWhereNhom1 = drCauHinh["stringWhere"].ToString();
//                        dtView.RowFilter = stringWhereNhom1;
//                        dtTam1 = new DataTable();
//                        dtTam1 = dtView.ToTable();
//                        if (dtTam1.Rows.Count != 0)
//                        {
//                            label = drCauHinh["label"].ToString();
//                            strSttNhom1 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom1, "");
//                            ws.Cell("A" + dongXuat).Value = strSttNhom1;
//                            xuatDongGroup(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {

//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam1, stringWhereNhom1 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam1, stringWhereNhom1 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            //else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            //{
//                            //    xuatDuAn(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            //}
//                            //else if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            //{
//                            //    xuatNhomVaDuAn(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            //}
//                            sttNhom1 += 1;
//                        }
//                        sttNhom2 = 1;
//                        strSttNhom2 = "";
//                    }
//                    else if (stringWhereNhom2 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "2")
//                    {
//                        stringWhereNhom2 = stringWhereNhom1 == "" ? "" : (stringWhereNhom1 + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : ""));
//                        dtView.RowFilter = stringWhereNhom2;
//                        dtTam2 = new DataTable();
//                        dtTam2 = dtView.ToTable();
//                        if (dtTam2.Rows.Count != 0)
//                        {
//                            strSttNhom2 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom2, strSttNhom1);
//                            ws.Cell("A" + dongXuat).Value = strSttNhom2;
//                            label = drCauHinh["label"].ToString();
//                            xuatDongGroup(ref wb, drCauHinh, dtTam2, stringWhereNhom2, rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {

//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam2, stringWhereNhom2 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);

//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam2, stringWhereNhom2 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam2, stringWhereNhom2, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam2, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            sttNhom2 += 1;
//                        }
//                        sttNhom3 = 1;
//                        strSttNhom3 = "";
//                    }
//                    else if (stringWhereNhom3 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "3")
//                    {
//                        stringWhereNhom3 = stringWhereNhom2 == "" ? "" : (stringWhereNhom2 + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : ""));
//                        dtView.RowFilter = stringWhereNhom3;
//                        dtTam3 = new DataTable();
//                        dtTam3 = dtView.ToTable();
//                        if (dtTam3.Rows.Count != 0)
//                        {
//                            strSttNhom3 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom3, strSttNhom2);
//                            ws.Cell("A" + dongXuat).Value = strSttNhom3;
//                            label = drCauHinh["label"].ToString();
//                            xuatDongGroup(ref wb, drCauHinh, dtTam3, stringWhereNhom3, rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {

//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam3, stringWhereNhom3 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);

//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam3, stringWhereNhom3 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam3, stringWhereNhom3, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam3, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            sttNhom3 += 1;
//                        }
//                        sttNhom4 = 1;
//                        strSttNhom4 = "";
//                    }
//                    else if (stringWhereNhom4 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "4")
//                    {
//                        stringWhereNhom4 = stringWhereNhom3 == "" ? "" : (stringWhereNhom3 + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : ""));
//                        dtView.RowFilter = stringWhereNhom4;
//                        dtTam4 = new DataTable();
//                        dtTam4 = dtView.ToTable();
//                        if (dtTam4.Rows.Count != 0)
//                        {
//                            strSttNhom4 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom4, strSttNhom3);

//                            ws.Cell("A" + dongXuat).Value = strSttNhom4;
//                            label = drCauHinh["label"].ToString();
//                            xuatDongGroup(ref wb, drCauHinh, dtTam4, stringWhereNhom3, rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {

//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam4, stringWhereNhom3 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);

//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam4, stringWhereNhom3 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam4, stringWhereNhom3, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam4, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            sttNhom4 += 1;
//                        }
//                        sttNhom5 = 1;
//                        strSttNhom5 = "";
//                    }
//                    else if (stringWhereNhom5 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "5")
//                    {
//                        stringWhereNhom5 = stringWhereNhom4 == "" ? "" : (stringWhereNhom4 + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : ""));
//                        dtView.RowFilter = stringWhereNhom5;
//                        dtTam5 = new DataTable();
//                        dtTam5 = dtView.ToTable();
//                        if (dtTam5.Rows.Count != 0)
//                        {
//                            strSttNhom5 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom5, strSttNhom4);
//                            ws.Cell("A" + dongXuat).Value = strSttNhom5;
//                            label = drCauHinh["label"].ToString();
//                            xuatDongGroup(ref wb, drCauHinh, dtTam5, stringWhereNhom5, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {
//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam5, stringWhereNhom5 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);

//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam5, stringWhereNhom5 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam5, stringWhereNhom5, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam5, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            sttNhom5 += 1;
//                        }
//                    }
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = XLBorderStyleValues.Thin;
//                }
//            }
//        }
//        public void xuatDuAn(ref XLWorkbook wb, DataRow drCauHinh, DataTable tab, string stringWhere, string rangeStart, string rangeEnd, ref int dongXuat, string label, string[] cotXuatTong, int cotExcelBDTinhTong)
//        {
//            string group = ".", groupDuAn = "", stringWhereGroup = "", stringWhereDuAn = "";
//            DataView dtView = new DataView(tab);
//            var ws = wb.Worksheet("Sheet1");
//            int sttXuat = 1;
//            foreach (DataRow dr in tab.DefaultView.ToTable(true, "sttDuAnpr_sd").Rows)
//            {
//                group = dr["sttDuAnpr_sd"].ToString();
//                DataTable tabTam = new DataTable();
//                stringWhereGroup = stringWhere == "" ? "sttDuAnpr_sd='" + group + "'" : stringWhere + " and sttDuAnpr_sd='" + group + "'";
//                dtView.RowFilter = stringWhereGroup;
//                tabTam = dtView.ToTable();

//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = false;
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                ws.Cell("A" + dongXuat).Value = layCotSTT(drCauHinh["kieuXuatSTT_DuAn"].ToString(), sttXuat, "");
//                if (tabTam.Rows.Count != 0)
//                    for (int i = int.Parse(drCauHinh["viTriBD_KTXuatChuoi"].ToString().Split(',')[0].ToString()); i <= int.Parse(drCauHinh["viTriBD_KTXuatChuoi"].ToString().Split(',')[1].ToString()); i++)
//                    {
//                        ws.Cell(cotXuat[i] + dongXuat).Value = tabTam.Rows[0]["cot" + i].ToString();
//                    }
//                xuatDongGroup(ref wb, drCauHinh, tabTam, stringWhereDuAn, rangeStart, rangeEnd, ref dongXuat, tabTam.Rows[0]["cot2"].ToString(), cotXuatTong, int.Parse(drCauHinh["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                if (drCauHinh["xuatTrongNgoaiNuoc"].ToString() == "True" && tabTam.DefaultView.ToTable(true, "nhom8").Rows.Count > 1)
//                {
//                    //xu?t trong nu?c
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                    xuatDongGroup(ref wb, drCauHinh, tabTam, stringWhereGroup + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(drCauHinh["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                    //xu?t nu?c ngoài
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                    xuatDongGroup(ref wb, drCauHinh, tabTam, stringWhereGroup + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(drCauHinh["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                }
//                sttXuat++;
//            }
//        }
//        public void xuatNhomVaDuAn(ref XLWorkbook wb, DataRow drCauHinh, DataTable tab, string stringWhere, string rangeStart, string rangeEnd, ref int dongXuat, string label, string[] cotXuatTong, int cotExcelBDTinhTong)
//        {
//            var ws = wb.Worksheet("Sheet1");
//            string group = ".", stringWhereGroup = "";
//            int sttXuat = 1;
//            DataView dtView = new DataView(tab);
//            foreach (DataRow dr in tab.DefaultView.ToTable(true, label).Rows)
//            {
//                if (group != dr[label].ToString())
//                {
//                    group = dr[label].ToString();
//                    DataTable tabTam = new DataTable();
//                    stringWhereGroup = stringWhere == "" ? label + "='" + group + "'" : stringWhere + " and " + label + "='" + group + "'";
//                    dtView.RowFilter = stringWhereGroup;
//                    tabTam = dtView.ToTable();
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = true;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                    ws.Cell("A" + dongXuat).Value = ws.Cell("A" + dongXuat).Value = layCotSTT(drCauHinh["kieuXuatSTT_cotXuatTiepTheo"].ToString(), sttXuat, "");
//                    xuatDongGroup(ref wb, drCauHinh, tabTam, stringWhereGroup, rangeStart, rangeEnd, ref dongXuat, dr[label].ToString(), cotXuatTong, int.Parse(drCauHinh["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                    if (drCauHinh["xuatDuAn"].ToString() == "True")
//                        xuatDuAn(ref wb, drCauHinh, tabTam, stringWhereGroup, rangeStart, rangeEnd, ref dongXuat, dr[label].ToString(), cotXuatTong, int.Parse(drCauHinh["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                    sttXuat++;
//                }
//            }
//            wb.Save();
//        }
//        public string layCotSTT(string kieuXuat, int sttXuat, string sttNhomTruoc)
//        {
//            switch (kieuXuat)
//            {
//                case "0":
//                    return sttXuat.ToString();
//                    break;
//                case "1":
//                    return IntToRoman(sttXuat);
//                    break;
//                case "2":
//                    return IntToAlphabet(sttXuat, true);
//                    break;
//                case "3":
//                    return IntToAlphabet(sttXuat, false);
//                    break;
//                case "4":
//                    return sttNhomTruoc + "." + IntToRoman(sttXuat);
//                    break;
//                case "5":
//                    return sttNhomTruoc + "." + IntToAlphabet(sttXuat, true);
//                    break;
//                case "6":
//                    return sttNhomTruoc + "." + IntToAlphabet(sttXuat, false);
//                    break;
//                case "7":
//                    return sttNhomTruoc + "." + sttXuat.ToString();
//                    break;
//            }
//            return "";
//        }
//        public void xuatDongGroup(ref XLWorkbook wb, DataRow drCauHinh, DataTable tab, string stringWhere, string rangeStart, string rangeEnd, ref int dongXuat, string label, string[] cotXuatTong, int cotExcelBDTinhTong, string stt_kieu, bool format)
//        {
//            //L?y các bi?n c?n thi?t 
//            var ws = wb.Worksheet("Sheet1");
//            if (format == true)
//            {
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = (drCauHinh["Bold"].ToString() == "True" ? true : false);
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = (drCauHinh["Italic"].ToString() == "True" ? true : false);
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = (drCauHinh["Thin"].ToString() == "True" ? XLBorderStyleValues.Thin : XLBorderStyleValues.Dashed);
//                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//            }
//            ws.Cell(cotXuat[2].ToString() + dongXuat).Value = label;
//            DataView dw = new DataView(tab);
//            dw.RowFilter = stringWhere;
//            if (dw.ToTable().Rows.Count > 0)
//            {
//                for (int i = 0; i < cotXuatTong.Length; i++)
//                {
//                    if (cotXuatTong[i] != "")
//                    {
//                        if (cotXuatTong[i].Contains("-") || cotXuatTong[i].Contains("+"))
//                        {
//                            var cot = "";
//                            decimal giaTri = 0;
//                            string phepTinh = "";
//                            bool thucHienTinh = false;
//                            for (int k = 0; k < cotXuatTong[i].Length; k++)
//                            {
//                                if (cotXuatTong[i].Substring(k, 1) == "-")
//                                {
//                                    if (thucHienTinh == false)
//                                    {
//                                        giaTri = decimal.Parse(tab.Compute("sum(" + cot + ")", stringWhere).ToString());
//                                        thucHienTinh = true;
//                                    }
//                                    else
//                                    {
//                                        if (phepTinh == "-")
//                                            giaTri = giaTri - decimal.Parse(tab.Compute("sum(" + cot + ")", stringWhere).ToString());
//                                        else
//                                            giaTri = giaTri + decimal.Parse(tab.Compute("sum(" + cot + ")", stringWhere).ToString());
//                                    }
//                                    cot = "";
//                                    phepTinh = "-";
//                                }
//                                else if (cotXuatTong[i].Substring(k, 1) == "+")
//                                {
//                                    if (thucHienTinh == false)
//                                    {
//                                        giaTri = decimal.Parse(tab.Compute("sum(" + cot + ")", stringWhere).ToString());
//                                        thucHienTinh = true;
//                                    }
//                                    else
//                                    {
//                                        if (phepTinh == "-")
//                                            giaTri = giaTri - decimal.Parse(tab.Compute("sum(" + cot + ")", stringWhere).ToString());
//                                        else
//                                            giaTri = giaTri + decimal.Parse(tab.Compute("sum(" + cot + ")", stringWhere).ToString());
//                                    }
//                                    cot = "";
//                                    phepTinh = "+";
//                                }
//                                else if ((cotXuatTong[i].Substring(k, 1) != "-") && cotXuatTong[i].Substring(k, 1) != "+")
//                                    cot = cot + cotXuatTong[i].Substring(k, 1);
//                            }
//                            if (phepTinh == "+")
//                                giaTri = giaTri + decimal.Parse(tab.Compute("sum(" + cot + ")", stringWhere).ToString());
//                            else
//                                giaTri = giaTri - decimal.Parse(tab.Compute("sum(" + cot + ")", stringWhere).ToString());
//                            ws.Cell(cotXuat[cotExcelBDTinhTong].ToString() + dongXuat).Value = giaTri.ToString();
//                        }
//                        else
//                        {
//                            ws.Cell(cotXuat[cotExcelBDTinhTong].ToString() + dongXuat).Value = tab.Compute("sum(" + cotXuatTong[i] + ")", stringWhere);
//                        }
//                    }
//                    cotExcelBDTinhTong += 1;
//                }
//            }
//            dongXuat += 1;
//        }


//        /// <summary>
//        /// Xuất DataTable 2 nhóm
//        /// </summary>
//        /// <param name="dt">Datatable truyền vào</param>
//        /// <param name="colSumStart">Cột bắt đầu sum</param>
//        /// <param name="colSumEnd">Cột kết thúc sum</param>
//        /// <param name="idGroup1">STT group 1</param>
//        /// <param name="idGroup2">STT group 2</param>
//        /// <param name="checkSum">Xuất tổng cộng dòng đầu</param>
//        /// <param name="labelSum">Chuỗi dòng tổng cộng</param>
//        /// <returns>object[]</returns>
//        public object[] getTable2Group(DataTable dt, int colSumStart, int colSumEnd, int idGroup1, int idGroup2, bool checkSum, string labelSum)
//        {
//            object[] arr = new object[2];

//            DataTable tblDes = dt.Copy();
//            DataColumn colAddID = tblDes.Columns.Add("ID", System.Type.GetType("System.String"));
//            DataColumn colAddBold = tblDes.Columns.Add("Bold", System.Type.GetType("System.Boolean"));
//            DataColumn colAddItalic = tblDes.Columns.Add("Italic", System.Type.GetType("System.Boolean"));
//            DataColumn colAddBorder = tblDes.Columns.Add("Border", System.Type.GetType("System.Boolean"));
//            try
//            {
//                tblDes.Columns.Remove(tblDes.Columns[0]);
//                tblDes.Columns.Remove(tblDes.Columns[0]);
//                tblDes.Rows.Clear();
//                string group1 = "", group2 = "";
//                int colContent = 3;
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (checkSum == true && i == 0)
//                    {
//                        tblDes.Rows.Add();
//                        tblDes.Rows[tblDes.Rows.Count - 1][0] = labelSum.ToUpper();
//                        for (int c = colSumStart; c <= colSumEnd; c++)
//                        {
//                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", "");
//                        }
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                    }
//                    if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//                    {

//                        //Them dòng tên dự án
//                        tblDes.Rows.Add();
//                        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];//cột 5 chứa nhóm 5
//                        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup2, false);
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";

//                        for (int c = colContent + 1; c <= colSumEnd; c++)
//                        {
//                            if (c < colSumStart)
//                            {
//                                tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//                            }
//                            else if (c > colSumStart || c <= colSumEnd)
//                            {
//                                tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' ");
//                            }
//                        }
//                        //Kiểm tra xem dự án có 1 hay 2 dòng
//                        if (dt.Rows[i][1].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][1].ToString() && dt.Rows[i][2].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][2].ToString() && dt.Rows.Count > 1) //tên dự án dòng trên trùng tên dự án dòng dưới
//                        {
//                            tblDes.Rows.Add();
//                            tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];//cột 3 chứa nội dung
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//                            }
//                            tblDes.Rows.Add();
//                            tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i + 1][3];//cột 3 chứa nội dung
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i + 1][c];
//                            }
//                            i += 1;
//                        }
//                        else //tên dự án dòng trên khác tên dự án dòng dưới
//                        {
//                            //xảy ra lỗi khi xét dòng cuối cùng nên phải kiểm tra (i+1) với rowcount
//                            tblDes.Rows.Add();
//                            tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];//cột 3 chứa nội dung
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                            tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//                            for (int c = colSumStart; c <= colSumEnd; c++)
//                            {
//                                tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//                            }
//                        }
//                    }
//                    else
//                    {
//                        //Them dòng nhóm 1
//                        group1 = dt.Rows[i][1].ToString();
//                        group2 = "";
//                        tblDes.Rows.Add();
//                        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][1].ToString().ToUpper();
//                        for (int c = colContent + 5; c <= colSumEnd; c++)
//                        {
//                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//                        }
//                        idGroup1 += 1;
//                        idGroup2 = 0;
//                        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup1, true);
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//                    }
//                }
//                colAddID.SetOrdinal(0);//set cột STT về vị trí đầu tiên
//                arr[0] = tblDes;
//                arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString();
//                return arr;
//            }
//            catch
//            {
//                return arr;
//            }
//        }

//        //public object[] getDataExportExcel(DataTable dt, int colSumStart, int colSumEnd, int groupCount, int idGroup1, int idGroup2, int idGroup3, int idGroup4, int idGroup5)
//        //{
//        //    object[] arr = new object[2];

//        //    DataTable tblDes = dt.Copy();
//        //    DataColumn colAddID = tblDes.Columns.Add("ID", System.Type.GetType("System.String"));
//        //    DataColumn colAddBold = tblDes.Columns.Add("Bold", System.Type.GetType("System.Boolean"));
//        //    DataColumn colAddItalic = tblDes.Columns.Add("Italic", System.Type.GetType("System.Boolean"));
//        //    DataColumn colAddBorder = tblDes.Columns.Add("Border", System.Type.GetType("System.Boolean"));
//        //    try
//        //    {
//        //        tblDes.Columns.Remove(tblDes.Columns[0]);
//        //        tblDes.Columns.Remove(tblDes.Columns[0]);
//        //        tblDes.Columns.Remove(tblDes.Columns[0]);
//        //        tblDes.Columns.Remove(tblDes.Columns[0]);
//        //        tblDes.Columns.Remove(tblDes.Columns[0]);
//        //        tblDes.Rows.Clear();
//        //        string group1 = "", group2 = "", group3 = "", group4 = "", group5 = "";
//        //        int colContent = 6;
//        //        for (int i = 0; i < dt.Rows.Count; i++)
//        //        {
//        //            if (group1 == dt.Rows[i][1].ToString())//cot 1 chứa nhóm 1
//        //            {
//        //                if (group2 == dt.Rows[i][2].ToString())//cot 2 chứa nhóm 2
//        //                {
//        //                    if (group3 == dt.Rows[i][3].ToString())//cot 3 chứa nhóm 3
//        //                    {
//        //                        if (group4 == dt.Rows[i][4].ToString())//cot 4 chứa nhóm 4
//        //                        {
//        //                            //group4 = "";
//        //                            //Them dòng tên dự án
//        //                            tblDes.Rows.Add();
//        //                            tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][5];//cột 5 chứa nhóm 5
//        //                            group5 = dt.Rows[i][5].ToString();
//        //                            idGroup5 += 1;
//        //                            tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup5, false);
//        //                            tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//        //                            tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                            tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";

//        //                            for (int c = colContent + 1; c <= colSumEnd; c++)
//        //                            {
//        //                                if (c < colSumStart)
//        //                                {
//        //                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];//xuất nội dung của các cột kiểu text sau cột nội dung (sau cột 5) cho đến cột kiểu số
//        //                                }
//        //                                else if (c > colSumStart || c <= colSumEnd)
//        //                                {
//        //                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "' AND " + dt.Columns[5].ColumnName + "='" + group5 + "'");
//        //                                }
//        //                            }
//        //                            //Kiểm tra xem dự án có 1 hay 2 dòng
//        //                            if (dt.Rows[i][4].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][4].ToString() && dt.Rows[i][5].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][5].ToString()) //tên dự án dòng trên khác tên dự án dòng dưới
//        //                            {
//        //                                tblDes.Rows.Add();
//        //                                tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][6];//cột 6 chứa nội dung
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//        //                                for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                                {
//        //                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//        //                                }
//        //                                tblDes.Rows.Add();
//        //                                tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i + 1][6];//cột 6 chứa nội dung
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//        //                                for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                                {
//        //                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i + 1][c];
//        //                                }
//        //                                i += 1;

//        //                            }
//        //                            else //tên dự án dòng trên cùng tên dự án dòng dưới
//        //                            {
//        //                                //xảy ra lỗi khi xét dòng cuối cùng nên phải kiểm tra (i+1) với rowcount
//        //                                tblDes.Rows.Add();
//        //                                tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][6];//cột 6 chứa nội dung
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                                tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//        //                                for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                                {
//        //                                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//        //                                }
//        //                            }

//        //                            ////Kiểm tra xem dự án có 1 hay 2 dòng
//        //                            //if (dt.Rows[i][4].ToString() == dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][4].ToString() && dt.Rows[i][5].ToString() != dt.Rows[((i + 1) < dt.Rows.Count ? i + 1 : i)][5].ToString() || (i + 1) == dt.Rows.Count) //tên dự án dòng trên khác tên dự án dòng dưới
//        //                            //{
//        //                            //    //xảy ra lỗi khi xét dòng cuối cùng nên phải kiểm tra (i+1) với rowcount
//        //                            //    tblDes.Rows.Add();
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][6];//cột 6 chứa nội dung
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//        //                            //    for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                            //    {
//        //                            //        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//        //                            //    }
//        //                            //}
//        //                            //else //tên dự án dòng trên cùng tên dự án dòng dưới
//        //                            //{
//        //                            //    tblDes.Rows.Add();
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][6];//cột 6 chứa nội dung
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//        //                            //    for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                            //    {
//        //                            //        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i][c];
//        //                            //    }
//        //                            //    tblDes.Rows.Add();
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i + 1][6];//cột 6 chứa nội dung
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "False";
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                            //    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "True";
//        //                            //    for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                            //    {
//        //                            //        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Rows[i + 1][c];
//        //                            //    }
//        //                            //    i += 1;
//        //                            //}
//        //                        }
//        //                        else
//        //                        {//Them dòng nhóm 4
//        //                            group4 = dt.Rows[i][4].ToString();
//        //                            tblDes.Rows.Add();
//        //                            tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][4];
//        //                            for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                            {
//        //                                tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "' AND " + dt.Columns[4].ColumnName + "='" + group4 + "'");
//        //                            }
//        //                            idGroup4 += 1;
//        //                            tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = "'" + idGroup3.ToString() + "." + idGroup4.ToString();
//        //                            tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//        //                            tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "True";
//        //                            tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//        //                            i -= 1; //xử lý tiếp dòng dữ liệu hiện hành
//        //                        }
//        //                    }
//        //                    else
//        //                    {//Them dòng nhóm 3
//        //                        group3 = dt.Rows[i][3].ToString();
//        //                        tblDes.Rows.Add();
//        //                        tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][3];
//        //                        for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                        {
//        //                            tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "' AND " + dt.Columns[3].ColumnName + "='" + group3 + "'");
//        //                        }
//        //                        idGroup3 += 1;
//        //                        tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = idGroup3.ToString();
//        //                        tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//        //                        tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                        tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//        //                        i -= 1; //xử lý tiếp dòng dữ liệu hiện hành
//        //                    }
//        //                }
//        //                else
//        //                {
//        //                    //Them dòng nhóm 2
//        //                    group2 = dt.Rows[i][2].ToString();
//        //                    tblDes.Rows.Add();
//        //                    tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][2];
//        //                    for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                    {
//        //                        tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "' AND " + dt.Columns[2].ColumnName + "='" + group2 + "'");
//        //                    }
//        //                    idGroup2 += 1;
//        //                    tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToRoman(idGroup2);
//        //                    tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//        //                    tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                    tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//        //                    i -= 1; //xử lý tiếp dòng dữ liệu hiện hành1
//        //                }
//        //            }
//        //            else
//        //            {
//        //                //Them dòng nhóm 1
//        //                group1 = dt.Rows[i][1].ToString();
//        //                tblDes.Rows.Add();
//        //                tblDes.Rows[tblDes.Rows.Count - 1][0] = dt.Rows[i][1].ToString().ToUpper();
//        //                for (int c = colContent + 5; c <= colSumEnd; c++)
//        //                {
//        //                    tblDes.Rows[tblDes.Rows.Count - 1][c - colContent] = dt.Compute("SUM(" + dt.Columns[c].ColumnName + ")", dt.Columns[1].ColumnName + "='" + group1 + "'");
//        //                }
//        //                idGroup1 += 1;
//        //                tblDes.Rows[tblDes.Rows.Count - 1]["ID"] = IntToAlphabet(idGroup1, true);
//        //                tblDes.Rows[tblDes.Rows.Count - 1]["Bold"] = "True";
//        //                tblDes.Rows[tblDes.Rows.Count - 1]["Italic"] = "False";
//        //                tblDes.Rows[tblDes.Rows.Count - 1]["Border"] = "False";
//        //                i -= 1; //xử lý tiếp dòng dữ liệu hiện hành 
//        //            }
//        //        }
//        //        colAddID.SetOrdinal(0);//set cột STT về vị trí đầu tiên
//        //        arr[0] = tblDes;
//        //        arr[1] = idGroup1.ToString() + "-" + idGroup2.ToString() + "-" + idGroup3.ToString() + "-" + idGroup4.ToString() + "-" + idGroup5.ToString();
//        //        return arr;
//        //    }
//        //    catch
//        //    {
//        //        return arr;
//        //    }
//        //}
//        public void xuatBaoCao_lammoidw(ref XLWorkbook wb, DataTable tab, DataTable tabCauHinh, ref int dongXuat)
//        {
//            var ws = wb.Worksheet("Sheet1");
//            if (tabCauHinh.Rows.Count != 0)
//            {
//                string stringWhereNhom1 = "", stringWhereNhom2 = "", stringWhereNhom3 = "", stringWhereNhom4 = "", stringWhereNhom5 = "", stringWhereNhom6 = "", nhom7 = "", nhom8 = "", nhom9 = "";
//                DataTable dtTam1, dtTam2, dtTam3, dtTam4, dtTam5, dtTam6, dtTam7, dtTam8;
//                int sttNhom1 = 1, sttNhom2 = 1, sttNhom3 = 1, sttNhom4 = 1, sttNhom5 = 1;
//                string strSttNhom1 = "", strSttNhom2 = "", strSttNhom3 = "", strSttNhom4 = "", strSttNhom5 = "";
//                string rangeStart = "";
//                string rangeEnd = "";
//                string[] cotXuatTong = new string[int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[1].ToString()) - int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()) + 1];
//                string[] cotXuatChuoi = new string[int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatChuoi"].ToString().Split(',')[1].ToString()) - int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatChuoi"].ToString().Split(',')[0].ToString()) + 1];
//                string cotGroup = "";

//                //L?y c?t b?t d?u trong excel d? d?nh d?ng border
//                rangeStart = tabCauHinh.Rows[0]["Range"].ToString().Split(',')[0].ToString();
//                //L?y c?t k?t thúc trong excel d? d?nh d?ng border
//                rangeEnd = tabCauHinh.Rows[0]["Range"].ToString().Split(',')[1].ToString();
//                int j = 0;
//                for (int i = int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()); i <= int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[1].ToString()); i++)
//                {
//                    //T?o m?ng xu?t t?ng
//                    cotXuatTong[j] = tabCauHinh.Rows[0]["cot" + i.ToString()].ToString();
//                    j++;
//                }
//                j = 0;
//                for (int i = int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatChuoi"].ToString().Split(',')[0].ToString()); i <= int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatChuoi"].ToString().Split(',')[1].ToString()); i++)
//                {
//                    //T?o m?ng xu?t t?ng
//                    cotXuatChuoi[j] = tabCauHinh.Rows[0]["cot" + i.ToString()].ToString();
//                    j++;
//                }
//                string fillter = "";
//                string label = "";
//                DataView dtView = new DataView(tab);
//                string stringWhere = "";
//                //Xu?t n?i dung
//                foreach (DataRow drCauHinh in tabCauHinh.Rows)
//                {
//                    if (drCauHinh["label"].ToString().ToUpper() == "TRONGDO")
//                    {
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = (drCauHinh["Bold"].ToString() == "True" ? true : false);
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = (drCauHinh["Italic"].ToString() == "True" ? true : false);
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = (drCauHinh["Thin"].ToString() == "True" ? XLBorderStyleValues.Thin : XLBorderStyleValues.Dashed);
//                        ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;
//                        stringWhere = stringWhereNhom1
//                            + (stringWhereNhom2 == "" ? "" : " and " + stringWhereNhom2)
//                            + (stringWhereNhom3 == "" ? "" : " and " + stringWhereNhom3)
//                            + (stringWhereNhom4 == "" ? "" : " and " + stringWhereNhom4)
//                            + (stringWhereNhom5 == "" ? "" : " and " + stringWhereNhom5);

//                        dtView.RowFilter = stringWhere == "" ? "" : stringWhere + " " + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : "");
//                        DataTable dtTrongDo = new DataTable();
//                        dtTrongDo = dtView.ToTable();
//                        if (dtTrongDo.Rows.Count != 0)
//                        {
//                            ws.Cell(cotXuat[2].ToString() + dongXuat).Value = "Trong đó";
//                            dongXuat += 1;
//                        }
//                    }
//                    else if (drCauHinh["stringWhere"].ToString().ToUpper() == "TONGCONG")
//                    {
//                        label = drCauHinh["label"].ToString().ToUpper();
//                        xuatDongGroup(ref wb, drCauHinh, tab, "", rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);
//                        if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                        {

//                            //xu?t trong nu?c
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                            xuatDongGroup(ref wb, drCauHinh, tab, stringWhereNhom1 + "nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            //xu?t nu?c ngoài
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                            ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                            xuatDongGroup(ref wb, drCauHinh, tab, stringWhereNhom1 + "nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                        }
//                    }
//                    else if (stringWhereNhom1 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "1")
//                    {
//                        stringWhereNhom1 = drCauHinh["stringWhere"].ToString();
//                        dtView.RowFilter = stringWhereNhom1;
//                        dtTam1 = new DataTable();
//                        dtTam1 = dtView.ToTable();
//                        if (dtTam1.Rows.Count != 0)
//                        {
//                            label = drCauHinh["label"].ToString();
//                            strSttNhom1 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom1, "");
//                            ws.Cell("A" + dongXuat).Value = strSttNhom1;
//                            xuatDongGroup(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {

//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam1, stringWhereNhom1 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam1, stringWhereNhom1 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            //else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            //{
//                            //    xuatDuAn(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            //}
//                            //else if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            //{
//                            //    xuatNhomVaDuAn(ref wb, drCauHinh, dtTam1, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            //}
//                            sttNhom1 += 1;
//                        }
//                        sttNhom2 = 1;
//                        strSttNhom2 = "";
//                    }
//                    else if (stringWhereNhom2 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "2")
//                    {
//                        stringWhereNhom2 = stringWhereNhom1 == "" ? "" : (stringWhereNhom1 + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : ""));
//                        dtView.RowFilter = stringWhereNhom2;
//                        dtTam2 = new DataTable();
//                        dtTam2 = dtView.ToTable();
//                        if (dtTam2.Rows.Count != 0)
//                        {
//                            strSttNhom2 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom2, strSttNhom1);
//                            ws.Cell("A" + dongXuat).Value = "'" + strSttNhom2;
//                            label = drCauHinh["label"].ToString();
//                            xuatDongGroup(ref wb, drCauHinh, dtTam2, stringWhereNhom2, rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {

//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam2, stringWhereNhom2 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);

//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam2, stringWhereNhom2 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam2, stringWhereNhom2, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam2, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            sttNhom2 += 1;
//                        }
//                        sttNhom3 = 1;
//                        strSttNhom3 = "";
//                    }
//                    else if (stringWhereNhom3 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "3")
//                    {
//                        stringWhereNhom3 = stringWhereNhom2 == "" ? "" : (stringWhereNhom2 + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : ""));
//                        dtView.RowFilter = stringWhereNhom3;
//                        dtTam3 = new DataTable();
//                        dtTam3 = dtView.ToTable();
//                        if (dtTam3.Rows.Count != 0)
//                        {
//                            strSttNhom3 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom3, strSttNhom2);
//                            ws.Cell("A" + dongXuat).Value = "'" + strSttNhom3;
//                            label = drCauHinh["label"].ToString();
//                            xuatDongGroup(ref wb, drCauHinh, dtTam3, stringWhereNhom3, rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {

//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam3, stringWhereNhom3 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);

//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam3, stringWhereNhom3 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam3, stringWhereNhom3, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam3, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            sttNhom3 += 1;
//                        }
//                        sttNhom4 = 1;
//                        strSttNhom4 = "";
//                    }
//                    else if (stringWhereNhom4 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "4")
//                    {
//                        stringWhereNhom4 = stringWhereNhom3 == "" ? "" : (stringWhereNhom3 + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : ""));
//                        dtView.RowFilter = stringWhereNhom4;
//                        dtTam4 = new DataTable();
//                        dtTam4 = dtView.ToTable();
//                        if (dtTam4.Rows.Count != 0)
//                        {
//                            strSttNhom4 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom4, strSttNhom3);

//                            ws.Cell("A" + dongXuat).Value = "'" + strSttNhom4;
//                            label = drCauHinh["label"].ToString();
//                            xuatDongGroup(ref wb, drCauHinh, dtTam4, stringWhereNhom4, rangeStart, rangeEnd, ref dongXuat, label, cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {

//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam4, stringWhereNhom4 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);

//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam4, stringWhereNhom4 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam4, stringWhereNhom4, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam4, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            sttNhom4 += 1;
//                        }
//                        sttNhom5 = 1;
//                        strSttNhom5 = "";
//                    }
//                    else if (stringWhereNhom5 != drCauHinh["stringWhere"].ToString() && drCauHinh["capBaoCao"].ToString() == "5")
//                    {
//                        stringWhereNhom5 = stringWhereNhom4 == "" ? "" : (stringWhereNhom4 + (drCauHinh["stringWhere"].ToString().ToUpper() != "" ? "and " + drCauHinh["stringWhere"].ToString().ToUpper() : ""));
//                        dtView.RowFilter = stringWhereNhom5;
//                        dtTam5 = new DataTable();
//                        dtTam5 = dtView.ToTable();
//                        if (dtTam5.Rows.Count != 0)
//                        {
//                            strSttNhom5 = layCotSTT(drCauHinh["kieuXuatSTT_Group"].ToString(), sttNhom5, strSttNhom4);
//                            ws.Cell("A" + dongXuat).Value = "'" + strSttNhom5;
//                            label = drCauHinh["label"].ToString();
//                            xuatDongGroup(ref wb, drCauHinh, dtTam5, stringWhereNhom5, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", true);

//                            if (drCauHinh["xuatTrongNgoaiNuocGroup"].ToString() == "True")
//                            {
//                                //xu?t trong nu?c
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam5, stringWhereNhom5 + " and nhom8='Vốn trong nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn trong nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);

//                                //xu?t nu?c ngoài
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Bold = false;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Font.Italic = true;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.BottomBorder = XLBorderStyleValues.Dashed;
//                                ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.LeftBorder = ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.RightBorder = XLBorderStyleValues.Thin;

//                                xuatDongGroup(ref wb, drCauHinh, dtTam5, stringWhereNhom5 + " and nhom8='Vốn ngoài nước'", rangeStart, rangeEnd, ref dongXuat, "Vốn ngoài nước", cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()), "", false);
//                            }
//                            if (drCauHinh["cotXuatTiepTheo"].ToString() != "")
//                            {
//                                xuatNhomVaDuAn(ref wb, drCauHinh, dtTam5, stringWhereNhom5, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            else if (drCauHinh["xuatDuAn"].ToString() == "True")
//                            {
//                                xuatDuAn(ref wb, drCauHinh, dtTam5, stringWhereNhom1, rangeStart, rangeEnd, ref dongXuat, drCauHinh["cotXuatTiepTheo"].ToString(), cotXuatTong, int.Parse(tabCauHinh.Rows[0]["viTriBD_KTXuatTong"].ToString().Split(',')[0].ToString()));
//                            }
//                            sttNhom5 += 1;
//                        }
//                    }
//                    ws.Range(rangeStart + dongXuat + ":" + rangeEnd + dongXuat).Style.Border.TopBorder = XLBorderStyleValues.Thin;
//                    dtView = new DataView(tab);
//                }
//            }
//        }
//    }
//}
