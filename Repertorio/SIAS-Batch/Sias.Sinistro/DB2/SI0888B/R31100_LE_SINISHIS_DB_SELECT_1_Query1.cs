using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class R31100_LE_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R31100_LE_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            H.COD_OPERACAO,
            H.SIT_CONTABIL,
            H.DATA_MOVIMENTO,
            O.DES_OPERACAO
            INTO
            :SINISHIS-COD-OPERACAO,
            :SINISHIS-SIT-CONTABIL,
            :SINISHIS-DATA-MOVIMENTO,
            :GEOPERAC-DES-OPERACAO
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO O,
            SEGUROS.GE_SIS_FUNCAO_OPER F
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND H.COD_OPERACAO = O.COD_OPERACAO
            AND F.IDE_SISTEMA = :GESISFUO-IDE-SISTEMA
            AND F.COD_FUNCAO = :GESISFUO-COD-FUNCAO
            AND F.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER
            AND F.IDE_SISTEMA_OPER = O.IDE_SISTEMA
            AND F.COD_OPERACAO = O.COD_OPERACAO
            AND F.NUM_FATOR = 1
            AND F.TIPO_ENDOSSO = '9'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											H.COD_OPERACAO
							,
											H.SIT_CONTABIL
							,
											H.DATA_MOVIMENTO
							,
											O.DES_OPERACAO
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO O
							,
											SEGUROS.GE_SIS_FUNCAO_OPER F
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND H.COD_OPERACAO = O.COD_OPERACAO
											AND F.IDE_SISTEMA = '{this.GESISFUO_IDE_SISTEMA}'
											AND F.COD_FUNCAO = '{this.GESISFUO_COD_FUNCAO}'
											AND F.IDE_SISTEMA_OPER = '{this.GESISFUO_IDE_SISTEMA_OPER}'
											AND F.IDE_SISTEMA_OPER = O.IDE_SISTEMA
											AND F.COD_OPERACAO = O.COD_OPERACAO
											AND F.NUM_FATOR = 1
											AND F.TIPO_ENDOSSO = '9'";

            return query;
        }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }

        public static R31100_LE_SINISHIS_DB_SELECT_1_Query1 Execute(R31100_LE_SINISHIS_DB_SELECT_1_Query1 r31100_LE_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r31100_LE_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R31100_LE_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R31100_LE_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}