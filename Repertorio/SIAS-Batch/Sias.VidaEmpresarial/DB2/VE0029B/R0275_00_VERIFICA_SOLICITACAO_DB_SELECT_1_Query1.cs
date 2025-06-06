using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0029B
{
    public class R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1 : QueryBasis<R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            SITUACAO
            INTO :V1REL-SITUACAO
            FROM SEGUROS.V1RELATORIOS
            WHERE NUM_APOLICE = :V0PEND-NUM-APOL
            AND CODSUBES = :V0PEND-COD-SUBG
            AND CODRELAT = :V1REL-CODRELAT
            AND IDSISTEM = :V1REL-IDSISTEM
            AND SITUACAO = :V1REL-SITUACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SITUACAO
											FROM SEGUROS.V1RELATORIOS
											WHERE NUM_APOLICE = '{this.V0PEND_NUM_APOL}'
											AND CODSUBES = '{this.V0PEND_COD_SUBG}'
											AND CODRELAT = '{this.V1REL_CODRELAT}'
											AND IDSISTEM = '{this.V1REL_IDSISTEM}'
											AND SITUACAO = '{this.V1REL_SITUACAO}'";

            return query;
        }
        public string V1REL_SITUACAO { get; set; }
        public string V0PEND_NUM_APOL { get; set; }
        public string V0PEND_COD_SUBG { get; set; }
        public string V1REL_CODRELAT { get; set; }
        public string V1REL_IDSISTEM { get; set; }

        public static R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1 Execute(R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1 r0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1)
        {
            var ths = r0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1REL_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}