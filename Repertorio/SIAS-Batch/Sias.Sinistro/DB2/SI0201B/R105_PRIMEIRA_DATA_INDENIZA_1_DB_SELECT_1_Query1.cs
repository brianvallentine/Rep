using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0201B
{
    public class R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1 : QueryBasis<R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MIN(H.DATA_MOVIMENTO)
            INTO :SINISHIS-DATA-MOVIMENTO
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_SIS_FUNCAO_OPER O
            WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND O.COD_OPERACAO = H.COD_OPERACAO
            AND O.IDE_SISTEMA = 'SI'
            AND O.COD_FUNCAO = 2
            AND O.NUM_FATOR = 1
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MIN(H.DATA_MOVIMENTO)
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_SIS_FUNCAO_OPER O
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND O.COD_OPERACAO = H.COD_OPERACAO
											AND O.IDE_SISTEMA = 'SI'
											AND O.COD_FUNCAO = 2
											AND O.NUM_FATOR = 1
											WITH UR";

            return query;
        }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1 Execute(R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1 r105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1)
        {
            var ths = r105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}