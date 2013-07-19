using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace InitDataBase_fzd
{
    public partial class Form1 : Form
    {
        DataBase db;
        public Form1()
        {
            InitializeComponent();
        }
        //填充表的内容
        void fillTables()
        {
            fillS();
            fillP();
            fillJ();
            fillSPJ();
        }

        void fillS()
        {
            FileStream fs = new FileStream("./datafile/S.txt", FileMode.Open, FileAccess.Read);//读取文件设定
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));//设定读写的编码
            //使用StreamReader类来读取文件
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //  从数据流中读取每一行，直到文件的最后一行，并在rTB_Display.Text中显示出内容
            int SNO, STATUS;
            String SNAME, CITY;
            string strLine = m_streamReader.ReadLine();//读文件
            while (strLine != null)
            {
                String[] splt = strLine.Split(new char[]{'\t'},StringSplitOptions.RemoveEmptyEntries);
                SNO = Convert.ToInt32(splt[0]);
                SNAME = splt[1];
                STATUS = Convert.ToInt32(splt[2]);
                CITY = splt[3];
                db.ExcuteSqlNoResult("insert into S (SNO,SNAME,STATUS,CITY)values("
                    + SNO + ",'" + SNAME + "'," + STATUS + ",'" + CITY + "');");//插入数据
                strLine = m_streamReader.ReadLine();
            }
            //关闭此StreamReader对象
            m_streamReader.Close();
        }

        void fillP()
        {
            FileStream fs = new FileStream("./datafile/P.txt", FileMode.Open, FileAccess.Read);//读取文件设定
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));//设定读写的编码
            //使用StreamReader类来读取文件
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //  从数据流中读取每一行，直到文件的最后一行，并在rTB_Display.Text中显示出内容
            int PNO;
            String PNAME,COLOR;
            float WEIGHT;
            string strLine = m_streamReader.ReadLine();//读文件
            while (strLine != null)
            {
                String[] splt = strLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                PNO = Convert.ToInt32(splt[0]);
                PNAME = splt[1];
                COLOR = splt[2];
                WEIGHT = (float)(Convert.ToDouble(splt[3]));
                db.ExcuteSqlNoResult("insert into P(PNO,PNAME,COLOR,WEIGHT)values("
                    + PNO + ",'" + PNAME + "','" + COLOR + "'," + WEIGHT + ");");//插入数据
                strLine = m_streamReader.ReadLine();
            }
            //关闭此StreamReader对象
            m_streamReader.Close();
        }

        void fillJ()
        {
            FileStream fs = new FileStream("./datafile/J.txt", FileMode.Open, FileAccess.Read);//读取文件设定
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));//设定读写的编码
            //使用StreamReader类来读取文件
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //  从数据流中读取每一行，直到文件的最后一行，并在rTB_Display.Text中显示出内容
            int JNO;
            String JNAME,CITY;
            string strLine = m_streamReader.ReadLine();//读文件
            while (strLine != null)
            {
                String[] splt = strLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                JNO = Convert.ToInt32(splt[0]);
                JNAME = splt[1];
                CITY = splt[2];
                db.ExcuteSqlNoResult("insert into J(JNO,JNAME,CITY)values("
                    + JNO + ",'" + JNAME + "','" + CITY + "'" + ");");//插入数据
                strLine = m_streamReader.ReadLine();
            }
            //关闭此StreamReader对象
            m_streamReader.Close();
        }

        void fillSPJ()
        {
            FileStream fs = new FileStream("./datafile/SPJ.txt", FileMode.Open, FileAccess.Read);//读取文件设定
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));//设定读写的编码
            //使用StreamReader类来读取文件
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //  从数据流中读取每一行，直到文件的最后一行，并在rTB_Display.Text中显示出内容
            int SNO, PNO, JNO, QTY;
            string strLine = m_streamReader.ReadLine();//读文件
            while (strLine != null)
            {
                SNO = Convert.ToInt32(strLine.Substring(0, 1));
                PNO = Convert.ToInt32(strLine.Substring(2, 1));
                JNO = Convert.ToInt32(strLine.Substring(4, 1));
                QTY = Convert.ToInt32(strLine.Substring(6));
                db.ExcuteSqlNoResult("insert into SPJ (SNO,PNO,JNO,QTY)values("
                    + SNO + "," + PNO + "," + JNO + "," + QTY + ");");//插入数据
                strLine = m_streamReader.ReadLine();
            }
            //关闭此StreamReader对象
            m_streamReader.Close();
        }

        void clearTables()//清空数据表,按照顺序
        {
            db.ExcuteSqlNoResult
            (
                "delete borrow;" +
                "delete book;" +
                "delete card;" +
                "delete SPJ;" +
                "delete S;" +
                "delete P;" +
                "delete J;"
            );
        }

        void deleteTables()
        {
            try
            {
                db.ExcuteSqlNoResult
                (
                    "drop table borrow;" +
                    "drop table book;" +
                    "drop table card;" +
                    "drop table SPJ;" +
                    "drop table S;" +
                    "drop table P;" +
                    "drop table J;"
                );
            }
            catch (Exception )
            { }
            
        }
        //创建表和视图
        void createTables()
        {
            db.ExcuteSqlNoResult
            (
                "-------------------------------book\n"+
                "create table book "+
                "("+
                "	bno char(8) primary key not null"+
                "	,category char(10) not null"+
                "	,title varchar(40) not null"+
                "	,press char(30) not null"+
                "	,year int not null"+
                "	,author char(20) not null"+
                "	,price decimal(7,2) not null"+
                "	,total int not null "+
                "	,stock int not null "+
                "	,check(stock>=0 and total>=stock)"+
                ");"+
                "------------------------------card\n"+
                "create table card "+
                "("+
                "	cno char (7) not null primary key"+
                "	,name char(10) not null"+
                "	,department varchar(40) not null"+
                "	,type char(1) not null"+
                "	,check(type in ('T','G','U','O'))"+
                ");"+
                "-------------------------------borrow\n"+
                "create table borrow"+
                "("+
                "	cno char (7) not null"+
                "	,bno char(8) not null"+
                "	,borrowdate datetime not null"+
                "	,returndate datetime not null"+
                "	,primary key(bno,cno)"+
                "	,foreign key(bno) references book(bno)"+
                "	,foreign key(cno) references card(cno)"+
                ");"+
                "-------------------------------S\n"+
                "create table S"+
                "("+
                "	SNO int not null primary key"+
                "	,SNAME varchar(20) not null"+
                "	,STATUS int not null"+
                "	,CITY varchar(20) not null	" +
                ");"+
                "-------------------------------P\n"+
                "create table P"+
                "(	"+
                "	PNO int not null primary key"+
                "	,PNAME varchar(20) not null " +
                "	,COLOR varchar(20) not null" +
                "	,WEIGHT	float not null"+
                "	,check(WEIGHT>0)"+
                ");"+
                "-------------------------------J\n"+
                "create table J"+
                "("+
                "	JNO int not null primary key"+
                "	,JNAME varchar(20) not null" +
                "	,CITY varchar(20) not null" +
                ");"+
                "--------------------------------SPJ\n"+
                "create table SPJ"+
                "("+
                "	SNO int not null"+
                "	,PNO int not null"+
                "	,JNO int not null"+
                "	,QTY int not null"+
                "	,primary key(SNO,PNO,JNO)"+
                "	,foreign key(SNO) references S(SNO)"+
                "	,foreign key(PNO) references P(PNO)"+
                "	,foreign key(JNO) references J(JNO)"+
                ");"
           );
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (db == null)
                return;
            try
            {
                db.Open();
                clearTables();
                MessageBox.Show("数据清除成功！");
                db.Close();
            }
            catch (Exception)
            { }
        }

        
        private void btnName_Click(object sender, EventArgs e)
        {
            if (db == null)
                return;
            try
            {
                db.Open();
                this.deleteTables();
                MessageBox.Show("数据表删除成功！");
                db.Close();
                db = null;
            }
            catch (Exception)
            { }
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //打开数据库对象
            try
            {
                String sqlString = "";
                if (ckMode.Checked)
                {
                    sqlString = "Server=.;Initial Catalog="+txtDBname.Text.Trim()+";Integrated Security=True";
                }
                else
                {
                    sqlString = txtDBname.Text.Trim();                    
                }
                db = new DataBase(sqlString);
                db.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库不存在！！！");
                return;
            }            
            //创建表
            try
            {
                deleteTables();
                createTables();
                fillTables();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库初始化失败！");
            }
            MessageBox.Show("数据库初始化成功！");
            db.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show
            (
                "提示:\n\n"+
                "     填写要操作的数据库名称或者连接字符串(默认是C#与SQL Server 2008的连接字符串，若版本不同，需要自己写连接字符串)，单击Go即可初始化原始数据。"+
                "建立<<数据库原理概论(第四版)>>Page75的数据表S,P,J,SPJ并初始化."+
                "同时建立实验1中的book,card,borrow数据表，但不对其初始化,初值为空。   \n"+
                "                                                                                ———— 一叶孤城\n\n" 
            );
        }

        private void ckMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMode.Checked)
                txtDBname.Text = "DataBaseName";
            else
                txtDBname.Text = "Server=.;Initial Catalog=DataBaseName;Integrated Security=True";
            
        }
    }
}