using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0105_SELECT_COBHIS_DB_SELECT_1_Query1 : QueryBasis<M_0105_SELECT_COBHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_DEVOLUCAO
            INTO :DCLCOBER-HIST-VIDAZUL.COD-DEVOLUCAO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO =
            :DCLCOBER-HIST-VIDAZUL.NUM-CERTIFICADO
            AND NUM_PARCELA = 1
            AND COD_DEVOLUCAO = 116
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_DEVOLUCAO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO =
											'{this.NUM_CERTIFICADO}'
											AND NUM_PARCELA = 1
											AND COD_DEVOLUCAO = 116";

            return query;
        }
        public string COD_DEVOLUCAO { get; set; }
        public string NUM_CERTIFICADO { get; set; }

        public static M_0105_SELECT_COBHIS_DB_SELECT_1_Query1 Execute(M_0105_SELECT_COBHIS_DB_SELECT_1_Query1 m_0105_SELECT_COBHIS_DB_SELECT_1_Query1)
        {
            var ths = m_0105_SELECT_COBHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0105_SELECT_COBHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0105_SELECT_COBHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_DEVOLUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}