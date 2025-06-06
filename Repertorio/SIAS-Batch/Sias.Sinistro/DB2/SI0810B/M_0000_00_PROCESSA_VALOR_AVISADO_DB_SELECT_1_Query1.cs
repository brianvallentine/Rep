using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0810B
{
    public class M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_FATOR
            INTO :GESISFUO-NUM-FATOR
            FROM SEGUROS.GE_SIS_FUNCAO_OPER
            WHERE IDE_SISTEMA = 'SI'
            AND COD_FUNCAO = 3
            AND IDE_SISTEMA_OPER = IDE_SISTEMA
            AND COD_OPERACAO = :V0HIST-OPERACAO-2
            AND TIPO_ENDOSSO = '9'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_FATOR
											FROM SEGUROS.GE_SIS_FUNCAO_OPER
											WHERE IDE_SISTEMA = 'SI'
											AND COD_FUNCAO = 3
											AND IDE_SISTEMA_OPER = IDE_SISTEMA
											AND COD_OPERACAO = '{this.V0HIST_OPERACAO_2}'
											AND TIPO_ENDOSSO = '9'";

            return query;
        }
        public string GESISFUO_NUM_FATOR { get; set; }
        public string V0HIST_OPERACAO_2 { get; set; }

        public static M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1 Execute(M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1 m_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_PROCESSA_VALOR_AVISADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GESISFUO_NUM_FATOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}