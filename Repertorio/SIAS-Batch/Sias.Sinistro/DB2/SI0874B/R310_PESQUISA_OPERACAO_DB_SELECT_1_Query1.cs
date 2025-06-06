using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1 : QueryBasis<R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT H.COD_OPERACAO,
            P.DES_OPERACAO,
            H.COD_USUARIO,
            H.DATA_MOVIMENTO
            INTO
            :SINISHIS-COD-OPERACAO,
            :GEOPERAC-DES-OPERACAO,
            :SINISHIS-COD-USUARIO,
            :SINISHIS-DATA-MOVIMENTO
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO P
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND P.IDE_SISTEMA = 'SI'
            AND P.COD_OPERACAO = H.COD_OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT H.COD_OPERACAO
							,
											P.DES_OPERACAO
							,
											H.COD_USUARIO
							,
											H.DATA_MOVIMENTO
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO P
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND H.COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND P.IDE_SISTEMA = 'SI'
											AND P.COD_OPERACAO = H.COD_OPERACAO";

            return query;
        }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1 Execute(R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1 r310_PESQUISA_OPERACAO_DB_SELECT_1_Query1)
        {
            var ths = r310_PESQUISA_OPERACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}