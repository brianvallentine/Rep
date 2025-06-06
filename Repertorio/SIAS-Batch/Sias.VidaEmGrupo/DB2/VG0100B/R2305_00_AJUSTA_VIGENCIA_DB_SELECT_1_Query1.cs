using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 : QueryBasis<R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.DATA_INIVIGENCIA +
            B.PERI_FATURAMENTO MONTH - 1 DAY
            INTO :WHOST-DATA-TERVIGENCIA
            FROM SEGUROS.V1FATURAS A,
            SEGUROS.SUBGRUPOS_VGAP B
            WHERE A.NUM_APOLICE = :V1SOLF-NUM-APOL
            AND A.COD_SUBGRUPO = :V1SOLF-COD-SUBG
            AND A.NUM_FATURA = :V1SOLF-NUM-FAT
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.DATA_INIVIGENCIA +
											B.PERI_FATURAMENTO MONTH - 1 DAY
											FROM SEGUROS.V1FATURAS A
							,
											SEGUROS.SUBGRUPOS_VGAP B
											WHERE A.NUM_APOLICE = '{this.V1SOLF_NUM_APOL}'
											AND A.COD_SUBGRUPO = '{this.V1SOLF_COD_SUBG}'
											AND A.NUM_FATURA = '{this.V1SOLF_NUM_FAT}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.COD_SUBGRUPO = A.COD_SUBGRUPO";

            return query;
        }
        public string WHOST_DATA_TERVIGENCIA { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }
        public string V1SOLF_COD_SUBG { get; set; }
        public string V1SOLF_NUM_FAT { get; set; }

        public static R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 Execute(R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 r2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = r2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}