using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1040S
{
    public class R100_PROCESSA_OPER_DB_SELECT_1_Query1 : QueryBasis<R100_PROCESSA_OPER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            FUNCAO_OPERACAO,
            IND_TIPO_FUNCAO
            INTO
            :GEOPERAC-FUNCAO-OPERACAO,
            :GEOPERAC-IND-TIPO-FUNCAO
            FROM
            SEGUROS.GE_OPERACAO
            WHERE
            IDE_SISTEMA = 'SI'
            AND COD_OPERACAO = :GEOPERAC-COD-OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											FUNCAO_OPERACAO
							,
											IND_TIPO_FUNCAO
											FROM
											SEGUROS.GE_OPERACAO
											WHERE
											IDE_SISTEMA = 'SI'
											AND COD_OPERACAO = '{this.GEOPERAC_COD_OPERACAO}'";

            return query;
        }
        public string GEOPERAC_FUNCAO_OPERACAO { get; set; }
        public string GEOPERAC_IND_TIPO_FUNCAO { get; set; }
        public string GEOPERAC_COD_OPERACAO { get; set; }

        public static R100_PROCESSA_OPER_DB_SELECT_1_Query1 Execute(R100_PROCESSA_OPER_DB_SELECT_1_Query1 r100_PROCESSA_OPER_DB_SELECT_1_Query1)
        {
            var ths = r100_PROCESSA_OPER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_PROCESSA_OPER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_PROCESSA_OPER_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEOPERAC_FUNCAO_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_IND_TIPO_FUNCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}