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
    public class R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1 : QueryBasis<R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            COUNT(*)
            INTO :V0ENDO-QTD-PGTO:VIND-QTD-PGTO
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V0PEND-NUM-APOL
            AND CODSUBES = :V0PEND-COD-SUBG
            AND SITUACAO = :V0PEND-SITUACAO
            AND TIPO_ENDOSSO = :V0PEND-TP-ENDOSSO
            AND DTVENCTO > :V0PEND-DTVENCTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COUNT(*)
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V0PEND_NUM_APOL}'
											AND CODSUBES = '{this.V0PEND_COD_SUBG}'
											AND SITUACAO = '{this.V0PEND_SITUACAO}'
											AND TIPO_ENDOSSO = '{this.V0PEND_TP_ENDOSSO}'
											AND DTVENCTO > '{this.V0PEND_DTVENCTO}'";

            return query;
        }
        public string V0ENDO_QTD_PGTO { get; set; }
        public string VIND_QTD_PGTO { get; set; }
        public string V0PEND_TP_ENDOSSO { get; set; }
        public string V0PEND_NUM_APOL { get; set; }
        public string V0PEND_COD_SUBG { get; set; }
        public string V0PEND_SITUACAO { get; set; }
        public string V0PEND_DTVENCTO { get; set; }

        public static R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1 Execute(R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1 r0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1)
        {
            var ths = r0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_QTD_PGTO = result[i++].Value?.ToString();
            dta.VIND_QTD_PGTO = string.IsNullOrWhiteSpace(dta.V0ENDO_QTD_PGTO) ? "-1" : "0";
            return dta;
        }

    }
}