using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0860B
{
    public class R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1 : QueryBasis<R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(H.DATA_MOVIMENTO),DATE( '9999-12-30' ))
            INTO :SINISHIS-DATA-MOVIMENTO
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO P
            WHERE H.NUM_APOL_SINISTRO = :SINBENCB-NUM-SINISTRO
            AND H.SIT_REGISTRO <> '2'
            AND P.COD_OPERACAO = H.COD_OPERACAO
            AND P.IDE_SISTEMA = 'SI'
            AND P.FUNCAO_OPERACAO = 'IND'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(H.DATA_MOVIMENTO)
							,DATE( '9999-12-30' ))
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO P
											WHERE H.NUM_APOL_SINISTRO = '{this.SINBENCB_NUM_SINISTRO}'
											AND H.SIT_REGISTRO <> '2'
											AND P.COD_OPERACAO = H.COD_OPERACAO
											AND P.IDE_SISTEMA = 'SI'
											AND P.FUNCAO_OPERACAO = 'IND'";

            return query;
        }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINBENCB_NUM_SINISTRO { get; set; }

        public static R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1 Execute(R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1 r0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1)
        {
            var ths = r0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}