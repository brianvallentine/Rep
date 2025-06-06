using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0048B
{
    public class R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1 : QueryBasis<R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT H.DATA_MOVIMENTO,
            CURRENT_DATE,
            DAYS(CURRENT_DATE) - DAYS(H.DATA_MOVIMENTO)
            INTO :SINISHIS-DATA-MOVIMENTO,
            :WS-CURRENT-DATE,
            :WS-QTDE-DIAS-PENDENTE
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.COD_OPERACAO = 101
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT H.DATA_MOVIMENTO
							,
											CURRENT_DATE
							,
											DAYS(CURRENT_DATE) - DAYS(H.DATA_MOVIMENTO)
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.COD_OPERACAO = 101
											WITH UR";

            return query;
        }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string WS_CURRENT_DATE { get; set; }
        public string WS_QTDE_DIAS_PENDENTE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1 Execute(R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1 r1200_00_BUSCA_DATAS_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_BUSCA_DATAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.WS_CURRENT_DATE = result[i++].Value?.ToString();
            dta.WS_QTDE_DIAS_PENDENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}