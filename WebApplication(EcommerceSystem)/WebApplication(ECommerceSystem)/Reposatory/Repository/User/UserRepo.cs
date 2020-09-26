using Shared.Common;
using System;
using System.Collections.Generic;

namespace Reposatory.Repository.User
{
    public class UserRepo : IUserRepo
    {
        RepositoryDao dao;
        public UserRepo()
        {
            dao = new RepositoryDao();
        }
        public DbResponse SignUp(UserCommon model)
        {
            try
            {
                var sql = "EXEC proc_tblUsers ";
                sql += " @flag = " + dao.FilterString("I");
                sql += ",@FirstName = " + dao.FilterString(model.FirstName);
                sql += ",@MiddleName = " + dao.FilterString(model.MiddleName);
                sql += ",@LastName = " + dao.FilterString(model.LastName);
                sql += ",@UserId = " + dao.FilterString(model.UserId);
                sql += ",@Address = " + dao.FilterString(model.Address);
                sql += ",@District = " + dao.FilterString(model.District);
                sql += ",@State = " + dao.FilterString(model.State);
                sql += ",@Country = " + dao.FilterString(model.Country);
                sql += ",@MobileNo = " + dao.FilterString(model.MobileNo);
                sql += ",@Email = " + dao.FilterString(model.Email);
                sql += ",@Password = " + dao.FilterString(model.Password);
                sql += ",@BirthDate = " + dao.FilterString(model.BirthDate);
                sql += ",@Gender = " + dao.FilterString(model.Gender);
                sql += ",@ShopAddress = " + dao.FilterString(model.StoreAddress);
                sql += ",@AccountType = " + dao.FilterString(model.AccountType);
                sql += ",@Language = " + dao.FilterString(model.Language);
                //sql += ",@Verificataion = " + dao.FilterString(model.Verificataion);
                sql += ",@StoreName = " + dao.FilterString(model.StoreName);
                sql += ",@StoreAddress = " + dao.FilterString(model.StoreAddress);
                sql += ",@StoreNo = " + dao.FilterString(model.StoreNo);
                sql += ",@PANNO = " + dao.FilterString(model.PANNO);
                sql += ",@ProductType = " + dao.FilterString(model.ProductType);
                sql += ",@StoreContactNo = " + dao.FilterString(model.StoreContactNo);
                sql += ",@Longitude =" + dao.FilterString(model.Longitude);
                sql += ",@Latitude =" + dao.FilterString(model.Latitude);
                sql += ",@VerificationCode =" + dao.FilterString(model.VerificationCode);
                sql += ",@VerificationFor =" + dao.FilterString(model.VerificationFor);
                sql += ",@VerificationSuccess =" + dao.FilterString(model.VerificationSuccess);
                sql += ",@TermsAndCondition = " + dao.FilterString(model.TermsAndCondition);


                return dao.ParseDbResponse(sql);

            }
            catch (Exception ex)
            {
                return dao.ExceptionDbResponse(ex.Message);
            }

        }
        public UserCommon SignIn(string User, String Password)
        {
            UserCommon data = new UserCommon();
            try
            {

                var sql = "Exec proc_tblUsers ";
                sql += " @flag = " + dao.FilterString("S");
                sql += ",@Email = " + dao.FilterString(User);
                sql += ",@Password = " + dao.FilterString(Password);
                var dr = dao.ExecuteDataRow(sql);
                if (dr != null)
                {
                    data.AccountType = dr["AccountType"].ToString();
                    data.UserId = dr["UserId"].ToString();
                    data.Address = dr["Address"].ToString();
                    data.BirthDate = dr["BirthDate"].ToString();
                    data.Country = dr["Country"].ToString();
                    data.District = dr["District"].ToString();
                    data.Email = dr["Email"].ToString();
                    data.Gender = dr["Gender"].ToString();
                    data.FirstName = dr["FirstName"].ToString();
                    data.MiddleName = dr["MiddleName"].ToString();
                    data.LastName = dr["LastName"].ToString();
                    data.Language = dr["Language"].ToString();
                    data.MobileNo = dr["MobileNo"].ToString();
                    data.PANNO = dr["PANNO"].ToString();
                    data.ProductType = dr["ProductType"].ToString();
                    data.ShopAddress = dr["ShopAddress"].ToString();
                    data.State = dr["State"].ToString();
                    data.RowId = Convert.ToInt32(dr["RowId"]);
                    data.StoreAddress = dr["StoreAddress"].ToString();
                    data.StoreContactNo = dr["StoreContactNo"].ToString();
                    data.StoreName = dr["StoreName"].ToString();
                    data.StoreNo = dr["StoreNo"].ToString();
                    data.User = dr["Users"].ToString();
                    data.Longitude = dr["Longitude"].ToString();
                    data.Latitude = dr["Latitude"].ToString();

                }
                return data;
            }
            catch (Exception ex)
            {
                return data;
            }

        }
        public DbResponse Verify(string Email, string VerificationCode)
        {
            try
            {
                var sql = "EXEC proc_tblUsers ";
                sql += " @flag = " + dao.FilterString("Verify");
                sql += " @Email = " + dao.FilterString(Email);
                sql += " @VerificationCode = " + dao.FilterString(VerificationCode);
                sql += " @VerificationSuccess = " + dao.FilterString("1");

                return dao.ParseDbResponse(sql);

            }
            catch (Exception ex)
            {
                return dao.ExceptionDbResponse(ex.Message);
            }
        }

        public DbResponse ForgotPassword(UserCommon Common)
        {
            try
            {
                var sql = "EXEC proc_tblUsers ";
                sql += " @flag = " + dao.FilterString("FPassword");
                sql += " @Email = " + dao.FilterString(Common.Email);
                sql += " @VerificationCode = " + dao.FilterString(Common.VerificationCode);
                sql += " @VerificationFor = " + dao.FilterString(Common.VerificationFor);
                sql += " @VerificationSuccess = " + dao.FilterString(Common.VerificationSuccess);


                return dao.ParseDbResponse(sql);

            }
            catch (Exception ex)
            {
                return dao.ExceptionDbResponse(ex.Message);
            }

        }

        public string NotificationCount(string User)
        {
            var list = new List<NotificationCommon>();
            var sql = "Exec proc_tblNotification @flag=" + dao.FilterString("NotificationCount");
            sql += ", @User=" + dao.FilterString(User);            
            var dr = dao.ExecuteDataRow(sql);
            string NotificationCount = dr.Table.Rows[0]["NotificationCount"].ToString();  //dr.Rows[0].
            return NotificationCount;
            //return "0";
        }

        public List<NotificationCommon> ShowNotification(string User)
        {
            var list = new List<NotificationCommon>();
            var sql = "Exec proc_tblNotification @flag=" + dao.FilterString("showNotification");
            sql += ", @User=" + dao.FilterString(User);
            var dt = dao.ExecuteDataTable(sql);

            if (null != dt)
            {
                int sn = 1;
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var common = new NotificationCommon()
                    {
                        RowId = Convert.ToInt32(item["RowId"]),
                        NotificationBody=item["NotificationBody"].ToString(),
                        NotificationBy=item["NotificationBy"].ToString(),
                        NotificationFor=item["NotificationFor"].ToString(),
                        NotificationStatus=item["NotificationStatus"].ToString(),
                        NotificationSubject=item["NotificationSubject"].ToString(),
                        isRead=item["isRead"].ToString(),
                        User = item["CreatedBy"].ToString(),
                        CreatedDate = item["CreatedDate"].ToString()
                       
                    };
                    sn++;
                    list.Add(common);
                }
            }
            return list;
            
        }


    }
}
