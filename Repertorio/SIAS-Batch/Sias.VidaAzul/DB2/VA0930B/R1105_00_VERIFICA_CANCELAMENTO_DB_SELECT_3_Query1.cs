using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1 : QueryBasis<R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPERACAO ,
            DATA_OPERACAO
            INTO :SEGURHIS-COD-OPERACAO ,
            :SEGURHIS-DATA-OPERACAO
            FROM SEGUROS.SEGURADOSVGAP_HIST
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND COD_OPERACAO BETWEEN 400 AND 499
            ORDER BY DATA_OPERACAO DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_OPERACAO 
							,
											DATA_OPERACAO
											FROM SEGUROS.SEGURADOSVGAP_HIST
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND COD_OPERACAO BETWEEN 400 AND 499
											ORDER BY DATA_OPERACAO DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string SEGURHIS_COD_OPERACAO { get; set; }
        public string SEGURHIS_DATA_OPERACAO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }

        public static R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1 Execute(R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1 r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1)
        {
            var ths = r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1();
            var i = 0;
            dta.SEGURHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SEGURHIS_DATA_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}