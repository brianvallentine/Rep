using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1 : QueryBasis<R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),+0)
            INTO :WS-HOST-QTD-SINISTROS
            FROM SEGUROS.SINISTRO_MESTRE A
            ,SEGUROS.SINISTRO_CAUSA B
            WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND A.SIT_REGISTRO �= '2'
            AND B.COD_CAUSA = A.COD_CAUSA
            AND B.RAMO_EMISSOR = :ENDOSSOS-RAMO-EMISSOR
            AND B.GRUPO_CAUSAS = 'PT'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.SINISTRO_MESTRE A
											,SEGUROS.SINISTRO_CAUSA B
											WHERE A.NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND A.SIT_REGISTRO �= '2'
											AND B.COD_CAUSA = A.COD_CAUSA
											AND B.RAMO_EMISSOR = '{this.ENDOSSOS_RAMO_EMISSOR}'
											AND B.GRUPO_CAUSAS = 'PT'
											WITH UR";

            return query;
        }
        public string WS_HOST_QTD_SINISTROS { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }

        public static R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1 Execute(R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1 r1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1)
        {
            var ths = r1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1250_00_SELECT_SINICAUSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_QTD_SINISTROS = result[i++].Value?.ToString();
            return dta;
        }

    }
}