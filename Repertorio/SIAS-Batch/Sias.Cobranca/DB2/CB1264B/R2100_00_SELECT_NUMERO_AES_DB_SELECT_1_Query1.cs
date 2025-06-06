using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1264B
{
    public class R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            ENDOS_CANCELA
            INTO
            :NUMERAES-ENDOS-CANCELA
            FROM
            SEGUROS.NUMERO_AES
            WHERE
            ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR
            AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ENDOS_CANCELA
											FROM
											SEGUROS.NUMERO_AES
											WHERE
											ORGAO_EMISSOR = '{this.APOLICES_ORGAO_EMISSOR}'
											AND RAMO_EMISSOR = '{this.APOLICES_RAMO_EMISSOR}'";

            return query;
        }
        public string NUMERAES_ENDOS_CANCELA { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }

        public static R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 r2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERAES_ENDOS_CANCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}