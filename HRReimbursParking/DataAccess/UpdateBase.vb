Imports System.Configuration
Imports System.Data.SqlClient
Public Class UpdateBase
    Dim Conn As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim DataAccess As New DataAccessBase
#Region "Constanta"
    Dim const_sp_UPDATE_LOGOUT As String = "sp_UPDATE_LOGOUT"
    Dim const_sp_UPDATE_DATA_PARKING As String = "sp_UPDATE_DATA_PARKING"
    Dim const_SP_UPDATE_DATA_REIMBURS_PARKING As String = "SP_UPDATE_DATA_REIMBURS_PARKING"
    Dim const_SP_EDIT_USER_MATRIX As String = "sp_EDIT_USER_MATRIX"
#End Region
    Public Function f_Edit_User_Matrix(ByVal _UserName As String, ByVal _IdMenuChild As String,
                                       ByVal _CreatedBy As String, ByVal ENTITY As String,
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
    Public Function f_UpdateLogout(ByVal _userid As String, ByVal _entity As String) As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        Dim _connectionString As String = Conn
        Return DataAccess.ExecuteNonQuery(_connectionString, const_sp_UPDATE_LOGOUT, CommandType.StoredProcedure, oParam)

    End Function
    Public Function f_EDITDATA_PARKING(ByVal ID As String, ByVal NAMAKARYAWAN As String,
                                       ByVal NOPOL_EXISTING As String, ByVal TYPEKENDARAAN_EXISTING As String,
                                       ByVal NOPOL_UPDATE As String, ByVal TYPEKENDARAAN_UPDATE As String,
                                       ByVal PERIOD_3 As String, ByVal PERIOD_4 As String,
                                       ByVal PERIOD_5 As String, ByVal REMARKS As String, ByVal CREATEDBY As String,
                                       ByVal ENTITY As String, ByVal RANGEPERIOD As String, ByVal NOPOL_UPDATE2 As String,
                                       ByVal NOPOL_EXISTING2 As String, ByVal SINGLEORDOUBLE As String, ByVal SINGLEORDOUBLE_EXISTING As String) As Integer

        Dim oParam(16) As SqlParameter

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

        oParam(12) = New SqlParameter("@RANGEPERIOD", Data.SqlDbType.VarChar)
        oParam(12).Value = CType(RANGEPERIOD, String)

        oParam(13) = New SqlParameter("@NOPOL_UPDATE2", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(NOPOL_UPDATE2, String)

        oParam(14) = New SqlParameter("@SINGLEORDOUBLE", Data.SqlDbType.VarChar)
        oParam(14).Value = CType(SINGLEORDOUBLE, String)

        oParam(15) = New SqlParameter("@NOPOL_EXISTING2", Data.SqlDbType.VarChar)
        oParam(15).Value = CType(NOPOL_EXISTING2, String)

        oParam(16) = New SqlParameter("@SINGLEORDOUBLE_EXISTING", Data.SqlDbType.VarChar)
        oParam(16).Value = CType(SINGLEORDOUBLE_EXISTING, String)

        Dim _connectionString As String = Conn
        Return DataAccess.ExecuteNonQuery(_connectionString, const_sp_UPDATE_DATA_PARKING, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_EDIT_DATA_REIMBURS_PARKING(ByVal Employee_ID As String, ByVal Employee_Name As String, ByVal Entity As String,
                                                 ByVal Type_Vehicle As String, ByVal NoPol_1 As String,
                                                 ByVal NoPol_2 As String, ByVal SingleOrDouble As String, ByVal Total_Amount As String,
                                                 ByVal Date_From As String, ByVal Date_To As String, ByVal Year As Integer, ByVal Total_Days As Integer, ByVal Total_Amount_Approve As String, ByVal Remarks As String,
                                                 ByVal Created_By As String, ByVal Update_By As String, ByVal Flag As String, ByVal Approve_By As String, ByVal idx As String, ByVal source As String)
        Dim oParam(19) As SqlParameter

        oParam(0) = New SqlParameter("@Employee_ID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(Employee_ID, String)

        oParam(1) = New SqlParameter("@Employee_Name", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(Employee_Name, String)

        oParam(2) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(Entity, String)

        oParam(3) = New SqlParameter("@Type_Vehicle", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(Type_Vehicle, String)

        'oParam(4) = New SqlParameter("@Amount", Data.SqlDbType.Decimal)
        'oParam(4).Value = CType(Amount, Decimal)

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

        oParam(12) = New SqlParameter("@Total_Amount_Approve", Data.SqlDbType.VarChar)
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

        oParam(18) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(idx, String)

        oParam(19) = New SqlParameter("@Source", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(source, String)

        Dim _connectionString As String = Conn
        Return DataAccess.ExecuteNonQuery(_connectionString, const_SP_UPDATE_DATA_REIMBURS_PARKING, CommandType.StoredProcedure, oParam)

    End Function
End Class
