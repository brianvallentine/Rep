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
    public class R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1 : QueryBasis<R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO * B.NUM_FATOR), 0)
            INTO :WS-VALOR-PENDENTE
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_SIS_FUNCAO_OPER B
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND B.IDE_SISTEMA = 'SI'
            AND H.COD_OPERACAO = B.COD_OPERACAO
            AND B.COD_FUNCAO IN (1,7,11)
            AND B.TIPO_ENDOSSO = '9'
            AND B.IDE_SISTEMA_OPER = B.IDE_SISTEMA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO * B.NUM_FATOR)
							, 0)
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_SIS_FUNCAO_OPER B
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND B.IDE_SISTEMA = 'SI'
											AND H.COD_OPERACAO = B.COD_OPERACAO
											AND B.COD_FUNCAO IN (1
							,7
							,11)
											AND B.TIPO_ENDOSSO = '9'
											AND B.IDE_SISTEMA_OPER = B.IDE_SISTEMA
											WITH UR";

            return query;
        }
        public string WS_VALOR_PENDENTE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1 Execute(R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1 r1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_VALOR_PENDENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}