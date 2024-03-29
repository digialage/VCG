using DAL;
/// <summary>
/// Developed by Meghana on 11.09.2014 for the List of Accounts Under Arbitration and Execution
/// </summary>
public class ArbitrationExecution
{
    static string strSql = "";
    DAL.DataFetch objDataFetch = new DataFetch();
    Log objLog = new Log();
    public ArbitrationExecution()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string BranchFill()
    {
        strSql = " SELECT BRAN_NAME,BRAN_SNO FROM MASTER.BRANCH";
        return strSql;
    }
    public string ODFill(string branch)
    {
        strSql = " SELECT ODST_SNO,ODST_NAME,ODST_ABBR FROM ODSCHEMESETUP";
        strSql += " WHERE ODST_BRANCH = " + branch;
        strSql += " ORDER BY ODST_SNO";
        return strSql;
    }
    public string LoanFill(string branch)
    {
        strSql = " SELECT LSCH_SNO,LSCH_DES,LSCH_ABBREV ";
        strSql += " FROM LOANSCHEMESETUP ";
        strSql += " WHERE LSCH_BRANCH = " + branch;
        strSql += " ORDER BY LSCH_SNO";
        return strSql;
    }
    public string OtherDuesOD(string branch, string strOD)
    {
        strSql = " SELECT DISTINCT(ACDT_GLLINK) AS GL,ACCM_DESCRIPTION,NVL(ACDT_SLLINK,0) ACDT_SLLINK ";
        strSql += " FROM ACCOUNTMASTERD,ACCOUNTMASTER,ODSCHEMESETUP ";
        strSql += " WHERE ACDT_ABBR = ODST_ABBR ";
        strSql += " AND ACDT_GLLINK = ACCM_CODE ";
        strSql += " AND ACDT_GLLINK <> ODST_GLLINK ";
        strSql += " AND ACDT_GLLINK <> ODST_INTGLLINK ";
        strSql += " AND ACDT_GLLINK <> ODST_PENGLLINK ";
        strSql += " AND ODST_BRANCH = " + branch;
        strSql += " AND ODST_ABBR IN (" + strOD + ")";
        return strSql;
    }
    public string OtherDuesLoan(string branch, string strLoan)
    {
        strSql = " SELECT DISTINCT(ACDT_GLLINK) AS GL,ACCM_DESCRIPTION,NVL(ACDT_SLLINK,0) ACDT_SLLINK ";
        strSql += " FROM ACCOUNTMASTERD,ACCOUNTMASTER,LOANSCHEMESETUP ";
        strSql += " WHERE ACDT_ABBR = LSCH_ABBREV ";
        strSql += " AND ACDT_GLLINK = ACCM_CODE ";
        strSql += " AND ACDT_GLLINK <> LSCH_GLLINK ";
        strSql += " AND ACDT_GLLINK <> LSCH_INTGLLINK ";
        strSql += " AND ACDT_GLLINK <> LSCH_PENGLLINK ";
        strSql += " AND LSCH_BRANCH =" + branch;
        strSql += " AND LSCH_ABBREV IN(" + strLoan + ")";
        return strSql;
    }
}