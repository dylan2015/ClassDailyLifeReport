using FISCA;
using FISCA.Presentation;
using Framework;
using Framework.Security;
using JHSchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDailyLifeReport
{
    public class Program
    {
        [MainMethod()]
        public static void Main()
        {
            RibbonBarItem rbItem3 = Class.Instance.RibbonBarItems["資料統計"];

            rbItem3["報表"]["學務相關報表"]["日常生活表現總表(外掛)"].Enable = Class.Instance.SelectedList.Count >= 1;

            rbItem3["報表"]["學務相關報表"]["日常生活表現總表(外掛)"].Click += delegate
            {
                if (Class.Instance.SelectedList.Count >= 1)
                {
                    ClassDailyLifeReport StudentRW = new ClassDailyLifeReport();
                    StudentRW.ShowDialog();
                }
            };

            Class.Instance.SelectedListChanged += delegate
            {
                rbItem3["報表"]["學務相關報表"]["日常生活表現總表(外掛)"].Enable =
                    Class.Instance.SelectedList.Count >= 1 & User.Acl["HsinChu.JHBehavior.Class.Report0010.Out"].Executable;
            };

            Catalog ribbon1 = RoleAclSource.Instance["班級"]["報表"];
            ribbon1.Add(new RibbonFeature("HsinChu.JHBehavior.Class.Report0010.Out", "日常生活表現總表(外掛)"));

        }
    }
}
