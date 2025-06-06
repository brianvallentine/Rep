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
    public class R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 : QueryBasis<R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TERMO,
            COD_SUBGRUPO,
            PERI_PAGAMENTO,
            SITUACAO
            INTO :V0TERMO-NUM-TERMO,
            :V0TERMO-COD-SUBG,
            :V0TERMO-PERIPGTO,
            :V0TERMO-SITUACAO
            FROM SEGUROS.V0TERMOADESAO
            WHERE NUM_APOLICE = :V0PEND-NUM-APOL
            AND COD_SUBGRUPO = :V0PEND-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TERMO
							,
											COD_SUBGRUPO
							,
											PERI_PAGAMENTO
							,
											SITUACAO
											FROM SEGUROS.V0TERMOADESAO
											WHERE NUM_APOLICE = '{this.V0PEND_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V0PEND_COD_SUBG}'";

            return query;
        }
        public string V0TERMO_NUM_TERMO { get; set; }
        public string V0TERMO_COD_SUBG { get; set; }
        public string V0TERMO_PERIPGTO { get; set; }
        public string V0TERMO_SITUACAO { get; set; }
        public string V0PEND_NUM_APOL { get; set; }
        public string V0PEND_COD_SUBG { get; set; }

        public static R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 Execute(R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 r0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1)
        {
            var ths = r0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0TERMO_NUM_TERMO = result[i++].Value?.ToString();
            dta.V0TERMO_COD_SUBG = result[i++].Value?.ToString();
            dta.V0TERMO_PERIPGTO = result[i++].Value?.ToString();
            dta.V0TERMO_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}