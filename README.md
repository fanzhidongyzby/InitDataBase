InitDataBase-fzd
==========

项目名称
-----------

数据库初始化程序

开发环境
-----------

Visual Studio 2010

详细说明
-----------

1. 根据提供的数据文件自动创建数据库。
2. 操作步骤：
	 * 填写要操作的数据库名称或者连接字符串(默认是C#与SQL Server 2008的连接字符串，若版本不同，需要自己写连接字符串)，单击Go即可初始化原始数据。
	 * 建立<<数据库原理概论(第四版)>>Page75的数据表S,P,J,SPJ并初始化。
	 * 同时建立实验1中的book,card,borrow数据表，但不对其初始化,初值为空。