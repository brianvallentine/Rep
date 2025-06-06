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
    public class R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1 : QueryBasis<R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR), 0.00)
            INTO :SINISHIS-VAL-OPERACAO
            FROM SEGUROS.SINISTRO_HISTORICO A,
            SEGUROS.GE_SIS_FUNCAO_OPER B
            WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND B.IDE_SISTEMA = 'SI'
            AND A.COD_OPERACAO = B.COD_OPERACAO
            AND B.COD_FUNCAO IN (3,9,13)
            AND B.TIPO_ENDOSSO = '9'
            AND B.IDE_SISTEMA_OPER = 'SI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR)
							, 0.00)
											FROM SEGUROS.SINISTRO_HISTORICO A
							,
											SEGUROS.GE_SIS_FUNCAO_OPER B
											WHERE A.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND B.IDE_SISTEMA = 'SI'
											AND A.COD_OPERACAO = B.COD_OPERACAO
											AND B.COD_FUNCAO IN (3
							,9
							,13)
											AND B.TIPO_ENDOSSO = '9'
											AND B.IDE_SISTEMA_OPER = 'SI'
											WITH UR";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1 Execute(R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1 r1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}