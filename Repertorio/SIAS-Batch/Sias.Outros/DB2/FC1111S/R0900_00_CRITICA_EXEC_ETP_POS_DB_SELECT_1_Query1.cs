using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC1111S
{
    public class R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1 : QueryBasis<R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(COUNT(*),+0)
            INTO :WHOST-QTD-ETP-POST
            FROM SEGUROS.GE_ROTINA_ETAPA A,
            SEGUROS.GE_EXEC_ROTINA_ETAPA B
            WHERE A.NOM_ROTINA = :GE386-NOM-ROTINA
            AND A.SEQ_ETAPA > :GE386-SEQ-ETAPA
            AND A.DTH_FIM_VIGENCIA IS NULL
            AND A.IND_TIPO_ETAPA = 0
            AND B.NOM_ROTINA = A.NOM_ROTINA
            AND B.SEQ_ETAPA = A.SEQ_ETAPA
            AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA
            AND B.NUM_EXEC_ETAPA = A.QTD_EXEC_ETAPA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.GE_ROTINA_ETAPA A
							,
											SEGUROS.GE_EXEC_ROTINA_ETAPA B
											WHERE A.NOM_ROTINA = '{this.GE386_NOM_ROTINA}'
											AND A.SEQ_ETAPA > '{this.GE386_SEQ_ETAPA}'
											AND A.DTH_FIM_VIGENCIA IS NULL
											AND A.IND_TIPO_ETAPA = 0
											AND B.NOM_ROTINA = A.NOM_ROTINA
											AND B.SEQ_ETAPA = A.SEQ_ETAPA
											AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA
											AND B.NUM_EXEC_ETAPA = A.QTD_EXEC_ETAPA";

            return query;
        }
        public string WHOST_QTD_ETP_POST { get; set; }
        public string GE386_NOM_ROTINA { get; set; }
        public string GE386_SEQ_ETAPA { get; set; }

        public static R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1 Execute(R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1 r0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTD_ETP_POST = result[i++].Value?.ToString();
            return dta;
        }

    }
}