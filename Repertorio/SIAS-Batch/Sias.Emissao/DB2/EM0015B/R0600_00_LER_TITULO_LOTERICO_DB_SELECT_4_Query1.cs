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
    public class R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1 : QueryBasis<R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIO ,
            SITUACAO
            INTO :FOLLOUP-VAL-OPERACAO ,
            :FOLLOUP-SIT-REGISTRO
            FROM SEGUROS.V0FOLLOWUP
            WHERE NUM_APOLICE = :LTMVPROP-NUM-TITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIO 
							,
											SITUACAO
											FROM SEGUROS.V0FOLLOWUP
											WHERE NUM_APOLICE = '{this.LTMVPROP_NUM_TITULO}'";

            return query;
        }
        public string FOLLOUP_VAL_OPERACAO { get; set; }
        public string FOLLOUP_SIT_REGISTRO { get; set; }
        public string LTMVPROP_NUM_TITULO { get; set; }

        public static R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1 Execute(R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1 r0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1)
        {
            var ths = r0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1();
            var i = 0;
            dta.FOLLOUP_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.FOLLOUP_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}