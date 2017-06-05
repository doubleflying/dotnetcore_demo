using Dapper;
using MySql.Data.MySqlClient;

public class DataService
{
    private MySqlConnection conn;
    public DataService()
    {
        conn = new MySqlConnection("server=127.0.0.1;database=test;uid=root;pwd=Mysql520!;charset='gbk'");
    }
    public void Insert()
    {
        conn.Execute("insert into user values(null, '测试2', 'http://www.cnblogs.com/doublefly/', 28)");
    }
}