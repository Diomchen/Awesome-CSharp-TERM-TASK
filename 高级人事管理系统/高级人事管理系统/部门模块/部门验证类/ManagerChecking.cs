using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 高级人事管理系统.登陆模块;
using 高级人事管理系统.部门模块.部门选择模块.人事部门;
using 高级人事管理系统.部门模块.部门选择模块.其他部门;

namespace 高级人事管理系统.部门模块.部门验证类
{
    class ManagerChecking
    {
        public string username{get;set;}

        public void identifyDepartment(string username) {
            this.username = username;
            
            using (var db = new MSDSecondEntities()) {
                var idDpartment = from x in db.staff
                                  where x.s_username == username
                                  select x.s_department;
                
                List<string> list = idDpartment.ToList();
                if (list[0].Trim().Equals("人事管理部"))
                {
                    PersonnelDepartment pd = new PersonnelDepartment();
                    pd.ShowDialog();

                }
                else {
                    otherDepartment od = new otherDepartment(list[0].Trim());
                    od.ShowDialog();

                }
   
            }
        }
    }
}
