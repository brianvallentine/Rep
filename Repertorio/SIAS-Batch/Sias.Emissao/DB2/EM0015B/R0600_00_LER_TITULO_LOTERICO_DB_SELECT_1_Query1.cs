using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1 : QueryBasis<R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_PROPOSTA),0)
            INTO :LTMVPROP-SEQ-PROPOSTA
            FROM SEGUROS.LT_MOV_PROPOSTA
            WHERE NUM_APOLICE = :V0EMISD-NUM-APOLICE
            AND COD_MOVIMENTO = '9'
            AND SIT_MOVIMENTO IN ( '1' , 'T' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_PROPOSTA)
							,0)
											FROM SEGUROS.LT_MOV_PROPOSTA
											WHERE NUM_APOLICE = '{this.V0EMISD_NUM_APOLICE}'
											AND COD_MOVIMENTO = '9'
											AND SIT_MOVIMENTO IN ( '1' 
							, 'T' )";

            return query;
        }
        public string LTMVPROP_SEQ_PROPOSTA { get; set; }
        public string V0EMISD_NUM_APOLICE { get; set; }

        public static R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1 Execute(R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1 r0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTMVPROP_SEQ_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}