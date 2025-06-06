using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0130B
{
    public class R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO
            ,DATA_MOV_ABERTO - 02 MONTH
            ,DATA_MOV_ABERTO - 13 MONTH
            ,DATA_MOV_ABERTO + 01 MONTH
            ,YEAR(DATA_MOV_ABERTO + 01 MONTH)
            ,MONTH(DATA_MOV_ABERTO + 01 MONTH)
            INTO :SISTEMAS-DTMOV-ABERTO
            ,:SISTEMAS-DTTER-COTACAO
            ,:SISTEMAS-DTINI-COTACAO
            ,:SISTEMAS-DTMOV-ABERTO-30
            ,:SISTEMAS-DTMOV-YEAR
            ,:SISTEMAS-DTMOV-MONTH
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VE'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
											,DATA_MOV_ABERTO - 02 MONTH
											,DATA_MOV_ABERTO - 13 MONTH
											,DATA_MOV_ABERTO + 01 MONTH
											,YEAR(DATA_MOV_ABERTO + 01 MONTH)
											,MONTH(DATA_MOV_ABERTO + 01 MONTH)
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VE'
											WITH UR";

            return query;
        }
        public string SISTEMAS_DTMOV_ABERTO { get; set; }
        public string SISTEMAS_DTTER_COTACAO { get; set; }
        public string SISTEMAS_DTINI_COTACAO { get; set; }
        public string SISTEMAS_DTMOV_ABERTO_30 { get; set; }
        public string SISTEMAS_DTMOV_YEAR { get; set; }
        public string SISTEMAS_DTMOV_MONTH { get; set; }

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
            dta.SISTEMAS_DTMOV_ABERTO = result[i++].Value?.ToString();
            dta.SISTEMAS_DTTER_COTACAO = result[i++].Value?.ToString();
            dta.SISTEMAS_DTINI_COTACAO = result[i++].Value?.ToString();
            dta.SISTEMAS_DTMOV_ABERTO_30 = result[i++].Value?.ToString();
            dta.SISTEMAS_DTMOV_YEAR = result[i++].Value?.ToString();
            dta.SISTEMAS_DTMOV_MONTH = result[i++].Value?.ToString();
            return dta;
        }

    }
}