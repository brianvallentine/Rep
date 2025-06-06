using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1 : QueryBasis<R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_SINISTRO),0)
            INTO :NUMERAES-SEQ-SINISTRO
            FROM SEGUROS.NUMERO_AES
            WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR
            AND RAMO_EMISSOR = :SIARDEVC-COD-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_SINISTRO)
							,0)
											FROM SEGUROS.NUMERO_AES
											WHERE ORGAO_EMISSOR = '{this.APOLICES_ORGAO_EMISSOR}'
											AND RAMO_EMISSOR = '{this.SIARDEVC_COD_RAMO}'";

            return query;
        }
        public string NUMERAES_SEQ_SINISTRO { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string SIARDEVC_COD_RAMO { get; set; }

        public static R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1 Execute(R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1 r2500_00_MAX_NUMERAES_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_MAX_NUMERAES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_MAX_NUMERAES_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERAES_SEQ_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}