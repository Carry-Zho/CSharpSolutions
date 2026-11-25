using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Collections_DataTable_YM_GroupBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable onBoardingData = new DataTable();
            onBoardingData.Columns.Add("工号",typeof(string));
            onBoardingData.Columns.Add("法人实体", typeof(string));
            onBoardingData.Columns.Add("一层组织", typeof(string));
            onBoardingData.Columns.Add("二层组织", typeof(string));
            onBoardingData.Columns.Add("三层组织", typeof(string));
            onBoardingData.Columns.Add("四层组织", typeof(string));

            onBoardingData.Rows.Add(new string[] { "001", "YM", "层", "层层", "层层层", "层层层层" });
            onBoardingData.Rows.Add(["002", "YM", "层", "层层", "层层层", ""]);
            onBoardingData.Rows.Add(["003", "KD", "层", "层层", "层层层", "层层层层"]);

            DataTable mailMapping = new DataTable();
            mailMapping.Columns.Add("法人实体", typeof(string));
            mailMapping.Columns.Add("一层组织", typeof(string));
            mailMapping.Columns.Add("二层组织", typeof(string));
            mailMapping.Columns.Add("三层组织", typeof(string));
            mailMapping.Columns.Add("四层组织", typeof(string));
            mailMapping.Columns.Add("收件人", typeof(string));
            mailMapping.Columns.Add("抄送人", typeof(string));

            mailMapping.Rows.Add(["YM", "层", "层层", "层层层", "层层层层","YMTo1","YMCc1"]);
            mailMapping.Rows.Add(["", "层", "层层", "层层层", "", "YMTo1", "YMCc1"]);

            mailMapping.Rows.Add(["", "层", "层层", "层层层", "层层层层", "YMTo3", "YMCc3"]);

            //分组onBoardingData，分组依据法人实体_一层组织_二层组织_三层组织_四层组织

            IEnumerable<IGrouping<string,DataRow>> groups = onBoardingData.AsEnumerable().GroupBy(rw => 
            rw.Field<string>("法人实体")+"_"+
            rw.Field<string>("一层组织") + "_" +
            rw.Field<string>("二层组织") + "_" +
            rw.Field<string>("三层组织") + "_" +
            rw.Field<string>("四层组织")
            );

            //foreach (IGrouping<string, DataRow> group in groups)
            //{
            //    Console.WriteLine(group.Key);
            //    string[] orgs = group.Key.Split("_", StringSplitOptions.None);
            //    Console.WriteLine(orgs.Count());
            //}

            List<(string,IGrouping<string, DataRow>)> list = new List<(string, IGrouping<string, DataRow>)>();





            foreach (IGrouping<string, DataRow> group in groups)
            {
                string[] ops = group.Key.Split("_", StringSplitOptions.None);

                bool isMatchAll = mailMapping
                    .AsEnumerable().Where(
                    rw =>   rw.Field<string>("法人实体") + "_" +
                            rw.Field<string>("一层组织") + "_" +
                            rw.Field<string>("二层组织") + "_" +
                            rw.Field<string>("三层组织") + "_" +
                            rw.Field<string>("四层组织")
                        == group.Key)
                        .Any();

                bool isMatchPartial = mailMapping
                                      .AsEnumerable().Where(
                                                            rw => string.IsNullOrWhiteSpace(rw.Field<string>("法人实体")) &&
                                                            "_"+
                                                            rw.Field<string>("一层组织") + "_" +
                                                            rw.Field<string>("二层组织") + "_" +
                                                            rw.Field<string>("三层组织") + "_" +
                                                            rw.Field<string>("四层组织")
                                                            == group.Key.Replace(ops[0],""))
                                       .Any();
                if (isMatchAll)
                {
                    var mailRow = mailMapping
                    .AsEnumerable().Where(
                    rw => rw.Field<string>("法人实体") + "_" +
                            rw.Field<string>("一层组织") + "_" +
                            rw.Field<string>("二层组织") + "_" +
                            rw.Field<string>("三层组织") + "_" +
                            rw.Field<string>("四层组织")
                        == group.Key)
                        .First();
                    list.Add((mailRow.Field<string>("收件人") + "/" + mailRow.Field<string>("抄送人"), group));
                }
                else if (isMatchPartial)
                {
                    var mailRow = mailMapping
                                  .AsEnumerable()
                                  .Where(
                                          rw => string.IsNullOrWhiteSpace(rw.Field<string>("法人实体")) &&
                                           "_" +
                                           rw.Field<string>("一层组织") + "_" +
                                           rw.Field<string>("二层组织") + "_" +
                                           rw.Field<string>("三层组织") + "_" +
                                           rw.Field<string>("四层组织")
                                           == group.Key.Replace(ops[0], ""))
                                       .First();
                    list.Add((mailRow.Field<string>("收件人") + "/" + mailRow.Field<string>("抄送人"), group));
                }
                else
                {
                    throw new Exception($"存在未匹配到收件者的分组:{group.Key}");

                }
            }
            Console.WriteLine(list.Count);

            var finalGp = list.GroupBy(itm => itm.Item1);
            Console.WriteLine(finalGp.Count());

            foreach (var gp in finalGp)
            {
                Console.WriteLine("邮件分组："+gp.Key+"包含"+ gp.Count()+"条组织分组数量");

                foreach (var rw in gp)
                {
                    var s = rw.Item2;
                    Console.WriteLine(s.Key);
                    Console.WriteLine(s.First().Field<string>("工号"));
                }    
            }
        }
    }
}