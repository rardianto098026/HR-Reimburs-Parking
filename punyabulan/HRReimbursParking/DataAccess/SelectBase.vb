Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Public Class SelectBase
    Dim Conn As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim DataAccess As New DataAccessBase
#Region "Constanta"
    Dim const_sp_INSERT_LOGIN As String = "sp_INSERT_LOGIN"
    Dim const_sp_CHECK_MENU As String = "sp_check_Menu_MASTER"
    Dim const_sp_CHECK_MENU_NAME_MASTER As String = "sp_check_Menu_name"
    Dim const_sp_InsertUploadFile As String = "sp_INSERT_UPLOADFILE"
    Dim const_sp_SEL_LOAD_DATA_PARKING As String = "sp_SEL_LOAD_DATA_PARKING"
    Dim const_sp_SEL_LIST_PARKING_ADMIN As String = "sp_SEL_LIST_PARKING_ADMIN"
    Dim const_sp_SEL_LOAD_DATA_PARKING_ADMIN As String = "sp_SEL_LOAD_DATA_PARKING_ADMIN"
    Dim const_sp_SEL_EXPORT_PARKING_ADMIN As String = "sp_SEL_EXPORT_PARKING_ADMIN"
    Dim const_sp_SEL_CHECK_DATA_PARKING As String = "sp_SEL_CHECK_DATA_PARKING"
    Dim const_sp_SEL_EMPL_NUMBER As String = "sp_SEL_EMPL_NUMBER"
    Dim const_sp_SEL_EMPL_NUMBER_WITH_EMAIL As String = "sp_SEL_EMPL_NUMBER_WITH_EMAIL"
    Dim const_sp_SEL_CHECK_DATA_PARKING_EMPLOYEE As String = "sp_SEL_CHECK_DATA_PARKING_EMPLOYEE"
    Dim const_sp_SEL_STAT_KARYAWAN As String = "sp_SEL_STAT_KARYAWAN"
    Dim const_sp_GET_TYPE_VEHICLE As String = "sp_GET_TYPE_VEHICLE"
    Dim const_SP_GET_AMOUNT_BY_VEHICLE As String = "SP_GET_AMOUNT_BY_VEHICLE"
    Dim const_SP_GET_EMPLOYEE As String = "SP_GET_EMPLOYEE"
    Dim const_SP_GET_MONTH_QUARTER As String = "SP_GET_MONTH_QUARTER"
    Dim const_SP_GETMONTH_BY_QUARTER As String = "SP_GETMONTH_BY_QUARTER"
    Dim const_SP_GET_TOTAL_AMOUNT As String = "SP_GET_TOTAL_AMOUNT"
    Dim const_SP_GET_TOTAL_DAYS As String = "SP_GET_TOTAL_DAYS"
    Dim const_SP_VALIDATION As String = "SP_VALIDATION"
    Dim const_SP_List_Export As String = "SP_List_Export"
    Dim const_SP_SEL_LIST_PARKING_REIMBURS As String = "SP_SEL_LIST_PARKING_REIMBURS"
    Dim const_SP_SEL_LOAD_DATA_REIMBURSMENT_REQUEST As String = "SP_SEL_LOAD_DATA_REIMBURSMENT_REQUEST"
    'Dim const_SP_SEL_LOADDATA_CALCULATION As String = "SP_SEL_LOADDATA_CALCULATION"
    Dim const_sp_GET_COUNT_REIMBURS_EMPLOYEE As String = "sp_GET_COUNT_REIMBURS_EMPLOYEE"
    Dim const_sp_check_Access_Menu As String = "sp_check_Access_Menu"
    Dim const_SP_CHECK_MST_EMPLOYEE As String = "SP_CHECK_MST_EMPLOYEE"
    Dim const_SP_CHECK_TRN_LOGIN As String = "SP_CHECK_TRN_LOGIN"
    Dim const_SP_CHECK_WORKTYPE As String = "SP_CHECK_WORKTYPE"
    Dim const_sp_SEL_QUARTER As String = "sp_SEL_QUARTER_LOAD"
    Dim const_sp_SEL_QUARTER_SEARCH As String = "sp_SEL_QUARTER_SEARCH"
    Dim const_sp_SEL_LIST_MST_EXPIRED As String = "sp_SEL_LIST_MST_EXPIRED"
    Dim const_SP_CEK_DATE_FROM As String = "SP_CEK_DATE_FROM"
    Dim const_SP_CEK_DATE_TO As String = "SP_CEK_DATE_TO"

#End Region
    Public Function f_CEK_DATE_FROM(ByVal EmpID As String, ByVal Datee As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmpID, String)

        oParam(1) = New SqlClient.SqlParameter("@DATE_FROM", SqlDbType.VarChar)
        oParam(1).Value = CType(Datee, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_CEK_DATE_FROM, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CEK_DATE_TO(ByVal EmpID As String, ByVal Datee As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmpID, String)

        oParam(1) = New SqlClient.SqlParameter("@DATE_TO", SqlDbType.VarChar)
        oParam(1).Value = CType(Datee, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_CEK_DATE_TO, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CHECK_WORKTYPE(ByVal EmpID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmpID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_CHECK_WORKTYPE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CHECK_TRN_LOGIN(ByVal EmpID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmpID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_CHECK_TRN_LOGIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CHECK_MST_EMPLOYEE(ByVal EmpID As String, ByVal EMAIL As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmpID, String)

        oParam(1) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(1).Value = CType(EMAIL, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_CHECK_MST_EMPLOYEE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_check_Access_Menu(ByVal Path As String, ByVal EmpId As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Path", SqlDbType.VarChar)
        oParam(0).Value = CType(Path, String)

        oParam(1) = New SqlClient.SqlParameter("@EmpId", SqlDbType.VarChar)
        oParam(1).Value = CType(EmpId, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_check_Access_Menu, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_InsertLogin(ByVal _userid As String, ByVal _ip As String, ByVal _entity As String, ByVal EMPLID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        oParam(1) = New SqlClient.SqlParameter("@IP", SqlDbType.VarChar)
        oParam(1).Value = CType(_ip, String)

        oParam(2) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(2).Value = CType(EMPLID, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_INSERT_LOGIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CheckMMenus(ByVal _UserName As String, ByVal _MenuID As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlClient.SqlParameter("@IDMenu", SqlDbType.VarChar)
        oParam(1).Value = CType(_MenuID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_CHECK_MENU, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_CheckMMenu(ByVal _UserName As String, ByVal _MenuID As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlClient.SqlParameter("@IDMenu", SqlDbType.VarChar)
        oParam(1).Value = CType(_MenuID, String)

        Dim _connectionString As String = Conn
        'dt = FillDataset(_connectionString, const_sp_CHECK_MENUS, CommandType.StoredProcedure, oParam)
        dt = DataAccess.FillDataset(_connectionString, const_sp_CHECK_MENU_NAME_MASTER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_InsertUploadFile(ByVal _filename As String, ByVal _createdby As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@FILENAME", SqlDbType.VarChar)
        oParam(0).Value = CType(_filename, String)

        oParam(1) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(1).Value = CType(_createdby, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_InsertUploadFile, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LOAD_DATA_PARKING(ByVal EMPLOYEEID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEEID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LOAD_DATA_PARKING, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_PARKING_ADMIN(ByVal EmplID As String, ByVal Name As String, ByVal TypeVeh As String,
                                             ByVal Entity As String, ByVal NoPol As String, ByVal Update As String, ByVal Range As String,
                                             ByVal FlagEmplID As String, ByVal FlagName As String, ByVal FlagTypeVeh As String,
                                             ByVal FlagEntity As String, ByVal FlagNoPol As String, ByVal FlagUpdate As String,
                                             ByVal FlagRange As String, ByVal StatKaryawan As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(14) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmplID, String)

        oParam(1) = New SqlClient.SqlParameter("@Name", SqlDbType.VarChar)
        oParam(1).Value = CType(Name, String)

        oParam(2) = New SqlClient.SqlParameter("@TypeVeh", SqlDbType.VarChar)
        oParam(2).Value = CType(TypeVeh, String)

        oParam(3) = New SqlClient.SqlParameter("@Entity", SqlDbType.VarChar)
        oParam(3).Value = CType(Entity, String)

        oParam(4) = New SqlClient.SqlParameter("@FlagEmplID", SqlDbType.VarChar)
        oParam(4).Value = CType(FlagEmplID, String)

        oParam(5) = New SqlClient.SqlParameter("@FlagName", SqlDbType.VarChar)
        oParam(5).Value = CType(FlagName, String)

        oParam(6) = New SqlClient.SqlParameter("@FlagTypeVeh", SqlDbType.VarChar)
        oParam(6).Value = CType(FlagTypeVeh, String)

        oParam(7) = New SqlClient.SqlParameter("@FlagEntity", SqlDbType.VarChar)
        oParam(7).Value = CType(FlagEntity, String)

        oParam(8) = New SqlClient.SqlParameter("@NoPol", SqlDbType.VarChar)
        oParam(8).Value = CType(NoPol, String)

        oParam(9) = New SqlClient.SqlParameter("@FlagNoPol", SqlDbType.VarChar)
        oParam(9).Value = CType(FlagNoPol, String)

        oParam(10) = New SqlClient.SqlParameter("@Update", SqlDbType.VarChar)
        oParam(10).Value = CType(Update, String)

        oParam(11) = New SqlClient.SqlParameter("@FlagUpdate", SqlDbType.VarChar)
        oParam(11).Value = CType(FlagUpdate, String)

        oParam(12) = New SqlClient.SqlParameter("@Range", SqlDbType.VarChar)
        oParam(12).Value = CType(Range, String)

        oParam(13) = New SqlClient.SqlParameter("@FlagRange", SqlDbType.VarChar)
        oParam(13).Value = CType(FlagRange, String)

        oParam(14) = New SqlClient.SqlParameter("@StatKaryawan", SqlDbType.VarChar)
        oParam(14).Value = CType(StatKaryawan, String)



        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_PARKING_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LOAD_DATA_PARKING_ADMIN(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LOAD_DATA_PARKING_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_EXPORT_PARKING_ADMIN(ByVal EmplID As String, ByVal Name As String, ByVal TypeVeh As String,
                                             ByVal Entity As String, ByVal NoPol As String, ByVal Update As String, ByVal Range As String,
                                             ByVal FlagEmplID As String, ByVal FlagName As String, ByVal FlagTypeVeh As String,
                                             ByVal FlagEntity As String, ByVal FlagNoPol As String, ByVal FlagUpdate As String,
                                             ByVal FlagRange As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(13) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmplID, String)

        oParam(1) = New SqlClient.SqlParameter("@Name", SqlDbType.VarChar)
        oParam(1).Value = CType(Name, String)

        oParam(2) = New SqlClient.SqlParameter("@TypeVeh", SqlDbType.VarChar)
        oParam(2).Value = CType(TypeVeh, String)

        oParam(3) = New SqlClient.SqlParameter("@Entity", SqlDbType.VarChar)
        oParam(3).Value = CType(Entity, String)

        oParam(4) = New SqlClient.SqlParameter("@FlagEmplID", SqlDbType.VarChar)
        oParam(4).Value = CType(FlagEmplID, String)

        oParam(5) = New SqlClient.SqlParameter("@FlagName", SqlDbType.VarChar)
        oParam(5).Value = CType(FlagName, String)

        oParam(6) = New SqlClient.SqlParameter("@FlagTypeVeh", SqlDbType.VarChar)
        oParam(6).Value = CType(FlagTypeVeh, String)

        oParam(7) = New SqlClient.SqlParameter("@FlagEntity", SqlDbType.VarChar)
        oParam(7).Value = CType(FlagEntity, String)

        oParam(8) = New SqlClient.SqlParameter("@NoPol", SqlDbType.VarChar)
        oParam(8).Value = CType(NoPol, String)

        oParam(9) = New SqlClient.SqlParameter("@FlagNoPol", SqlDbType.VarChar)
        oParam(9).Value = CType(FlagNoPol, String)

        oParam(10) = New SqlClient.SqlParameter("@Update", SqlDbType.VarChar)
        oParam(10).Value = CType(Update, String)

        oParam(11) = New SqlClient.SqlParameter("@FlagUpdate", SqlDbType.VarChar)
        oParam(11).Value = CType(FlagUpdate, String)

        oParam(12) = New SqlClient.SqlParameter("@Range", SqlDbType.VarChar)
        oParam(12).Value = CType(Range, String)

        oParam(13) = New SqlClient.SqlParameter("@FlagRange", SqlDbType.VarChar)
        oParam(13).Value = CType(FlagRange, String)



        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EXPORT_PARKING_ADMIN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_CHECK_DATA(ByVal EMPLOYEEID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEEID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_CHECK_DATA_PARKING, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_EMPL_NUMBER(ByVal EMPLOYEENAME As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEENAME", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEENAME, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMPL_NUMBER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_EMPL_NUMBER_WITH_EMAIL(ByVal EMAIL As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(0).Value = CType(EMAIL, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_EMPL_NUMBER_WITH_EMAIL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_CHECK_DATA_PARKING_EMPLOYEE(ByVal EMPLOYEEID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEEID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_CHECK_DATA_PARKING_EMPLOYEE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_STAT_KARYAWAN(ByVal EMPLOYEEID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEEID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_STAT_KARYAWAN, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_GET_TYPE_VEHICLE() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_GET_TYPE_VEHICLE, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_GET_AMOUNT_BY_VEHICLE(ByVal Vehicle As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Vehicle", SqlDbType.VarChar)
        oParam(0).Value = CType(Vehicle, String)


        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_GET_AMOUNT_BY_VEHICLE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_GET_EMPLOYEE(ByVal Employee_ID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Employee_ID", SqlDbType.VarChar)
        oParam(0).Value = CType(Employee_ID, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_GET_EMPLOYEE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_GET_MONTH_QUARTER() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_GET_MONTH_QUARTER, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_GETMONTH_BY_QUARTER(ByVal Quarter As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Quarter", SqlDbType.VarChar)
        oParam(0).Value = CType(Quarter, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_GETMONTH_BY_QUARTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_GET_TOTAL_AMOUNT(ByVal TYPEVEHICLE As String, ByVal JUMLAHPERIODE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@TYPEVEHICLE", SqlDbType.VarChar)
        oParam(0).Value = CType(TYPEVEHICLE, String)

        oParam(1) = New SqlClient.SqlParameter("@JUMLAHPERIODE", SqlDbType.VarChar)
        oParam(1).Value = CType(JUMLAHPERIODE, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_GET_TOTAL_AMOUNT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_GET_TOTAL_DAYS(ByVal Datefrom As String, ByVal Dateto As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Datefrom", SqlDbType.VarChar)
        oParam(0).Value = CType(Datefrom, String)
        oParam(1) = New SqlClient.SqlParameter("@Dateto", SqlDbType.VarChar)
        oParam(1).Value = CType(Dateto, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_GET_TOTAL_DAYS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_VALIDATION(ByVal ID As String, ByVal NAME As String, ByVal YEAR As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMP_ID", SqlDbType.VarChar)
        oParam(0).Value = CType(ID, String)

        oParam(1) = New SqlClient.SqlParameter("@EMP_NAME", SqlDbType.VarChar)
        oParam(1).Value = CType(NAME, String)

        'oParam(2) = New SqlClient.SqlParameter("@RANGE_PERIOD", SqlDbType.VarChar)
        'oParam(2).Value = CType(RANGE_PERIOD, String)

        oParam(2) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(2).Value = CType(YEAR, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_VALIDATION, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_List_Export(ByVal ID As String, ByVal NAME As String, ByVal ENTITY As String, ByVal RANGE As String, ByVal YEAR As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmplID", SqlDbType.VarChar)
        oParam(0).Value = CType(ID, String)
        oParam(1) = New SqlClient.SqlParameter("@Name", SqlDbType.VarChar)
        oParam(1).Value = CType(NAME, String)
        oParam(2) = New SqlClient.SqlParameter("@Entity", SqlDbType.VarChar)
        oParam(2).Value = CType(ENTITY, String)
        oParam(3) = New SqlClient.SqlParameter("@Range", SqlDbType.VarChar)
        oParam(3).Value = CType(RANGE, String)
        oParam(4) = New SqlClient.SqlParameter("@Year", SqlDbType.VarChar)
        oParam(4).Value = CType(YEAR, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_List_Export, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_PARKING_REIMBURS(ByVal Employee_ID As String, ByVal Employee_Name As String, ByVal Entity As String,
                                                ByVal Status As String, ByVal Year As String, ByVal FlagEmployeeID As String,
                                                ByVal FlagEmployeeName As String, ByVal FlagEntity As String, ByVal FlagStatus As String,
                                                ByVal FlagYear As String, ByVal StatKaryawan As String, ByVal Source As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(10) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Employee_ID", SqlDbType.VarChar)
        oParam(0).Value = CType(Employee_ID, String)

        oParam(1) = New SqlClient.SqlParameter("@Employee_Name", SqlDbType.VarChar)
        oParam(1).Value = CType(Employee_Name, String)

        oParam(2) = New SqlClient.SqlParameter("@Entity", SqlDbType.VarChar)
        oParam(2).Value = CType(Entity, String)

        oParam(3) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar)
        oParam(3).Value = CType(Status, String)

        oParam(4) = New SqlClient.SqlParameter("@Year", SqlDbType.VarChar)
        oParam(4).Value = CType(Year, String)

        oParam(5) = New SqlClient.SqlParameter("@FlagEmployeeID", SqlDbType.VarChar)
        oParam(5).Value = CType(FlagEmployeeID, String)

        oParam(6) = New SqlClient.SqlParameter("@FlagEmployeeName", SqlDbType.VarChar)
        oParam(6).Value = CType(FlagEmployeeName, String)

        oParam(7) = New SqlClient.SqlParameter("@FlagEntity", SqlDbType.VarChar)
        oParam(7).Value = CType(FlagEntity, String)

        oParam(8) = New SqlClient.SqlParameter("@FlagStatus", SqlDbType.VarChar)
        oParam(8).Value = CType(FlagStatus, String)

        oParam(9) = New SqlClient.SqlParameter("@FlagYear", SqlDbType.VarChar)
        oParam(9).Value = CType(FlagYear, String)

        oParam(10) = New SqlClient.SqlParameter("@Source", SqlDbType.VarChar)
        oParam(10).Value = CType(Source, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_SEL_LIST_PARKING_REIMBURS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LOAD_DATA_REIMBURSMENT_REQUEST(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_SP_SEL_LOAD_DATA_REIMBURSMENT_REQUEST, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    'Public Function f_SEL_LOADDATA_CALCULATION(ByVal IDX As String) As DataTable

    '    Dim dt As New DataTable
    '    Dim oParam(0) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
    '    oParam(0).Value = CType(IDX, String)

    '    Dim _connectionString As String = Conn
    '    dt = DataAccess.FillDataset(_connectionString, const_SP_SEL_LOADDATA_CALCULATION, CommandType.StoredProcedure, oParam)

    '    Return dt

    'End Function
    Public Function f_SEL_GET_COUNT_REIMBURS_EMPLOYEE(ByVal EMPLOYEEID As String, ByVal YEAR As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLOYEEID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLOYEEID, String)

        oParam(1) = New SqlClient.SqlParameter("@YEAR", SqlDbType.VarChar)
        oParam(1).Value = CType(YEAR, String)

        'oParam(2) = New SqlClient.SqlParameter("@RANGE_PERIOD", SqlDbType.VarChar)
        'oParam(2).Value = CType(RANGE_PERIOD, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_GET_COUNT_REIMBURS_EMPLOYEE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_QUARTER_LOAD() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_QUARTER, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_QUARTER(ByVal Quarter As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@QUARTER", SqlDbType.VarChar)
        oParam(0).Value = CType(Quarter, String)

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_QUARTER_SEARCH, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_MST_EXPIRED() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = Conn
        dt = DataAccess.FillDataset(_connectionString, const_sp_SEL_LIST_MST_EXPIRED, CommandType.StoredProcedure)

        Return dt

    End Function

End Class
