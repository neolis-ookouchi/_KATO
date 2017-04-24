﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using KATO.Form.M1010_Daibunrui;
using KATO.Form.M1110_Chubunrui;
using KATO.Form.F0140_TanaorosiInput;
using KATO.Common.Util;
using KATO.Common.Form;
using KATO.Common.Business;
using static KATO.Common.Util.CommonTeisu;

namespace KATO.Common.Form
{
    public partial class DaibunruiList : System.Windows.Forms.Form
    {
        //並び替えボタンの連続押しを防ぐ判定
        int intOrderCode = 1;

        //どこのウィンドウかの判定（初期値）
        public int intFrmKind = 0;

        public DaibunruiList()
        {
            InitializeComponent();
        }

        public string _Title
        {
            set
            {
                String[] aryTitle = new string[] { value };
                this.Text = string.Format(STR_TITLE, aryTitle);
            }
        }


        private void DaiBunruiList_Load(object sender, EventArgs e)
        {
            this.Show();
            this._Title = "大分類リスト";
            // フォームでもキーイベントを受け取る
            this.KeyPreview = true;
            this.btnF12.Text = "F12:戻る";

            setDatagridView();
        }

        ///<summary>
        ///setDatagridView
        ///データグリッドビュー表示
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        private void setDatagridView()
        {
            //処理部に移動
            DaibunruiList_B daibunlistB = new DaibunruiList_B();
            //データグリッドビュー部分
            dgvSeihin.DataSource = daibunlistB.setDatagridView();

            //幅の値を設定
            dgvSeihin.Columns["大分類コード"].Width = 150;
            dgvSeihin.Columns["大分類名"].Width = 150;

            //中央揃え
            dgvSeihin.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRecords.Text = "該当件数( " + dgvSeihin.RowCount.ToString() + "件)";

            //件数が0の場合
            if (lblRecords.Text == "0")
            {
                //表示を変える
                MessageBox.Show("データが見つかりませんでした。");
                return;
            }
        }



        ///<summary>
        ///judDaiBunruiListKeyDown
        ///キー入力判定
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        private void judDaiBunruiListKeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
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
                    break;
                case Keys.F12:
                    //戻るボタン
                    this.btnEndClick(sender, e);
                    break;

                default:
                    break;
            }
        }


        ///<summary>
        ///btnEndClick
        ///戻るボタンを押したとき
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/2
        ///カラム論理名
        ///</summary>
        private void btnEndClick(object sender, EventArgs e)
        {
            setEndAction();
        }

        ///<summary>
        ///setEndAction
        ///戻るボタンの処理
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>
        private void setEndAction()
        {
            this.Close();

            //データ渡し用
            List<int> lstInt = new List<int>();

            //データ渡し用
            lstInt.Add(intFrmKind);

            //処理部に移動
            DaibunruiList_B daibunlistB = new DaibunruiList_B();
            daibunlistB.setEndAction(lstInt);
        }


        ///<summary>
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータをダブルクリックしたとき
        ///作成者：大河内
        ///作成日：2017/3/2
        ///更新者：大河内
        ///更新日：2017/3/6
        ///カラム論理名
        ///</summary>
        public void setdgvSeihinDoubleClick(object sender, EventArgs e)
        {
            setSelectItem();
        }

        ///<summary>
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータ選択中にキーが押されたとき
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/6
        ///カラム論理名
        ///</summary>        
        private void judDgvSeihinKeyDown(object sender, KeyEventArgs e)
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
                    //ダブルクリックと同じ効果
                    setSelectItem();
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
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
                    break;
                case Keys.F12:
                    //戻るボタン
                    this.btnEndClick(sender, e);
                    break;

                default:
                    break;
            }
        }

        ///<summary>
        ///setdgvSeihinDoubleClick
        ///データグリッドビュー内のデータ選択後の処理
        ///作成者：大河内
        ///作成日：2017/3/6
        ///更新者：大河内
        ///更新日：2017/3/23
        ///カラム論理名
        ///</summary>        
        private void setSelectItem()
        {
            if (intFrmKind == 0)
            {
                return;
            }

            //データ渡し用
            List<string> lstString = new List<string>();
            List<int> lstInt = new List<int>();

            //選択行の大分類コード取得
            string strSelectid = (string)dgvSeihin.CurrentRow.Cells[0].Value;

            lstInt.Add(intFrmKind);
            lstString.Add(strSelectid);

            //処理部に移動
            DaibunruiList_B daibunListB = new DaibunruiList_B();
            daibunListB.setSelectItem(lstInt, lstString);

            setEndAction();
        }

        // タイトルバーの閉じるボタン、コントロールボックスの「閉じる」、Alt + F4 を無効
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.Demand,
                Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int FRM_NOCLOSE = 0x200;
                CreateParams cpForm = base.CreateParams;
                cpForm.ClassStyle = cpForm.ClassStyle | FRM_NOCLOSE;

                return cpForm;
            }
        }
    }
}
