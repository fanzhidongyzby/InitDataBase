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
        //���������
        void fillTables()
        {
            fillS();
            fillP();
            fillJ();
            fillSPJ();
        }

        void fillS()
        {
            FileStream fs = new FileStream("./datafile/S.txt", FileMode.Open, FileAccess.Read);//��ȡ�ļ��趨
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));//�趨��д�ı���
            //ʹ��StreamReader������ȡ�ļ�
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //  ���������ж�ȡÿһ�У�ֱ���ļ������һ�У�����rTB_Display.Text����ʾ������
            int SNO, STATUS;
            String SNAME, CITY;
            string strLine = m_streamReader.ReadLine();//���ļ�
            while (strLine != null)
            {
                String[] splt = strLine.Split(new char[]{'\t'},StringSplitOptions.RemoveEmptyEntries);
                SNO = Convert.ToInt32(splt[0]);
                SNAME = splt[1];
                STATUS = Convert.ToInt32(splt[2]);
                CITY = splt[3];
                db.ExcuteSqlNoResult("insert into S (SNO,SNAME,STATUS,CITY)values("
                    + SNO + ",'" + SNAME + "'," + STATUS + ",'" + CITY + "');");//��������
                strLine = m_streamReader.ReadLine();
            }
            //�رմ�StreamReader����
            m_streamReader.Close();
        }

        void fillP()
        {
            FileStream fs = new FileStream("./datafile/P.txt", FileMode.Open, FileAccess.Read);//��ȡ�ļ��趨
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));//�趨��д�ı���
            //ʹ��StreamReader������ȡ�ļ�
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //  ���������ж�ȡÿһ�У�ֱ���ļ������һ�У�����rTB_Display.Text����ʾ������
            int PNO;
            String PNAME,COLOR;
            float WEIGHT;
            string strLine = m_streamReader.ReadLine();//���ļ�
            while (strLine != null)
            {
                String[] splt = strLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                PNO = Convert.ToInt32(splt[0]);
                PNAME = splt[1];
                COLOR = splt[2];
                WEIGHT = (float)(Convert.ToDouble(splt[3]));
                db.ExcuteSqlNoResult("insert into P(PNO,PNAME,COLOR,WEIGHT)values("
                    + PNO + ",'" + PNAME + "','" + COLOR + "'," + WEIGHT + ");");//��������
                strLine = m_streamReader.ReadLine();
            }
            //�رմ�StreamReader����
            m_streamReader.Close();
        }

        void fillJ()
        {
            FileStream fs = new FileStream("./datafile/J.txt", FileMode.Open, FileAccess.Read);//��ȡ�ļ��趨
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));//�趨��д�ı���
            //ʹ��StreamReader������ȡ�ļ�
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //  ���������ж�ȡÿһ�У�ֱ���ļ������һ�У�����rTB_Display.Text����ʾ������
            int JNO;
            String JNAME,CITY;
            string strLine = m_streamReader.ReadLine();//���ļ�
            while (strLine != null)
            {
                String[] splt = strLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                JNO = Convert.ToInt32(splt[0]);
                JNAME = splt[1];
                CITY = splt[2];
                db.ExcuteSqlNoResult("insert into J(JNO,JNAME,CITY)values("
                    + JNO + ",'" + JNAME + "','" + CITY + "'" + ");");//��������
                strLine = m_streamReader.ReadLine();
            }
            //�رմ�StreamReader����
            m_streamReader.Close();
        }

        void fillSPJ()
        {
            FileStream fs = new FileStream("./datafile/SPJ.txt", FileMode.Open, FileAccess.Read);//��ȡ�ļ��趨
            StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));//�趨��д�ı���
            //ʹ��StreamReader������ȡ�ļ�
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //  ���������ж�ȡÿһ�У�ֱ���ļ������һ�У�����rTB_Display.Text����ʾ������
            int SNO, PNO, JNO, QTY;
            string strLine = m_streamReader.ReadLine();//���ļ�
            while (strLine != null)
            {
                SNO = Convert.ToInt32(strLine.Substring(0, 1));
                PNO = Convert.ToInt32(strLine.Substring(2, 1));
                JNO = Convert.ToInt32(strLine.Substring(4, 1));
                QTY = Convert.ToInt32(strLine.Substring(6));
                db.ExcuteSqlNoResult("insert into SPJ (SNO,PNO,JNO,QTY)values("
                    + SNO + "," + PNO + "," + JNO + "," + QTY + ");");//��������
                strLine = m_streamReader.ReadLine();
            }
            //�رմ�StreamReader����
            m_streamReader.Close();
        }

        void clearTables()//������ݱ�,����˳��
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
        //���������ͼ
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
                MessageBox.Show("��������ɹ���");
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
                MessageBox.Show("���ݱ�ɾ���ɹ���");
                db.Close();
                db = null;
            }
            catch (Exception)
            { }
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //�����ݿ����
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
                MessageBox.Show("���ݿⲻ���ڣ�����");
                return;
            }            
            //������
            try
            {
                deleteTables();
                createTables();
                fillTables();
            }
            catch (Exception)
            {
                MessageBox.Show("���ݿ��ʼ��ʧ�ܣ�");
            }
            MessageBox.Show("���ݿ��ʼ���ɹ���");
            db.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show
            (
                "��ʾ:\n\n"+
                "     ��дҪ���������ݿ����ƻ��������ַ���(Ĭ����C#��SQL Server 2008�������ַ��������汾��ͬ����Ҫ�Լ�д�����ַ���)������Go���ɳ�ʼ��ԭʼ���ݡ�"+
                "����<<���ݿ�ԭ�����(���İ�)>>Page75�����ݱ�S,P,J,SPJ����ʼ��."+
                "ͬʱ����ʵ��1�е�book,card,borrow���ݱ����������ʼ��,��ֵΪ�ա�   \n"+
                "                                                                                �������� һҶ�³�\n\n" 
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