using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1 : QueryBasis<R2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.DATA_INIVIGENCIA
            INTO :PROPOSTA-DATA-INIVIGENCIA
            FROM SEGUROS.MR_PROP_RENOVACAO A,
            SEGUROS.PROPOSTAS B
            WHERE A.NUM_TITULO = :MR028-NUM-TITULO
            AND B.COD_FONTE = A.COD_FONTE
            AND B.NUM_PROPOSTA = A.NUM_PROPOSTA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.DATA_INIVIGENCIA
											FROM SEGUROS.MR_PROP_RENOVACAO A
							,
											SEGUROS.PROPOSTAS B
											WHERE A.NUM_TITULO = '{this.MR028_NUM_TITULO}'
											AND B.COD_FONTE = A.COD_FONTE
											AND B.NUM_PROPOSTA = A.NUM_PROPOSTA
											WITH UR";

            return query;
        }
        public string PROPOSTA_DATA_INIVIGENCIA { get; set; }
        public string MR028_NUM_TITULO { get; set; }

        public static R2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1 Execute(R2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1 r2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1)
        {
            var ths = r2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2670_00_SELECT_RENOVACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOSTA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}