using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace aspnetcorewebapi2._0.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var service = new DataService();

            MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=test;uid=root;pwd=Mysql520!;charset='gbk'");
            service.Insert();
            //con.Execute("insert into user values(null, '测试2', 'http://www.cnblogs.com/doublefly/', 28)");
            //新增数据返回自增id
            var id = con.QueryFirst<int>("insert into user values(null, 'linezero', 'http://www.cnblogs.com/linezero/', 18);select last_insert_id();");
            //修改数据
            con.Execute("update user set UserName = 'linezero123' where Id = @Id", new { Id = id });
            //查询数据
            var list=con.Query<User>("select * from user");
            foreach (var item in list)
            {
                Console.WriteLine($"用户名：{item.UserName} 链接：{item.Url}");
            }
            //删除数据
            con.Execute("delete from user where Id = @Id", new { Id = id });
            Console.WriteLine("删除数据后的结果");
            list = con.Query<User>("select * from user");
            foreach (var item in list)
            {
                Console.WriteLine($"用户名：{item.UserName} 链接：{item.Url}");
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
