using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :V1PARC-QUANTIDADE:VIND-QUANTIDADE
            FROM SEGUROS.V1PARCELA
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOS = :V1PARC-NRENDOS
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.V1PARCELA
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOS = '{this.V1PARC_NRENDOS}'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string V1PARC_QUANTIDADE { get; set; }
        public string VIND_QUANTIDADE { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1 Execute(R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1 r6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_QUANTIDADE = result[i++].Value?.ToString();
            dta.VIND_QUANTIDADE = string.IsNullOrWhiteSpace(dta.V1PARC_QUANTIDADE) ? "-1" : "0";
            return dta;
        }

    }
}