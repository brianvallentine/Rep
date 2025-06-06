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
    public class M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1 : QueryBasis<M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO),0)
            INTO :W-HOST-VALOR-FRANQUIA
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.COD_OPERACAO = 21
            AND NOT EXISTS
            ( SELECT C.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO C
            WHERE C.NUM_APOL_SINISTRO =
            :SINISHIS-NUM-APOL-SINISTRO
            AND C.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND C.COD_OPERACAO IN (1093,1193)
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
											AND H.COD_OPERACAO = 21
											AND NOT EXISTS
											( SELECT C.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO C
											WHERE C.NUM_APOL_SINISTRO =
											'{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND C.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND C.COD_OPERACAO IN (1093
							,1193)
											)
											WITH UR";

            return query;
        }
        public string W_HOST_VALOR_FRANQUIA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1 Execute(M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1 m_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1)
        {
            var ths = m_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_HOST_VALOR_FRANQUIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}