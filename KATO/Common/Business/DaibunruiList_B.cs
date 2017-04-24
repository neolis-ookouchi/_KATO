using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Form.M1010_Daibunrui;
using KATO.Form.M1110_Chubunrui;
using KATO.Form.F0140_TanaorosiInput;

namespace KATO.Common.Business
{
    class DaibunruiList_B
    {
        string strSQLName = null;

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/22
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

            strSQLName = "DaibunruiList_View";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("CommonForm");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //検索データを表示
            dtGetTableGrid = dbConnective.ReadSql(strSQLInput);

            return (dtGetTableGrid);
        }

        ///<summary>
        ///setEndAction
        ///元の画面に戻る
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
                if (lstInt[0] == 1 && frm.Name.Equals("M1010_Daibunrui"))
                {
                    //データを連れてくるため、newをしないこと
                    M1010_Daibunrui daibunrui = (M1010_Daibunrui)frm;
                    daibunrui.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 2 && frm.Name.Equals("M1110_Chubunrui"))
                {
                    //データを連れてくるため、newをしないこと
                    M1110_Chubunrui chubunrui = (M1110_Chubunrui)frm;
                    chubunrui.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 5 && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setDaibunruiListClose();
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 7 && frm.Name == "ShouhinList")
                {
                    //データを連れてくるため、newをしないこと
                    ShouhinList shouhinsist = (ShouhinList)frm;
                    shouhinsist.setDaibunruiListClose();
                    break;
                }
            }
        }

        ///<summary>
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータ選択後の処理
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

            strSQLName = "";

            strSQLName = "C_LIST_Daibun_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] strArray = { lstString[0] };

            strSQLInput = string.Format(strSQLInput, strArray);

            dtSelectData = dbconnective.ReadSql(strSQLInput);

            switch (lstInt[0])
            {
                //大分類
                case 1:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name.Equals("M1010_Daibunrui"))
                        {
                            //データを連れてくるため、newをしないこと
                            M1010_Daibunrui daibunrui = (M1010_Daibunrui)frm;
                            daibunrui.setDaibunrui(dtSelectData);
                            break;
                        }
                    }
                    break;

                //中分類
                case 2:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name.Equals("M1110_Chubunrui"))
                        {
                            //データを連れてくるため、newをしないこと
                            M1110_Chubunrui chubunrui = (M1110_Chubunrui)frm;
                            chubunrui.setDaibunrui(dtSelectData);
                            break;
                        }
                    }
                    break;
                //棚番
                case 5:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name.Equals("F0140_TanaorosiInput"))
                        {
                            //データを連れてくるため、newをしないこと
                            F0140_TanaorosiInput tanaorosinput = (F0140_TanaorosiInput)frm;
                            tanaorosinput.setDaibunrui(dtSelectData);
                            break;
                        }
                    }
                    break;
                //商品リスト
                case 7:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name.Equals("ShouhinList"))
                        {
                            //データを連れてくるため、newをしないこと
                            ShouhinList shouhinlist = (ShouhinList)frm;
                            shouhinlist.setDaibunrui(dtSelectData);
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
