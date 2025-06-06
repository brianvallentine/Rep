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
    public class M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1 : QueryBasis<M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IFNULL(COUNT(*),0)
            INTO :WS-CNT-SEGURADOS
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_APOLICE = :SEGVGAP-NUM-APOLICE
            AND DATA_INIVIGENCIA <> :WS-INIVIGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IFNULL(COUNT(*)
							,0)
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_APOLICE = '{this.SEGVGAP_NUM_APOLICE}'
											AND DATA_INIVIGENCIA <> '{this.WS_INIVIGENCIA}'";

            return query;
        }
        public string WS_CNT_SEGURADOS { get; set; }
        public string SEGVGAP_NUM_APOLICE { get; set; }
        public string WS_INIVIGENCIA { get; set; }

        public static M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1 Execute(M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1 m_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1)
        {
            var ths = m_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_CNT_SEGURADOS = result[i++].Value?.ToString();
            return dta;
        }

    }
}