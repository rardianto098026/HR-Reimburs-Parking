Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Public Class InsertBase
    Dim Conn As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim DataAccess As New DataAccessBase
#Region "Constanta"
    Dim const_sp_INSERT_LOGIN As String = "sp_INSERT_LOGIN"
    Dim const_SP_INS_MST_MENU As String = "sp_Add_Master_Menu"
    Dim const_SP_INS_MST_MENU_CHILD As String = "sp_Add_Master_Menu_Child"
    Dim const_SP_INSERT_USER_MATRIX As String = "sp_ADD_USER_MATRIX"
    Dim const_SP_EDIT_USER_MATRIX As String = "sp_EDIT_USER_MATRIX"
    Dim const_SP_UPLOAD_DATA_REIMBURS As String = "sp_INSERT_TRN_UPLOAD_DATA_PARKIR"
    Dim const_SP_GET_BODY_EMAIL As String = "Get_Body_Email"
    Dim const_SP_INS_USER_PASS As String = "SP_INS_USER_PASS"
    Dim const_SP_INSERT_AMOUNT_VEHICLE As String = "SP_INSERT_AMOUNT_VEHICLE"
    Dim const_SP_INSERT_TRN_REIMBURSMENT_PARKING_EMPLOYEE As String = "SP_INSERT_TRN_REIMBURSMENT_PARKING_EMPLOYEE"
    Dim const_sp_INSERT_MST_EXPIRED As String = "sp_INSERT_MST_EXPIRED"
#End Region
    Public Function f_InsertLogin(ByVal _userid As String, ByVal _ip As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        oParam(1) = New SqlClient.SqlParameter("@IP", SqlDbType.VarChar)
        oParam(1).Value = CType(_ip, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_INSERT_LOGIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Insert_Mst_Menu(ByVal _MenuName As String, ByVal _entity As String)

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlParameter("@MenuName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_MenuName, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_MST_MENU, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_Mst_Menu_Child(ByVal _MenuChildName As String, ByVal _path As String, ByVal _IDMenu As String, ByVal _entity As String)

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlParameter("@MenuChildName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_MenuChildName, String)

        oParam(1) = New SqlParameter("@IDMenu", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IDMenu, String)

        oParam(2) = New SqlParameter("@path", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_path, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_MST_MENU_CHILD, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_User_Matrix(ByVal _UserName As String, ByVal _IdMenuChild As String, _
                                         ByVal _CreatedBy As String, ByVal ENTITY As String, _
                                         ByVal ROLE As String, ByVal EmployeeID As String)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IdMenuChild, String)

        oParam(2) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CreatedBy, String)

        oParam(3) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(ENTITY, String)

        oParam(4) = New SqlParameter("@ROLE", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(ROLE, String)

        oParam(5) = New SqlParameter("@EmployeeID", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(EmployeeID, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INSERT_USER_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Edit_User_Matrix(ByVal _UserName As String, ByVal _IdMenuChild As String, _
                                       ByVal _CreatedBy As String, ByVal ENTITY As String, _
                                       ByVal ROLE As String, ByVal EmployeeID As String)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IdMenuChild, String)

        oParam(2) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CreatedBy, String)

        oParam(3) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(ENTITY, String)

        oParam(4) = New SqlParameter("@ROLE", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(ROLE, String)

        oParam(5) = New SqlParameter("@EmployeeID", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(EmployeeID, String)



        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_EDIT_USER_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_INSERT_UPLOAD_DATA_REIMBURS(ByVal ID As String, ByVal NAMAKARYAWAN As String,
                                       ByVal NOPOL_EXISTING As String, ByVal TYPEKENDARAAN_EXISTING As String,
                                       ByVal NOPOL_UPDATE As String, ByVal NOPOL_UPDATE2 As String, ByVal TYPEKENDARAAN_UPDATE As String,
                                       ByVal SINGLEORDOUBLE As String, ByVal PERIOD_3 As String, ByVal PERIOD_4 As String,
                                       ByVal PERIOD_5 As String, ByVal REMARKS As String, ByVal CREATEDBY As String,
                                       ByVal ENTITY As String, ByVal UPLOADID As Integer, ByVal RANGEPERIOD As String,
                                       ByVal NOPOL_EXISTING2 As String, ByVal SINGLEORDOUBLE_EXISTING As String)

        Dim oParam(17) As SqlParameter

        oParam(0) = New SqlParameter("@ID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ID, String)

        oParam(1) = New SqlParameter("@NAMAKARYAWAN", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(NAMAKARYAWAN, String)

        oParam(2) = New SqlParameter("@NOPOL_EXISTING", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(NOPOL_EXISTING, String)

        oParam(3) = New SqlParameter("@TYPEKENDARAAN_EXISTING", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(TYPEKENDARAAN_EXISTING, String)

        oParam(4) = New SqlParameter("@NOPOL_UPDATE", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(NOPOL_UPDATE, String)

        oParam(5) = New SqlParameter("@TYPEKENDARAAN_UPDATE", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(TYPEKENDARAAN_UPDATE, String)

        oParam(6) = New SqlParameter("@PERIOD_3", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(PERIOD_3, String)

        oParam(7) = New SqlParameter("@PERIOD_4", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(PERIOD_4, String)

        oParam(8) = New SqlParameter("@PERIOD_5", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(PERIOD_5, String)

        oParam(9) = New SqlParameter("@REMARKS", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(REMARKS, String)

        oParam(10) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(CREATEDBY, String)

        oParam(11) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(ENTITY, String)

        oParam(12) = New SqlParameter("@UPLOADID", Data.SqlDbType.VarChar)
        oParam(12).Value = CType(UPLOADID, String)

        oParam(13) = New SqlParameter("@RANGEPERIOD", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(RANGEPERIOD, String)

        oParam(14) = New SqlParameter("@NOPOL_UPDATE2", Data.SqlDbType.VarChar)
        oParam(14).Value = CType(NOPOL_UPDATE2, String)

        oParam(15) = New SqlParameter("@SINGLEORDOUBLE", Data.SqlDbType.VarChar)
        oParam(15).Value = CType(SINGLEORDOUBLE, String)

        oParam(16) = New SqlParameter("@NOPOL_EXISTING2", Data.SqlDbType.VarChar)
        oParam(16).Value = CType(NOPOL_EXISTING2, String)

        oParam(17) = New SqlParameter("@SINGLEORDOUBLE_EXISTING", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(SINGLEORDOUBLE_EXISTING, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_UPLOAD_DATA_REIMBURS, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_GET_BODY_EMAIL(ByVal NAME As String, ByVal EMPLOYEEID As String)

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlParameter("@Name", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(NAME, String)

        oParam(1) = New SqlParameter("@EMPLOYEEID", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(EMPLOYEEID, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_GET_BODY_EMAIL, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_INS_USER_PASS(ByVal USERNAME As String, ByVal PASS As String)

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlParameter("@USERNAME", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(USERNAME, String)

        oParam(1) = New SqlParameter("@PASS", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PASS, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INS_USER_PASS, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_INSERT_AMOUNT_VEHICLE(ByVal Vehicle As String, ByVal Amount As Decimal, ByVal Year As Integer,
                                            ByVal Quarter As String, ByVal Range_Period As String, ByVal Submit As String)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@Vehicle", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(Vehicle, String)

        oParam(1) = New SqlParameter("@Amount", Data.SqlDbType.Decimal)
        oParam(1).Value = CType(Amount, Decimal)

        oParam(2) = New SqlParameter("@Year", Data.SqlDbType.Int)
        oParam(2).Value = CType(Year, String)

        oParam(3) = New SqlParameter("@Quarter", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(Quarter, String)

        oParam(4) = New SqlParameter("@Range_Period", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(Amount, String)

        oParam(5) = New SqlParameter("@Submit", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(Submit, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INSERT_AMOUNT_VEHICLE, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_INSERT_TRN_REIMBURSMENT_PARKING_EMPLOYEE(ByVal Employee_ID As String, ByVal Employee_Name As String, ByVal Entity As String,
                                                               ByVal Type_Vehicle As String, ByVal NoPol_1 As String,
                                                               ByVal NoPol_2 As String, ByVal SingleOrDouble As String, ByVal Total_Amount As String,
                                                               ByVal Date_From As String, ByVal Date_To As String, ByVal Year As Integer, ByVal Total_Days As Integer,
                                                               ByVal Total_Amount_Approve As String, ByVal Remarks As String,
                                                               ByVal Created_By As String, ByVal Update_By As String, ByVal Flag As String, ByVal Approve_By As String)

        Dim oParam(17) As SqlParameter

        oParam(0) = New SqlParameter("@Employee_ID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(Employee_ID, String)

        oParam(1) = New SqlParameter("@Employee_Name", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(Employee_Name, String)

        oParam(2) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(Entity, String)

        oParam(3) = New SqlParameter("@Type_Vehicle", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(Type_Vehicle, String)

        oParam(4) = New SqlParameter("@NoPol_1", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(NoPol_1, String)

        oParam(5) = New SqlParameter("@NoPol_2", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(NoPol_2, String)

        oParam(6) = New SqlParameter("@SingleOrDouble", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(SingleOrDouble, String)

        'oParam(8) = New SqlParameter("@RangePeriod", Data.SqlDbType.VarChar)
        'oParam(8).Value = CType(RangePeriod, String)

        'oParam(9) = New SqlParameter("@Period_1", Data.SqlDbType.VarChar)
        'oParam(9).Value = CType(Period_1, String)

        'oParam(10) = New SqlParameter("@Period_2", Data.SqlDbType.VarChar)
        'oParam(10).Value = CType(Period_2, String)

        'oParam(11) = New SqlParameter("@Period_3", Data.SqlDbType.VarChar)
        'oParam(11).Value = CType(Period_3, String)

        oParam(7) = New SqlParameter("@Total_Amount", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(Total_Amount, String)

        oParam(8) = New SqlParameter("@Date_From", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(Date_From, String)

        oParam(9) = New SqlParameter("@Date_To", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(Date_To, String)

        oParam(10) = New SqlParameter("@Year", Data.SqlDbType.Int)
        oParam(10).Value = CType(Year, String)

        oParam(11) = New SqlParameter("@Total_Days", Data.SqlDbType.Int)
        oParam(11).Value = CType(Total_Days, String)

        oParam(12) = New SqlParameter("@Total_Amount_Approve", Data.SqlDbType.Int)
        oParam(12).Value = CType(Total_Amount_Approve, String)

        oParam(13) = New SqlParameter("@Remarks", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(Remarks, String)

        oParam(14) = New SqlParameter("@Created_By", Data.SqlDbType.VarChar)
        oParam(14).Value = CType(Created_By, String)

        oParam(15) = New SqlParameter("@Update_By", Data.SqlDbType.VarChar)
        oParam(15).Value = CType(Update_By, String)

        oParam(16) = New SqlParameter("@Flag", Data.SqlDbType.VarChar)
        oParam(16).Value = CType(Flag, String)

        oParam(17) = New SqlParameter("@Approve_By", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(Approve_By, String)


        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_SP_INSERT_TRN_REIMBURSMENT_PARKING_EMPLOYEE, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_INSERT_MST_EXPIRED(ByVal QUARTER As String, ByVal Years As String, ByVal DATES As Date,
                                         ByVal CREATEDBY As String, ByVal RANGEPERIOD As String)

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlParameter("@QUARTER", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(QUARTER, String)

        oParam(1) = New SqlParameter("@YEAR", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(Years, String)

        oParam(2) = New SqlParameter("@DATE", Data.SqlDbType.Date)
        oParam(2).Value = CType(DATES, Date)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CREATEDBY, String)

        oParam(4) = New SqlParameter("@RANGEPERIOD", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(RANGEPERIOD, String)

        Dim _connectionString As String = Conn

        Return (DataAccess.ExecuteNonQuery(_connectionString, const_sp_INSERT_MST_EXPIRED, Data.CommandType.StoredProcedure, oParam))

    End Function
End Class