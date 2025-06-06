using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1 : QueryBasis<R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTH
            INTO :HISCOBPR-DATA-INIVIGENCIA
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA + {this.SUBGVGAP_PERI_FATURAMENTO} MONTH
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1 Execute(R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1 r2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1)
        {
            var ths = r2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}