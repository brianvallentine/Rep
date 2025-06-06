using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0111_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0111_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CO
            ,SENHA
            ,NIVEL_AUTORIZACAO
            ,TIPO_FUNCAO
            INTO :USUFILSE-COD-CO
            ,:USUFILSE-SENHA
            ,:USUFILSE-NIVEL-AUTORIZACAO
            ,:USUFILSE-TIPO-FUNCAO
            FROM SEGUROS.USU_FIL_SENHA
            WHERE CODUSU = :USUFILSE-CODUSU
            AND ( TIPO_FUNCAO = 'CRITICA VIDA' )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CO
											,SENHA
											,NIVEL_AUTORIZACAO
											,TIPO_FUNCAO
											FROM SEGUROS.USU_FIL_SENHA
											WHERE CODUSU = '{this.USUFILSE_CODUSU}'
											AND ( TIPO_FUNCAO = 'CRITICA VIDA' )";

            return query;
        }
        public string USUFILSE_COD_CO { get; set; }
        public string USUFILSE_SENHA { get; set; }
        public string USUFILSE_NIVEL_AUTORIZACAO { get; set; }
        public string USUFILSE_TIPO_FUNCAO { get; set; }
        public string USUFILSE_CODUSU { get; set; }

        public static P0111_05_INICIO_DB_SELECT_1_Query1 Execute(P0111_05_INICIO_DB_SELECT_1_Query1 p0111_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0111_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0111_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0111_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.USUFILSE_COD_CO = result[i++].Value?.ToString();
            dta.USUFILSE_SENHA = result[i++].Value?.ToString();
            dta.USUFILSE_NIVEL_AUTORIZACAO = result[i++].Value?.ToString();
            dta.USUFILSE_TIPO_FUNCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}