using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace KATO.Common.Util
{
    class CommonTeisu
    {
        // 全画面共通 タイトル
        public const String STR_TITLE = "{0}";
        //ファンクションキーボタン判定
        public const String STR_FUNC_F1  = "F1:登録";
        public const String STR_FUNC_F2  = "";
        public const String STR_FUNC_F3  = "F3:削除";
        public const String STR_FUNC_F4  = "F4:取消";
        public const String STR_FUNC_F5  = "";
        public const String STR_FUNC_F6  = "";
        public const String STR_FUNC_F7  = "";
        public const String STR_FUNC_F8  = "";
        public const String STR_FUNC_F9  = "F9:検索";
        public const String STR_FUNC_F10 = "";
        public const String STR_FUNC_F11 = "F11:印刷";
        public const String STR_FUNC_F12 = "F12:終了";

        public const String STR_BTN_F01 = "btnF01";
        public const String STR_BTN_F02 = "btnF02";
        public const String STR_BTN_F03 = "btnF03";
        public const String STR_BTN_F04 = "btnF04";
        public const String STR_BTN_F05 = "btnF05";
        public const String STR_BTN_F06 = "btnF06";
        public const String STR_BTN_F07 = "btnF07";
        public const String STR_BTN_F08 = "btnF08";
        public const String STR_BTN_F09 = "btnF09";
        public const String STR_BTN_F10 = "btnF10";
        public const String STR_BTN_F11 = "btnF11";
        public const String STR_BTN_F12 = "btnF12";

        //ウィンドウ判定
        public const int FRM_DAIBUNRUI = 1;
        public const int FRM_CYUBUNRUI = 2;
        public const int FRM_MAKER = 3;
        public const int FRM_TANTOUSYA = 4;
        public const int FRM_TANAOROSHI = 5;
        public const int FRM_TANAOROSHI_EDIT = 6;
        public const int FRM_SHOUHINLIST = 7;

        //メッセージボックスアイコン
        public const int DIAG_INFOMATION = 0;
        public const int DIAG_ERROR = 1;
        public const int DIAG_EXCLAMATION = 2;
        public const int DIAG_QUESTION = 3;

        //メッセージボックスボタン数
        public const int BTN_ZERO = 0;
        public const int BTN_OK = 1;
        public const int BTN_YESNO = 2;
        public const int BTN_YESNOCANCEL = 3;

        //メッセージボックス題名
        public const string TEXT_TOUROKU = "登録";
        public const string TEXT_INPUT = "入力項目";
        public const string TEXT_DEL = "削除";

        //メッセージボックス内容物
        public const string LABEL_TOUROKU = "正常に登録されました";
        public const string LABEL_NULL = "項目が空です。文字を入力してください。";
        public const string LABEL_DEL_BEFORE = "表示中のレコードを削除します。よろしいですか。";
        public const string LABEL_DEL_AFTER = "正常に削除されました。";
        public const string LABEL_DATE_ALERT = "入力された日付が正しくありません。";

        //カレンダーの初期値
        public const int CALENDER_TODAY = 0;
        public const int CALENDER_MONTH_FIRST = 1;
        public const int CALENDER_MONTH_END = 2;


        // テーブル対応のSQLファイル
        public const string C_SQL_DAIBUNRUI_UPD = "C_SQL_DAIBUNRUI_UPD";
        public const string C_SQL_DAIBUNRUI_DEL = "C_SQL_DAIBUNRUI_DEL";

        public static readonly SqlDbType[] P_C_SQL_DAIBUNRUI_UPD =
        {
            SqlDbType.Char
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.NChar
            ,SqlDbType.Char
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
            ,SqlDbType.DateTime
            ,SqlDbType.NChar
        };

        public static readonly SqlDbType[] P_C_SQL_DAIBUNRUI_DEL =
        {
            SqlDbType.Char
        };

        public static Dictionary<String, SqlDbType[]> paramDic = new Dictionary<string, SqlDbType[]>()
        {
            { "C_SQL_DAIBUNRUI_UPD",  P_C_SQL_DAIBUNRUI_UPD }
            ,{ "C_SQL_DAIBUNRUI_DEL",  P_C_SQL_DAIBUNRUI_DEL }
        };
        
    }
}
