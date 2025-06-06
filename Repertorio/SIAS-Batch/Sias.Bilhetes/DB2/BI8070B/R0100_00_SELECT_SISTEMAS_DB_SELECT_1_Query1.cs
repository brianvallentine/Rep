using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO
            ,CURRENT DATE
            ,DATA_MOV_ABERTO - 1 MONTH
            ,DATA_MOV_ABERTO - 12 MONTH
            ,DATA_MOV_ABERTO + 1 MONTH
            ,DATA_MOV_ABERTO + 20 DAYS
            ,DATA_MOV_ABERTO + 10 DAYS
            INTO :SISTEMA-DTMOVABE
            ,:SISTEMA-CURRENT
            ,:SISTEMA-DTTERCOT
            ,:SISTEMA-DTINICOT
            ,:SISTEMA-DTMOV01M
            ,:SISTEMA-DTMOV20D
            ,:SISTEMA-DTMOV10D
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'BI'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
											,CURRENT DATE
											,DATA_MOV_ABERTO - 1 MONTH
											,DATA_MOV_ABERTO - 12 MONTH
											,DATA_MOV_ABERTO + 1 MONTH
											,DATA_MOV_ABERTO + 20 DAYS
											,DATA_MOV_ABERTO + 10 DAYS
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'BI'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }
        public string SISTEMA_CURRENT { get; set; }
        public string SISTEMA_DTTERCOT { get; set; }
        public string SISTEMA_DTINICOT { get; set; }
        public string SISTEMA_DTMOV01M { get; set; }
        public string SISTEMA_DTMOV20D { get; set; }
        public string SISTEMA_DTMOV10D { get; set; }

        public static R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMA_DTMOVABE = result[i++].Value?.ToString();
            dta.SISTEMA_CURRENT = result[i++].Value?.ToString();
            dta.SISTEMA_DTTERCOT = result[i++].Value?.ToString();
            dta.SISTEMA_DTINICOT = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOV01M = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOV20D = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOV10D = result[i++].Value?.ToString();
            return dta;
        }

    }
}