using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATO.Form;
using KATO.Common;
using KATO.Common.Util;
using System.Windows.Forms;
using System.Data;
using KATO.Common.Ctl;

namespace KATO.Business.M1010_Daibunrui
{
    class M1010_Daibunrui_B
    {
        ///<summary>
        ///addDaibunrui
        ///テキストボックス内のデータをDBに登録
        ///作成者：大河内
        ///作成日：2017/3/21
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public Boolean addDaibunrui(List<string> lstString)
        {
            //
            //共通化されるので修正しないでください
            //
            Boolean blnSuccess = false;

            //接続用クラスのインスタンス作成
            DBConnective dbConnective = new DBConnective();

            //トランザクション開始
            dbConnective.BeginTrans();

            try
            {
                string[] strArray = new string[] { lstString[0], lstString[1], lstString[2], lstString[3], lstString[4], lstString[5], lstString[6], lstString[7], "N", DateTime.Now.ToString(), lstString[8], DateTime.Now.ToString(), lstString[8] };

                dbConnective.RunSqlCommon(CommonTeisu.C_SQL_DAIBUNRUI_UPD, strArray);

                //コミット開始
                dbConnective.Commit();

                blnSuccess = true;
                return (blnSuccess);
            }
            catch (Exception e)
            {
                //ロールバック開始
                dbConnective.Rollback();
                return (blnSuccess);
                //throwを入れる
            }
            //finally
            //{
            //    //closeが入る
            //}
        }

        ///<summary>
        ///delDaibunrui
        ///テキストボックス内のデータをDBから削除のチェック機能
        ///作成者：大河内
        ///作成日：2017/4/14
        ///更新者：大河内
        ///更新日：2017/4/14
        ///カラム論理名
        ///</summary>
        public bool delDaibunruiCheck(List<string> lstString)
        {
            //接続用クラスのインスタンス作成
            DBConnective dbConnective = new DBConnective();

            //トランザクション開始
            dbConnective.BeginTrans();

            try
            {
                string[] strArray = new string[] { lstString[0] };

                dbConnective.RunSqlCommon(CommonTeisu.C_SQL_DAIBUNRUI_DEL, strArray);

                //コミット開始
                dbConnective.Commit();

                return (true);
            }
            catch (Exception e)
            {
                //ロールバック開始
                dbConnective.Rollback();
                return (false);
                //throwを入れる
            }
        }
        ///<summary>
        ///delDaibunrui
        ///テキストボックス内のデータをDBから削除
        ///作成者：大河内
        ///作成日：2017/3/21
        ///更新者：大河内
        ///更新日：2017/4/14
        ///カラム論理名
        ///</summary>
        public bool delDaibunrui(List<string> lstString)
        {
            return true;
        }

        ///<summary>
        ///judtxtDaibunruiLeave
        ///code入力箇所からフォーカスが外れた時
        ///作成者：大河内
        ///作成日：2017/3/21
        ///更新者：大河内
        ///更新日：2017/4/7
        ///カラム論理名
        ///</summary>
        public DataTable judTxtDaibunruiLeave(List<string> lstString)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            strSQLName = "M1010_Daibun_SELECT_LEAVE";

            //データ渡し用
            lstStringSQL.Add("Common");
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            //配列設定
            string[] strArray = { lstString[0] };

            strSQLInput = string.Format(strSQLInput, strArray);

            DataTable dtSetcode_B = new DataTable();

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            //SQL文を直書き（＋戻り値を受け取る)
            dtSetcode_B = dbconnective.ReadSql(strSQLInput);

            return (dtSetcode_B);
        }
    }
}
