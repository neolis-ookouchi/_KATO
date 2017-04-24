﻿using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Form.M1010_Daibunrui;
using KATO.Form.M1110_Chubunrui;
using KATO.Form.M1020_Maker;
using KATO.Form.F0140_TanaorosiInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KATO.Common.Business
{
    class MakerList_B
    {
        string strSQLName = null;

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/4/11
        ///カラム論理名
        ///</summary>
        public DataTable setDatagridView()
        {
            DataTable dtGetTableGrid = new DataTable();

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            strSQLName = "";

            strSQLName = "MakerList_View";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("CommonForm");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            strSQLInput = string.Format(strSQLInput);

            //検索データを表示
            dtGetTableGrid = dbConnective.ReadSql(strSQLInput);

            return (dtGetTableGrid);
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/4/11
        ///カラム論理名
        ///</summary>
        public DataTable setKensaku(List<int> lstInt, List<string> lstString)
        {
            DataTable dtGetTableGrid = new DataTable();

            string strWhere = null;

            //SQL用に移動
            DBConnective dbConnective = new DBConnective();

            strWhere = "WHERE a.削除 = 'N'";

            //大分類
            if (lstString[0] != "")
            {
                strWhere = strWhere + " AND a.メーカーコード IN (SELECT メーカーコード FROM 商品 WHERE 削除 = 'N' AND 大分類コード = '" + lstString[0] + "')";
            }

            if (lstString[1] != "")
            {
                //現行では検索不可能だが可能になった
                strWhere = strWhere + "AND a.メーカー名 LIKE '%" + lstString[1] + "%'";
            }

            //並び替えボタンクリック時の動き
            if (lstInt[0] == 1)
            {
                dtGetTableGrid = dbConnective.ReadSql("SELECT a.メーカーコード, a.メーカー名 FROM メーカー a " + strWhere + " ORDER BY a.メーカーコード");
            }
            else
            {
                dtGetTableGrid = dbConnective.ReadSql("SELECT a.メーカーコード, a.メーカー名 FROM メーカー a " + strWhere + " ORDER BY a.メーカー名");
            }
            return (dtGetTableGrid);
        }


        ///<summary>
        ///setDatagridView
        ///戻るボタンの処理
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/4/11
        ///カラム論理名
        ///</summary>
        public void setEndAction(List<int> lstInt)
        {
            //全てのフォームの中から
            foreach (System.Windows.Forms.Form frm in Application.OpenForms)
            {
                //目的のフォームを探す
                if (lstInt[0] == 1 && frm.Name == "M1010_Daibunrui")
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 2 && frm.Name == "M1110_Chubunrui")
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 3 && frm.Name == "M1020_Maker")
                {
                    //データを連れてくるため、newをしないこと
                    M1020_Maker maker = (M1020_Maker)frm;
                    maker.setmakerListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 5 && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setMakerListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 6 && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setMakerListCloseEdit();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 7 && frm.Name == "ShouhinList")
                {
                    //データを連れてくるため、newをしないこと
                    ShouhinList shouhinlist = (ShouhinList)frm;
                    shouhinlist.setMakerListClose();
                    break;
                }

            }
        }


        ///<summary>
        ///setSelectItem
        ///各画面へのデータ渡し
        ///作成者：大河内
        ///作成日：2017/3/23
        ///更新者：大河内
        ///更新日：2017/4/11
        ///カラム論理名
        ///</summary>
        public void setSelectItem(List<int> lstInt, List<string> lstString)
        {
            DataTable dtSelectData;

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            strSQLName = "C_LIST_Maker_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] strArray = { lstString[0] };

            strSQLInput = string.Format(strSQLInput, strArray);

            //SQL文を直書き（＋戻り値を受け取る)
            dtSelectData = dbconnective.ReadSql(strSQLInput);

            switch (lstInt[0])
            {
                //大分類
                case 1:
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                //中分類
                case 2:
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                //メーカー
                case 3:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "M1020_Maker")
                        {
                            //データを連れてくるため、newをしないこと
                            M1020_Maker maker = (M1020_Maker)frm;
                            maker.setMakerCode(dtSelectData);
                            break;
                        }
                    }
                    break;
                case 5:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "F0140_TanaorosiInput")
                        {
                            //データを連れてくるため、newをしないこと
                            F0140_TanaorosiInput tanaorosinput = (F0140_TanaorosiInput)frm;
                            tanaorosinput.setMakerCode(dtSelectData);
                            break;
                        }
                    }
                    break;
                case 6:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "F0140_TanaorosiInput")
                        {
                            //データを連れてくるため、newをしないこと
                            F0140_TanaorosiInput tanaorosinput = (F0140_TanaorosiInput)frm;
                            tanaorosinput.setMakerEdit(dtSelectData);
                            break;
                        }
                    }
                    break;
                case 7:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "ShouhinList")
                        {
                            //データを連れてくるため、newをしないこと
                            ShouhinList shouhinlist = (ShouhinList)frm;
                            shouhinlist.setMakerCode(dtSelectData);
                            break;
                        }
                    }
                    break;
            }
        }

        ///<summary>
        ///judtxtDaibunTextLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/29
        ///更新者：大河内
        ///更新日：2017/4/11
        ///カラム論理名
        ///</summary>
        public DataTable judtxtDaibunTextLeave(List<string> lstString)
        {
            DataTable dtGetTable = new DataTable();

            //SQL用に移動
            DBConnective dbconnective = new DBConnective();


            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] strArray = { lstString[0] };

            strSQLInput = string.Format(strSQLInput, strArray);

            //SQL文を直書き（＋戻り値を受け取る)
            dtGetTable = dbconnective.ReadSql(strSQLInput);

            return (dtGetTable);
        }
    }
}
