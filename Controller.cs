using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Parking_Finder
{
    class Controller
    {
        public  string user_name;
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }
         public void TerminateConnection()
        {
            dbMan.CloseConnection();
            Console.WriteLine("Connection closed");

        }
        //;;;;;;;;;;;;;;;;;Sahar;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

        public int CheckPassword_Basic(string username, string password)
        {
            //Query the DB to check for username/password
            string query = "SELECT Type from account where username = '" + username + "' and password='" + password + "';";
            object p = dbMan.ExecuteScalar(query);
            if (p == null) return 0;
            else return (int)p;
        }
        
        public DataTable SelectName() //get current user name
        {
            string query = "SELECT CName FROM clients WHERE username='" + user_name + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectMobile() //get current user Mobile
        {
            string query = "SELECT Telephone FROM clients WHERE username='" + user_name + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectAllClient()
        {

            string query = "SELECT * FROM Clients where Username='"+user_name+"';";
            return dbMan.ExecuteReader(query);

        }
        public DataTable SelectAlC()
        {

            string query = "SELECT * FROM Clients;";
            return dbMan.ExecuteReader(query);

        }
        public DataTable SelectUsername(string s, string pass)
        {
            string query = "SELECT * FROM Account where Username = '" + s + "' and Password='" + pass + "';";
            return dbMan.ExecuteReader(query);
        }
        public int ChangeUserName(string s) //get current user name
        {
            string query = "UPDATE Account SET " +
                "Username='" + s + "' WHERE username='" + user_name + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int ChangeName(string s,int eid=0) //get current user name
        {
            string query="";
            if (eid == 0)
            {
                query = "UPDATE Clients SET " +
                     "CName='" + s + "' WHERE username='" + user_name + "';";
            }
            else {
                query = "UPDATE Employee SET EName='" + s + "' WHERE Employee_ID=" + eid + ";";
            }
            return dbMan.ExecuteNonQuery(query);
        }
        public int ChangeMobile(int t,int eid=0) //get current user name
        {
            string query="" ;
            if (eid == 0)
            {
                query = "UPDATE Clients SET Telephone='" + t + "' WHERE username='" + user_name + "';";
            }
            else {
                query = "UPDATE Employee SET Telephone='" + t + "' WHERE Employee_ID=" + eid + ";";
            }
        return dbMan.ExecuteNonQuery(query);
        }
        public int ChangePassword(string p) //get current user name
        {
            string query = "UPDATE Account SET " +
                "password='" + p + "' WHERE username='" + user_name + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable CheckPasswordc() //get current user name
        {
            string query = "SELECT * FROM Account where username='"+user_name+"';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable CheckPassword() //get current user name
        {
            string query = "SELECT * FROM Employee;";
            return dbMan.ExecuteReader(query);
        }
        public int Rate(int r, int sid, int cid)
        {

            string query = "INSERT INTO Ratings (CID,SID,Rating) VALUES (" +

               "" + cid + "," +
               "" + sid + "," +
               "" + r + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateRating(int r, int sid, int cid)
        {

            string query = "Update Ratings SET Rating=" + r + " WHERE CID=" + cid + " and SID=" + sid + " ;";
            return dbMan.ExecuteNonQuery(query);

        }
        public int review(int cid, int sid, DateTime d, string r)
        {
            string query = "INSERT INTO Reviews(CID,SID,_DateTime,Review) VALUES (" +

              "" + cid + "," +
              "" + sid + "," +
              "'" + d.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
              "'" + r + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable selectLocations()
        {
            string query = "select * from Location ;";
            return dbMan.ExecuteReader(query);
        }
        public int Bookmark(int cid, int loid)
        {
            string query = "Insert INTO bookmarked(Client_ID,Location_ID) VALUES(" +
                "" + cid + "," +
                "" + loid + ");";

            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable SelectAllCity()
        {
            string query = "select distinct city from Location  ;";
            return dbMan.ExecuteReader(query);

        }
        public DataTable SelectDistinctArea(string c)
        {
            string query = "select Distinct area, LOCATION_ID from Location where city='" + c + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectDistinctDistrict(string A, string C)
        {
            string query = "select Distinct DISTRICT from Location where city='" + C + "' AND  Area='" + A + "';";
            return dbMan.ExecuteReader(query);
        }
        
        public int LocationID(string c, string A, string D)
        {
            string query = "select LOCATION_ID from Location where city='" + c + "' AND  Area='" + A + "' and District='" + D + " ';";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getClientID(string un) //get current user name //Sahar
        {
            string query = "SELECT Client_ID FROM clients WHERE username='" + un + "';";
            return (int)dbMan.ExecuteScalar(query);
        }
        public DataTable getsavedLoc(int cid)
        {
            string query = "SELECT l.Location_ID as ID,concat(Area,',',District,',',City) as savedlocation  FROM Bookmarked b ,location l WHERE Client_ID=" + cid + " and b.LOCATION_ID=l.Location_ID ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getlocga(int li)  //get garages at certain location
        {
            string query = " select spot_ID as gi,SNAME from parking_place where Location_ID=" + li + ";";
            return dbMan.ExecuteReader(query);

        }
        public int Insert_Card(Int64 c, int id)
        {
            string query = "INSERT INTO Client_Credit(Client_ID,CREDIT_CARD_NO) VALUES (" +

             "" + id + "," +

             "'" + c + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getcard(int id)
        {
            string query = " select CREDIT_CARD_NO from Client_Credit where Client_ID=" + id + ";";
            return dbMan.ExecuteReader(query);
        }

        public int Updatecreditcard(int i, Int64 c)
        {
            string query = "UPDATE Client_Credit SET " +
                "CREDIT_CARD_NO= " + c + " WHERE Client_ID=" + i + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        ////////////////////////////////////////////////////////////////
        public DataTable ClientRev(int sid) {
            string query="SELECT Client_Name AS 'User',Review,Reply,_DateTime FROM all_reviews where SID="+sid+";";
            return dbMan.ExecuteReader(query);
        }
        public bool IsFree(int sid) {
            String StoredProcedureName = "Is_Free";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            int is_free = 1;
            Parameters.Add("@SptID", sid);
            Parameters.Add("@FREE", is_free);
            MySqlDataReader r = dbMan.ReturnReader(StoredProcedureName, Parameters, 1);

            is_free = Convert.ToInt16(r.GetValue(0));
            r.Close();
            if (is_free == 1)
                return true;
            return false;

        }
        public bool CreditClient(int cid) {
            string query = "SELECT * FROM client_credit WHERE Client_ID= "+cid+";";
            DataTable dt=dbMan.ExecuteReader(query);
            if (dt == null)
                return false;
            return true;
        }
        //;;;;;;;;;;;;;Employee;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        public int RetrieveEmployeeID() {
            string query = "SELECT Employee_ID FROM Employee WHERE Username='" + user_name + "';";
            return Convert.ToInt16(dbMan.ExecuteScalar(query));
        }
        public int RetrieveEmployeeSpotID()
        {
            string query = "SELECT Spot_ID FROM Employee WHERE Username='" + user_name + "';";
            return Convert.ToInt16(dbMan.ExecuteScalar(query));
        }
        public string GarageName(int id)
        {
            string query = "SELECT Sname FROM parking_place WHERE Spot_ID=" + id + ";";
            return (string)dbMan.ExecuteScalar(query);
        }
        public int UpdateReply(int sptid,int cid,DateTime rdate,string reply) {
            string query = "UPDATE Reviews SET Reply='" + reply + "' WHERE CID=" + cid + " AND SID=" + sptid + " AND _DateTime='" + rdate.ToString("yyyy-MM-dd HH:mm:ss") + "';";
            return dbMan.ExecuteNonQuery(query);

        }
        public DataTable InfoNoAvg(int eid) {
            string query = " SELECT P.SName,E.Ename FROM EMPLOYEE AS E, PARKING_PLACE AS P WHERE E.Employee_ID =" + eid + " AND P.Spot_ID = E.Spot_ID;";
            return dbMan.ExecuteReader(query);
        }
        public int Insert_Account(string un, string pass, string type)
        {
            string StoredProcedureName = StoredProcedures.InsertAccount;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@username", un);
            Parameters.Add("@password", pass);
            Parameters.Add("@Type", type);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);

        }
        public int Insert_Client(string name, string un, int tel)
        {
            string StoredProcedureName = "Inser_Client"; //no need for stored procedures class 
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@C_N", name);
            Parameters.Add("@U_N", un);
            if (tel == 0)
                Parameters.Add("@TEL", null);
            else
                Parameters.Add("@TEL", tel);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);

        }
        public DataTable EmployeeInfo(int id) {
            String StoredProcedureName = "EmplInfo";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ID", id);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public MySqlDataReader Performance(int empId) {
            String StoredProcedureName = "Performance";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@EMPID", empId);
            return dbMan.ReturnReader(StoredProcedureName, Parameters);
        }
        public int Occupied(int spotid)
        {
            String StoredProcedureName = "Percent_occ";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SPTID", spotid);
            return Convert.ToInt16(dbMan.ExecuteScalar(StoredProcedureName, Parameters));
        }
        public MySqlDataReader Month3(int m1, int m2, int m3, int y1, int y2, int y3, int sptid)
        {
            String StoredProcedureName = "Total_Res_3Month";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@M1", m1);
            Parameters.Add("@M2", m2);
            Parameters.Add("@M3", m3);
            Parameters.Add("@SPTID", sptid);
            Parameters.Add("@Year1", y1);
            Parameters.Add("@Year2", y2);
            Parameters.Add("@Year3", y3);
            
            return dbMan.ReturnReader(StoredProcedureName, Parameters);
        }
        public int Current(int sptid) {
            String StoredProcedureName = "Total_Res_Current_Month";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            int total_res=6;
            Parameters.Add("@SPTID", sptid);
            Parameters.Add("@TOT_RES", total_res);
            MySqlDataReader r=dbMan.ReturnReader(StoredProcedureName, Parameters,1);

            total_res = Convert.ToInt16(r.GetValue(0));
            r.Close();
            return total_res;
        }
        public DataTable Reviews(int spotid,int filt) {
            String StoredProcedureName = "View_Review";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SPTID", spotid);
            Parameters.Add("@rat", filt);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public int SetArrival(int empid) {
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string query="UPDATE Employee SET Arrival='"+now+"'WHERE Employee_ID="+empid+";";
            return dbMan.ExecuteNonQuery(query);

        }
        public int SetDep(int empid) {
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string query="UPDATE Employee SET Departure='"+now+"'WHERE Employee_ID="+empid+";";
            int x=dbMan.ExecuteNonQuery(query);
            if (x == 1) {
                query = "SELECT Arrival,Monthly_Worked_Hours FROM Employee WHERE Employee_ID=" + empid + ";";
                DataTable d = dbMan.ExecuteReader(query);
                DateTime arr=Convert.ToDateTime(d.Rows[0].ItemArray[0]);
                TimeSpan hours = DateTime.Now - arr;
                int s = Convert.ToInt32(d.Rows[0].ItemArray[1]) + Convert.ToInt32(hours.Hours);
                query = "UPDATE Employee SET Monthly_Worked_Hours=" + s+ " WHERE Employee_ID=" + empid + ";";
                return dbMan.ExecuteNonQuery(query);
            }

            return x;
        }
      //;;;;;;;;;;;;;;Salma;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

        public int InsertAccount(string username, string password, string type)
        {
            String StoredProcedureName = "Insert_Account";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@username", username);
            Parameters.Add("@password", password);
            Parameters.Add("@Type", type);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int InsertEmpl(string Ename, Int64 Essn, int tel, int salary, string username, int spotid)
        {
            String StoredProcedureName = "Insert_employee";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@E_Name", Ename);
            Parameters.Add("@E_SSN", Essn);
            Parameters.Add("@E_Tel", tel);
            Parameters.Add("@E_User_name", username);
            Parameters.Add("@E_Salary", salary);
            Parameters.Add("@E_Spot_ID", spotid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable SelectEmpNameSSN(int spotid)
        {
            string query = "SELECT EName,Employee_ID FROM employee AS E, account AS A WHERE Spot_ID = " + spotid + "  AND E.Username = A.Username AND Type = 'employee';";
            return dbMan.ExecuteReader(query);
        }
        public int UpdateSalary(int eid, int salary)
        {
            string query = "UPDATE employee SET Salary =" + salary + " WHERE Employee_ID = " + eid + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int DeleteAccount(int eid)
        {
            string query = "DELETE FROM account WHERE Username IN ( SELECT employee.Username FROM employee WHERE Employee_ID=" + eid + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int DeleteEmp(int eid)
        {
            string query = "DELETE FROM employee WHERE Employee_ID=" + eid + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable FindEmp(Int64 ssn )
        {
            string query = "SELECT EName FROM employee WHERE SSN=" + ssn+ ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable FindUsername(string username)
        {
            string query = "SELECT * FROM account WHERE Username='" + username + "';";
            return dbMan.ExecuteReader(query);
        }
     
         public int UpdatePayAndOvertimeRates(int payrate, int overrate, int sid)
         {
             string query = "UPDATE parking_place SET Pay_Rate =" + payrate + ", Overtime_Rate=" + overrate + " WHERE Spot_ID = " + sid + ";";
             return dbMan.ExecuteNonQuery(query);
         }
   
         /*public int InsertTransaction(DateTime arr, DateTime dep, float pay, string method, int cid, int sid, float deposite)
         {
             string query = "INSERT INTO transactions (Arrival_DateTime,Dep_DateTime,Amount_Paid,Payment_Method,CID,SID,Deposit) VALUES (" + arr + "," + dep + "," + pay + ",'" + method + "'," + cid + "," + sid + "," + deposite + ");";
             return dbMan.ExecuteNonQuery(query);

         }*/
     
         public DataTable GetGarageInfo(int S_ID)
         {
             String StoredProcedureName = "Garage_Details";
             Dictionary<string, object> Parameters = new Dictionary<string, object>();
             Parameters.Add("@S_ID", S_ID);
             return dbMan.ExecuteReader(StoredProcedureName, Parameters);
         }
        
         public DataTable SelectAllParking(int S_ID, Int32 platesno)
         {
             string query;
             if (platesno < 0)
             {
                 query = "SELECT Client_Name,Client_ID,Plates_Number,Expected_Dep,Arrival,Floor,Lane,Section,Deposit FROM all_current WHERE Spot_ID= " + S_ID + ";";
             }
             else if (S_ID < 0)
                 query = "SELECT Client_Name FROM all_current WHERE Plates_Number= " + platesno + ";";

             else
                 query = "SELECT Client_Name,Client_ID,Plates_Number,Expected_Dep,Arrival,Floor,Lane,Section,Deposit FROM all_current WHERE Spot_ID= " + S_ID + " AND Plates_Number= " + platesno + ";";
             return dbMan.ExecuteReader(query);
         }
        
         public DataTable SelectParkingOfClient(int S_ID,int cid)
        {
            string query = "SELECT Plates_Number FROM current_parking WHERE Spot_ID= " + S_ID +" and Client_ID="+cid+ ";";
            return dbMan.ExecuteReader(query);
        }

       public int InsertTransaction(DateTime arr,DateTime dep,float pay,string method,int cid,int sid,float deposite)
        {
            String StoredProcedureName = "Insert_Transaction";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@arr", arr);
            Parameters.Add("@dep", dep);
            Parameters.Add("@pay", pay);
            Parameters.Add("@method", method);
            Parameters.Add("@cid", cid);
            Parameters.Add("@sid", sid);
            Parameters.Add("@deposite", deposite);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);

        }

       public DataTable SelectReservation(int spotid, int cid)
       {
           String StoredProcedureName = "SelectReservation";
           Dictionary<string, object> Parameters = new Dictionary<string, object>();
           Parameters.Add("@spotid", spotid);
           Parameters.Add("@cid", cid);
           return dbMan.ExecuteReader(StoredProcedureName, Parameters);
       }
       public DataTable SelectClientFromReservation(int spotid)
       {
           string query = "SELECT CName,C.Client_ID FROM clients AS C,reservation AS R WHERE C.Client_ID = R.Client_ID AND Spot_ID=" + spotid + ";";
           return dbMan.ExecuteReader(query);
       }
       public int DeleteParkingCar(Int32 platesno)
       {
           string query = "DELETE FROM current_parking WHERE Plates_Number= " + platesno + ";";
           return dbMan.ExecuteNonQuery(query);
       }
       public DataTable SelectDepTimeFromReservation(int spotid)
       {
           string query = "SELECT Reservation_ID,DepDT FROM reservation WHERE Spot_ID=" + spotid + ";";
           return dbMan.ExecuteReader(query);
       }
       public DataTable SelectAllReservationbyID(int Res_ID)
       {
           string query = "SELECT * FROM reservation WHERE Reservation_ID = " + Res_ID;
           return dbMan.ExecuteReader(query);
       }
       public int DeleteReservation(int rid)
       {
           string query = "DELETE FROM reservation WHERE Reservation_ID= " + rid + ";";
           return dbMan.ExecuteNonQuery(query);
       }
       public int InsertParkingCar(DateTime arr, DateTime dep, Int32 pno, int floor, int lane, char section, int cid, int sid, float deposite)
       {
           String StoredProcedureName = "InsertParkingCar";
           Dictionary<string, object> Parameters = new Dictionary<string, object>();
           Parameters.Add("@arr", arr);
           Parameters.Add("@dep", dep);
           Parameters.Add("@pno", pno);
           Parameters.Add("@floor", floor);
           Parameters.Add("@lane", lane);
           Parameters.Add("@section", section);
           Parameters.Add("@cid", cid);
           Parameters.Add("@sid", sid);
           Parameters.Add("@deposite", deposite);
           return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);

       }
       public DataTable SelectAllTrans(int sid)
       {
           string query = "SELECT Month,Year,Total_Amount_Paid,Total_Deposit,Client_ID,Client_Name FROM all_trans WHERE SID = " + sid + ";";
           return dbMan.ExecuteReader(query);
       }
       public DataTable SelectTrans(int sid, double amount, int value, int month, int year)
       {
           string query = "";
           if (value == -1)
               query = "SELECT Total_Amount_Paid,Total_Deposit,Client_ID,Client_Name FROM all_trans WHERE SID = " + sid + " and Total_Amount_Paid <" + amount + " and Month=" + month + " and Year=" + year + ";";
           if (value == 0)
               query = "SELECT Total_Amount_Paid,Total_Deposit,Client_ID,Client_Name FROM all_trans WHERE SID = " + sid + " and Total_Amount_Paid =" + amount + " and Month=" + month + " and Year=" + year + ";";
           if (value == 1)
               query = "SELECT Total_Amount_Paid,Total_Deposit,Client_ID,Client_Name FROM all_trans WHERE SID = " + sid + " and Total_Amount_Paid >" + amount + " and Month=" + month + " and Year=" + year + ";";

           return dbMan.ExecuteReader(query);
       }
       public DataTable SelectTransClient(int sid, int cid, int month, int year)
       {
           string query = "SELECT Total_Amount_Paid,Total_Deposit,Client_ID,Client_Name FROM all_trans WHERE SID = " + sid + " and Client_ID =" + cid + " and Month=" + month + " and Year=" + year + ";";
           return dbMan.ExecuteReader(query);
       }

       public List<List<object>> Selectfreeforparkingnow(string depofadded)
       {
           DataTable full;
           DataTable all;
           string query = "(select Spot_ID,Floor,Section,Lane from parkingfinder.reservation where ArrDT < '" + depofadded + "') UNION (select Spot_ID,Floor,Section,Lane from parkingfinder.current_parking);";
           string query1 = "select Spot_ID, No_Floors, No_Sections, No_Lanes from parkingfinder.parking_place;";
           full = dbMan.ExecuteReader(query);
           all = dbMan.ExecuteReader(query1);
           List<List<object>> empty = new List<List<object>>();

           {
               foreach (DataRow parkingplace in all.Rows)
               {
                   int spot_id = (int)parkingplace["Spot_ID"];
                   int floors = (int)parkingplace["No_Floors"];
                   int sections = (int)parkingplace["No_Sections"];
                   int Lanes = (int)parkingplace["No_Lanes"];
                   for (int i = 0; i < floors; i++)
                   {
                       for (int j = 0; j < sections; j++)
                       {
                           char m;
                           m = (char)(j + (int)'A');

                           for (int k = 0; k < Lanes; k++)
                           {
                               if (!full.AsEnumerable().Any(x => (int)x["Spot_ID"] == spot_id && (int)x["Floor"] == i && (string)x["Section"] == m.ToString() && (int)x["Lane"] == k))
                               {
                                   List<object> FSL = new List<object>();
                                   FSL.Add(spot_id);
                                   FSL.Add(i);
                                   FSL.Add(m);
                                   FSL.Add(k);
                                   empty.Add(FSL);
                               }
                           }
                       }

                   }

               }
               return empty;
           }

       }
       public DataTable FindInParkingCars(int spotid, int lane, int section, int floor)
       {
           string query = "Select * From current_parking WHERE Spot_ID=" + spotid + " AND Lane=" + lane + " AND Section='" + section + "' AND Floor=" + floor + ";";
           return dbMan.ExecuteReader(query);
       }
        //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
      
        //;;;;;;;;;;;;;;;Client;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        //;;;;;;;;;;;;;;;;;Mai;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        public int ChangeReservation(int res_ID, DateTime arrival, DateTime departure, float deposit, int floor, int lane, String section, int Spot_ID) //MAI
        {
            string query = "UPDATE reservation SET ArrDT='" + arrival.ToString("yyyy-MM-dd HH:mm:ss") + "',DepDT='" + departure.ToString("yyyy-MM-dd hh:mm:ss") + "',Deposit=" + deposit + ",Floor=" + floor + ",Lane=" + lane + ",Section='" + section + "',Spot_ID=" + Spot_ID + " WHERE Reservation_ID=" + res_ID + ";";
            return (int)dbMan.ExecuteNonQuery(query);
        }

        public int addReservation(DateTime arrival, DateTime departure, float deposit, int floor, int lane, String section, int client_ID, int Spot_ID)
        {
            string query = "INSERT INTO reservation ( ArrDT, DepDT, Deposit, Floor, Lane, Section,Client_ID,Spot_ID) VALUES (" +


                "'" + arrival.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "'" + departure.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "" + deposit + "," +
                "" + floor + "," +
                "" + lane + "," +
                "'" + section + "'," +
                "" + client_ID + "," +
                 "" + Spot_ID +
                "" + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int addtoRefund(DateTime Refund_date, string cancel_reason, float amount_refunded, int clientID, int spotID)
        {
            string query = "INSERT INTO refund (Date_Of_Cancel, Cancel_Reason, Amount_Refunded, Client_ID,Spot_ID) VALUES (" +

                "'" + Refund_date.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "'" + cancel_reason + "'," +
                "" + amount_refunded + "," +
                "" + clientID + "," +
                "" + spotID +
                "" + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int addtoRefund2(DateTime Canceldate, string reason, float amount, int clientid, int spotid)
        {

            string StoredProcedureName = StoredProcedures.addRefund;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@canceldate", Canceldate.ToString("yyyy-MM-dd"));
            Parameters.Add("@reason", reason);
            Parameters.Add("@amount", amount);
            Parameters.Add("@clientid", clientid);
            Parameters.Add("@spotid", spotid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }


        public int SaveGarage(int clientID, int spotID)
        {
            string query = "INSERT INTO saved_place (Client_ID,Spot_ID) VALUES (" +

                "" + clientID + "," +
                "" + spotID +
                "" + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int SaveGarage2(int clientid, int spotid)
        {

            string StoredProcedureName = StoredProcedures.saveGarage;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@clientid", clientid);
            Parameters.Add("@spotid", spotid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int UpdatePlatesNumber(Int32 pno, Int32 prevpno)
        {
            string query = "UPDATE current_parking SET Plates_Number=" + pno + " WHERE Plates_Number=" + prevpno + ";";
            return (int)dbMan.ExecuteNonQuery(query);
        }
        public int UpdateClientIDParkingCar(Int32 pno, int id)
        {
            string query = "UPDATE current_parking SET Client_ID=" + id + " WHERE Plates_Number=" + pno + ";";
            return (int)dbMan.ExecuteNonQuery(query);
        }
        public int UpdateLocationParkingCar(Int32 pno, int f, char s, int l)
        {
            string query = "UPDATE current_parking SET Floor=" + f + ", Section ='" + s + "', Lane =" + l + " WHERE Plates_Number=" + pno + ";";
            return (int)dbMan.ExecuteNonQuery(query);
        }
        public DataTable checkeditdep(int spotid, int lane, char section, int floor, string dep)
        {
            string query = "Select * From reservation WHERE Spot_ID=" + spotid + " AND Lane=" + lane + " AND Section='" + section + "' AND Floor=" + floor + " AND ArrDT<'" + dep + "';";
            return dbMan.ExecuteReader(query);
        }
        public int UpdateDepTime(Int32 pno, string dep)
        {
            string query = "UPDATE current_parking SET Expected_Dep='" + dep + "' WHERE Plates_Number=" + pno + ";";
            return (int)dbMan.ExecuteNonQuery(query);
        }


        public DataTable SelectReservationbyID(int Res_ID)
        {
            string query = "SELECT ArrDT,DepDT,Floor,Section,Lane,Spot_ID FROM reservation WHERE Reservation_ID = " + Res_ID;
            return dbMan.ExecuteReader(query);
        }
        public int CancelReservation(int res_ID)
        {
            string query = "DELETE FROM reservation WHERE Reservation_ID=" + res_ID;
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable SelectGaragesNames()
        {
            string query = "select SName,Spot_ID from parkingfinder.parking_place;";
            return dbMan.ExecuteReader(query);
        }
        public DateTime getArrDT(int res_ID)
        {
            string query = "SELECT ArrDT FROM reservation WHERE Reservation_ID=" + res_ID + ";";
            return (DateTime)dbMan.ExecuteScalar(query);
        }
        public DateTime getDepDT(int res_ID)
        {
            string query = "SELECT DepDT FROM reservation WHERE Reservation_ID=" + res_ID + ";";
            return (DateTime)dbMan.ExecuteScalar(query);
        }
        public List<List<object>> Selectfreeplaces()
        {
            DataTable full;
            DataTable all;
            string query = "(select Spot_ID,Floor,Section,Lane from parkingfinder.reservation)UNION(select Spot_ID,Floor,Section,Lane from parkingfinder.current_parking);";
            string query1 = "select Spot_ID, No_Floors, No_Sections, No_Lanes from parkingfinder.parking_place;";
            full = dbMan.ExecuteReader(query);
            all = dbMan.ExecuteReader(query1);
            List<List<object>> empty = new List<List<object>>();

            {
                foreach (DataRow parkingplace in all.Rows)
                {
                    int spot_id = (int)parkingplace["Spot_ID"];
                    int floors = (int)parkingplace["No_Floors"];
                    int sections = (int)parkingplace["No_Sections"];
                    int Lanes = (int)parkingplace["No_Lanes"];
                    for (int i = 0; i < floors; i++)
                    {
                        for (int j = 0; j < sections; j++)
                        {
                            char m;
                            m = (char)(j + (int)'A');

                            for (int k = 0; k < Lanes; k++)
                            {
                                if (!full.AsEnumerable().Any(x => (int)x["Spot_ID"] == spot_id && (int)x["Floor"] == i && (string)x["Section"] == m.ToString() && (int)x["Lane"] == k))
                                {
                                    List<object> FSL = new List<object>();
                                    FSL.Add(spot_id);
                                    FSL.Add(i);
                                    FSL.Add(m);
                                    FSL.Add(k);
                                    empty.Add(FSL);
                                }
                            }
                        }

                    }

                }
                return empty;
            }

        }
        public List<List<object>> Selectfreeandcurrent(int res_ID)
        {
            DataTable full;
            DataTable all;
            string query = "(select Spot_ID,Floor,Section,Lane from parkingfinder.reservation)UNION(select Spot_ID,Floor,Section,Lane from parkingfinder.current_parking);";
            string query1 = "select Spot_ID, No_Floors, No_Sections, No_Lanes from parkingfinder.parking_place;";
            full = dbMan.ExecuteReader(query);
            all = dbMan.ExecuteReader(query1);
            List<List<object>> empty = new List<List<object>>();

            {
                foreach (DataRow parkingplace in all.Rows)
                {
                    int spot_id = (int)parkingplace["Spot_ID"];
                    int floors = (int)parkingplace["No_Floors"];
                    int sections = (int)parkingplace["No_Sections"];
                    int Lanes = (int)parkingplace["No_Lanes"];
                    for (int i = 0; i < floors; i++)
                    {
                        for (int j = 0; j < sections; j++)
                        {
                            char m;
                            m = (char)(j + (int)'A');

                            for (int k = 0; k < Lanes; k++)
                            {
                                if (!full.AsEnumerable().Any(x => (int)x["Spot_ID"] == spot_id && (int)x["Floor"] == i && (string)x["Section"] == m.ToString() && (int)x["Lane"] == k))
                                {
                                    List<object> FSL = new List<object>();
                                    FSL.Add(spot_id);
                                    FSL.Add(i);
                                    FSL.Add(m);
                                    FSL.Add(k);
                                    empty.Add(FSL);
                                }
                            }
                        }

                    }

                }
                string query2 = "select Spot_ID,Floor,Section,Lane from parkingfinder.reservation where Reservation_ID=" + res_ID;
                DataTable current = dbMan.ExecuteReader(query2);
                int Spot_ID = (int)current.Rows[0][0];
                int Floor = (int)current.Rows[0][1];
                char Section = current.Rows[0][2].ToString()[0];
                int Lane = (int)current.Rows[0][3];

                List<object> current1 = new List<object>();
                current1.Add(Spot_ID);
                current1.Add(Floor);
                current1.Add(Section);
                current1.Add(Lane);
                empty.Add(current1);
                return empty;
            }

        }
        public List<int> Selectfreegarages(List<List<object>> empty)
        {
            return new List<int>(empty.Select(x => (int)x[0]).Distinct());
        }

        public List<int> Selectfreefloors(List<List<object>> empty, int spot_id)
        {
            return new List<int>(empty.Where(x => (int)x[0] == spot_id).Select(x => (int)x[1]).Distinct());
        }
        public List<string> Selectfreesections(List<List<object>> empty, int spot_id, int floor)
        {
            return new List<string>(empty.Where(x => (int)x[0] == spot_id && (int)x[1] == floor).Select(x => x[2].ToString()).Distinct());
        }
        public List<int> Selectfreelanes(List<List<object>> empty, int spot_id, int floor, string section)
        {
            return new List<int>(empty.Where(x => (int)x[0] == spot_id && (int)x[1] == floor && x[2].ToString() == section).Select(x => (int)x[3]).Distinct());
        }


        public DataTable getGaragesnamesbyID(List<int> garages)
        {

            string query = "select SName,Spot_ID from parking_place where Spot_ID IN (" + String.Join(",", garages.Select(Pno => Pno.ToString()).ToArray()) + ");";
            return dbMan.ExecuteReader(query);
        }

        public float getgaragePayRateDeposit(int spot_ID)
        {
            string query = "select Pay_Rate from parking_place where parking_place.Spot_ID=" + spot_ID + ";";
            Object obj = dbMan.ExecuteScalar(query);
            return (float)obj;
        }
        public float getRefundAmount(int res_ID)
        {
            string query = "Select Deposit FROM reservation where Reservation_ID=" + res_ID;
            return (float)dbMan.ExecuteScalar(query);
        }
        public int getgarageID(int res_ID)
        {
            string query = "Select Spot_ID FROM reservation where Reservation_ID=" + res_ID;
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getclientID(int res_ID)
        {
            string query = "Select Client_ID FROM reservation where Reservation_ID=" + res_ID;
            return (int)dbMan.ExecuteScalar(query);
        }
        public string getGarageName(int garage_ID)
        {
            string query = "Select SName FROM parking_place where Spot_ID=" + garage_ID;
            return dbMan.ExecuteScalar(query).ToString();
        }
        public float getGaragePayRate(int garage_ID)
        {
            string query = "Select Pay_Rate FROM parking_place where Spot_ID=" + garage_ID;
            return (float)dbMan.ExecuteScalar(query);
        }
        public float getGarageOverRate(int garage_ID)
        {
            string query = "Select overtime_Rate FROM parking_place where Spot_ID=" + garage_ID;
            return (float)dbMan.ExecuteScalar(query);
        }
        public int getNo_Floors(int garage_ID)
        {
            string query = "Select No_Floors FROM parking_place where Spot_ID=" + garage_ID;
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getNo_Sections(int garage_ID)
        {
            string query = "Select No_Sections FROM parking_place where Spot_ID=" + garage_ID;
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getNo_Lanes(int garage_ID)
        {
            string query = "Select No_Lanes FROM parking_place where Spot_ID=" + garage_ID;
            return (int)dbMan.ExecuteScalar(query);
        }
        public string getStreet(int garage_ID)
        {
            string query = "Select Street FROM parking_place where Spot_ID=" + garage_ID;
            return dbMan.ExecuteScalar(query).ToString();
        }
        public string getDistrict(int garage_ID)
        {
            string query = "Select District FROM parkingfinder.location,parkingfinder.parking_place where location.Location_ID=parking_place.Location_ID and Spot_ID=" + garage_ID;
            return dbMan.ExecuteScalar(query).ToString();
        }
        public string getArea(int garage_ID)
        {
            string query = "Select Area FROM parkingfinder.location,parkingfinder.parking_place where location.Location_ID=parking_place.Location_ID and Spot_ID=" + garage_ID;
            return dbMan.ExecuteScalar(query).ToString();
        }
        public string getCity(int garage_ID)
        {
            string query = "Select City FROM parkingfinder.location,parkingfinder.parking_place where location.Location_ID=parking_place.Location_ID and Spot_ID=" + garage_ID;
            return dbMan.ExecuteScalar(query).ToString();
        }

        public decimal getRatingsavrg(int garage_ID)
        {
            string query = "Select avg(Rating) FROM ratings where SID=" + garage_ID+";";
            object o = dbMan.ExecuteScalar(query);
            if (o != DBNull.Value)
             return Convert.ToDecimal(o);
            return 0;
        }
        public DataTable SelectReservationDESC(int client_ID)
        {
            string query = "Select Reservation_ID, concat(SName,': Floor ',Floor,' :Section ',Section,' :Lane ',Lane) as Description  From reservation INNER JOIN parking_place ON reservation.Spot_ID = parking_place.Spot_ID WHERE Client_ID=" + client_ID;
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectReservationDESC2(int client_ID)
        {
            string StoredProcedureName = StoredProcedures.getDescription;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("clientID", client_ID);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public int getClientID() //get current user name //Sahar
        {
            string query = "SELECT Client_ID FROM clients WHERE username='" + user_name + "';";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable getSavedGarages(int client_ID)
        {

            string query = "Select parking_place.Spot_ID,parking_place.SName From parking_place INNER JOIN saved_place ON saved_place.Spot_ID = parking_place.Spot_ID WHERE saved_place.Client_ID = " + client_ID;
            return dbMan.ExecuteReader(query);
        }
        //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    }
}
