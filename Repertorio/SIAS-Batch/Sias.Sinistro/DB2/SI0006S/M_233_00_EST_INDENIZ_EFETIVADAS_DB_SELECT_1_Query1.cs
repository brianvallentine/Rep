using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0006S
{
    public class M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1 : QueryBasis<M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO),0)
            INTO :W-HOST-VALOR-CALCULADO-99
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.COD_OPERACAO IN (1050, 4001, 4000)
            AND H.OCORR_HISTORICO IN
            ( SELECT DISTINCT H1.OCORR_HISTORICO
            FROM SEGUROS.SINISTRO_HISTORICO H1
            WHERE H1.NUM_APOL_SINISTRO =
            :SINISHIS-NUM-APOL-SINISTRO
            AND H1.COD_OPERACAO IN (1003 , 1004, 1001)
            )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.COD_OPERACAO IN (1050
							, 4001
							, 4000)
											AND H.OCORR_HISTORICO IN
											( SELECT DISTINCT H1.OCORR_HISTORICO
											FROM SEGUROS.SINISTRO_HISTORICO H1
											WHERE H1.NUM_APOL_SINISTRO =
											'{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H1.COD_OPERACAO IN (1003 
							, 1004
							, 1001)
											)
											WITH UR";

            return query;
        }
        public string W_HOST_VALOR_CALCULADO_99 { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1 Execute(M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1 m_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1)
        {
            var ths = m_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_HOST_VALOR_CALCULADO_99 = result[i++].Value?.ToString();
            return dta;
        }

    }
}