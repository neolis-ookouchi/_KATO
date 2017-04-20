﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using KATO.Common.Ctl;
using KATO.Common.Form;
using KATO.Common.Util;
using KATO.Business.JuchuInput;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Form.JuchuInput
{
    public partial class JuchuInput : BaseForm
    {
        public JuchuInput()
        {
            InitializeComponent();

        }

        private void JuchuInput_Load(object sender, EventArgs e)
        {
            //日付テキストの初期値セットアップ
            baseCalendar1.setUp(CommonTeisu.CALENDER_MONTH_END);
        }

        ///<summary>
        ///delText
        ///テキストボックス内の文字を削除
        ///作成者：大河内
        ///作成日：2017/4/5
        ///更新者：大河内
        ///更新日：2017/4/5
        ///カラム論理名
        ///</summary>
        private void delText()
        {
            //delFormClear(this);
            BaseForm formreset = new BaseForm();
            formreset.delFormClear(this);

            baseText1.Focus();
        }



        private void baseText1_Leave(object sender, EventArgs e)
        {
            Boolean blnNull = false;

            DataTable dtSetcode;

            //文字判定
            if (baseText1.blIsEmpty() == false)
            {
                return;
            }

            //前後の空白を取り除く
            baseText1.Text = baseText1.Text.Trim();

            //処理部に移動
            JuchuInput_B juchuinputB = new JuchuInput_B();
            //戻り値のDatatableを取り込む
            dtSetcode = juchuinputB.baseText1_Leave(baseText1.Text);

            if (dtSetcode.Rows.Count == 0)
            {
                baseText1.Focus();
                return;
            }
            else
            {
                KeyValuePair<int, String>[] kvpData = new KeyValuePair<int, String>[dtSetcode.Rows.Count];
                for (int intcnt = 0; intcnt < dtSetcode.Rows.Count; intcnt++)
                {
                    //KeyValuePairに取り込み
                    KeyValuePair<int, String> kvpKari = new KeyValuePair<int, String>(int.Parse(dtSetcode.Rows[intcnt]["中分類コード"].ToString()), dtSetcode.Rows[intcnt]["中分類名"].ToString());
                    //ArrayListに入れる
                    kvpData[intcnt] = kvpKari;
                }

                //KeyValuePairに再取り込み
                blnNull = baseComboBox1.setComboBox(kvpData);

                if (blnNull == true)
                {
                    baseComboBox1.Text = "";
                }

                baseComboBox1.Focus();
            }
        } 

        private void baseComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baseComboBox1.SelectedItem == null)
            {
                return;
            }

            baseLabelGray1.Text = ((KeyValuePair<int, string>)this.baseComboBox1.SelectedItem).Key.ToString();
        }

        ///<summary>
        ///judDaiBunruiKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/4/6
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        private void judJuchuInputKeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Delete:
                    break;
                case Keys.Back:
                    break;
                case Keys.Enter:
                    //TABボタンと同じ効果
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    //this.addDaibunrui();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    //this.delDaibunrui();
                    break;
                case Keys.F4:
                    this.delText();
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    //印刷
                    //PrintReport();
                    break;
                case Keys.F12:
                    this.Close();
                    break;

                default:
                    break;
            }
        }


        ///<summary>
        ///judBtnClick
        ///ボタンの反応
        ///作成者：大河内
        ///作成日：2017/4/6
        ///更新者：大河内
        ///更新日：2017/4/6
        ///カラム論理名
        ///</summary>
        private void judBtnClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case STR_BTN_F01: // 登録
                    //this.addDaibunrui();
                    break;
                case STR_BTN_F03: // 削除
                    //this.delDaibunrui();
                    break;
                case STR_BTN_F04: // 取り消し
                    this.delText();
                    break;
                //case STR_BTN_F11: //印刷
                //    this.XX();
                //    break;
                case STR_BTN_F12: // 終了
                    this.Close();
                    break;
            }
        }

        //受注番号一覧表示
        private void baseButton1_Click(object sender, EventArgs e)
        {
            //データ渡し用
            List<string> lstStringSQL = new List<string>();

            string strSQLName = null;

            strSQLName = "JuchuInput_DataGridView";

            //データ渡し用
            lstStringSQL.Add(strSQLName);

            OpenSQL opensql = new OpenSQL();
            string strSQLInput = opensql.setOpenSQL(lstStringSQL);

            strSQLInput = string.Format(strSQLInput);

            //SQLのインスタンス作成
            DBConnective dbconnective = new DBConnective();

            baseDataGridView1.DataSource = dbconnective.ReadSql(strSQLInput);
            baseDataGridViewEdit1.DataSource = dbconnective.ReadSql(strSQLInput);
        }

        private void baseCalendar1_Leave(object sender, EventArgs e)
        {
            Boolean blnDateJud;

            blnDateJud = baseCalendar1.updCalendarLeave(baseCalendar1.Text);

            if (blnDateJud == false)
            {
                //メッセージボックスの処理、削除完了のウィンドウ(OK)
                BaseMessageBox basemessagebox = new BaseMessageBox(this, CommonTeisu.TEXT_INPUT, CommonTeisu.LABEL_DATE_ALERT, CommonTeisu.BTN_OK, CommonTeisu.DIAG_INFOMATION);
                basemessagebox.ShowDialog();
                baseCalendar1.Focus();
                return;
            }
            else
            {
                return;
            }
        }
    }
}
