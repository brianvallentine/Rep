using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0100S
{
    public class R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1 : QueryBasis<R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VALRDT), 0)
            INTO :V1REND-VALRDT
            FROM SEGUROS.V1RENDIMENTO
            WHERE IDECBT = :V2FAVO-IDECBT
            AND CODPDT = :V1FAVO-CODFAV
            AND SITUACAO IN ( '0' , '1' )
            AND CODSVI IN (0,0561,0588,3208,
            8045,3223,0916)
            AND (DATRDT BETWEEN :WS-DTINIREF
            AND :WS-DTFIMREF)
            AND COD_EMPRESA = :WHOST-CODEMP
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VALRDT)
							, 0)
											FROM SEGUROS.V1RENDIMENTO
											WHERE IDECBT = '{this.V2FAVO_IDECBT}'
											AND CODPDT = '{this.V1FAVO_CODFAV}'
											AND SITUACAO IN ( '0' 
							, '1' )
											AND CODSVI IN (0
							,0561
							,0588
							,3208
							,
											8045
							,3223
							,0916)
											AND (DATRDT BETWEEN '{this.WS_DTINIREF}'
											AND '{this.WS_DTFIMREF}')
											AND COD_EMPRESA = '{this.WHOST_CODEMP}'";

            return query;
        }
        public string V1REND_VALRDT { get; set; }
        public string V2FAVO_IDECBT { get; set; }
        public string V1FAVO_CODFAV { get; set; }
        public string WHOST_CODEMP { get; set; }
        public string WS_DTINIREF { get; set; }
        public string WS_DTFIMREF { get; set; }

        public static R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1 Execute(R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1 r0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1)
        {
            var ths = r0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1REND_VALRDT = result[i++].Value?.ToString();
            return dta;
        }

    }
}