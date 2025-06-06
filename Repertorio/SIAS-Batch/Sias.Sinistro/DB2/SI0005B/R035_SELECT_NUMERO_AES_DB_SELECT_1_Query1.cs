using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1 : QueryBasis<R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_SINISTRO
            INTO :NUMERAES-SEQ-SINISTRO
            FROM SEGUROS.NUMERO_AES
            WHERE ORGAO_EMISSOR = 10
            AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_SINISTRO
											FROM SEGUROS.NUMERO_AES
											WHERE ORGAO_EMISSOR = 10
											AND RAMO_EMISSOR = '{this.APOLICES_RAMO_EMISSOR}'";

            return query;
        }
        public string NUMERAES_SEQ_SINISTRO { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }

        public static R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1 Execute(R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1 r035_SELECT_NUMERO_AES_DB_SELECT_1_Query1)
        {
            var ths = r035_SELECT_NUMERO_AES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERAES_SEQ_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}