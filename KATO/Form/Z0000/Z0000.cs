﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KATO.Common.Ctl;
using KATO.Common.Util;
using KATO.Form;
using static KATO.Common.Util.CommonTeisu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Permissions;

namespace KATO.Form.Z0000
{
    public partial class Z0000 : BaseForm
    {
        public Z0000()
        {
            InitializeComponent();

            this.btnF12.Text = STR_FUNC_F12;

        }

        private void Z0000_Load(object sender, EventArgs e)
        {
            //TabControlをオーナードローする
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //DrawItemイベントハンドラを追加
            tabControl1.DrawItem += new DrawItemEventHandler(TabControl1_DrawItem);
        }

        //TabControl1のDrawItemイベントハンドラ
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //対象のTabControlを取得
            TabControl tab = (TabControl)sender;
            //タブページのテキストを取得
            string txt = tab.TabPages[e.Index].Text;

            //タブのテキストと背景を描画するためのブラシを決定する
            Brush foreBrush, backBrush;
            //FontStyle fontText;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //選択されているタブのテキストを赤、背景を青とする
                foreBrush = Brushes.Black;
                backBrush = Brushes.WhiteSmoke;
                //fontText = FontStyle.Bold;
            }
            else
            {
                //選択されていないタブのテキストは灰色、背景を白とする
                foreBrush = Brushes.Black;
                backBrush = Brushes.WhiteSmoke;
                //fontText = FontStyle.Regular;
            }

            //StringFormatを作成
            StringFormat sf = new StringFormat();
            //中央に表示する
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //フォントスタイルの指定
            //e.Font.Style = 
            //背景の描画
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            //Textの描画
            e.Graphics.DrawString(txt, e.Font, foreBrush, e.Bounds, sf);
        }

        //大分類表示
        private void baseMenuButton1_Click(object sender, EventArgs e)
        {
            M1010_Daibunrui.M1010_Daibunrui daibun = new M1010_Daibunrui.M1010_Daibunrui();
            daibun.ShowDialog();
        }

        //中分類表示
        private void baseMenuButton2_Click(object sender, EventArgs e)
        {
            M1110_Chubunrui.M1110_Chubunrui chubun = new M1110_Chubunrui.M1110_Chubunrui();
            chubun.ShowDialog();
        }

        //メーカー表示
        private void baseMenuButton4_Click(object sender, EventArgs e)
        {
            M1020_Maker.M1020_Maker maker = new M1020_Maker.M1020_Maker();
            maker.ShowDialog();
        }

        //棚卸入力表示
        private void baseMenuButton5_Click(object sender, EventArgs e)
        {
            F0140_TanaorosiInput.F0140_TanaorosiInput tana = new F0140_TanaorosiInput.F0140_TanaorosiInput();
            tana.ShowDialog();
        }

        //受注入力（共通部品テスト用）表示
        private void baseMenuButton6_Click(object sender, EventArgs e)
        {
            JuchuInput.JuchuInput juchu = new JuchuInput.JuchuInput();
            juchu.ShowDialog();
        }

        //F12が押されたら
        private void judF12Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //キーが押されたら
        private void judKeyDown(object sender, KeyEventArgs e)
        {
            //キー入力情報によって動作を変える
            switch (e.KeyCode)
            {
                case Keys.F12:
                    this.Close();
                    break;
            }

        }
    }
}
