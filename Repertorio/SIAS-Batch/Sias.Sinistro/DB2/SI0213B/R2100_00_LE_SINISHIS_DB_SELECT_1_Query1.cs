using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R2100_00_LE_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R2100_00_LE_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.OCORR_HISTORICO
            INTO :SINISHIS-OCORR-HISTORICO
            FROM SEGUROS.SINISTRO_HISTORICO A,
            SEGUROS.GE_OPERACAO B
            WHERE A.NUM_APOL_SINISTRO
            = :SINISHIS-NUM-APOL-SINISTRO
            AND A.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND B.IDE_SISTEMA = 'SI'
            AND A.COD_OPERACAO = B.COD_OPERACAO
            AND B.FUNCAO_OPERACAO IN ( 'RSREP' , 'RSHOP' )
            AND B.IND_TIPO_FUNCAO =
            (SELECT C.IND_TIPO_FUNCAO
            FROM SEGUROS.GE_OPERACAO C
            WHERE C.COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND C.IDE_SISTEMA = 'SI' )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.OCORR_HISTORICO
											FROM SEGUROS.SINISTRO_HISTORICO A
							,
											SEGUROS.GE_OPERACAO B
											WHERE A.NUM_APOL_SINISTRO
											= '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND A.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND B.IDE_SISTEMA = 'SI'
											AND A.COD_OPERACAO = B.COD_OPERACAO
											AND B.FUNCAO_OPERACAO IN ( 'RSREP' 
							, 'RSHOP' )
											AND B.IND_TIPO_FUNCAO =
											(SELECT C.IND_TIPO_FUNCAO
											FROM SEGUROS.GE_OPERACAO C
											WHERE C.COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND C.IDE_SISTEMA = 'SI' )";

            return query;
        }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static R2100_00_LE_SINISHIS_DB_SELECT_1_Query1 Execute(R2100_00_LE_SINISHIS_DB_SELECT_1_Query1 r2100_00_LE_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_LE_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_LE_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_LE_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}