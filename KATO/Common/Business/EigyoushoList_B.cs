using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Common.Util;
using System.Windows.Forms;
using KATO.Form.F0140_TanaorosiInput;

namespace KATO.Common.Business
{
    class EigyoushoList_B
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

            strSQLName = "EigyoushoList_View";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add("CommonForm");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            strSQLInput = string.Format(strSQLInput);

            //検索データを表示
            dtGetTableGrid = dbConnective.ReadSql(strSQLInput);

            dtGetTableGrid.Columns["営業所コード"].ColumnName = "業種コード";
            dtGetTableGrid.Columns["営業所名"].ColumnName = "業種名";

            return (dtGetTableGrid);
        }

        ///<summary>
        ///setEndAction
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
                if (lstInt[0] == 1 && frm.Name.Equals("M1010_Daibunrui"))
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 2 && frm.Name.Equals("M1110_Chubunrui"))
                {
                    MessageBox.Show("移動前のウィンドウが違います。（大分類）", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                //目的のフォームを探す
                else if (lstInt[0] == 5 && frm.Name == "F0140_TanaorosiInput")
                {
                    //データを連れてくるため、newをしないこと
                    F0140_TanaorosiInput tanaorosiinput = (F0140_TanaorosiInput)frm;
                    tanaorosiinput.setEigyoushoListClose();
                    break;
                }
            }
        }

        ///<summary>
        ///setSelectItem
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

            strSQLName = "C_LIST_Eigyousho_SELECT_LEAVE";

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
                    break;
                //中分類
                case 2:
                    break;
                //棚番
                case 5:
                    //全てのフォームの中から
                    foreach (System.Windows.Forms.Form frm in Application.OpenForms)
                    {
                        //目的のフォームを探す
                        if (frm.Name == "F0140_TanaorosiInput")
                        {
                            //データを連れてくるため、newをしないこと
                            F0140_TanaorosiInput tanaorosinput = (F0140_TanaorosiInput)frm;
                            tanaorosinput.setEigyousho(dtSelectData);
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
