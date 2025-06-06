using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1 : QueryBasis<M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            , DATA_TERVIGENCIA
            INTO :SUBGVGAP-DATA-INIVIGENCIA
            ,:SUBGVGAP-DATA-TERVIGENCIA
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											, DATA_TERVIGENCIA
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'";

            return query;
        }
        public string SUBGVGAP_DATA_INIVIGENCIA { get; set; }
        public string SUBGVGAP_DATA_TERVIGENCIA { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1 Execute(M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1 m_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = m_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SUBGVGAP_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}